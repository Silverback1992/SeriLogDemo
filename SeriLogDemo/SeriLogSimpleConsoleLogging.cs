using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriLogDemo
{
    public static class SeriLogSimpleConsoleLogging
    {
        public static void LogToConsoleMostBasic()
        {
            //The root Logger is created using LoggerConfiguration.

            //This is typically done once at application start-up, and the logger saved for later use by application classes.
            //Multiple loggers can be created and used independently if required.

            using var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            log.Information("Hello World");
        }

        public static void LogToConsoleUsingGlobal()
        {
            //Serilog's global, statically accessible logger, is set via Log.Logger and can be invoked using the static methods on the Log class.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("I used the global logger!");
        }
    }
}
