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
				getBatCode();
			}
		}

		public void imageHanding()
		{
			if (SoureceImage !=null )
			{
				try
				{
					Mat img = SoureceImage.Mat;
					Image<Gray, byte> otsu = SoureceImage.CopyBlank();
					// 转灰度图
					//CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Gray);
					// 中值滤波(去除椒盐噪声)
					CvInvoke.MedianBlur(img, otsu, 3);
					// Otsu二值化
					CvInvoke.Threshold(otsu, img, 0, 255, ThresholdType.Otsu);
					// 高斯滤波
					CvInvoke.GaussianBlur(img, img, new Size(3, 3), 0);
					// 形态学梯度运算
					Mat StructingElement = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(5, 5), new Point(-1, -1));
					CvInvoke.MorphologyEx(img, img, MorphOp.Gradient, StructingElement, new Point(-1, -1), 6, BorderType.Default, new MCvScalar(0));
					// 边缘检测
					CvInvoke.Canny(img, img, 100, 200);

					List<RotatedRect> boxList = new List<RotatedRect>();
					List<int> index = new List<int>();
					using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
					{
						// 寻找轮廓
						CvInvoke.FindContours(img, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

						int count = contours.Size;
						for (int i = 0; i < count; i++)
						{
							using (VectorOfPoint contour = contours[i])
							using (VectorOfPoint approxContour = new VectorOfPoint())
							{
								CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
								if (CvInvoke.ContourArea(approxContour, false) > 200)
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
										if (isRectangle)
										{
											boxList.Add(CvInvoke.MinAreaRect(approxContour));
										}
									}
								}
							}
						}
					}
					Image<Bgr, Byte> lineImage = SoureceImage.Convert<Bgr, byte>().CopyBlank();
					Image<Gray, byte> testimg = SoureceImage.CopyBlank();
					foreach (RotatedRect box in boxList)
					{
						lineImage.Draw(box, new Bgr(Color.DarkOrange), 2);
						PointF[] vertices = new PointF[4];
						vertices = box.GetVertices();
						//for (int i = 0; i < 4; i++)
						//line(image, vertices[i], vertices[(i + 1) % 4], Scalar(0, 255, 0));
						Rectangle brect = box.MinAreaRect();
						lineImage.Draw(brect, new Bgr(Color.DarkOrange), 2);

					}
					otsu.ROI = boxList[1].MinAreaRect();
					testimg = otsu.Clone();
					otsu.ROI = Rectangle.Empty;
					Mat mapMatrix = new Mat();
					PointF poi = new PointF(testimg.Size.Width / 2, testimg.Size.Height / 2);
					CvInvoke.GetRotationMatrix2D(poi, boxList[1].Angle, 1.2, mapMatrix);
					CvInvoke.WarpAffine(testimg, testimg, mapMatrix, testimg.Size);

					SoureceImage.Bitmap = testimg.Bitmap;
					//ShowFormImage();
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
					Possible.Add(BarcodeFormat.DATA_MATRIX);
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
