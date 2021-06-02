using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Serilog;
using Serilog.Configuration;

namespace WebApi.Utilidades
{
    /// <summary>
    /// 
    /// </summary>
    public  static class Logger
    {
        private static ILogger LogFile = new LoggerConfiguration()
.MinimumLevel.Debug()
.WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "\\"  + ConfigurationManager.AppSettings["serilogFile.path"].ToString())
.CreateLogger();

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void Warning(string msg)
        {
            LogFile.Warning(msg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void Fatal(string msg)
        {
            LogFile.Fatal(msg);
        }

        public static void Info(string msg)
        {
            LogFile.Information(msg);
        }
    }
}
