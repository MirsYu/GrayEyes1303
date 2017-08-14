using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Windows.Forms;
using System.Data;

namespace VisionPlatform
{
	class ThreadControlBaseClass
	{

		// 定义一个更新图像委托
		public delegate void UpdateImage(Image<Bgr, byte> img, 
			ToolStripStatusLabel simpleStatus,
			ToolStripStatusLabel runtime,
			DataTable dataSource);
		public event UpdateImage UpdateImageDelegate;

		// 图像输出
		private static Image<Bgr, byte> outImg;

		// 状态输出
		protected ToolStripStatusLabel SourSimpleStatus = new ToolStripStatusLabel();
		protected ToolStripStatusLabel SourRunTime = new ToolStripStatusLabel();

		// 数据源输出
		protected DataTable SourDataTable = new DataTable();

		/// <summary>
		/// 子类图像
		/// </summary>
		protected Image<Bgr, byte> SoureceImage
		{
			// 得到form上全局img
			get { return Form1.Image1; }
			set { outImg = value; }
		}

		protected ToolStripStatusLabel SimpleStatus
		{
			get { return SourSimpleStatus; }
			set { SourSimpleStatus = value; }
		}

		protected ToolStripStatusLabel mRuntime
		{
			get { return SourRunTime; }
			set { SourRunTime = value; }
		}

		protected DataTable DataSource
		{
			get { return SourDataTable; }
			set { SourDataTable = value; }
		}

		/// <summary>
		/// 图像处理
		/// </summary>
		public virtual void ImageProcessing()
		{

		}

		protected void ShowFormImage()
		{
			UpdateImageDelegate(SoureceImage, SimpleStatus, mRuntime, DataSource);
		}
	}
}
