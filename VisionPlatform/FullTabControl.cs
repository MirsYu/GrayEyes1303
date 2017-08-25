using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisionPlatform
{
	/// <summary>   
	/// 解决系统TabControl多余边距问题   
	/// </summary>   
	public class FullTabControl : TabControl
	{
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle rect = base.DisplayRectangle;
				return new Rectangle(rect.Left - 4, rect.Top - 2, rect.Width + 8, rect.Height + 6);
			}
		}
	}
}
