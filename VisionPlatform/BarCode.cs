using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using VisionPlatform.Properties;
using ZXing;
using ZXing.QrCode;

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
