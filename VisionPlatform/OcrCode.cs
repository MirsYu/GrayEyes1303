using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Data;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace VisionPlatform
{
	class OcrCode : ThreadControlBaseClass
	{
		private static OcrCode ocrcode = new OcrCode("");
		/// <summary>
		/// OCR引擎
		/// </summary>
		private Tesseract _ocr;

		public static OcrCode Instance
		{
			get { return ocrcode; }
		}

		public override void ImageProcessing()
		{
			List<IInputOutputArray> PlateImagesList = new List<IInputOutputArray>();
			List<IInputOutputArray> filterePlateImagesList = new List<IInputOutputArray>();
			List<RotatedRect> detectedPlateRegionList = new List<RotatedRect>();
			List<String> test = new List<string>();
			test= DetectPlate(SoureceImage, PlateImagesList, filterePlateImagesList, detectedPlateRegionList);

			DataSource = new DataTable();
			DataSource.Columns.Add("字符串", typeof(System.String));
			DataRow newLine = DataSource.NewRow();
			newLine["字符串"] = test[0];
			DataSource.Rows.Add(newLine);

			SoureceImage.Bitmap = filterePlateImagesList[0].GetInputOutputArray().GetMat().Bitmap;
			ShowFormImage();
		}

		/// <summary>
		/// 创建一个检测器
		/// </summary>
		/// <param name="dataPath">
		/// datapath 必须是tessdata的父目录的名称和// /必须以/结尾
		/// </param>
		public OcrCode (String dataPath)
		{
			//创建OCR引擎
			_ocr = new Tesseract(dataPath, "eng", OcrEngineMode.TesseractCubeCombined);
			_ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
		}

		/// <summary>
		/// 从给定的图像中检测字符
		/// </summary>
		/// <param name="img">给定图像</param>
		/// <param name="PlateImagesList">存储检测到的字符串区域的图像列表</param>
		/// <param name="filterePlateImagesList"></param>
		/// <param name="detectedPlateRegionList">存储字符区域列表</param>
		/// <returns>每个字符串的单词列表</returns>
		public List<String> DetectPlate(
			IInputArray img,
			List<IInputOutputArray> PlateImagesList,
			List<IInputOutputArray> filterePlateImagesList,
			List<RotatedRect> detectedPlateRegionList
			)
		{
			List<String> word = new List<string>();
			using (Mat gray = img.GetInputArray().GetMat())
			using (Mat canny = new Mat())
			using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
			{
				//CvInvoke.CvtColor(img, gray, ColorConversion.Bgr2Gray);
				// 检测轮廓
				CvInvoke.Canny(gray, canny, 100, 50, 3, false);
				// 寻找边缘
				// 得到层级关系
				//hierachy [0，i，0] 是下一个轮廓的索引
				//hierachy [0，i，1] 是同一层次结构级别上的先前轮廓的索引，或者 - 如果不存在则为-1。
				//hierachy [0，i，2] code > 是轮廓 i 的子项的索引或 -如果不存在则为 - 1
				//hierachy [0，i，3] 是轮廓父类的索引 i 或 - 1如果不存在

				int[,] hierachy = CvInvoke.FindContourTree(canny, contours, ChainApproxMethod.ChainApproxSimple);
				FindPlate(contours, hierachy, 0, gray, canny, PlateImagesList, filterePlateImagesList, detectedPlateRegionList, word);
			}
			return word;
		}

		private void FindPlate(
			VectorOfVectorOfPoint contours, int[,] hierachy,int idx,IInputArray gray,IInputArray canny,
			List<IInputOutputArray> PlateImageList,List<IInputOutputArray> filteredPlateImageList,List<RotatedRect> detectedPlateRegionList,
			List<String> word)
		{
			for (; idx >=0;idx = hierachy[idx,0])
			{
				// 寻找有多少个子轮廓
				int numberOfChildren = GetNumberOfChildren(hierachy, idx);
				if (numberOfChildren == 0) continue;
				using (VectorOfPoint contour = contours[idx])
				{
					// 轮廓内的面积
					if (CvInvoke.ContourArea(contour) > 400)
					{
						if (numberOfChildren < 3)
						{
							// 子轮廓小于3 认定不是字符串区域
							// 再次去搜索这个子轮廓 子项索引
							FindPlate(contours, hierachy, hierachy[idx, 2], gray, canny, PlateImageList,
								filteredPlateImageList, detectedPlateRegionList, word);
							continue;
						}

						// 旋转矩形 最小面积矩形
						RotatedRect box = CvInvoke.MinAreaRect(contour);
						if (box.Angle < -45.0)
						{
							float tmp = box.Size.Width;
							box.Size.Width = box.Size.Height;
							box.Size.Height = tmp;
							box.Angle += 90.0f;
						}
						else if (box.Angle > 45.0)
						{
							float tmp = box.Size.Width;
							box.Size.Width = box.Size.Height;
							box.Size.Height = tmp;
							box.Angle -= 90.0f;
						}

						double whRatio = (double)box.Size.Width / box.Size.Height;
						// 字符串长度和宽度
						if (!(3.0< whRatio && whRatio<10.0))
						{
							// 认定不是个字符串 但是继续搜索子区域
							if (hierachy[idx,2] > 0)
							{
								FindPlate(contours, hierachy, hierachy[idx, 2], gray, canny, PlateImageList,
									filteredPlateImageList, detectedPlateRegionList, word);
								continue;
							}
						}

						using (Mat tmp1 = new Mat())
						using (Mat tmp2 = new Mat())
						{
							PointF[] srcCorners = box.GetVertices();
							PointF[] destConers = new PointF[]
							{
								new PointF(0,box.Size.Height - 1),
								new PointF(0,0),
								new PointF(box.Size.Width - 1, 0),
								new PointF(box.Size.Width - 1,box.Size.Height -1)
							};
							using (Mat rot = CvInvoke.GetAffineTransform(srcCorners, destConers))
							{
								CvInvoke.WarpAffine(gray, tmp1, rot, Size.Round(box.Size));
							}

							// 调整字符串大小
							Size approxSize = new Size(240, 180);
							double scale = Math.Min(approxSize.Width / box.Size.Width, approxSize.Height / box.Size.Height);
							Size newSize = new Size((int)Math.Round(box.Size.Width * scale), (int)Math.Round(box.Size.Height * scale));
							CvInvoke.Resize(tmp1, tmp2, newSize, 0, 0, Inter.Cubic);

							// 移除边缘像素
							int edgePixlSize = 2;
							Rectangle newRoi = new Rectangle(new Point(edgePixlSize, edgePixlSize),
								tmp2.Size - new Size(2 * edgePixlSize, 2 * edgePixlSize));
							Mat plate = new Mat(tmp2, newRoi);
							Mat filteredPlate = FilterPlate(plate);

							Tesseract.Character[] words;
							StringBuilder strBuilder = new StringBuilder();
							using (Mat tmp = filteredPlate.Clone())
							{
								// 检测图片
								_ocr.Recognize(tmp);
								words = _ocr.GetCharacters();

								if (words.Length == 0)
								{
									continue;
								}
								for (int i = 0; i < words.Length; i++)
								{
									strBuilder.Append(words[i].Text);
								}
							}
							word.Add(strBuilder.ToString());
							PlateImageList.Add(plate);
							filteredPlateImageList.Add(filteredPlate);
							detectedPlateRegionList.Add(box);
						}
					}
				}
			}
		}

		private static int GetNumberOfChildren(int[,] hierachy,int idx)
		{
			// 第一个
			idx = hierachy[idx, 2];
			if (idx < 0)
			{
				return 0;
			}
			int count = 1;
			while (hierachy[idx,0] > 0)
			{
				count++;
				idx = hierachy[idx, 0];
			}
			return count;
		}

		/// <summary>
		/// 移除噪点
		/// </summary>
		/// <param name="plate">字符串图片</param>
		/// <returns></returns>
		private static Mat FilterPlate(Mat plate)
		{
			Mat thresh = new Mat();
			// 阈值操作 120阈值大小，255最大灰度值 类型BinaryInv 反阈值
			CvInvoke.Threshold(plate, thresh, 120, 255, ThresholdType.BinaryInv);

			Size plateSize = plate.Size;
			using (Mat plateMask = new Mat(plateSize.Height, plateSize.Width, DepthType.Cv8U, 1))
			using (Mat plateCanny = new Mat())
			using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
			{
				// 将图像设为某个值
				plateMask.SetTo(new MCvScalar(255.0));
				// 边缘检测
				CvInvoke.Canny(plate, plateCanny, 100, 50);
				// 寻找轮廓
				CvInvoke.FindContours(plateCanny, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

				int count = contours.Size;
				for (int i = 1; i < count; i++)
				{
					using (VectorOfPoint contour = contours[i])
					{
						// 外接矩形
						Rectangle rect = CvInvoke.BoundingRectangle(contour);
						// 右移相当于除以2
						if (rect.Height > (plateSize.Height >> 1))
						{
							rect.X -= 1; rect.Y -= 1;rect.Width += 2; rect.Height += 2;
							Rectangle roi = new Rectangle(Point.Empty, plate.Size);
							// 交集？
							rect.Intersect(roi);
							// 画矩形？
							CvInvoke.Rectangle(plateMask, rect, new MCvScalar(), -1);
						}
					}
				}
				thresh.SetTo(new MCvScalar(), plateMask);
			}
			CvInvoke.Erode(thresh, thresh, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
			CvInvoke.Dilate(thresh, thresh, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
			return thresh;
		}

		private void getOcr()
		{
			_ocr = new Tesseract("", "eng", OcrEngineMode.TesseractCubeCombined);
			_ocr.SetVariable("tessedit_char_blacklist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ - 1234567890");
			Bgr drawColor = new Bgr(Color.Blue);
			Image <Gray, byte> gray = SoureceImage.Convert<Gray, byte>();
			_ocr.Recognize(gray);
			Tesseract.Character[] characters = _ocr.GetCharacters();
			foreach (Tesseract.Character c in characters)
			{
				gray.Draw(c.Region, new Gray(0), 1);
			}

			DataSource = new DataTable();
			DataSource.Columns.Add("字符串", typeof(System.String));
			DataRow newLine = DataSource.NewRow();
			newLine["字符串"] = _ocr.GetText();
			DataSource.Rows.Add(newLine);

			SoureceImage.Bitmap = gray.Bitmap;
			ShowFormImage();
		}
	}
}
