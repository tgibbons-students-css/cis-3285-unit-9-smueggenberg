using System;

using SingleResponsibilityPrinciple.Contracts;
using System.IO;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log>\n" +
                                  "  <type>WARN</type>\n" +
                                  "  <message>" + message + "</message>\n" +
                                  "</log>"
                                  , args);
            }

            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log>\n" +
                                  "  <type>INFO</type>\n" +
                                  "  <message>" + message + "</message>\n" +
                                  "</log>"
                                  , args);
            }

            Console.WriteLine(string.Concat("INFO: ", message), args);
        }
    }
}
