using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace VisionPlatform
{
	class ThreadControlBaseClass
	{

		// 定义一个更新图像委托
		public delegate void UpdateImage(Image<Bgr, byte> img);
		public event UpdateImage UpdateImageDelegate;

		// 图像输出
		private static Image<Bgr, byte> Imgout;

		/// <summary>
		/// 子类图像
		/// </summary>
		protected Image<Bgr, byte> SoureceImage
		{
			// 得到form上全局img
			get { return Form1.Image1; }
			set { Imgout = value; }
		}

		/// <summary>
		/// 图像处理
		/// </summary>
		public virtual void ImageProcessing()
		{

		}

		protected void ShowFormImage()
		{
			UpdateImageDelegate(Imgout);
		}
	}
}
