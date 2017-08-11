using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialportControl
{
    public partial class SerialportControl: UserControl
    {
        public SerialportControl()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			textBox2.Text = Environment.GetEnvironmentVariable("OS");
		}
	}
}
