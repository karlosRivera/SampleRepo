using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Linq;

namespace DGVirtualScrollWithXMLFile
{
    public static class Utility
    {
 
        public static DataTable ConvertToDataTable(this IEnumerable<XElement> data)
        {
            var table = new DataTable();
            // create the columns
            foreach (var xe in data.First().Descendants())
                table.Columns.Add(xe.Name.LocalName, typeof(string));
            // fill the data
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (var xe in item.Descendants())
                    row[xe.Name.LocalName] = xe.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ToDataTable<T>(this List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)
            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }
    }


  
}
