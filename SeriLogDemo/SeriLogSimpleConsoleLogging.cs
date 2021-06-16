using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Configuration;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static void DoubleLogToConsole()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Me double");
        }

        public static void LogToConsoleWithMinimumLevel()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("ME INVISIBLE");
            Log.Warning("Me minimum level log");
        }

        public static void DifferentDoubleLogToConsole()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)
                .CreateLogger();

            Log.Warning("I will only appear once even though we are double logging because 2nd console log has a different min loglevel");
        }

        public static void LogToConsoleWithThreadIdEnrich()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithThreadId()
                .WriteTo.Console(
                    outputTemplate: "{Message} {ThreadId} {NewLine}")
                .CreateLogger();

            Log.Information("Henlo");
        }

        public static void LogToConsoleWithUserNameAndCustomPropertyEnrich()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithProperty("FavNumber", 7)
                .WriteTo.Console(
                    outputTemplate: "{Timestamp:HH:mm} [{Level}] {Message} btw {EnvironmentUserName}'s fav number is {FavNumber} {NewLine}")
                .CreateLogger();

            Log.Fatal("Very big error");
        }

        public static void LogToConsoleSimpleRepresentationControl()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            string name = "Pete";
            Log.Information("Henlo {Name}", name);
        }

        public static void LogToConsoleCollectionRepresentationControl()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var programmingLanguages = new[] { "C#", "Javascript", "Typescript" };
            Log.Information("Learn these programming languages by September: {pastehere}", programmingLanguages);
        }

        public static void LogToConsoleObjectRepresentationControl()
        {
            //When Serilog doesn't recognise the type, and no operator is specified (see below) then the object will be rendered using ToString().
            var dog = new Animal("Alett", "Dalmatian Colored");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Dog name is: {conn}", dog);
        }

        public static void LogToConsoleWithDesctructuring()
        {
            //There are many places where, given the capability, it makes sense to serialise a log event property as a structured object. 
            //DTOs(data transfer objects), messages, events and models are often best logged by breaking them down into properties with values.
            var dog = new Animal("Alett", "Dalmatian Colored");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Information about this dog: {@doginfo}", dog);
        }

        public static void LogToConsoleWithCustomizedStoredData()
        {
            //Often only a selection of properties on a complex object are of interest.
            var dog = new Animal("Alett", "Dalmatian Colored");

            Log.Logger = new LoggerConfiguration()
                .Destructure.ByTransforming<Animal>(r => new { AnimalColor = r.Color})
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("This dog's color is: {@c}", dog);
        }

        public static void LogToConsoleWithDynamicLevels()
        {
            //You might have an application where certain levels are only displayed/used when someone is debugging, but in production they are not used
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Information;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.Console()
                .CreateLogger();

            Log.Debug("Me invisible");
            levelSwitch.MinimumLevel = LogEventLevel.Debug;
            Log.Debug("Me not invisible");
        }

        public static void LogToConsoleWithDetailsReadFromSettings()
        {
            //Need to reference Microsoft.Extensions.Configuration.Json cause this is a console app...
            //For .NET 5 the new standard for appsettings are json files
            //If you are using some .NET framework stuff, then go for: https://github.com/serilog/serilog-settings-appsettings
            //Different nuget, for xml, but same idea: the loggerconfiguration will read the details from the some settings file instead of being coded into the builder

            var config = new ConfigurationBuilder()
                .AddJsonFile("SerilogSettingsConsole.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Verbose("This wont be shown bc of the way we setup SerilogSettingsConsole.json");
            Log.Debug("But this will be logged for the same reason");
        }
    }
}
