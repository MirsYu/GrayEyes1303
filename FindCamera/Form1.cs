using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindCamera
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		NetCamera.Camera cam = new NetCamera.Camera();

		private void mydele (object Idelsender, EventArgs Idlee)
		{
			if (cam.CameraImg != null)
			{
				imageBox1.Image = new Image<Gray, byte>(new Bitmap(cam.CameraImg));
				txtBox_IP.Text = cam.CameraIP;
				GC.Collect();
				GC.SuppressFinalize(this);
			}
		}

		private void btn_Find_Click(object sender, EventArgs e)
		{
			cam.LocalMac = txtBox_Mac.Text;
			int temp = 0;
			int.TryParse(txtBox_Thcount.Text, out temp);
			cam.thCout = temp;
			timer1.Start();
			cam.GetGateWay();
			cam.GetCameraIP();
			
			txtBox_Gateway.Text = cam.mGateWay + "1";

			Application.Idle += new EventHandler(mydele);
			btn_Find.Enabled = false;
		}

		private void btn_ThreadAbort_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < cam.scanIP.Count; i++)
			{
				cam.scanIP[i].Abort();
			}
			cam.scanIP.Clear();
			btn_ThreadAbort.Enabled = false;
			timer1.Stop();
			GC.Collect();
			GC.SuppressFinalize(this);
		}

		private void btn_Clean_Click(object sender, EventArgs e)
		{

			Application.Idle -= new EventHandler(mydele);

			btn_ThreadAbort_Click(sender, e);
			if (cam.Client != null)
			{
				cam.Client.Abort();
			}

			if (cam.socket !=null)
			{
				cam.socket.Dispose();
			}
			cam.dispose();
			btn_Find.Enabled = true;
			btn_ThreadAbort.Enabled = true;
			timer1.Stop();
			GC.Collect();
			GC.SuppressFinalize(this);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int j = 0;
			for (int i = 0; i < cam.scanIP.Count; i++)
			{
				if (cam.scanIP[i].ThreadState == ThreadState.Stopped)
				{
					j++;
				}
			}
			if (j == int.Parse(txtBox_Thcount.Text) && cam.Client == null)
			{
				timer1.Stop();
				MessageBox.Show("寻找完毕，未找到相机");
				
			}
		}
	}
}
