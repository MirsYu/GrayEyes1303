using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using ZXing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using VisionPlatform.Properties;

namespace VisionPlatform
{
	class BarCode : ThreadControlBaseClass
	{
		private static BarCode barcode = new BarCode();
		public static BarCode Instance
		{
			get { return barcode; }
		}

		public override void ImageProcessing()
		{
			while (true)
			{
				if (SoureceImage != null)
				{
					try
					{
						Image<Gray, byte> imgtest = SoureceImage.Clone().Convert<Gray, byte>();
						//CvInvoke.GaussianBlur(SoureceImage, imgtest, new Size(3, 3), 0, 0);
						//CvInvoke.Threshold(imgtest, imgtest, 100, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
						IBarcodeReader reader = new BarcodeReader();

						DateTime timeStart = DateTime.Now;
						Result result = reader.Decode(imgtest.ToBitmap());
						double runTime = -1D;
						if (result != null)
						{
							runTime = (result.Timestamp - timeStart.Ticks) / 10000D;

							SimpleStatus.Image = Resources.SimpleState_True;
							mRuntime.Text = "运行时间:" + runTime + "毫秒";
							DataSource = new DataTable();
							DataSource.Columns.Add("条码类型", typeof(System.String));
							DataSource.Columns.Add("解码的字符串", typeof(System.String));
							DataRow newLine = DataSource.NewRow();
							newLine["条码类型"] = result.BarcodeFormat.ToString();
							newLine["解码的字符串"] = result.Text;
							DataSource.Rows.Add(newLine);
						}
						SoureceImage = imgtest.Clone().Convert<Bgr, byte>();
						ShowFormImage();
					}
					catch (Exception)
					{
						SimpleStatus.Image = Resources.SimpleState_False;
						mRuntime.Text = "运行时间:" + 0 + "毫秒";
						ShowFormImage();
					}
				}
			}
		}
	}
}
