using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PopupControl;

namespace Async
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = new Size(Size.Width * 2, Size.Height * 2);
            DoubleBuffered = true;
            ResizeRedraw = false;
        }
        protected override void WndProc(ref Message m)
        {
            //if ((Parent as Popup).ProcessResizing(ref m))
            //{
            //    return;
            //}
            base.WndProc(ref m);
        }
    }
}
