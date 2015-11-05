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
    public partial class frmComments : MetroFramework.Forms.MetroForm
    {
        string _country = "";
        public event EventHandler<comments> DataChanged;
        
        public frmComments()
        {
            InitializeComponent();
            
        }

        public frmComments(string _AccountRef, string _CustomerName, string _PhNo, string _PartNo, string _rating, string _comments, int jid, string country, int row, int col)
        {
            InitializeComponent();
            lblAccRef.Text = "";
            lblCustName.Text = "";
            lblPhoneNo.Text = "";
            lblPartNo.Text = "";
            cboRating.Text = "";
            txtComments.Text = "";
            loadRating();

            AccountRef = _AccountRef;
            CustomerName = _CustomerName;
            Phone = _PhNo;
            PartNumber = _PartNo;
            Rating = _rating;
            Comment = _comments;
            JobID = jid;
            _country = country;
            this.Row = row;
            this.Col = col;
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            lblAccRef.Text = AccountRef;
            lblCustName.Text = CustomerName;
            lblPhoneNo.Text = Phone;
            lblPartNo.Text = PartNumber;
            cboRating.Text =  Rating.ToString();
            int index = cboRating.FindString(Rating.ToString());
            if (index < 0)
                index = 0;
            else
                cboRating.SelectedIndex = index;
            txtComments.Text = Comment;

        }

        private void loadRating()
        {
            cboRating.Items.Clear();
            cboRating.Items.Add("--Select--");
            for (int i = 0; i <= 10; i++)
                cboRating.Items.Add(i.ToString());

            cboRating.Items.Add("N/A");
        }

        int _row = 0;
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        int _col = 0;
        public int Col
        {
            get
            {
                return _col;
            }
            set
            {
                _col = value;
            }
        }
        string _AccountRef = "";
        public string AccountRef
        {
            get
            {
                return _AccountRef;
            }
            set
            {
                _AccountRef = value;
            }
        }

        string _CustomerName="";
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

        string _PhNo = "";
        public string Phone
        {
            get
            {
                return _PhNo;
            }
            set
            {
                _PhNo = value;
            }
        }

        string _PartNo = "";
        public string PartNumber
        {
            get
            {
                return _PartNo;
            }
            set
            {
                _PartNo = value;
            }
        }

        string _rating ="";
        public string Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        int _JID = 0;
        public int JobID
        {
            get
            {
                return _JID;
            }
            set
            {
                _JID = value;
            }
        }

        string _comments = "";
        public string Comment
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
            }
        }

        bool _isUpdated = false;
        public bool IsUpdated 
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                _isUpdated = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strRating = "";
            Messages oErrMsg = Messages.Instance;
            FeedBack oFeedBack = new FeedBack();
            picbox.Visible = true;

            Application.DoEvents();

            if (cboRating.Text.Trim() == "--Select--")
            {
                strRating = "";
            }
            else
            {
                strRating = cboRating.Text.Trim();
            }

            try
            {

                oErrMsg = oFeedBack.UpdateFeedBack(JobID, strRating, txtComments.Text.Trim(), AccountRef, PartNumber);
                if (!oErrMsg.IsError)
                {
                    picbox.Visible = false;
                    comments _cmm = new comments();
                    _cmm.Comments = txtComments.Text;
                    _cmm.Rating = strRating;
                    _cmm.Row = this.Row;
                    _cmm.Col = this.Col;
                    OnValueChanged(_cmm);

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    picbox.Visible = false;
                    MessageBox.Show(oErrMsg.Message);
                }
            }
            catch (Exception ex)
            {
                picbox.Visible = false;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected virtual void OnValueChanged(comments e)
        {
            // Create a copy of the event to work with
            EventHandler<comments> eh = DataChanged;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (eh != null)
                eh(this, e);
        }
    }
}
