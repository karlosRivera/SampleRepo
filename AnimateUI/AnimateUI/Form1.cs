using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Data.SqlClient;

namespace AnimateUI
{
    public partial class Form1 : Form
    {
        public delegate void ProcessAnimation(bool show);
        ProcessAnimation pa;

        public Form1()
        {
            InitializeComponent();
            pa = this.ShowAnimation;
            pictureBox1.Visible = false;
            pictureBox1.BackColor = Color.Transparent;

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawImage(pictureBox1.Image,
                    (int)((pictureBox1.Image.Width) / 2),
                    (int)((pictureBox1.Image.Height) / 2));
                g.Save();
                pictureBox1.Refresh();
            }
        }

        private void ShowAnimation(bool show)
        {
            if (show)
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            ThreadPool.QueueUserWorkItem(o =>
            {
                this.Invoke(this.pa, true);
                dataGridView1.Invoke((MethodInvoker) delegate
                {
                    dataGridView1.DataSource = null;
                });

                DataTable dt = LoadData();

                dataGridView1.Invoke((MethodInvoker)delegate
                {
                    dataGridView1.DataSource = dt;
                });

                this.Invoke(this.pa, false);
                button1.Invoke((MethodInvoker)delegate
                {
                    button1.Enabled = true;
                });
            });
        }

        private DataTable LoadData()
        {
            DataTable dt = null;
            using (SqlConnection sqlConn = new SqlConnection(@"Data Source=192.168.88.2\BBAREMAN;Initial Catalog=BBAJobBoardForGB;uid=sa;pwd=8B@R5m@n"))
            {
                sqlConn.Open();
                string query = String.Format(@"select Name,CountryCode,Telephone from specialists");
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                sqlConn.Close();
                sqlConn.Dispose();
            }
            return dt;
        }
    }

}
