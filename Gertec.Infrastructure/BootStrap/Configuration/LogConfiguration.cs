using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Gertec.Infrastructure.BootStrap.Configuration
{
    public static class LogConfiguration
    {
        public static void UseCustomLog(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog(Log.Logger);
        }
    }
}