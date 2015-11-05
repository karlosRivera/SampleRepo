using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework;
using CSRBusiness;

namespace CSRAssistant
{
    public partial class frmCallStat : MetroFramework.Forms.MetroForm
    {
        frmMain _ParentForm = null;

        public frmCallStat()
        {
            InitializeComponent();
        }

        public frmCallStat(frmMain _Parent)
        {
            _ParentForm = _Parent;
            InitializeComponent();
            picbox.Hide();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
            picbox.Show();
            btnSearch.Enabled = btnClose.Enabled = false;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Messages oErrMsg = Messages.Instance;

            CallStat oCallStat = new CallStat();
            oErrMsg = oCallStat.LoadData(dtRateFrom.Value.ToString("yyyyMMdd"));
            if (!oErrMsg.IsError)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        dgList.DataSource = ((DataSet)oErrMsg.Results).Tables[0];
                    }));
                }
                else
                {
                    dgList.DataSource = ((DataSet)oErrMsg.Results).Tables[0];
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show(oErrMsg.Message);
                    }));
                }
                else
                {
                    MessageBox.Show(oErrMsg.Message);
                }

            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picbox.Hide();
            btnSearch.Enabled = btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //this.Close();
        }
       
        private void frmCallStat_Move(object sender, EventArgs e)
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
    }
}
