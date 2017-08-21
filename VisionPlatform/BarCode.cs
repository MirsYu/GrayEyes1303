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
using ZXing.QrCode;
using System.Collections.Generic;

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
			//while (true)
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
					UMat img = SoureceImage.ToUMat();
					// 转灰度图
					//CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Gray);
					// 中值滤波(去除椒盐噪声)
					CvInvoke.MedianBlur(img, img, 3);
					// Otsu二值化
					CvInvoke.Threshold(img, img, 0, 255, ThresholdType.Otsu);
					// 高斯滤波
					CvInvoke.GaussianBlur(img, img, new Size(3, 3), 0);
					// 梯度图
					Image<Gray, byte> grad_x1 = new Image<Gray, byte>(img.Size);
					Image<Gray, byte> grad_y1 = new Image<Gray, byte>(img.Size);
					Image<Gray, byte> grad_all = new Image<Gray, byte>(img.Size);
					CvInvoke.Sobel(img, grad_x1, img.Depth,0, 1, 3);
					CvInvoke.Sobel(img, grad_y1, img.Depth,1, 0, 3);
					CvInvoke.Add(grad_x1, grad_y1, grad_all);

					CvInvoke.Canny(img, img, 100, 200);
					// 腐蚀
					//Mat StructingElement = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1));
					//CvInvoke.Erode(img, img, StructingElement, new Point(-1, -1), 6, BorderType.Default, new MCvScalar(0));
					//UMat image1 = img.Clone();
					//CvInvoke.Erode(img, image1, StructingElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
					//UMat img_result = img.Clone();
					// 相减找出形态学边界
					//CvInvoke.Subtract(img, image1, img);
					// 寻找轮廓
					//UMat hierarchy = new UMat();
					//using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
					//{
					//	CvInvoke.FindContours(img_result, contours, hierarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
					//}

					//LineSegment2D[] lines = CvInvoke.HoughLinesP(img, 1, Math.PI / 45.0, 20, 30, 10);
					//Image<Bgr, Byte> lineImage = SoureceImage.Convert<Bgr, byte>().CopyBlank();
					//foreach (LineSegment2D line in lines)
					//{
					//	lineImage.Draw(line, new Bgr(Color.White), 2);
					//}

					List<RotatedRect> boxList = new List<RotatedRect>();

					using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
					{
						CvInvoke.FindContours(img, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
						int count = contours.Size;
						for (int i = 0; i < count; i++)
						{
							using (VectorOfPoint contour = contours[i])
							using (VectorOfPoint approxContour = new VectorOfPoint())
							{
								CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
								if (CvInvoke.ContourArea(approxContour, false) > 250)
								{
									if (approxContour.Size == 4)
									{
										bool isRectangle = true;
										Point[] pts = approxContour.ToArray();
										LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

										for (int j = 0; j < edges.Length; j++)
										{
											double angle = Math.Abs(
											   edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
											if (angle < 80 || angle > 100)
											{
												isRectangle = false;
												break;
											}
										}
										if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
									}
								}
							}
						}
					}
					Image<Bgr, Byte> lineImage = SoureceImage.Convert<Bgr, byte>().CopyBlank();
					foreach (RotatedRect box in boxList)
						lineImage.Draw(box, new Bgr(Color.DarkOrange), 2);
					SoureceImage.Bitmap = lineImage.Bitmap;
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
					List<BarcodeFormat> Possible = new List<BarcodeFormat>();
					Possible.Add(BarcodeFormat.QR_CODE);
					reader.Options.PossibleFormats = Possible;

					DateTime timeStart = DateTime.Now;
					Result result = reader.Decode(imgtest.Bitmap);
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
