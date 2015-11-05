using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;


namespace ucDGVirtualScroll
{
    public partial class ucVirtualScrollGrid : UserControl
    {

        public event EventHandler DataloadingStart;
        public event EventHandler DataloadingEnd;

        private string strPrevSortCol = "";
        private string strSortOrder = "ASC";

        private string _ConnectionString = "";

        public void OnDataloadingStart(EventArgs e)
        {
            EventHandler handler = DataloadingStart;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void OnDataloadingEnd(EventArgs e)
        {
            EventHandler handler = DataloadingEnd;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [Description("Specify connection string"), Category("Custom")]
        public string ConnectionString
        {
            get
            {
                return string.IsNullOrEmpty(_ConnectionString) ? "" : _ConnectionString;
            }

            set { _ConnectionString = value; }
        }

        private string _TableName = "";
        [Description("Database table name"), Category("Custom")]
        public string TableName
        {
            get
            {
                return string.IsNullOrEmpty(_TableName) ? "" : _TableName;
            }

            set { _TableName = value; }
        }

        private string _SortColumn = "";
        [Description("Sorting column name with orders"), Category("Custom")]
        public string SortColumn
        {
            get
            {
                return string.IsNullOrEmpty(_SortColumn) ? "" : _SortColumn;
            }

            set { 
                _SortColumn = value;
                strPrevSortCol = value;
            }
        }

        private string _SortOrder = "";
        [Description("Sorting orders like ASC/DESC"), Category("Custom")]
        public string SortOrder
        {
            get
            {
                return string.IsNullOrEmpty(_SortOrder) ? "" : _SortOrder;
            }

            set { _SortOrder = value; }
        }

        private string _Filters = "";
        [Description("Specify filters for where clause"), Category("Custom")]
        public string Filters
        {
            get
            {
                return string.IsNullOrEmpty(_Filters) ? "" : _Filters;
            }
            set
            {
                if (value.IndexOf("where") > 0)
                {
                    value.Replace("where", string.Empty);
                }
                _Filters = value;
            }
        }

        private int _PageSize = 0;
        [Description("Page size"), Category("Custom")]
        public int PageSize
        {
            get
            {
                return _PageSize;
            }

            set { _PageSize = value; }
        }

        private bool _ShowRowNumber = true;
        [Description("Show Row Number"), Category("Custom")]
        public bool ShowRowNumber
        {
            get
            {
                return _ShowRowNumber;
            }

            set { _ShowRowNumber = value; }
        }


        private Cache memoryCache = null;

        public ucVirtualScrollGrid()
        {
            InitializeComponent();

            // use DoubleBuffered to remove flicker when user load frequently clicking on load button
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                this.dgView,
                new object[] { true });

            this.dgView.VirtualMode = true;
            this.dgView.ReadOnly = true;
            this.dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgView.CellValueNeeded += new DataGridViewCellValueEventHandler(dgView_CellValueNeeded);
            this.dgView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgView_RowPostPaint);
            this.dgView.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgView_ColumnHeaderMouseClick);

        }


        public void LoadData()
        {
            // this function will load data into data table
            dgView.Rows.Clear();
            dgView.Refresh();
            dgView.Columns.Clear();
            dgView.DataSource = null;

            try
            {
                DataRetriever retriever = null;
                retriever = new DataRetriever(ConnectionString, TableName, Filters, SortColumn + " " + SortOrder);
                memoryCache = new Cache(retriever, PageSize);
                memoryCache.CacheExpire += OnCacheExpire;
                memoryCache.CacheFilled += OnCacheFilled;
                retriever.Columns.Cast<DataColumn>().ToList().ForEach(n => dgView.Columns.Add(n.ColumnName, n.ColumnName));
                this.dgView.RowCount = retriever.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection could not be established. " + "Verify that the connection string is valid.");
                Application.Exit();
            }

            // Adjust the column widths based on the displayed values. 
            this.dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            /*
            // set the sorting glyph initially when data load
            if (strSortOrder == "ASC")
            {
                this.dgView.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                this.dgView.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
            }
             * */
        }

        void OnCacheExpire(object sender, EventArgs e)
        {
            //this event will eaise when data will load from db
            OnDataloadingStart(EventArgs.Empty);
        }

        void OnCacheFilled(object sender, EventArgs e)
        {
            //this event will eaise when data will load from db
            OnDataloadingEnd(EventArgs.Empty);
        }

        private void dgView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //this function will populate unbound grid row and column wise. debug it then u can understand how grid is populating.
            e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
        }

        private void dgView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (ShowRowNumber)
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
        }

        private void dgView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // sorting is handle by this event handler
            //dgView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(n => n.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None);

            string strSortCol = this.dgView.Columns[e.ColumnIndex].Name;

            if (strPrevSortCol.Trim().ToUpper() != strSortCol.Trim().ToUpper())
            {
                this.dgView.Columns[strPrevSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                strPrevSortCol = strSortCol;
                strSortOrder = "ASC";
            }

            if (this.dgView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending)
            {
                this.dgView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                strSortOrder = "DESC";
            }
            else if (this.dgView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending)
            {
                this.dgView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                strSortOrder = "ASC";
            }
            else
            {
                if (strSortOrder == "ASC")
                    this.dgView.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                else
                    this.dgView.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;

            }

            dgView.Rows.Clear();

            DataRetriever retriever = new DataRetriever(ConnectionString, TableName, Filters , strSortCol + " " + strSortOrder);
            memoryCache = new Cache(retriever, PageSize);
            this.dgView.RowCount = retriever.RowCount;
            dgView.Refresh();
        }


    }


    public class Cache
    {
        private static int RowsPerPage;

        public event EventHandler CacheExpire;
        public event EventHandler CacheFilled;
        // Represents one page of data.   
        public struct DataPage
        {
            public DataTable table;
            private int lowestIndexValue;
            private int highestIndexValue;

            


            public DataPage(DataTable table, int rowIndex)
            {
                this.table = table;
                lowestIndexValue = MapToLowerBoundary(rowIndex);
                highestIndexValue = MapToUpperBoundary(rowIndex);
                System.Diagnostics.Debug.Assert(lowestIndexValue >= 0);
                System.Diagnostics.Debug.Assert(highestIndexValue >= 0);
            }

            public int LowestIndex
            {
                get
                {
                    return lowestIndexValue;
                }
            }

            public int HighestIndex
            {
                get
                {
                    return highestIndexValue;
                }
            }

            public static int MapToLowerBoundary(int rowIndex)
            {
                // Return the lowest index of a page containing the given index. 
                return (rowIndex / RowsPerPage) * RowsPerPage;
            }

            private static int MapToUpperBoundary(int rowIndex)
            {
                // Return the highest index of a page containing the given index. 
                return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
            }
        }

        private DataPage[] cachePages;
        private IDataPageRetriever dataSupply;

        public Cache(IDataPageRetriever dataSupplier, int rowsPerPage)
        {
            dataSupply = dataSupplier;
            Cache.RowsPerPage = rowsPerPage;
            LoadFirstTwoPages();
        }

        protected void OnCacheExpire(EventArgs e)
        {
            EventHandler handler = CacheExpire;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void OnCacheFilled(EventArgs e)
        {
            EventHandler handler = CacheFilled;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        // Sets the value of the element parameter if the value is in the cache. 
        private bool IfPageCached_ThenSetElement(int rowIndex,
            int columnIndex, ref string element)
        {
            if (IsRowCachedInPage(0, rowIndex))
            {
                element = cachePages[0].table
                    .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }
            else if (IsRowCachedInPage(1, rowIndex))
            {
                element = cachePages[1].table
                    .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                return true;
            }

            return false;
        }

        public string RetrieveElement(int rowIndex, int columnIndex)
        {
            string element = null;

            if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
            {
                return element;
            }
            else
            {
                OnCacheExpire(EventArgs.Empty);
                element= RetrieveData_CacheIt_ThenReturnElement(
                    rowIndex, columnIndex);
                OnCacheFilled(EventArgs.Empty);
                return element;
            }
        }

        private void LoadFirstTwoPages()
        {
            cachePages = new DataPage[]
            {
                new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), RowsPerPage), 0), 
                new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(RowsPerPage), RowsPerPage), RowsPerPage)
            };
        }

        private string RetrieveData_CacheIt_ThenReturnElement(int rowIndex, int columnIndex)
        {
            // Retrieve a page worth of data containing the requested value.
            DataTable table = dataSupply.SupplyPageOfData(
                DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);

            // Replace the cached page furthest from the requested cell 
            // with a new page containing the newly retrieved data.
            cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);

            return RetrieveElement(rowIndex, columnIndex);
        }

        // Returns the index of the cached page most distant from the given index 
        // and therefore least likely to be reused. 
        private int GetIndexToUnusedPage(int rowIndex)
        {
            if (rowIndex > cachePages[0].HighestIndex &&
                rowIndex > cachePages[1].HighestIndex)
            {
                int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
                int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
                int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
                if (offsetFromPage0 < offsetFromPage1)
                {
                    return 1;
                }
                return 0;
            }

        }

        // Returns a value indicating whether the given row index is contained 
        // in the given DataPage.  
        private bool IsRowCachedInPage(int pageNumber, int rowIndex)
        {
            return rowIndex <= cachePages[pageNumber].HighestIndex &&
                rowIndex >= cachePages[pageNumber].LowestIndex;
        }

    }

    public interface IDataPageRetriever
    {
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }

    public class DataRetriever : IDataPageRetriever
    {
        private string tableName;
        private SqlCommand command;
        private string sortColumn;
        private string filters;


        public DataRetriever(string connectionString, string tableName,string filters, string sortColumn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
            this.tableName = tableName;
            this.sortColumn = sortColumn;
            this.filters = filters;
        }

        private int rowCountValue = -1;

        public int RowCount
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (rowCountValue != -1)
                {
                    return rowCountValue;
                }

                if (filters.Trim().ToUpper().IndexOf("WHERE") > -1)
                {
                    filters = filters.ToUpper().Replace("WHERE", string.Empty);
                }

                // Retrieve the row count from the database.
                command.CommandText = "SELECT COUNT(*) FROM " + tableName + " WHERE 1=1 " + (filters.Trim().Length > 0 ? " AND " : string.Empty) + filters;
                rowCountValue = (int)command.ExecuteScalar();
                return rowCountValue;
            }
        }

        private DataColumnCollection columnsValue;

        public DataColumnCollection Columns
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (columnsValue != null)
                {
                    return columnsValue;
                }

                // Retrieve the column information from the database.
                command.CommandText = "SELECT * FROM " + tableName;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.FillSchema(table, SchemaType.Source);
                columnsValue = table.Columns;
                return columnsValue;
            }
        }

        private string commaSeparatedListOfColumnNamesValue = null;

        private string CommaSeparatedListOfColumnNames
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (commaSeparatedListOfColumnNamesValue != null)
                {
                    return commaSeparatedListOfColumnNamesValue;
                }

                // Store a list of column names for use in the 
                // SupplyPageOfData method.
                System.Text.StringBuilder commaSeparatedColumnNames =
                    new System.Text.StringBuilder();
                bool firstColumn = true;
                foreach (DataColumn column in Columns)
                {
                    if (!firstColumn)
                    {
                        commaSeparatedColumnNames.Append(", ");
                    }
                    commaSeparatedColumnNames.Append(column.ColumnName);
                    firstColumn = false;
                }

                commaSeparatedListOfColumnNamesValue =
                    commaSeparatedColumnNames.ToString();
                return commaSeparatedListOfColumnNamesValue;
            }
        }

        // Declare variables to be reused by the SupplyPageOfData method. 
        private string columnToSortBy;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            // Store the name of the ID column. This column must contain unique  
            // values so the SQL below will work properly. 
            if (columnToSortBy == null)
            {
                columnToSortBy = this.Columns[0].ColumnName;
            }

            if (!this.Columns[columnToSortBy].Unique)
            {
                throw new InvalidOperationException(String.Format(
                    "Column {0} must contain unique values.", columnToSortBy));
            }

            // Retrieve the specified number of rows from the database, starting 
            // with the row specified by the lowerPageBoundary parameter.
            if (filters.Trim().ToUpper().IndexOf("WHERE") > -1)
            {
                filters = filters.ToUpper().Replace("WHERE", string.Empty);
            }

            command.CommandText = "Select Top " + rowsPerPage + " " +
                CommaSeparatedListOfColumnNames + " From " + tableName +
                " WHERE 1=1 AND " + filters + " " + (filters.Trim().Length > 0 ? " AND " : string.Empty) + columnToSortBy + " NOT IN (SELECT TOP " +
                lowerPageBoundary + " " + columnToSortBy + " From " +
                tableName + "  WHERE 1=1 " + (filters.Trim().Length > 0 ? " AND " : string.Empty) + filters + " Order By " + sortColumn +
                ") Order By " + sortColumn;
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }

    }

    public class ProgressEventArgs : EventArgs
    {
        public int Status { get; private set; }

        public ProgressEventArgs(int status)
        {
            Status = status;
        }
    }
}
