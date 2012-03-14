using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObLib.Domain;

namespace ObLib
{
    public class Logger
    {
        public static void logError(Exception ex)
        {
            logError(string.Format("Exception. Message: {0}, Stack trace: {1}.",
                ex.Message,
                ex.StackTrace));
        }

        static public void logError(String error)
        {
            //TODO
        }
    }
}
