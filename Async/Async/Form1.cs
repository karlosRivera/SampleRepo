using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PopupControl;

namespace Async
{
    public partial class Form1 : Form
    {
        Popup complex;
        Settings complexPopup;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            complex = new Popup(complexPopup = new Settings());
            complex.Resizable = true;
            complexPopup.button1.Click += (_sender, _e) =>
            {
                MessageBox.Show(complexPopup.textBox1.Text);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complex.Show(sender as Button);
        }

    }
}
