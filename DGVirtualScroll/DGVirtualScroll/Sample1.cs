using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DGVirtualScroll
{
    public partial class Sample1 : Form
    {
        public Sample1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ucVirtualScrollGrid1.ConnectionString = "Initial Catalog=Test1;Data Source=BBATRIDIP\\SQLSERVER2008R2;" +
                "Integrated Security=SSPI;Persist Security Info=False";

            ucVirtualScrollGrid1.DataloadingStart += LoadingDataStart;
            ucVirtualScrollGrid1.DataloadingEnd += LoadingDataEnd;
            ucVirtualScrollGrid1.TableName = "Orders";
            ucVirtualScrollGrid1.SortColumn = "OrderID";
            ucVirtualScrollGrid1.SortOrder = "ASC";
            ucVirtualScrollGrid1.Filters = txtFilters.Text;
            ucVirtualScrollGrid1.PageSize = 16;
            ucVirtualScrollGrid1.ShowRowNumber = true;
            ucVirtualScrollGrid1.LoadData();
        }

        void LoadingDataStart(object sender, EventArgs e)
        {
            lblComents.Text = "Loading data...";
            System.Threading.Thread.Sleep(1000);
        }

        void LoadingDataEnd(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            lblComents.Text = "Loading end...";
        }

    }
}
