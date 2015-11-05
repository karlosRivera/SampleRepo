using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;
namespace InvertedSoftwareRecorder
{
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
    }

    public struct ReturnResult
    {
        public string Message;
        public bool Success;
        public string Title;
    }
}
