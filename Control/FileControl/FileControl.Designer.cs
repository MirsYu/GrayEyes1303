namespace FileControl
{
    partial class FileControl
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.txtBox_FilePath = new System.Windows.Forms.TextBox();
			this.lab_FilePath = new System.Windows.Forms.Label();
			this.lab_ReadInfo = new System.Windows.Forms.Label();
			this.lab_WriteInfo = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btn_OpenFile = new System.Windows.Forms.Button();
			this.btn_SaveFile = new System.Windows.Forms.Button();
			this.btn_ReadFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtBox_FilePath
			// 
			this.txtBox_FilePath.Location = new System.Drawing.Point(72, 9);
			this.txtBox_FilePath.Name = "txtBox_FilePath";
			this.txtBox_FilePath.Size = new System.Drawing.Size(240, 21);
			this.txtBox_FilePath.TabIndex = 0;
			// 
			// lab_FilePath
			// 
			this.lab_FilePath.AutoSize = true;
			this.lab_FilePath.Location = new System.Drawing.Point(7, 12);
			this.lab_FilePath.Name = "lab_FilePath";
			this.lab_FilePath.Size = new System.Drawing.Size(59, 12);
			this.lab_FilePath.TabIndex = 1;
			this.lab_FilePath.Text = "FilePath:";
			// 
			// lab_ReadInfo
			// 
			this.lab_ReadInfo.AutoSize = true;
			this.lab_ReadInfo.Location = new System.Drawing.Point(7, 42);
			this.lab_ReadInfo.Name = "lab_ReadInfo";
			this.lab_ReadInfo.Size = new System.Drawing.Size(59, 12);
			this.lab_ReadInfo.TabIndex = 2;
			this.lab_ReadInfo.Text = "ReadInfo:";
			// 
			// lab_WriteInfo
			// 
			this.lab_WriteInfo.AutoSize = true;
			this.lab_WriteInfo.Location = new System.Drawing.Point(1, 151);
			this.lab_WriteInfo.Name = "lab_WriteInfo";
			this.lab_WriteInfo.Size = new System.Drawing.Size(65, 12);
			this.lab_WriteInfo.TabIndex = 3;
			this.lab_WriteInfo.Text = "WriteInfo:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(72, 39);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(240, 100);
			this.textBox2.TabIndex = 4;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(72, 148);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(240, 100);
			this.textBox3.TabIndex = 5;
			// 
			// btn_OpenFile
			// 
			this.btn_OpenFile.Location = new System.Drawing.Point(328, 7);
			this.btn_OpenFile.Name = "btn_OpenFile";
			this.btn_OpenFile.Size = new System.Drawing.Size(75, 23);
			this.btn_OpenFile.TabIndex = 6;
			this.btn_OpenFile.Text = "OpenFile";
			this.btn_OpenFile.UseVisualStyleBackColor = true;
			this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
			// 
			// btn_SaveFile
			// 
			this.btn_SaveFile.Location = new System.Drawing.Point(328, 151);
			this.btn_SaveFile.Name = "btn_SaveFile";
			this.btn_SaveFile.Size = new System.Drawing.Size(75, 23);
			this.btn_SaveFile.TabIndex = 7;
			this.btn_SaveFile.Text = "SaveFile";
			this.btn_SaveFile.UseVisualStyleBackColor = true;
			this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
			// 
			// btn_ReadFile
			// 
			this.btn_ReadFile.Location = new System.Drawing.Point(328, 42);
			this.btn_ReadFile.Name = "btn_ReadFile";
			this.btn_ReadFile.Size = new System.Drawing.Size(75, 23);
			this.btn_ReadFile.TabIndex = 8;
			this.btn_ReadFile.Text = "ReadFile";
			this.btn_ReadFile.UseVisualStyleBackColor = true;
			this.btn_ReadFile.Click += new System.EventHandler(this.btn_ReadFile_Click);
			// 
			// FileControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btn_ReadFile);
			this.Controls.Add(this.btn_SaveFile);
			this.Controls.Add(this.btn_OpenFile);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.lab_WriteInfo);
			this.Controls.Add(this.lab_ReadInfo);
			this.Controls.Add(this.lab_FilePath);
			this.Controls.Add(this.txtBox_FilePath);
			this.Name = "FileControl";
			this.Size = new System.Drawing.Size(410, 256);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.TextBox txtBox_FilePath;
		private System.Windows.Forms.Label lab_FilePath;
		private System.Windows.Forms.Label lab_ReadInfo;
		private System.Windows.Forms.Label lab_WriteInfo;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button btn_OpenFile;
		private System.Windows.Forms.Button btn_SaveFile;
		private System.Windows.Forms.Button btn_ReadFile;
	}
}
