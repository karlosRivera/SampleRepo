using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using CSRBusiness;
using System.Threading;
using System.IO;
using SKYPE4COMLib;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSRAssistant
{
    public partial class frmCallAssistant : MetroFramework.Forms.MetroForm
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        frmMain _ParentForm = null;
        frmWaitForm wfrm = null;
        private static readonly Object thisLock = new Object();
        Skype skype;

        public frmCallAssistant()
        {
            InitializeComponent();
            wfrm = new frmWaitForm();
        }

        private void SetLineSize()
        {
            this.lineShape1.X2 = splitContainer1.Panel1.Width + 100;
        }

        public frmCallAssistant(frmMain _Parent)
        {
            _ParentForm = _Parent;
            InitializeComponent();
            wfrm = new frmWaitForm();
        }

        private void frmCallAssistant_Load(object sender, EventArgs e)
        {
            Utils.ReadProperty(metroStyleManager1);
            dtpkFrom.Enabled = dtpkTo.Enabled = false;
            SetLineSize();
            GetTemplateFromXML();

            //Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["localVoiceRecordsPath"].Value == null || config.AppSettings.Settings["localVoiceRecordsPath"].Value=="")
            {
                btnCall.Enabled = false;
            }

        }

        private void frmCallAssistant_Move(object sender, EventArgs e)
        {
            int left = this.Left;
            int top = this.Top;

            if (this.Left < _ParentForm.Left)
            {
                left = _ParentForm.Left;
            }
            if (this.Right > _ParentForm.Right)
            {
                left = _ParentForm.Right - this.Width;
            }
            if (this.Top < _ParentForm.Top)
            {
                top = _ParentForm.Top;
            }
            if (this.Bottom > _ParentForm.Bottom)
            {
                top = _ParentForm.Bottom - this.Height;
            }

            this.Location = new Point(left, top);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtJID.Text.Trim() != "" || txtTrackNo.Text.Trim() != "")
            {
                this.wfrm.Show();
                System.Windows.Forms.Application.DoEvents();
                new Thread(() => { lock (thisLock) { SearchByID(); } }).Start();
            }
        }

        private void SearchByID()
        {
            Messages oErrMsg = Messages.Instance;
            CallerAssistant oCallerAssistant = new CallerAssistant();

            if (this.InvokeRequired)
            {

                this.Invoke(new MethodInvoker(delegate
                {
                    //this.Cursor = Cursors.WaitCursor;
                    btnGo.Enabled = false;
                    btnFillJobs.Enabled = false;
                }));
            }
            else
            {
                btnFillJobs.Enabled = false;
                btnGo.Enabled = false;
            }


            if (!Utils.PingTest())
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        //this.Cursor = Cursors.Default;
                        MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                        return;
                    }));
                }
                else
                {
                    //this.Cursor = Cursors.Default;
                    MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                    return;
                }
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    oErrMsg = oCallerAssistant.LoadData(txtJID.Text.Trim(), txtTrackNo.Text.Trim(), 1, 100, 0);
                    if (!oErrMsg.IsError)
                    {
                        dgList.DataSource = ((DataSet) oErrMsg.Results).Tables[0];
                        this.wfrm.Hide();
                        btnGo.Enabled = true;
                        btnFillJobs.Enabled = true;
                    }
                    else
                    {
                        this.wfrm.Hide();
                        btnGo.Enabled = true;
                        btnFillJobs.Enabled = true;
                        MessageBox.Show(oErrMsg.Message);
                    }
                }));
            }

        }

        private void SearchByMisc()
        {
            string strKeyWord = "", strFrom = "", strTo = "";
            bool flag = false;
            Messages oErrMsg = Messages.Instance;
            CallerAssistant oCallerAssistant = new CallerAssistant();

            if (!Utils.PingTest())
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        //this.Cursor = Cursors.Default;
                        MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                        return;
                    }));
                }
                else
                {
                    //this.Cursor = Cursors.Default;
                    MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                    return;
                }
            }


            if (this.InvokeRequired)
            {

                this.Invoke(new MethodInvoker(delegate
                {
                    //this.Cursor = Cursors.WaitCursor;
                    btnGo.Enabled = false;
                    btnFillJobs.Enabled = false;

                    if (rdAllDebtorJobs.Checked)
                    {
                        strKeyWord = "ALL DEBTOR JOBS";
                        flag = true;
                    }

                    if (!flag)
                    {
                        if (rdCallBack.Checked)
                        {
                            strKeyWord = "ONLY CALL BACK JOBS";
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        if (rdAllDoneShip.Checked)
                        {
                            strKeyWord = "ALL DONE AND SHIPPED JOBS";
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        if (rdCallNotDone.Checked)
                        {
                            strKeyWord = "ALL CALL NOT DONE JOBS";
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        if (rdAllEscalated.Checked)
                        {
                            strKeyWord = "ALL ESCALATED JOBS";
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        if (rdFrom.Checked)
                        {
                            strKeyWord = "FROM";
                            strFrom = dtpkFrom.Value.ToString("yyyyMMdd");
                            strTo = dtpkTo.Value.AddDays(1).ToString("yyyyMMdd");
                            flag = true;
                        }
                        else
                        {
                            strKeyWord = "";
                            strFrom = dtpkJobDate.Value.ToString("yyyyMMdd");
                            strTo = dtpkJobDate.Value.AddDays(1).ToString("yyyyMMdd");
                        }
                    }
                }));
            }
            else
            {
                btnFillJobs.Enabled = false;
                btnGo.Enabled = false;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    oErrMsg = oCallerAssistant.LoadData(strKeyWord, strFrom, strTo, 0);
                    if (!oErrMsg.IsError)
                    {
                        dgList.DataSource = ((DataSet) oErrMsg.Results).Tables[0];
                        this.wfrm.Hide();
                        btnGo.Enabled = true;
                        btnFillJobs.Enabled = true;
                    }
                    else
                    {
                        this.wfrm.Hide();
                        btnGo.Enabled = true;
                        btnFillJobs.Enabled = true;
                        MessageBox.Show(oErrMsg.Message);
                    }
                }));
            }
        }

        private void btnFillJobs_Click(object sender, EventArgs e)
        {
            this.wfrm.Show();
           System.Windows.Forms.Application.DoEvents();
            new Thread(() => { lock (thisLock) { SearchByMisc(); } }).Start();

        }

        private void dgList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int rowSelect = 0;
            Messages oMsg = Messages.Instance;
            CallerAssistant oCallerAssistant = new CallerAssistant();
            rowSelect = e.RowIndex;
            string AccRef = dgList[1, rowSelect].Value.ToString();
            lblJID.Text = dgList[0, rowSelect].Value.ToString();
            lblOERef.Text = dgList[2, rowSelect].Value.ToString();

            lblCustName.Text  = dgList[7, rowSelect].Value.ToString();
            lblContactName.Text = dgList[8, rowSelect].Value.ToString();
            lblAccRef.Text = dgList[1, rowSelect].Value.ToString();

            
            if (CSRBusiness.User.Country != "USA")
            {
                oMsg = oCallerAssistant.GetAddress(AccRef, true);
                if (!oMsg.IsError)
                {
                    txtPhNo.Text =PhoneFormat((string)oMsg.Results);
                }
                else
                {
                    MessageBox.Show(oMsg.Results.ToString());
                }
            }
            else
            {
                oMsg = oCallerAssistant.GetAddressUSA(AccRef, true);
                if (!oMsg.IsError)
                {
                    txtPhNo.Text = PhoneFormat((string)oMsg.Results);
                }
                else
                {
                    MessageBox.Show(oMsg.Results.ToString());
                }
            }


            if (CSRBusiness.User.Country != "USA")
            {
                oMsg = oCallerAssistant.GetAddress(AccRef, false);
                if (!oMsg.IsError)
                {
                    txtAddress.Text = (string)oMsg.Results;
                }
                else
                {
                    MessageBox.Show(oMsg.Results.ToString());
                }

            }
            else
            {
                oMsg = oCallerAssistant.GetAddressUSA(AccRef, false);
                if (!oMsg.IsError)
                {
                    txtAddress.Text = (string)oMsg.Results;
                }
                else
                {
                    MessageBox.Show(oMsg.Results.ToString());
                }
            }



            oMsg = oCallerAssistant.LoadRemarks(Convert.ToInt32(lblJID.Text), false);
            if (!oMsg.IsError)
            {
                txtOldRem.Text = (string)oMsg.Results;
            }
            else
            {
                MessageBox.Show(oMsg.Results.ToString());
            }

            string callStatus = dgList[12, rowSelect].Value.ToString();
            oMsg = oCallerAssistant.LoadRemarks(Convert.ToInt32(lblJID.Text), true);
            if (!oMsg.IsError)
            {
                txtShopRemarks.Text = (string)oMsg.Results;
            }
            else
            {
                MessageBox.Show(oMsg.Results.ToString());
            }

            oMsg = oCallerAssistant.GetShippingInfo(lblJID.Text);
            DataSet shipping = null;
            if (!oMsg.IsError)
            {
                shipping = (DataSet)oMsg.Results;
            }
            else
            {
                MessageBox.Show(oMsg.Results.ToString());
            }

            cboShipNo.DataSource = null;
            cboRetShipNo.DataSource = null;

            cboShipNo.Items.Clear();
            cboRetShipNo.Items.Clear();

            if (shipping != null)
            {
                if (shipping.Tables[0].Rows.Count > 0)
                {
                    cboShipNo.DataSource = shipping.Tables[0].DefaultView;
                    cboShipNo.DisplayMember = "NormalTrackNo";
                    cboShipNo.ValueMember = "NormalTrackNo";

                    cboShipNo.Enabled = true;
                    cboShipNo.SelectedIndex = 0;
                    lblShipCount.Text = cboShipNo.Items.Count.ToString();
                }
                else
                {
                    cboShipNo.Items.Clear();
                    cboShipNo.Enabled = false;
                    lblShipCount.Text = "0";
                }

                if (shipping.Tables[1].Rows.Count > 0)
                {
                    cboRetShipNo.DataSource = shipping.Tables[1].DefaultView;
                    cboRetShipNo.DisplayMember = "ReturnTrackNo";
                    cboRetShipNo.ValueMember = "ReturnTrackNo";
                    cboRetShipNo.Enabled = true;
                    cboRetShipNo.SelectedIndex = 0;
                    lblRetCount.Text = cboRetShipNo.Items.Count.ToString();
                }
                else
                {
                    cboRetShipNo.Items.Clear();
                    cboRetShipNo.Enabled = false;
                    lblRetCount.Text = "0";
                }
            }

            if (callStatus == "Escalated")
                rdEscalated.Checked = true;
            if (callStatus == "Not Done")
                rdNotDone.Checked = true;
            if (callStatus == "Done & Shipped")
                rdDonewithShip.Checked = true;
            if (callStatus == "Call Back")
                rdCallBack.Checked = true;
            if (callStatus == "Done")
                rdDone.Checked = true;
        }

        private string PhoneFormat(string strPhone)
        {
            string retVAl = "";
            if (strPhone.Trim() != "")
            {
                if (CSRBusiness.User.Country == "GBR")
                {
                    if (!strPhone.Trim().StartsWith("+44"))
                    {
                        retVAl = "+44";
                    }
                }
                else if (CSRBusiness.User.Country == "DEU")
                {
                    if (!strPhone.Trim().StartsWith("+49"))
                    {
                        retVAl = "+49";
                    }
                }
                else if (CSRBusiness.User.Country == "FRA")
                {
                    if (!strPhone.Trim().StartsWith("+33"))
                    {
                        retVAl = "+33";
                    }
                }
                else if (CSRBusiness.User.Country == "ITA")
                {
                    if (!strPhone.Trim().StartsWith("+39"))
                    {
                        retVAl = "+39";
                    }
                }
                else if (CSRBusiness.User.Country == "USA" || CSRBusiness.User.Country == "CAD")
                {
                    if (!strPhone.Trim().StartsWith("+1"))
                    {
                        retVAl = "+1";
                    }
                }
                else if (CSRBusiness.User.Country == "ESP")
                {
                    if (!strPhone.Trim().StartsWith("+34"))
                    {
                        retVAl = "+34";
                    }
                }

                retVAl = retVAl + strPhone;
            }
            return retVAl;
        }

        private void rdFrom_CheckedChanged(object sender, EventArgs e)
        {
            if(!rdFrom.Checked)
                dtpkFrom.Enabled = dtpkTo.Enabled = false;
            else
                dtpkFrom.Enabled = dtpkTo.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CallerAssistant oCallerAssistant = new CallerAssistant();

            if (!Utils.PingTest())
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        //this.Cursor = Cursors.Default;
                        MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                        return;
                    }));
                }
                else
                {
                    //this.Cursor = Cursors.Default;
                    MessageBox.Show("VPN disconnected. Please connect and try again.", "CSR Assistance");
                    return;
                }
            }
            btnSave.Enabled = false;
            System.Windows.Forms.Application.DoEvents();

            string status = string.Empty;
            //this.Cursor = Cursors.WaitCursor;
            if (rdDone.Checked)
            {
                status = "Done";
            }
            if (rdCallBack.Checked)
            {
                status = "Call Back";
            }
            if (rdDonewithShip.Checked)
            {
                status = "Done & Shipped";
            }
            if (rdNotDone.Checked)
            {
                status = "Not Done";
            }
            if (rdEscalated.Checked)
            {
                status = "Escalated";
            }

            if (Convert.ToInt32(lblJID.Text) > 0)
            {
                if (oCallerAssistant.SaveCallRem(lblJID.Text, txtPhNo.Text.Trim(), txtRem.Text, status, (lblOERef.Text.Trim().Length > 14 ? lblOERef.Text.Trim().Substring(14) : lblOERef.Text.Trim()), txtShopRemarks.Text.Trim()))
                {
                    MessageBox.Show("Data saved successfully", "Call Status");
                }
            }

            btnSave.Enabled = true;
            System.Windows.Forms.Application.DoEvents();

        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            if (txtTemplate.Text.Length > 0)
            {
                lstTemplate.Items.Add(txtTemplate.Text);
                AddTemplateToXML(txtTemplate.Text);
                txtTemplate.Text = "";
            }
            else
                MessageBox.Show("Please enter a template text.", "CSR Assistant");
        }

        private void GetTemplateFromXML()
        {
            DataSet ds = new DataSet();
            string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\templates.xml";
            if (File.Exists(path))
            {
                try
                {
                    ds.ReadXml(path);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        lstTemplate.Items.Add(ds.Tables[0].Rows[i]["TemplateName"].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "CSR Assistant");
                }
            }
            else
                MessageBox.Show("Template file does not exist.Please add templates first", "CSR Assistant");
        }

        private void AddTemplateToXML(string nm)
        {
            string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\templates.xml";
            DataTable dt = new DataTable("TemplateTable");
            dt.Columns.Add("TemplateName");
            DataRow dr;
            if (lstTemplate.Items.Count > 0)
            {
                try
                {
                    for (int b = 0; b < lstTemplate.Items.Count; b++)
                    {
                        dr = dt.NewRow();
                        dr[0] = lstTemplate.Items[b].ToString();
                        dt.Rows.Add(dr);
                    }
                    if (File.Exists(path))
                        File.Delete(path);
                    dt.WriteXml(path);
                    MessageBox.Show("Template successfully inserted.", "CSR Assistant");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "CSR Assistant");
                }
            }
        }

        private void btnRemTemplate_Click(object sender, EventArgs e)
        {
            if (lstTemplate.Items.Count > 0 && lstTemplate.SelectedIndex >= 0)
            {
                lstTemplate.Items.RemoveAt(lstTemplate.SelectedIndex);
                RemoveTemplateFromXML();
            }
            else
                MessageBox.Show("You have not made any selection or template list is empty.", "CSR Assistant");

        }

        private void RemoveTemplateFromXML()
        {
            DataTable dt = new DataTable("TemplateTable");
            string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\templates.xml";

            dt.Columns.Add("TemplateName");
            DataRow dr;

            if (lstTemplate.Items.Count > 0)
            {
                try
                {
                    for (int b = 0; b < lstTemplate.Items.Count; b++)
                    {
                        dr = dt.NewRow();
                        dr[0] = lstTemplate.Items[b].ToString();
                        dt.Rows.Add(dr);
                    }
                    if (File.Exists(path))
                        File.Delete(path);
                    dt.WriteXml(path);
                    MessageBox.Show("Template successfully removed.", "CSR Assistant");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "CSR Assistant");
                }
            }
            else
                File.Delete(path);
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["localVoiceRecordsPath"].Value != null && config.AppSettings.Settings["ServerVoiceRecordsPath"].Value != null)
                {
                    if (config.AppSettings.Settings["localVoiceRecordsPath"].Value.Trim() != "" && config.AppSettings.Settings["ServerVoiceRecordsPath"].Value.Trim() != "")
                    {
                        if (txtPhNo.Text.Trim() != "")
                        {
                            btnCall.Enabled = false;
                            skype = new SKYPE4COMLib.Skype();
                            skype.CallStatus += new _ISkypeEvents_CallStatusEventHandler(ChangeCallStatus);
                            Call call = skype.PlaceCall(txtPhNo.Text);
                            //Call call = skype.PlaceCall("echo123");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Sound file save location not found");
                    }
                }
                else
                {
                    MessageBox.Show("Sound file save location not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Call Customer");
            }
        }

        private void ChangeCallStatus(Call call, TCallStatus status)
        {
            try
            {
                //call is now calling
                string storefilelocation = "";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["localVoiceRecordsPath"].Value != null && config.AppSettings.Settings["localVoiceRecordsPath"].Value!="")
                {
                    if (!Directory.Exists(config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", "")))
                    {
                        Directory.CreateDirectory(config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", ""));
                    }
                    storefilelocation = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", "") + "\\";
                }
                else
                {
                    MessageBox.Show("Local sound file location does not exist");
                    return;
                }

                lblCallStatus.Visible = true;
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
                    picSound.Visible = true;
                    lblCallStatus.Text = "Call progress";
                    //record voice
                    //call.set_OutputDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "in.wav");
                    //call.set_CaptureMicDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "capture.wav");

                    call.set_OutputDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "in.wav");
                    call.set_CaptureMicDevice(TCallIoDeviceType.callIoDeviceTypeFile, storefilelocation + "capture.wav");

                }

                //call is finish (now can wav convert to mp3)
                else if (status == TCallStatus.clsFinished)
                {
                    lblCallStatus.Visible = picSound.Visible = false;
                    lblCallStatus.Text = "Call end";
                    MergeFiles();
                    if (skype != null)
                    {
                        Marshal.ReleaseComObject(skype);
                    }
                    skype = null;
                    btnCall.Enabled = true;

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
            string strWavPath = "", strLamePath = "";
            string storefilelocation = "";
            string wavfilename = "";
            string datetime = string.Format("{0} {1} {2} {3} {4} ", DateTime.Now.ToString("yyyy-MM-dd"), "time", DateTime.Now.ToString("hh-mm-ss"), "out going phone no", txtPhNo.Text);

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000); // Time for skype to release the files
                // Run Sox to merge both files into a single file
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings["localVoiceRecordsPath"].Value != null && config.AppSettings.Settings["localVoiceRecordsPath"].Value!="")
                {
                    storefilelocation = config.AppSettings.Settings["localVoiceRecordsPath"].Value.Replace(",", "") + "\\";
                    wavfilename = datetime ;
                }

                strWavPath = @"-m """ + storefilelocation + @"in.wav""" + @" """ + storefilelocation + @"capture.wav""" + @" """ + storefilelocation + wavfilename + ".wav" + @"""";
                strLamePath = @"-V2 """ + storefilelocation + wavfilename + @".wav""" + @" """ + storefilelocation + wavfilename + @".mp3""";
                
                try
                {
                    if (Utils.IsDebugging)
                    {
                        if (File.Exists(Utils.RootDir + @"\Sox\Sox.exe"))
                        {
                            Utils.RunExternalProcess(Utils.RootDir + @"\Sox\Sox.exe", strWavPath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        }

                        if (File.Exists(Utils.RootDir + @"\Lame\Lame.exe"))
                        {
                            Utils.RunExternalProcess(Utils.RootDir + @"\Lame\Lame.exe", strLamePath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        }
                    }
                    else
                    {
                        if (File.Exists(Environment.CurrentDirectory.ToString() + @"\Sox\Sox.exe"))
                        {
                            Utils.RunExternalProcess(Environment.CurrentDirectory.ToString() + @"\Sox\Sox.exe", strWavPath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        }

                        if (File.Exists(Environment.CurrentDirectory.ToString() + @"\Lame\Lame.exe"))
                        {
                            Utils.RunExternalProcess(Environment.CurrentDirectory.ToString() + @"\Lame\Lame.exe", strLamePath, true, 3000, string.Empty, string.Empty, false, true, false, true);
                        }

                    }

                    // If sox created the new file, delete both original files
                    if (Directory.Exists(storefilelocation))
                    {
                        if (File.Exists(storefilelocation + "in.wav"))
                            File.Delete(storefilelocation + "in.wav");

                        if (File.Exists(storefilelocation + "capture.wav"))
                            File.Delete(storefilelocation + "capture.wav");

                        if (File.Exists(storefilelocation + wavfilename + ".wav"))
                            File.Delete(storefilelocation + wavfilename + ".wav");
                    }
                }
                catch { }
            });
        }
    }
}
