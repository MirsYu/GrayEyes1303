﻿using System;
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

namespace VisionPlatform
{
	public partial class Form1 : Form
	{
		delegate void Form1UpdateImage(Image<Bgr, byte> img);

		private static Image<Bgr, byte> Imgform;

		public static Image<Bgr,byte> Image1
		{
			get { return Imgform; }
		}

		public Form1()
		{
			InitializeComponent();
			Imgform = new Image<Bgr, byte>(@".\Image\QR.jpg");

			BarCode.Instance.UpdateImageDelegate += UpdateImage;
			Thread thread = new Thread(BarCode.Instance.ImageProcessing);
			thread.IsBackground = true;
			thread.Start();
		}

		private void UpdateImage(Image<Bgr, byte> img)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Form1UpdateImage(delegate (Image<Bgr, Byte> newImg)
				{
					this.imageBox1.Image = newImg;
				}),img);
			}
			else
			{
				imageBox1.Image = img;
			}
		}
	}
}