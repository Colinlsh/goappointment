using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Appointment.API.Middleware
{
    /// <summary>
    /// Serilog logging middleware
    /// </summary>
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next request delegate in the middleware pipeline.</param>
        /// <exception cref="ArgumentNullException">next</exception>
        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Performs required operation before and after executing the next request delegate.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="env">The env.</param>
        /// <exception cref="ArgumentNullException">httpContext</exception>
        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env)
        {
            if (httpContext is null) { throw new ArgumentNullException(nameof(httpContext)); }

            var start = Stopwatch.GetTimestamp();
            var responseBodyStream = new MemoryStream();
            var originalResponseBodyStream = httpContext.Response.Body;
            var requestBody = await GetBodyAsync(httpContext.Request);

            try
            {
                httpContext.Response.Body = responseBodyStream;

                await _next(httpContext);

                var elapsedMs = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

                var responseBody = await GetBodyAsync(httpContext.Response);

                GetLoggerWithContext(httpContext, requestBody, responseBody, elapsedMs)
                    .Information(LogMessageTemplates.MiddlewareTemplate, GetRequestScheme(httpContext),
                        httpContext.Request.Method, GetPath(httpContext),
                        httpContext.Response?.StatusCode, elapsedMs);

                await responseBodyStream.CopyToAsync(originalResponseBodyStream);
            }
            catch (Exception ex)
            {
                var elapsedMs = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

                // On exception, 500 needs to be set as a default, else a 200 will be returned.
                // For more specific exception, different status codes shall be reassigned below.
                httpContext.Response.StatusCode = ex is IException customException
                    ? (int)customException.HttpStatusCode
                    : (int)HttpStatusCode.InternalServerError;

                if (!env.IsDevelopment()) { await ProcessHttpResponseForException(httpContext, ex); }

                var responseBody = await GetBodyAsync(httpContext.Response);

                GetLoggerWithContext(httpContext, requestBody, responseBody, elapsedMs)
                    .Error(ex, LogMessageTemplates.MiddlewareTemplate, GetRequestScheme(httpContext),
                        httpContext.Request.Method, GetPath(httpContext),
                        httpContext.Response?.StatusCode, elapsedMs);

                await responseBodyStream.CopyToAsync(originalResponseBodyStream);

                // Need to rethrow for full exception information to be
                // returned as response for Development mode.
                if (env.IsDevelopment()) { throw; }
            }
            finally
            {
                responseBodyStream.Dispose();
                httpContext.Response.Body = originalResponseBodyStream;
            }
        }

        private static async Task ProcessHttpResponseForException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            if (exception is IException customException)
            {
                await customException.TransformHttpResponseAsync(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync(
                    JsonConvert.SerializeObject(new
                    {
                        HttpStatusCode = HttpStatusCode.InternalServerError,
                        ErrorMessage = "Internal Server Error"
                    }));
            }
        }

        private static string GetRequestScheme(HttpContext httpContext)
        {
            return httpContext.Request.IsHttps ? "HTTPS" : "HTTP";
        }

        private static ILogger GetLoggerWithContext(HttpContext httpContext,
            string requestBody, string responseBody, double elapsedMs)
        {
            return Log.ForContext<SerilogMiddleware>()
                .ForContext("RequestMethod", httpContext.Request.Method)
                .ForContext("RequestPath", GetPath(httpContext))
                .ForContext("RequestBody", requestBody, true)
                .ForContext("ResponseStatusCode", httpContext.Response.StatusCode)
                .ForContext("ResponseBody", responseBody, true)
                .ForContext("ElapsedMs", elapsedMs)
                .ForContext("UserName", httpContext.User.Identity.Name);
        }

        private static double GetElapsedMilliseconds(long start, long stop)
        {
            return (stop - start) * 1000 / (double)Stopwatch.Frequency;
        }

        private static string GetPath(HttpContext httpContext)
        {
            return httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget ?? httpContext.Request.Path.ToString();
        }

        private static async Task<string> GetBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            _ = request.Body.Seek(0, SeekOrigin.Begin);

            return string.IsNullOrWhiteSpace(requestBody) ? null : requestBody;
        }

        private static async Task<string> GetBodyAsync(HttpResponse response)
        {
            _ = response.Body.Seek(0, SeekOrigin.Begin);

            using var streamReader = new StreamReader(response.Body, leaveOpen: true);
            var responseBody = await streamReader.ReadToEndAsync();

            _ = response.Body.Seek(0, SeekOrigin.Begin);

            return string.IsNullOrWhiteSpace(responseBody) ? null : responseBody;
        }
    }
}
