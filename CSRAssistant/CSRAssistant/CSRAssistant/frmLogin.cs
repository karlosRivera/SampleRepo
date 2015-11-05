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

namespace CSRAssistant
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public event EventHandler<LoginChanged> LoginDone;
        frmMain _parent = null;

        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(frmMain parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void SetLineSize()
        {
            //this.lineShape1.X1 = -20;
            this.lineShape1.X2 = this.Width + 100;
            //this.lineShape1.Y1 = 12;
            //this.lineShape1.Y2 = 12;
        }

        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Utils.ReadProperty(metroStyleManager1);
            SetLineSize();

            //if (Utils.GetSelectedMetroStyle != null)
            //{
            //    metroLabel1.Style = Utils.GetSelectedMetroStyle;
            //    metroLabel2.Style = Utils.GetSelectedMetroStyle;
            //    txtUserID.Style = Utils.GetSelectedMetroStyle;
            //    txtPwd.Style = Utils.GetSelectedMetroStyle;
            //    btnLogin.Style = Utils.GetSelectedMetroStyle;
            //    btnClose.Style = Utils.GetSelectedMetroStyle;
            //    cboCountry.Style = Utils.GetSelectedMetroStyle;
            //    metroLabel3.Style = Utils.GetSelectedMetroStyle;
            //}

            //if (Utils.GetSelectedMetroTheme != null)
            //{
            //    metroLabel1.Theme = Utils.GetSelectedMetroTheme;
            //    metroLabel2.Theme = Utils.GetSelectedMetroTheme;
            //    txtUserID.Theme = Utils.GetSelectedMetroTheme;
            //    txtPwd.Theme = Utils.GetSelectedMetroTheme;
            //    btnLogin.Theme = Utils.GetSelectedMetroTheme;
            //    btnClose.Theme = Utils.GetSelectedMetroTheme;
            //    cboCountry.Theme = Utils.GetSelectedMetroTheme;
            //    metroLabel3.Theme = Utils.GetSelectedMetroTheme;
            //}
            LoadCountries();
        }

        private void LoadCountries()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CountryName", typeof(string));
            dt.Columns.Add("CountryCode", typeof(string));
            DataRow dr = dt.NewRow();
            dr["CountryName"] = "United Kingdom";
            dr["CountryCode"] = "GBR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["CountryName"] = "United States";
            dr["CountryCode"] = "USA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["CountryName"] = "Germany";
            dr["CountryCode"] = "DEU";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["CountryName"] = "France";
            dr["CountryCode"] = "FRA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["CountryName"] = "Italy";
            dr["CountryCode"] = "ITA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["CountryName"] = "Spain";
            dr["CountryCode"] = "ESP";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["CountryName"] = "Canada";
            dr["CountryCode"] = "CAD";
            dt.Rows.Add(dr);

            cboCountry.DataSource = dt;
            cboCountry.DisplayMember = "CountryName";
            cboCountry.ValueMember = "CountryCode";
            cboCountry.BindingContext = this.BindingContext;
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            SetLineSize();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool flag = true;
            Messages oErrMsg = Messages.Instance;
            if (txtUserID.Text.Trim() == "")
            {
                MessageBox.Show("Enter User Name");
                txtUserID.Focus();
                flag=false;
            }

            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("Enter Password");
                txtPwd.Focus();
                flag = false;
            }

            if (cboCountry.Text.Trim() == "")
            {
                MessageBox.Show("Select Country");
                cboCountry.Focus();
                flag = false;
            }

            if (flag)
            {
                oErrMsg = Utils.ValidateLogin(txtUserID.Text, txtPwd.Text, cboCountry.SelectedValue.ToString());
                if (oErrMsg.IsError)
                {
                    MessageBox.Show(oErrMsg.Message);
                }
                else
                {
                    LoginChanged oLoginChanged = new LoginChanged();
                    oLoginChanged.Country = cboCountry.SelectedValue.ToString();
                    oLoginChanged.UserName = txtUserID.Text;
                    OnloginDone(oLoginChanged);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        protected virtual void OnloginDone(LoginChanged e)
        {
            // Create a copy of the event to work with
            EventHandler<LoginChanged> eh = LoginDone;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (eh != null)
                eh(this, e);
        }

        private void frmLogin_Move(object sender, EventArgs e)
        {
            int left = this.Left;
            int top = this.Top;

            if (this.Left < _parent.Left)
            {
                left = _parent.Left;
            }
            if (this.Right > _parent.Right)
            {
                left = _parent.Right - this.Width;
            }
            if (this.Top < _parent.Top)
            {
                top = _parent.Top;
            }
            if (this.Bottom > _parent.Bottom)
            {
                top = _parent.Bottom - this.Height;
            }

            this.Location = new Point(left, top);
        }

       
    }

    
}
