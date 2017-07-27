using System;
using System.Windows.Forms;
using System.IO;

namespace FileControl
{
	public partial class FileControl: UserControl
    {
        public FileControl()
        {
            InitializeComponent();
        }

		private void btn_OpenFile_Click(object sender, EventArgs e)
		{
			try
			{
				File.Open(txtBox_FilePath.Text, FileMode.OpenOrCreate);
			}
			catch (Exception)
			{
			}
		}

		private void btn_ReadFile_Click(object sender, EventArgs e)
		{

		}

		private void btn_SaveFile_Click(object sender, EventArgs e)
		{

		}
	}
}
