using Serilog;
using System;

namespace SeriLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Filters?
            //Sub-loggers?
            //LogContext? - maybe with db?
            //Deeper into Serilog.Settings.Configuration - maybe with db again

            #region Serilog Simple Console Logging

            SeriLogSimpleConsoleLogging.LogToConsoleMostBasic();
            SeriLogSimpleConsoleLogging.LogToConsoleUsingGlobal();
            SeriLogSimpleConsoleLogging.DoubleLogToConsole();
            SeriLogSimpleConsoleLogging.LogToConsoleWithMinimumLevel();
            SeriLogSimpleConsoleLogging.DifferentDoubleLogToConsole();
            SeriLogSimpleConsoleLogging.LogToConsoleWithThreadIdEnrich();
            SeriLogSimpleConsoleLogging.LogToConsoleWithUserNameAndCustomPropertyEnrich();
            SeriLogSimpleConsoleLogging.LogToConsoleSimpleRepresentationControl();
            SeriLogSimpleConsoleLogging.LogToConsoleCollectionRepresentationControl();
            SeriLogSimpleConsoleLogging.LogToConsoleObjectRepresentationControl();
            SeriLogSimpleConsoleLogging.LogToConsoleWithDesctructuring();
            SeriLogSimpleConsoleLogging.LogToConsoleWithCustomizedStoredData();
            SeriLogSimpleConsoleLogging.LogToConsoleWithDynamicLevels();
            SeriLogSimpleConsoleLogging.LogToConsoleWithDetailsReadFromSettings();

            #endregion Serilog Simple Console Logging

            #region Serilog Simple File Logging

            SeriLogSimpleFileLogging.LogToFileMostBasic();
            SeriLogSimpleFileLogging.LogToFileWithTemplate();
            SeriLogSimpleFileLogging.LogToFileWithSettings();

            #endregion Serilog Simple File Logging

            #region Serilog Simple db Logging

            SeriLogSimpleDBLog.LogToDbMostBasic();
            SeriLogSimpleDBLog.LogToDbWithFewerColumns();
            //ADD SOME MORE EXAMPLES

            #endregion Serilog Simple db Logging

            Log.CloseAndFlush();
        }
    }
}
