using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Reflection;
using System.Runtime.InteropServices;
using InvertedSoftwareRecorder;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SkypeCallTest
{
    public partial class Form1 : Form 
    {
        Skype skype;
        string storefilelocation = @"D:\SkypeCallFiles\";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            btnMakeCall.Enabled = false;
            //System.Windows.Forms.Application.DoEvents();

            skype = new SKYPE4COMLib.Skype();
            skype.CallStatus += new _ISkypeEvents_CallStatusEventHandler(ChangeCallStatus);
            Call call = skype.PlaceCall("echo123");
        }

        private void ChangeCallStatus(Call call, TCallStatus status)
        {
            try
            {
                //call is now calling
                if (status == TCallStatus.clsRinging)
                {
                    //this person calling -> call.PartnerDisplayName;
                    lblCallStatus.Text = "now calling";
                }

                //press disallow
                else if (status == TCallStatus.clsRefused)
                {
                    lblCallStatus.Text = "Refuse";
                }

                //press stop
                else if (status == TCallStatus.clsCancelled)
                {
                    lblCallStatus.Text = "Cancell";
                }

                //talk is now progress
                else if (status == TCallStatus.clsInProgress)
                {
                    lblCallStatus.Text = "Call progress";
                    //record voice
                    call.set_OutputDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "in.wav");
                    call.set_CaptureMicDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "capture.wav");
                }

                //call is finish (now can wav convert to mp3)
                else if (status == TCallStatus.clsFinished)
                {
                    lblCallStatus.Text = "Call end";
                    MergeFiles();
                    if (skype != null)
                    {
                        Marshal.ReleaseComObject(skype);
                    }
                    skype = null;
                    btnMakeCall.Enabled = true;
                    //System.Windows.Forms.Application.DoEvents();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
            }
        }

        private void MergeFiles()
        {
            string strWavPath = "", strLamePath = "" ;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000); // Time for skype to release the files
                // Run Sox to merge both files into a single file
                strWavPath = "-m "+ storefilelocation + "in.wav " + storefilelocation + "capture.wav "+ storefilelocation+ "merge.wav";
                strLamePath = "-V2 " + storefilelocation + "merge.wav " + storefilelocation + "merge.mp3";

                try
                {
                    if (Utils.IsDebugging)
                    {
                        Utils.RunExternalProcess(Utils.RootDir + @"\Sox\Sox.exe", strWavPath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        Utils.RunExternalProcess(Utils.RootDir + @"\Lame\Lame.exe", strLamePath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                    }
                    else
                    {
                        Utils.RunExternalProcess(Environment.CurrentDirectory + @"\Sox\Sox.exe", strWavPath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        Utils.RunExternalProcess(Environment.CurrentDirectory + @"\Lame\Lame.exe", strLamePath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                    }

                    // If sox created the new file, delete both original files
                    if (Directory.Exists(storefilelocation))
                    {
                        if (File.Exists(storefilelocation + "in.wav"))
                            File.Delete(storefilelocation + "in.wav");

                        if (File.Exists(storefilelocation + "capture.wav"))
                            File.Delete(storefilelocation + "capture.wav");

                        if (File.Exists(storefilelocation + "merge.wav"))
                            File.Delete(storefilelocation + "merge.wav");
                    }
                }
                catch { }
            });
        }

    }

}
