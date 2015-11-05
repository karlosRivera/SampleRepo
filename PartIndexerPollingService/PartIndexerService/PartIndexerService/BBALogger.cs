using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

namespace PartIndexerService
{
    /// <summary>
    /// this a logger class which help to save log info in xml file
    /// </summary>
    public class BBALogger
    {

        private static BBALogger _Instance;

        // _SyncRoot allow to access BBALogger _Instance synchronizely
        private static object _SyncRoot = new Object();

        // _readWriteLock allow to read/write log file synchronizely
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// MsgType enum allow to pass log type
        /// </summary>
        public enum MsgType
        {
            Error,
            Info,
            Warnings
        }

        /// <summary>
        /// BBALogger constructor
        /// </summary>
        private BBALogger()
        {
            LogFileName = DateTime.Now.ToString("dd-MM-yyyy");
            LogFileExtension = ".xml";
            LogPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Log";


            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }

            DirectorySecurity sec = Directory.GetAccessControl(LogPath);
            // Using this instead of the "Everyone" string means we work on non-English systems.
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(LogPath, sec);
        }

        /// <summary>
        /// this property return BBALogger Instance
        /// </summary>
        public static BBALogger Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Instance == null)
                            _Instance = new BBALogger();
                    }
                }
                return _Instance;
            }
        }

        /// <summary>
        /// return log file path
        /// </summary>
        public string LogPath { get; set; }

        /// <summary>
        /// return log file name
        /// </summary>
        public string LogFileName { get; set; }

        /// <summary>
        /// return log file name extension
        /// </summary>
        public string LogFileExtension { get; set; }

        /// <summary>
        /// return log file name with extension
        /// </summary>
        public string LogFile { get { return LogFileName + LogFileExtension; } }

        /// <summary>
        ///  return log file Full Path 
        /// </summary>
        public string LogFullPath { get { return Path.Combine(LogPath, LogFile); } }

        /// <summary>
        /// return true/false based on log file existance
        /// </summary>
        public bool LogExists { get { return File.Exists(LogFullPath); } }

        /// <summary>
        /// write data to log file
        /// </summary>
        /// <param name="inLogMessage"></param>
        /// <param name="msgtype"></param>
        public void WriteToLog(String inLogMessage, MsgType msgtype)
        {
            _readWriteLock.EnterWriteLock();
            try
            {
                LogFileName = DateTime.Now.ToString("dd-MM-yyyy");

                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }

                var settings = new System.Xml.XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true
                };

                StringBuilder sbuilder = new StringBuilder();
                using (StringWriter sw = new StringWriter(sbuilder))
                {
                    using (XmlWriter w = XmlWriter.Create(sw, settings))
                    {
                        w.WriteStartElement("LogInfo");
                        w.WriteElementString("Time", DateTime.Now.ToString());
                        if (msgtype == MsgType.Error)
                            w.WriteElementString("Error", inLogMessage);
                        else if (msgtype == MsgType.Info)
                            w.WriteElementString("Info", inLogMessage);
                        else if (msgtype == MsgType.Warnings)
                            w.WriteElementString("Warning", inLogMessage);

                        w.WriteEndElement();
                    }
                }
                using (StreamWriter Writer = new StreamWriter(LogFullPath, true, Encoding.UTF8))
                {
                    Writer.WriteLine(sbuilder.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        ///  call WriteToLog function
        /// </summary>
        /// <param name="inLogMessage"></param>
        /// <param name="msgtype"></param>
        public static void Write(String inLogMessage, MsgType msgtype)
        {
            Instance.WriteToLog(inLogMessage, msgtype);
        }
    }
}
