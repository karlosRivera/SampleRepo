using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServiceBrokerListener.Domain;

//drop proc sp_InstallListenerNotification_1

namespace DBChangeListener
{
    public partial class Form1 : Form
    {
        private const string CONNECTION_STRING = "server=sql08-2.orcsweb.com;uid=bba-reman;password=_bba_1227_kol;database=BBAreman;Pooling=true;Connect Timeout=20;";
        private const string DATABASE_NAME = "bbareman";
        private const string TABLE_NAME = "ContentChangeLog";
        private const string SCHEMA_NAME = "[bba-reman]";

        private SqlDependencyEx sqlDependency = new SqlDependencyEx(
                                                  CONNECTION_STRING,
                                                  DATABASE_NAME,
                                                  TABLE_NAME,
                                                  SCHEMA_NAME);
        public Form1()
        {
            InitializeComponent();
        }

        private void RegisterNotification()
        {
            sqlDependency.TableChanged += OnDataChange;
            sqlDependency.Start();
        }

        private void UnregisterNotification()
        {
            sqlDependency.Stop();
            sqlDependency.TableChanged -= OnDataChange;
        }

        private void OnDataChange(object sender, SqlDependencyEx.TableChangedEventArgs e)
        {
            // TODO: do stuff here
            // If you want to monitor changes of `ActivityDate` field only
            // you have to use the `TableChangedEventArgs` object.
            // It has the `NotificationType` field and the `Data` field.
            // The `Data` field contains information about the changes being made,
            // so you can filter it.
            int c = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnregisterNotification();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterNotification();
            MessageBox.Show("Start listening");
        }

    }
}
