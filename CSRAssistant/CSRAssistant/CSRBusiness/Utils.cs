using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Configuration;
using MetroFramework;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace CSRBusiness
{
    public static class User
    {
        public static string UserName
        {
            set;
            get;
        }

        public static string Password
        {
            set;
            get;
        }

        public static string Country
        {
            set;
            get;
        }

        public static string ConnectionString
        {
            set;
            get;
        }

        public static bool IsLoggedIn
        {
            set;
            get;
        }

    }

    public sealed class Messages
    {
        private static volatile Messages instance;
        private static object syncRoot = new Object();

        private Messages() { }

        public static Messages Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Messages();
                    }
                }

                return instance;
            }
        }

        public bool IsError
        {
            set;
            get;
        }

        public string Message
        {
            set;
            get;
        }

        public Object Results
        {
            set;
            get;
        }


    }


    public static class Utils
    {
        public static readonly string SkypeDiscover = "SkypeControlAPIDiscover";
        public static readonly string SkypeAttach = "SkypeControlAPIAttach";

        /// <summary>
        /// Run a process
        /// </summary>
        /// <param name="pathToProgram"></param>
        /// <param name="args"></param>
        /// <param name="waitForExit"></param>
        /// <param name="waitTime"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="readError"></param>
        /// <param name="readOutput"></param>
        /// <param name="asyncRead"></param>
        /// <param name="redirectInput"></param>
        /// <returns></returns>
        public static ReturnResult RunExternalProcess(string pathToProgram, string args, bool waitForExit, int waitTime, string userName, string password, bool readError, bool readOutput, bool asyncRead, bool redirectInput)
        {
            ReturnResult result = new ReturnResult();
            string output = string.Empty;
            string error = string.Empty;

            using (Process process = new Process())
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                try
                {
                    processStartInfo.FileName = pathToProgram;
                    if (!string.IsNullOrEmpty(args))
                        //processStartInfo.Arguments = args;
                        processStartInfo.Arguments = args;
                    processStartInfo.CreateNoWindow = true;
                    processStartInfo.UseShellExecute = false;
                    if (redirectInput)
                        processStartInfo.RedirectStandardInput = true;

                    if (readOutput)
                    {
                        processStartInfo.RedirectStandardOutput = true;
                        if (asyncRead)
                            process.OutputDataReceived += (sender, e) => output += e.Data;
                    }
                    if (readError)
                    {
                        processStartInfo.RedirectStandardError = true;
                        if (asyncRead)
                            process.ErrorDataReceived += (sender, e) => error += e.Data;
                    }
                    if (!string.IsNullOrEmpty(userName))
                        processStartInfo.UserName = userName;
                    if (!string.IsNullOrEmpty(password))
                    {
                        processStartInfo.Password = new System.Security.SecureString();
                        char[] passwordChars = password.ToCharArray();
                        foreach (char c in passwordChars)
                            processStartInfo.Password.AppendChar(c);
                    }
                    process.StartInfo = processStartInfo;
                    process.Start();
                    if (readOutput)
                    {
                        if (asyncRead)
                            process.BeginOutputReadLine();
                        else
                            output = process.StandardOutput.ReadToEnd();
                    }
                    if (readError)
                    {
                        if (asyncRead)
                            process.BeginErrorReadLine();
                        else
                            error = process.StandardError.ReadToEnd();
                    }
                    if (waitForExit)
                        process.WaitForExit(waitTime);
                    if (!process.HasExited)
                        process.Kill();
                    result.Message = output + error;
                    result.Success = true;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }
            return result;
        }

        public static bool IsDebugging
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached;
            }
        }

        static string _RootDir = "";
        public static string RootDir
        {
            get
            {
                System.IO.DirectoryInfo myDirectory = new DirectoryInfo(Environment.CurrentDirectory);
                _RootDir = myDirectory.Parent.Parent.FullName;
                return _RootDir;
            }
        }

        public static string LastFile { get; set; }

        public static bool IsDirectory(string path)
        {
            bool valid = false;
            try
            {
                System.IO.Path.GetFullPath(path);
                valid = true;
            }
            catch (Exception ex)
            {
                valid = false;
            }
            return valid;
        }

        public static string RemoveFirstLastChar(this string x)
        {
            string data = "";
            data = x;
            if (x.StartsWith(","))
                data = x.Substring(1, x.Length - 1);

            if (x.EndsWith(","))
                data = x.Substring(0, x.Length - 1);
            return data;
        } 

        public static bool PingTest()
        {
            string strIpAdd = string.Empty;
            if (User.Country == "GBR")
                strIpAdd = "192.168.88.2";
            else if (User.Country == "USA")
                strIpAdd = "192.168.1.2";
            else if (User.Country == "DEU")
                strIpAdd = "192.168.2.2";
            else if (User.Country == "FRA")
                strIpAdd = "192.168.77.10";
            else if (User.Country == "ITA")
                strIpAdd = "192.168.3.2";
            else if (User.Country == "ESP")
                strIpAdd = "192.168.55.10";
            else if (User.Country == "CAD")
                strIpAdd = "192.168.4.2";

            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            if (p.Send(strIpAdd).Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }

        public static bool LocalPingTest(string strIP)
        {
            string strIpAdd = string.Empty;
            strIpAdd = strIP;

            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            if (p.Send(strIpAdd).Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }

        public static bool FileInUse(string path)
        {
            bool flag = false;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    flag = fs.CanWrite;
                }
                return false;
            }
            catch (IOException ex)
            {
                return true;
            }
        }

        public static Bitmap GetImageByName(string imageName)
        {
            Assembly asm = Assembly.LoadFrom("CSRAssistant.exe");
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);
        }

        public static Messages ValidateLogin(string sUserID, string sPwd, string sCountry)
        {
            Messages oErrMsg = Messages.Instance;

            LoginConfigurationSection LoginConfigurationSection = (LoginConfigurationSection)ConfigurationManager.GetSection("LoginConfiguration");
            if (LoginConfigurationSection != null)
            {
                var UserCredentials = LoginConfigurationSection.Items
                .Cast<LoginElement>()
                .FirstOrDefault(_element => _element.UserName == sUserID.Trim() && _element.Pwd == sPwd.Trim() && _element.Country == sCountry.Trim());

                if (UserCredentials != null)
                {
                    if (UserCredentials.Country.Trim() != "")
                    {
                        DBConfigurationSection section = (DBConfigurationSection)ConfigurationManager.GetSection("DBConfiguration");
                        if (section != null)
                        {
                            var DbConnection = section.Items
                            .Cast<ItemsElement>()
                            .FirstOrDefault(_element => _element.CountryCode.ToUpper() == UserCredentials.Country.Trim().ToUpper());

                            if (DbConnection != null)
                            {
                                User.UserName = UserCredentials.UserName;
                                User.Password = UserCredentials.Pwd;
                                User.Country = UserCredentials.Country;
                                User.ConnectionString = string.Format("{0}{1}{2}{3}", "UID=" + DbConnection.UserID, ";PWD=" + DbConnection.Password,
                                ";Server=" + DbConnection.ServerName, ";Database=" + DbConnection.DBName);
                                User.IsLoggedIn = true;
                                oErrMsg.IsError = false;
                                oErrMsg.Message = "Success";
                            }
                            else
                            {
                                oErrMsg.IsError = true;
                                oErrMsg.Message = "Invalid country code for db settings in config file";
                            }
                        }
                    }
                    else
                    {
                        User.IsLoggedIn = false;
                        oErrMsg.IsError = true;
                        oErrMsg.Message = "Invalid Credential";

                    }
                }
                else
                {
                    User.IsLoggedIn = false;
                    oErrMsg.IsError = true;
                    oErrMsg.Message = "Invalid Credential";
                }
            }

            return oErrMsg;
        }

        public static void SaveProperty(System.ComponentModel.Component _Control)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Products.xml", settings);

            PropertyInfo[] properties = _Control.GetType().GetProperties();
            writer.WriteStartElement("metroStyleManager");
            foreach (PropertyInfo pi in properties)
            {
                writer.WriteElementString(pi.Name, Convert.ToString(pi.GetValue(_Control, null)));
            }
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }

        public static void ReadProperty(System.ComponentModel.Component _Control)
        {
            string _property = "", _value = "";
            if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Products.xml"))
            {
                XmlReader rdr = XmlReader.Create(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Products.xml");
                while (rdr.Read())
                {
                    if (rdr.NodeType == XmlNodeType.Element)
                    {
                        if (rdr.LocalName.ToUpper() != "METROSTYLEMANAGER")
                        {
                            _property = rdr.LocalName;
                            _value = rdr.ReadInnerXml();
                            if (_property.ToUpper() == "STYLE")
                            {
                                ((MetroFramework.Components.MetroStyleManager)_Control).Style = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), _value);
                                GetSelectedMetroStyle = ((MetroFramework.Components.MetroStyleManager)_Control).Style;
                            }
                            else if (_property.ToUpper() == "THEME")
                            {
                                ((MetroFramework.Components.MetroStyleManager)_Control).Theme = (MetroThemeStyle)Enum.Parse(typeof(MetroThemeStyle), _value);
                                GetSelectedMetroTheme = ((MetroFramework.Components.MetroStyleManager)_Control).Theme;
                            }
                        }
                    }
                }

                rdr.Close();
            }
        }


        public static MetroThemeStyle GetSelectedMetroTheme
        {
            set;
            get;
        }

        public static MetroColorStyle GetSelectedMetroStyle
        {
            set;
            get;
        }
    }

    public struct ReturnResult
    {
        public string Message;
        public bool Success;
        public string Title;
    }

    public class LoginChanged : EventArgs
    {
        public string UserName { get; set; }
        public string Country { get; set; }
    }

    public class comments : EventArgs
    {
        public string Rating { get; set; }
        public string Comments { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
