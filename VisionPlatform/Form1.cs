using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VisionPlatform
{
	public partial class Form1 : Form
	{
		delegate void Form1Update(Image<Gray, byte> img,
			ToolStripStatusLabel simpleStatus,
			ToolStripStatusLabel runtime,
			DataTable dataSource);

		private static Image<Gray, byte> Imgform;

		public static Image<Gray, byte> Image1
		{
			get { return Imgform; }
		}

		public Form1()
		{
			InitializeComponent();

			NetCamera.Camera cam = new NetCamera.Camera();
			cam.GetGateWay();
			cam.GetCameraIP();

			Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
			{
				if (cam.CameraImg != null)
				{
					Imgform = new Image<Gray, byte>(new Bitmap(cam.CameraImg));
				}
				});

			//Imgform = new Image<Gray, byte>(@"./Image/未标题-1.jpg");
			//Capture capture = new Capture();
			//Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
			//{
			//	Imgform = capture.QueryFrame().ToImage<Gray, byte>();
			//	//imageBox1.Image = Imgform;
			//});
			BarCode.Instance.UpdateImageDelegate += UpdateImage;
			Thread thread = new Thread(BarCode.Instance.ImageProcessing);
			thread.IsBackground = true;
			thread.Start();
		}

		private void UpdateImage(Image<Gray, byte> img,
			ToolStripStatusLabel simpleStatus,
			ToolStripStatusLabel runtime,
			DataTable dataSource)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Form1Update(delegate (Image<Gray, Byte> newImg,
					ToolStripStatusLabel newsimpleStatus,
					ToolStripStatusLabel newruntime,
					DataTable newdataSource)
				{
					this.imageBox1.Image = newImg.Convert<Gray,byte>();
					toolStripStatusLabel1.Image = newsimpleStatus.Image;
					toolStripStatusLabel2.Text = newruntime.Text;
					DataView data = dataGridView1.DataSource as DataView;
					if (data != newdataSource.DefaultView)
						dataGridView1.DataSource = newdataSource.DefaultView;
				}),img, simpleStatus, runtime, dataSource);
			}
			else
			{
				imageBox1.Image = img;
				toolStripStatusLabel1.Image = simpleStatus.Image;
				toolStripStatusLabel2.Text = runtime.Text;
				dataGridView1.DataSource = dataSource.DefaultView;
			}
		}
	}
}
