namespace Appointment.Infrastructure.Constants
{  
    public static class LogMessageTemplates
    {
        public const string MiddlewareTemplate = 
            "{RequestScheme} {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
    }
}
