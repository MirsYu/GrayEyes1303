using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;

namespace AcquireControl
{
	public partial class AcquireControl : UserControl
	{
		public AcquireControl()
		{
			InitializeComponent();
			HDevelopExport.mWindow = hWindowControl1.HalconWindow;
		}

		Thread thread = new Thread(HDevelopExport.acquireimage);

		private void btn_OpenCam_Click(object sender, EventArgs e)
		{
			thread.Start();
		}

		private void btn_ColseAcquire_Click(object sender, EventArgs e)
		{
			thread.Abort();
		}
	}
}
