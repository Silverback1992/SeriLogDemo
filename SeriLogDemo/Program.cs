using System;

namespace SeriLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Serilog Simple Console Logging

            SeriLogSimpleConsoleLogging.LogToConsoleMostBasic();
            SeriLogSimpleConsoleLogging.LogToConsoleUsingGlobal();

            #endregion Serilog Simple Console Logging
        }
    }
}
