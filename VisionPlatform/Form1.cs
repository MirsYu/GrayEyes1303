using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Threading;
using Emgu.CV.UI;

namespace VisionPlatform
{
	public partial class Form1 : Form
	{
		delegate void Form1Update(Image<Bgr, byte> img,
			ToolStripStatusLabel simpleStatus,
			ToolStripStatusLabel runtime,
			DataTable dataSource);

		private static Image<Bgr, byte> Imgform;

		public static Image<Bgr,byte> Image1
		{
			get { return Imgform; }
		}

		public Form1()
		{
			InitializeComponent();
			//Imgform = new Image<Bgr, byte>(@"./Image/QR.jpg");

			Capture capture = new Capture(); //create a camera captue
			Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
			{  //run this until application closed (close button click on image viewer)
				Imgform = capture.QueryFrame().ToImage<Bgr,byte>(); //draw the image obtained from camera
				//imageBox1.Image = Imgform;

			});
			BarCode.Instance.UpdateImageDelegate += UpdateImage;
			Thread thread = new Thread(BarCode.Instance.ImageProcessing);
			thread.IsBackground = true;
			thread.Start();

		}

		private void UpdateImage(Image<Bgr, byte> img,
			ToolStripStatusLabel simpleStatus,
			ToolStripStatusLabel runtime,
			DataTable dataSource)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Form1Update(delegate (Image<Bgr, Byte> newImg,
					ToolStripStatusLabel newsimpleStatus,
					ToolStripStatusLabel newruntime,
					DataTable newdataSource)
				{
					this.imageBox1.Image = newImg;
					toolStripStatusLabel1.Image = newsimpleStatus.Image;
					toolStripStatusLabel2.Text = newruntime.Text;
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
