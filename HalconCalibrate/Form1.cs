using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalconCalibrate
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Calibtate calib = new Calibtate();

		private void btn_InCalibrate_Click(object sender, EventArgs e)
		{
			calib.InternalCalibrate(@"E:\VS2017\Caltab\Image\");
		}

		private void btn_outCalibrate_Click(object sender, EventArgs e)
		{
			calib.ExternalCalibrate(out double te1 ,out double te2);
			textBox2.Text = te1.ToString();
			textBox3.Text = te2.ToString();
		}
	}
}
