using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconTestDLL;
using System.Threading;

namespace HalconFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Thread thread = new Thread(HDevelopExport.acquireimage);

        private void button1_Click(object sender, EventArgs e)
        {
            HalconTest.Init(hWindowControl1.HalconWindow);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
    }
}
