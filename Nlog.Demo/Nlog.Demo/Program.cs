using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlog.Demo
{
    class Program
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Trace("Trace Message");
            logger.Debug("Debug Message");
            logger.Info("Info Message");
            logger.Error("Error Message");
            logger.Fatal("Fatal Message");
           
        }
    }
}
