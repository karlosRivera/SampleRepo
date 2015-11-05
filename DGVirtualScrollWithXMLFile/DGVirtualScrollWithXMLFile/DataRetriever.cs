using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq.Dynamic;

namespace DGVirtualScrollWithXMLFile
{

    public interface IDataPageRetriever
    {
        DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
    }

    public class DataRetriever : IDataPageRetriever
    {
        private string sortColumn;
        private string OrderDirection;
        private string xmlFilePath;

        public DataRetriever(string xmlFilePath, string sortColumn,string OrderDirection)
        {
            this.sortColumn = sortColumn;
            this.xmlFilePath = xmlFilePath;
            this.OrderDirection = OrderDirection;
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

                XDocument document = XDocument.Load(xmlFilePath);
                rowCountValue = document.Descendants("orders").Select(c => c).Count();
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

                XDocument document = XDocument.Load(xmlFilePath);
                columnsValue = document.Descendants("orders").Select(c => c).ToList().ConvertToDataTable().Columns;

                //columnsValue = Utility.ToDataTable(document.Descendants("orders").Select(c => c).ToList()).Columns;
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

            //if (!this.Columns[columnToSortBy].Unique)
            //{
            //    throw new InvalidOperationException(String.Format(
            //        "Column {0} must contain unique values.", columnToSortBy));
            //}

            // Retrieve the specified number of rows from the database, starting 
            // with the row specified by the lowerPageBoundary parameter.
            //command.CommandText = "Select Top " + rowsPerPage + " " +
            //    CommaSeparatedListOfColumnNames + " From " + tableName +
            //    " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
            //    lowerPageBoundary + " " + columnToSortBy + " From " +
            //    tableName + " Order By " + sortColumn + 
            //    ") Order By " + sortColumn ;
            //adapter.SelectCommand = command;

            XDocument document = XDocument.Load(xmlFilePath);
            var query = from r in document.Descendants("orders")
                select new
                {
                    OrderID = r.Element("OrderID").Value,
                    CustomerID = r.Element("CustomerID").Value,
                    EmployeeID = r.Element("EmployeeID").Value,
                    OrderDate = r.Element("OrderDate").Value,
                    RequiredDate = r.Element("RequiredDate").Value,
                    ShippedDate = r.Element("ShippedDate").Value,
                    ShipVia = r.Element("ShipVia").Value,
                    Freight = r.Element("Freight").Value,
                    ShipName = r.Element("ShipName").Value,
                    ShipAddress = r.Element("ShipAddress").Value,
                    ShipCity = r.Element("ShipCity").Value,
                    ShipRegion = r.Element("ShipRegion").Value,
                    ShipPostalCode = r.Element("ShipPostalCode").Value,
                    ShipCountry = r.Element("ShipCountry").Value
                };
            query = query.OrderBy(sortColumn + " " + OrderDirection);

            query = query.Skip(lowerPageBoundary).Take(rowsPerPage);

            DataTable table = query.ToList().ToDataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //adapter.Fill(table);
            return table;
        }

    }
}
