using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq.Dynamic;

namespace DGVirtualScrollWithXMLFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string XmlFile = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../")) + "Orders.xml";
            XDocument document = XDocument.Load(XmlFile);
            bool isDesc = true;
            //setup basic query
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
                ShipCountry = r.Element("ShipCountry").Value,
            };

            query = query.OrderBy(txtOrderField.Text + " " + txtOrderDirection.Text);

            int page = Convert.ToInt32(txtPageNo.Text);
            var pageSize = 10;
            query = query.Skip(pageSize * (page - 1)).Take(pageSize);

            //execute the query to get the actual result
            //var items = query.ToList();
            dataGridView1.DataSource = query.ToList();
        }
    }
}
