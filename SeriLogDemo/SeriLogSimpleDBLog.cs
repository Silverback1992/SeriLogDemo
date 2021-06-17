using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriLogDemo
{
    public static class SeriLogSimpleDBLog
    {
        public static void LogToDbMostBasic()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .MSSqlServer(
                    connectionString: @"Server=(localdb)\ggorog_dev;Database=Testing;Trusted_Connection=True;",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "SimpleDBLogging", AutoCreateSqlTable = true })
                .CreateLogger();

            Log.Information("Hello World");
        }

        public static void LogToDbWithFewerColumns()
        {
            var myColumOptions = new ColumnOptions();
            myColumOptions.Store.Remove(StandardColumn.MessageTemplate);
            myColumOptions.Store.Remove(StandardColumn.Properties);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: @"Server=(localdb)\ggorog_dev;Database=Testing;Trusted_Connection=True;",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "CustomizedSmallerLogTable", AutoCreateSqlTable = true },
                    columnOptions: myColumOptions)
                .CreateLogger();

            try
            {
                int meZero = 0;
                int dontDoit = 1 / meZero;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Dayum");
            }
        }

        public static void LogToDbHeavilyCustomized()
        {
            //TO DO
        }

        public static void LogToDbHeavlyCustomizedWithSettings()
        {
            //TO DO
        }
    }
}
