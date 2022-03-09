using Appointment.AWS.Application.Aws.Cognito;
using Appointment.Infrastructure.Aws.Cognito;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Contracts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Appointment.API.AWS.Cognito
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Appointment.API.AWS.Cognito", Version = "v1" });
            });

            services.AddMediatR(typeof(Signin.Handler).Assembly);
            services.AddSingleton<IAwsCognitoIdentityClient, AwsCognitoIdentityClient>();

            services.AddScoped<IAwsCognitoCommandService, AwsCognitoCommandService>();

            var awsconfig = Configuration.GetSection("AWS");
            services.Configure<AwsConfiguration>(awsconfig);
            var awsconfiguration = awsconfig.Get<AwsConfiguration>();

            var awscog = Configuration.GetSection("AWS:Cognito");
            services.Configure<AwsCognitoConfiguration>(awscog);
            var awscognito = awscog.Get<AwsCognitoConfiguration>();

            services.AddAuthentication("Bearer")
                    .AddJwtBearer(options =>
                    {
                        options.Audience = awsconfiguration.ClientId;
                        options.Authority = awscognito.Issuer;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointment.API.AWS.Cognito v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
