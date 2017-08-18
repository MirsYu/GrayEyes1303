using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Data;
using VisionPlatform.Properties;
using ZXing;
using Emgu.CV.ML;
using Emgu.CV.CvEnum;
using System.Drawing;
using Emgu.CV.Util;

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
				imageHanding();
				//getBatCode();
			}
		}

		public void imageHanding()
		{
			if (SoureceImage !=null )
			{
				try
				{
					UMat img = new UMat();

					CvInvoke.CvtColor(SoureceImage.Clone().Convert<Bgr,byte>(), img, ColorConversion.Bgr2Gray);
					UMat pyrDown = new UMat();
					CvInvoke.PyrDown(img, pyrDown);
					CvInvoke.PyrUp(pyrDown, img);
					UMat gass = new UMat();
					CvInvoke.GaussianBlur(img, gass, new Size(5, 5), 0);
					UMat cannyEdges = new UMat();
					CvInvoke.Canny(gass, cannyEdges, 100, 200);
					Image<Gray, byte> findContou = SoureceImage.CopyBlank();
					UMat hierarchy = new UMat();
					using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
					{
						CvInvoke.FindContours(cannyEdges, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
						Matrix<int> matrix = new Matrix<int>(hierarchy.Rows, hierarchy.Cols, hierarchy.NumberOfChannels);
						hierarchy.CopyTo(matrix);
						int count = contours.Size;
						for (int i = 0; i < count; i++)
						{
							int k = i;
							int cnum = 0;
							while (matrix.Data[0, k * 4 + 2] != -1)
							{
								k = matrix.Data[0, k * 4 + 2];
								cnum++;
							}
							if (cnum >=5)
							{
								CvInvoke.DrawContours(img, contours, i, new MCvScalar(0, 255, 0),3);
							}
						}
					}
					SoureceImage.Bitmap = cannyEdges.Bitmap;
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
						SoureceImage.Bitmap = imgtest.Bitmap;
					}
					else
					{
						SoureceImage = imgtest.Clone();
					}
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
