using System.Collections.Generic;

namespace Tum.PDE.ToolFramework.Modeling.Base
{
    /// <summary>
    /// Log helper class.
    /// </summary>
    public static class LogHelper
    {
        static System.Threading.Semaphore semaphore;
        static System.Diagnostics.Stopwatch stopWatch = null;
        static string log = "";
        static bool hasErrors = false;

        static LogHelper()
        {
            semaphore = new System.Threading.Semaphore(1, 1);
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public static string GetLog()
        {
            return log;
        }

        /// <summary>
        /// Gets whether errors have been logged.
        /// </summary>
        /// <returns></returns>
        public static bool HasErrors()
        {
            return hasErrors;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public static void StartTimer()
        {
            semaphore.WaitOne();
            stopWatch = System.Diagnostics.Stopwatch.StartNew();
            semaphore.Release();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public static void StopTimer()
        {
            semaphore.WaitOne();
            if( stopWatch != null )
                stopWatch.Stop();
            semaphore.Release();
        }

        /// <summary>
        /// Resets the log.
        /// </summary>
        public static void ResetLog()
        {
            semaphore.WaitOne();
            log = "";
            semaphore.Release();
        }

        /// <summary>
        /// Is log empty.
        /// </summary>
        public static bool IsEmpty()
        {
            return log.Length == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        public static void LogError(string desc)
        {
            semaphore.WaitOne();
            hasErrors = true;
            if( stopWatch != null )
                log += stopWatch.ElapsedMilliseconds / 1000.0 + "   " + desc + "\r\n";
            else
                log += desc + "\r\n";
            semaphore.Release();
        }

        /// <summary>
        /// Logs an event.
        /// </summary>
        /// <param name="desc">Description for the event.</param>
        public static void LogEvent(string desc)
        {
            semaphore.WaitOne();
            if( stopWatch != null )
                log += stopWatch.ElapsedMilliseconds / 1000.0 + "   " + desc + "\r\n";
            else
                log += desc + "\r\n";
            semaphore.Release();
        }

        /// <summary>
        /// Dumps the gathered log to a file.
        /// </summary>
        /// <param name="fileName"></param>
        public static void DumpLog(string fileName)
        {
            semaphore.WaitOne();
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(fileName))
            {
                writer.Write(log);
            }
            semaphore.Release();
        }
    }
}
