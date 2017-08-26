namespace VisionPlatform
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.imageBox1 = new Emgu.CV.UI.ImageBox();
			this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
			this.customTabControl4 = new System.Windows.Forms.CustomTabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.customTabControl2 = new System.Windows.Forms.CustomTabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.customTabControl3 = new System.Windows.Forms.CustomTabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
			this.customTabControl1.SuspendLayout();
			this.customTabControl4.SuspendLayout();
			this.customTabControl2.SuspendLayout();
			this.customTabControl3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 558);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1195, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripStatusLabel1.Image = global::VisionPlatform.Properties.Resources.SimpleState_02;
			this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(142, 17);
			this.toolStripStatusLabel2.Text = "运行时间:0000.0000毫秒";
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(235, 131);
			this.dataGridView1.TabIndex = 4;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1195, 25);
			this.toolStrip1.TabIndex = 9;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(40, 22);
			this.toolStripDropDownButton1.Text = "File";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.imageBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(614, 480);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Image";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// imageBox1
			// 
			this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageBox1.BackColor = System.Drawing.Color.DarkBlue;
			this.imageBox1.Location = new System.Drawing.Point(0, 0);
			this.imageBox1.Margin = new System.Windows.Forms.Padding(0);
			this.imageBox1.Name = "imageBox1";
			this.imageBox1.Size = new System.Drawing.Size(614, 480);
			this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageBox1.TabIndex = 2;
			this.imageBox1.TabStop = false;
			// 
			// customTabControl1
			// 
			this.customTabControl1.Controls.Add(this.tabPage1);
			// 
			// 
			// 
			this.customTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.customTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.customTabControl1.DisplayStyleProvider.FocusTrack = true;
			this.customTabControl1.DisplayStyleProvider.HotTrack = true;
			this.customTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.customTabControl1.DisplayStyleProvider.Opacity = 1F;
			this.customTabControl1.DisplayStyleProvider.Overlap = 0;
			this.customTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.customTabControl1.DisplayStyleProvider.Radius = 2;
			this.customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
			this.customTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.customTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.customTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			this.customTabControl1.HotTrack = true;
			this.customTabControl1.Location = new System.Drawing.Point(0, 47);
			this.customTabControl1.Name = "customTabControl1";
			this.customTabControl1.SelectedIndex = 0;
			this.customTabControl1.Size = new System.Drawing.Size(622, 508);
			this.customTabControl1.TabIndex = 10;
			// 
			// customTabControl4
			// 
			this.customTabControl4.Controls.Add(this.tabPage4);
			// 
			// 
			// 
			this.customTabControl4.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.customTabControl4.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.customTabControl4.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.customTabControl4.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.customTabControl4.DisplayStyleProvider.FocusTrack = true;
			this.customTabControl4.DisplayStyleProvider.HotTrack = true;
			this.customTabControl4.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.customTabControl4.DisplayStyleProvider.Opacity = 1F;
			this.customTabControl4.DisplayStyleProvider.Overlap = 0;
			this.customTabControl4.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.customTabControl4.DisplayStyleProvider.Radius = 2;
			this.customTabControl4.DisplayStyleProvider.ShowTabCloser = false;
			this.customTabControl4.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.customTabControl4.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.customTabControl4.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			this.customTabControl4.HotTrack = true;
			this.customTabControl4.Location = new System.Drawing.Point(864, 47);
			this.customTabControl4.Name = "customTabControl4";
			this.customTabControl4.SelectedIndex = 0;
			this.customTabControl4.Size = new System.Drawing.Size(331, 508);
			this.customTabControl4.TabIndex = 13;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 24);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(323, 480);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Inspector";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// customTabControl2
			// 
			this.customTabControl2.Controls.Add(this.tabPage2);
			// 
			// 
			// 
			this.customTabControl2.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.customTabControl2.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.customTabControl2.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.customTabControl2.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.customTabControl2.DisplayStyleProvider.FocusTrack = true;
			this.customTabControl2.DisplayStyleProvider.HotTrack = true;
			this.customTabControl2.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.customTabControl2.DisplayStyleProvider.Opacity = 1F;
			this.customTabControl2.DisplayStyleProvider.Overlap = 0;
			this.customTabControl2.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.customTabControl2.DisplayStyleProvider.Radius = 2;
			this.customTabControl2.DisplayStyleProvider.ShowTabCloser = false;
			this.customTabControl2.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.customTabControl2.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.customTabControl2.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			this.customTabControl2.HotTrack = true;
			this.customTabControl2.Location = new System.Drawing.Point(621, 47);
			this.customTabControl2.Name = "customTabControl2";
			this.customTabControl2.SelectedIndex = 0;
			this.customTabControl2.Size = new System.Drawing.Size(243, 344);
			this.customTabControl2.TabIndex = 14;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(235, 316);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Project";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// customTabControl3
			// 
			this.customTabControl3.Controls.Add(this.tabPage3);
			// 
			// 
			// 
			this.customTabControl3.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.customTabControl3.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
			this.customTabControl3.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			this.customTabControl3.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
			this.customTabControl3.DisplayStyleProvider.FocusTrack = true;
			this.customTabControl3.DisplayStyleProvider.HotTrack = true;
			this.customTabControl3.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.customTabControl3.DisplayStyleProvider.Opacity = 1F;
			this.customTabControl3.DisplayStyleProvider.Overlap = 0;
			this.customTabControl3.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
			this.customTabControl3.DisplayStyleProvider.Radius = 2;
			this.customTabControl3.DisplayStyleProvider.ShowTabCloser = false;
			this.customTabControl3.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
			this.customTabControl3.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
			this.customTabControl3.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
			this.customTabControl3.HotTrack = true;
			this.customTabControl3.Location = new System.Drawing.Point(621, 397);
			this.customTabControl3.Name = "customTabControl3";
			this.customTabControl3.SelectedIndex = 0;
			this.customTabControl3.Size = new System.Drawing.Size(243, 158);
			this.customTabControl3.TabIndex = 15;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dataGridView1);
			this.tabPage3.Location = new System.Drawing.Point(4, 24);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(235, 130);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Result";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
			this.ClientSize = new System.Drawing.Size(1195, 580);
			this.Controls.Add(this.customTabControl3);
			this.Controls.Add(this.customTabControl2);
			this.Controls.Add(this.customTabControl4);
			this.Controls.Add(this.customTabControl1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
			this.customTabControl1.ResumeLayout(false);
			this.customTabControl4.ResumeLayout(false);
			this.customTabControl2.ResumeLayout(false);
			this.customTabControl3.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.TabPage tabPage1;
		private Emgu.CV.UI.ImageBox imageBox1;
		private System.Windows.Forms.CustomTabControl customTabControl1;
		private System.Windows.Forms.CustomTabControl customTabControl4;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.CustomTabControl customTabControl2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CustomTabControl customTabControl3;
		private System.Windows.Forms.TabPage tabPage3;
	}
}

