using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace CallSkype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Skype skype;
            skype = new SKYPE4COMLib.Skype();
            Call call = skype.PlaceCall(txtPhonenNo.Text);
        }


    }
}
