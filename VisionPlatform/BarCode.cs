using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Data;
using VisionPlatform.Properties;
using ZXing;
using Emgu.CV.ML;
using Emgu.CV.CvEnum;
using System.Drawing;

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
				//imageHanding();
				getBatCode();
			}
		}

		public void imageHanding()
		{
			if (SoureceImage !=null )
			{
				try
				{
					double cannyThreshold = 100;
					double cannyThresholdLinking = 200;

					Image<Gray, byte> imgtest = SoureceImage.Clone();
					CvInvoke.Canny(imgtest, imgtest, cannyThreshold, cannyThresholdLinking);
					SoureceImage = imgtest.CopyBlank();

					SoureceImage.Bitmap = imgtest.Bitmap;
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

		public void getBatCode()
		{
			if (SoureceImage != null)
			{
				try
				{
					Image<Gray, byte> imgtest = SoureceImage.Clone();

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
						//QR
						ResultPoint[] tete =  result.ResultPoints;
						int offsetx = 0;
						int offsety = 0;
						if (tete.Length == 4)
						{
							offsetx = (int)(tete[2].X - tete[3].X) * 4 / 3;
							offsety = (int)(tete[2].X - tete[3].X) * 4 / 3;
						}

						int x = (int)(tete[1].X - offsetx);
						int y = (int)(tete[1].Y - offsety);
						int width = (int)(tete[2].X - tete[1].X + offsetx * 2);
						int height = (int)(tete[0].Y - tete[1].Y + offsety * 2);
						Rectangle rect = new Rectangle(x, y, width, height);
						imgtest.Draw(rect, new Gray(), 1);
					}
					//SoureceImage = imgtest.CopyBlank();
					//SoureceImage.Bitmap = imgtest.Bitmap;
					SoureceImage = imgtest.Clone();
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
