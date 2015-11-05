using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace DGVirtualScroll
{
    public partial class Form1 : Form
    {
        // connection string
        private string connectionString =
        "Initial Catalog=Test1;Data Source=BBATRIDIP\\SQLSERVER2008R2;" +
        "Integrated Security=SSPI;Persist Security Info=False";
        
        // here table name set from where data will be fetched
        // order table found in Northwind db
        private string table = "Orders";

        // Page_Size : so always 16 records will be fetch but first time 32 records will be fetch only
        int Page_Size = 16;
        private string strPrevSortCol = "";

        // default order by field name
        private string strSortCol = "OrderID";

        // default order direction
        private string strSortOrder = "ASC";

        private Cache memoryCache=null;

        public Form1()
        {
            InitializeComponent();

            // use DoubleBuffered to remove flicker when user load frequently clicking on load button
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                this.dataGridView1,
                new object[] { true });

            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
        }

        private void dataGridView1_CellValueNeeded(object sender,DataGridViewCellValueEventArgs e)
        {
            //this function will populate unbound grid row and column wise. debug it then u can understand how grid is populating.
            e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
            if (e.RowIndex == 14)
            {
                //here it populated all rows of the grid
                label1.Text = "Data loading completed";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Resetsort();
            LoadData(strSortCol, strSortOrder);
        }

        private void Resetsort()
        {
            // this function will reset few setting if user click on button click routine repeatedly
            strPrevSortCol = "OrderID";
            strSortCol = "OrderID";
            strSortOrder = "ASC";
        }

        private void LoadData(string strSortCol, string strSortOrder)
        {
            // this function will load data into data table
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            try
            {
                DataRetriever retriever = new DataRetriever(connectionString, table, strSortCol + " " + strSortOrder);
                memoryCache = new Cache(retriever, Page_Size);
                //foreach (DataColumn column in retriever.Columns)
                //{
                //    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                //}

                retriever.Columns.Cast<DataColumn>().ToList().ForEach(n => dataGridView1.Columns.Add(n.ColumnName, n.ColumnName));
                this.dataGridView1.RowCount = retriever.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection could not be established. " + "Verify that the connection string is valid.");
                Application.Exit();
            }
            
            // Adjust the column widths based on the displayed values. 
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            // set the sorting glyph initially when data load
            if (strSortOrder == "ASC")
            {
                this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // this routine will add row no to HeaderCell which comes left most
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // sorting is handle by this event handler
            string strSortCol = this.dataGridView1.Columns[e.ColumnIndex].Name;

            if (strPrevSortCol.Trim().ToUpper() != strSortCol.Trim().ToUpper())
            {
                this.dataGridView1.Columns[strPrevSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                strPrevSortCol = strSortCol;
                strSortOrder = "ASC";
            }

            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending)
            {
                this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                strSortOrder = "DESC";
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending)
            {
                this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                strSortOrder = "ASC";
            }
            else
            {
                if (strSortOrder == "ASC")
                    this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                else
                    this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;

            }

            dataGridView1.Rows.Clear();

            DataRetriever retriever = new DataRetriever(connectionString, table, strSortCol + " " + strSortOrder);
            memoryCache = new Cache(retriever, Page_Size);
            this.dataGridView1.RowCount = retriever.RowCount;
            dataGridView1.Refresh();
        }


    }
}
