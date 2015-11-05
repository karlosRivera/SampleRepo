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
using OutlookStyleControls;
using System.Collections;

namespace CSRAssistant
{
    public partial class frmOURFeedBack : MetroFramework.Forms.MetroForm
    {
        private static readonly Object thisLock = new Object();
        private string _country = "";
        int RangeExclude = 0;
        DataTable dtExport = null;
        frmWaitForm wfrm = null;
        frmMain _ParentForm = null;

        #region private members
        // specifies the current data view (bound/unbound, dataset)
        private string View;

        // remember the column index that was last sorted on
        private int prevColIndex = -1;

        // remember the direction the rows were last sorted on (ascending/descending)
        private ListSortDirection prevSortDirection = ListSortDirection.Ascending;
        #endregion private members

        public frmOURFeedBack()
        {
            InitializeComponent();
            lblCount.Text = "";
            wfrm = new frmWaitForm();
        }

        public frmOURFeedBack(frmMain ParentForm)
        {
            _ParentForm = ParentForm;
            InitializeComponent();
            lblCount.Text = "";
            wfrm = new frmWaitForm();
            metroTab.SelectedIndex = 0;
        }

        private void loadRating()
        {
            cboRating.Items.Clear();
            cboRating.Items.Add("--Select--");
            for (int i = 0; i <= 10; i++)
                cboRating.Items.Add(i.ToString());

            cboRating.Items.Add("N/A");
            cboRating.SelectedIndex = 0;
        }

        private void SetLineSize()
        {
            this.lineShape1.X1 = -20;
            this.lineShape1.X2 = this.Width;
            this.lineShape1.Y1 = 12;
            this.lineShape1.Y2 = 12;
        }

        private void frMain_LoginDone(object sender, LoginChanged e)
        {
            _ParentForm.tileUserName.Text = e.UserName;
            _ParentForm.tileCountryFlag.TileImage = (Image)Utils.GetImageByName(e.Country.ToString());
            _ParentForm.Refresh();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            SetLineSize();
        }

        private void frmOURFeedBack_Load(object sender, EventArgs e)
        {
            Utils.ReadProperty(metroStyleManager1);
            SetLineSize();
            if (metroTab.SelectedIndex == 1)
            {
                loadRating();
            }
        }

        private void btnRatingSearch_Click(object sender, EventArgs e)
        {
            metroTab.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkExcludeCallCust.Checked)
            {
                if (chkEnable.Checked)
                    RangeExclude = 1;
                else
                    RangeExclude = 0;
            }

            this.wfrm.Show();
            Application.DoEvents();

            new Thread(() => { lock (thisLock) { Search(); } }).Start();
        }

        private void Search()
        {
            Messages oErrMsg = Messages.Instance;
            FeedBack oFeedBack = new FeedBack();

            DataSet ds = null;

            if (this.InvokeRequired)
            {

                this.Invoke(new MethodInvoker(delegate
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnSearch.Enabled = false;
                }));
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                btnSearch.Enabled = false;
            }

            if (!Utils.PingTest())
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                        return;
                    }));
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                    return;
                }

            }

            if (chkExcludeCallCust.InvokeRequired)
            {
                chkExcludeCallCust.Invoke(new MethodInvoker(delegate
                {
                    oErrMsg = oFeedBack.LoadData(dtfrom.Value.ToString("yyyyMMdd"),
                        dtto.Value.ToString("yyyyMMdd"),
                        (chkExcludeCallCust.Checked ? 1 : 0),
                        txtSearch.Text, 1,
                        Pager.PageSize,
                        false,
                        txtJobID.Text,
                        dtExFrom.Value.ToString("yyyyMMdd"),
                        dtExTo.Value.ToString("yyyyMMdd"),
                        (chkRepair.Checked ? 1 : 0),
                        RangeExclude);
                }));
            }
            else
            {
                oErrMsg = oFeedBack.LoadData(dtfrom.Value.ToString("yyyyMMdd"),
                dtto.Value.ToString("yyyyMMdd"),
                (chkExcludeCallCust.Checked ? 1 : 0),
                txtSearch.Text, 1,
                Pager.PageSize,
                false,
                txtJobID.Text,
                dtExFrom.Value.ToString("yyyyMMdd"),
                dtExTo.Value.ToString("yyyyMMdd"),
                (chkRepair.Checked ? 1 : 0),
                RangeExclude);

            }

            if (!oErrMsg.IsError)
            {
                ds = (DataSet) oErrMsg.Results;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        dtExport = ds.Tables[0];
                    }
                }

                if (outlookGrid1.InvokeRequired)
                {
                    outlookGrid1.Invoke(new MethodInvoker(delegate
                    {
                        if (ds.Tables.Count > 0)
                        {
                            outlookGrid1.BindData(ds, "data");
                            View = "BoundInvoices";
                            DataGridViewCellEventArgs evt = new DataGridViewCellEventArgs(2, -1);
                            object sender = null;
                        }
                    }));
                }
                else
                {
                    if (ds.Tables.Count > 0)
                    {
                        outlookGrid1.BindData(ds, "data");
                        View = "BoundInvoices";
                        DataGridViewCellEventArgs evt = new DataGridViewCellEventArgs(2, -1);
                        object sender = null;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    this.wfrm.Hide();
                    Pager.RecordCount = 0;
                    if (ds.Tables.Count > 0)
                        Pager.RecordCount = Convert.ToInt32(ds.Tables["counter"].Rows[0]["CNT"].ToString());

                    Pager.PageSize = 20;
                    Pager.MaximumNumberofLinks = (Pager.RecordCount > 0 ? 5 : 0);
                    lblCount.Text = Pager.RecordCount.ToString();

                    if (Pager.RecordCount > 0)
                        Pager.Visible = true;
                    else
                        Pager.Visible = false;
                }));

            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.wfrm.Hide();
                    MessageBox.Show(oErrMsg.Message);
                }));

            }

            this.Invoke(new Action(() =>
            {
                this.btnSearch.Enabled = true;
                this.Cursor = Cursors.Default;
            }));
        }

        private void btnSearchRating_Click(object sender, EventArgs e)
        {
            Messages oErrMsg = Messages.Instance;
            FeedBack oFeedBack = new FeedBack();

            DataSet ds = null;
            this.Cursor = Cursors.WaitCursor;
            btnSearchRating.Enabled = false;

            if (!Utils.PingTest())
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("VPN disconnected. Please connect and try again.", "CSRAssistance");
                return;
            }

            oErrMsg = oFeedBack.LoadRating(dtRateFrom.Value.ToString("yyyyMMdd"),
            dtRateTo.Value.ToString("yyyyMMdd"),
            (cboRating.Text == "--Select--" ? string.Empty : cboRating.Text),
            (chkBlankComment.Checked ? 1 : 0), 20,
            1);

            if (!oErrMsg.IsError)
            {
                ds = (DataSet)oErrMsg.Results;
                if (ds.Tables.Count > 0)
                {
                    dgList.DataSource = ds.Tables[0];
                }

                this.wfrm.Hide();
                bbaPager1.RecordCount = 0;
                if (ds.Tables.Count > 0)
                    bbaPager1.RecordCount = Convert.ToInt32(ds.Tables["counter"].Rows[0]["CNT"].ToString());

                bbaPager1.PageSize = 20;
                bbaPager1.MaximumNumberofLinks = (bbaPager1.RecordCount > 0 ? 5 : 0);
                lblCounter.Text = bbaPager1.RecordCount.ToString();

                if (bbaPager1.RecordCount > 0)
                {
                    bbaPager1.Visible = true;
                }
                else
                {
                    bbaPager1.Visible = false;
                }
                this.Cursor = Cursors.Default;
                btnSearchRating.Enabled = true;
            }
            else
            {
                this.wfrm.Hide();
                this.btnRatingSearch.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(oErrMsg.Message);
            }
        }

        private void bbaPager1_PageClicked(object sender, PagerControl.PageClickEventHandler e)
        {
            Messages oErrMsg = Messages.Instance;
            FeedBack oFeedBack = new FeedBack();
            DataSet ds = null;

            oErrMsg = oFeedBack.LoadRating(dtRateFrom.Value.ToString("yyyyMMdd"),
            dtRateTo.Value.ToString("yyyyMMdd"),
            (cboRating.Text == "--Select--" ? string.Empty : cboRating.Text),
            (chkBlankComment.Checked ? 1 : 0), 20,
            e.SelectedPage);


            if (!oErrMsg.IsError)
            {
                ds = (DataSet)oErrMsg.Results;
                if (ds.Tables.Count > 0)
                {
                    dgList.DataSource = ds.Tables[0];
                }
            }
        }

        private void Pager_PageClicked(object sender, PagerControl.PageClickEventHandler e)
        {
            Messages oErrMsg = Messages.Instance;
            FeedBack oFeedBack = new FeedBack();
            DataSet ds = null;
            oErrMsg = oFeedBack.LoadData(dtfrom.Value.ToString("yyyyMMdd"),
            dtto.Value.ToString("yyyyMMdd"),
            (chkExcludeCallCust.Checked ? 1 : 0),
            txtSearch.Text, e.SelectedPage,
            Pager.PageSize,
            false,
            txtJobID.Text,
            dtExFrom.Value.ToString("yyyyMMdd"),
            dtExTo.Value.ToString("yyyyMMdd"),
            (chkRepair.Checked ? 1 : 0),
            (chkExcludeCallCust.Checked ? 1 : 0));

            if(!oErrMsg.IsError)
            {
                ds = (DataSet)oErrMsg.Results;
                if (ds.Tables.Count > 0)
                {
                    outlookGrid1.BindData(ds, "data");
                    View = "BoundInvoices";
                    DataGridViewCellEventArgs evt = new DataGridViewCellEventArgs(2, -1);
                }
            }
        }

       

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                dtExFrom.Enabled = true;
                dtExTo.Enabled = true;
            }
            else
            {
                dtExFrom.Enabled = false;
                dtExTo.Enabled = false;
            }

        }

        private void chkRepair_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepair.Checked)
                chkRepair.Text = "Repaired";
            else
                chkRepair.Text = "Not Repaired";
        }

        private void outlookGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
        }

        private void outlookGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                if (e.ColumnIndex == prevColIndex) // reverse sort order
                    direction = prevSortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;

                // remember the column that was clicked and in which direction is ordered
                prevColIndex = e.ColumnIndex;
                prevSortDirection = direction;

                // set the column to be grouped
                outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[e.ColumnIndex];

                //sort the grid (based on the selected view)
                switch (View)
                {
                    case "BoundContactInfo":
                        outlookGrid1.Sort(new ContactInfoComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundCategory":
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundInvoices":
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundQuarterly":
                        // this is an example of overriding the default behaviour of the
                        // Group object. Instead of using the DefaultGroup behavious, we
                        // use the AlphabeticGroup, so items are grouped together based on
                        // their first character:
                        // all items starting with A or a will be put in the same group.
                        IOutlookGridGroup prevGroup = outlookGrid1.GroupTemplate;

                        if (e.ColumnIndex == 0) // execption when user pressed the customer name column
                        {
                            // simply override the GroupTemplate to use before sorting
                            outlookGrid1.GroupTemplate = new OutlookGridAlphabeticGroup();
                            outlookGrid1.GroupTemplate.Collapsed = prevGroup.Collapsed;
                        }

                        // set the column to be grouped
                        // this must always be done before sorting
                        outlookGrid1.GroupTemplate.Column = outlookGrid1.Columns[e.ColumnIndex];

                        // execute the sort, arrange and group function
                        outlookGrid1.Sort(new DataRowComparer(e.ColumnIndex, direction));

                        //after sorting, reset the GroupTemplate back to its default (if it was changed)
                        // this is needed just for this demo. We do not want the other
                        // columns to be grouped alphabetically.
                        outlookGrid1.GroupTemplate = prevGroup;
                        break;
                    default: //UnboundContactInfo
                        outlookGrid1.Sort(outlookGrid1.Columns[e.ColumnIndex], direction);
                        break;
                }
            }

        }

        private void outlookGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Rating = "-1";
            if (e.RowIndex >= 0)
            {
                DataGridViewRow gr = outlookGrid1.Rows[e.RowIndex];
                if (!((OutlookGridRow)gr).IsGroupRow)
                {
                    int JobNo = Convert.ToInt32(outlookGrid1.Rows[e.RowIndex].Cells["JID"].Value.ToString());
                    string AccountReference = outlookGrid1.Rows[e.RowIndex].Cells["AccountReference"].Value.ToString();
                    string CustomerName = outlookGrid1.Rows[e.RowIndex].Cells["Customer Name"].Value.ToString();
                    string Telephone = outlookGrid1.Rows[e.RowIndex].Cells["Telephone"].Value.ToString();
                    string PartNo = outlookGrid1.Rows[e.RowIndex].Cells["Part No"].Value.ToString();
                    if (outlookGrid1.Rows[e.RowIndex].Cells["Rating"].Value.ToString().Trim() == "")
                    {
                        Rating = "-1";
                    }
                    else
                    {
                        Rating = (outlookGrid1.Rows[e.RowIndex].Cells["Rating"].Value.ToString() != "" ? outlookGrid1.Rows[e.RowIndex].Cells["Rating"].Value.ToString() : "-1");
                    }

                    string Comments = (outlookGrid1.Rows[e.RowIndex].Cells["Comments"].Value.ToString() != "" ? outlookGrid1.Rows[e.RowIndex].Cells["Comments"].Value.ToString() : "");

                    frmComments ps = new frmComments(AccountReference, CustomerName, Telephone, PartNo, (Rating == "-1" ? "" : Rating.ToString()), Comments, JobNo, _country, e.RowIndex, e.ColumnIndex);
                    ps.DataChanged += new EventHandler<comments>(Feedback_DataChanged);
                    ps.ShowDialog();
                    ps.DataChanged -= Feedback_DataChanged;
                    ps.Dispose();
                    ps = null;
                }
            }

        }

        private void Feedback_DataChanged(object sender, comments e)
        {
            outlookGrid1.Rows[e.Row].Cells[13].Value = e.Rating.Trim();
            outlookGrid1.Rows[e.Row].Cells[14].Value = e.Comments.Trim();

        }

        private void frmOURFeedBack_Move(object sender, EventArgs e)
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

        private void metroTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            this.Text = current.Text;
            this.Refresh();
            if ((sender as TabControl).SelectedIndex == 1)
            {
                loadRating();
            }
        }

    
    }

    #region Comparers - used to sort CustomerInfo objects and DataRows of a DataTable

    /// <summary>
    /// reusable custom DataRow comparer implementation, can be used to sort DataTables
    /// </summary>
    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }

    // custom object comparer implementation
    public class ContactInfoComparer : IComparer
    {
        private int propertyIndex;
        ListSortDirection direction;

        public ContactInfoComparer(int propertyIndex, ListSortDirection direction)
        {
            this.propertyIndex = propertyIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            ContactInfo obj1 = (ContactInfo)x;
            ContactInfo obj2 = (ContactInfo)y;

            switch (propertyIndex)
            {
                case 1:
                    return CompareStrings(obj1.Name, obj2.Name);
                case 2:
                    return CompareDates(obj1.Date, obj2.Date);
                case 3:
                    return CompareStrings(obj1.Subject, obj2.Subject);
                case 4:
                    return CompareNumbers(obj1.Concentration, obj2.Concentration);
                default:
                    return CompareNumbers((double)obj1.Id, (double)obj2.Id);
            }
        }
        #endregion

        private int CompareStrings(string val1, string val2)
        {
            return string.Compare(val1, val2) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }

        private int CompareDates(DateTime val1, DateTime val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

        private int CompareNumbers(double val1, double val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }
    }
    #endregion Comparers

    #region ContactInfo - example business object implementation
    public class ContactInfo
    {
        public ContactInfo()
        {
        }
        public ContactInfo(int id, string name, DateTime date, string subject, double con)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.subject = subject;
            this.concentration = con;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private double concentration;

        public double Concentration
        {
            get { return concentration; }
            set { concentration = value; }
        }

    }

    #endregion
}