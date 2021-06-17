using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriLogDemo
{
    public class SeriLogSimpleFileLogging
    {
        public static void LogToFileMostBasic()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("simpleLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello World");
        }

        public static void LogToFileWithTemplate()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithEnvironmentUserName()
                .WriteTo.File(@"E:\Programming\logWithTemplate.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss}] [{Level}] {Message} User: {EnvironmentUserName}")
                .CreateLogger();

            Log.Warning("Oops, something went wrong.");
        }

        public static void LogToFileWithSettings()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("SerilogSettingsFile.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Information("We logged with settings dawg");
        }
    }
}
