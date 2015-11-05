using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewSQLExecuter
{
    /// <summary>
    /// A Logging class implementing the Singleton pattern and an internal Queue to be flushed perdiodically
    /// </summary>
    public class LogWriter
    {
        private static LogWriter instance;
        private static Queue<Log> logQueue;
        private static DateTime LastFlushed = DateTime.Now;

        /// <summary>
        /// Private constructor to prevent instance creation
        /// </summary>
        private LogWriter() { }

        /// <summary>
        /// Represent SQL which will be executed for all country
        /// </summary>
        public string SQL { get; set; }

        /// <summary>
        /// An LogWriter instance that exposes a single instance
        /// </summary>
        public static LogWriter Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (instance == null)
                {
                    instance = new LogWriter();
                    logQueue = new Queue<Log>();
                }
                return instance;
            }
        }

        /// <summary>
        /// The single instance method that writes to the log file
        /// </summary>
        /// <param name="message">The message to write to the log</param>
        public void WriteToLog(string message, string Country)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log(message, Country);
                logQueue.Enqueue(logEntry);
            }
        }


        /// <summary>
        /// Flushes the Queue 
        /// </summary>
        public void FlushLog()
        {
            while (logQueue.Count > 0)
            {
                Log entry = logQueue.Dequeue();
            }
        }

        /// <summary>
        /// Return the Queue 
        /// </summary>
        public Queue<Log> GetLogs()
        {
            return logQueue;
        }

        /// <summary>
        /// Return count of Queue 
        /// </summary>
        public int Count()
        {
            return logQueue.Count;
        }
    }


    /// <summary>
    /// A Log class to store the message and the Date and Time the log entry was created
    /// </summary>
    public class Log
    {
        public string Message { get; set; }
        public string LogTime { get; set; }
        public string LogDate { get; set; }
        public string CountryCode { get; set; }

        public Log(string message, string Country)
        {
            Message = message;
            LogDate = DateTime.Now.ToString("yyyy-MM-dd");
            LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
            CountryCode = Country;
        }
    }
}
