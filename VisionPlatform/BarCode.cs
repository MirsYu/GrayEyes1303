using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;

namespace VisionPlatform
{
	class BarCode : ThreadControlBaseClass
	{
		public static BarCode Instance
		{
			get { return new BarCode(); }
		}

		public override void ImageProcessing ()
		{
			CvInvoke.GaussianBlur(SoureceImage, SoureceImage, new Size(3, 3), 0, 0);
			ShowFormImage();
		}
	}
}
