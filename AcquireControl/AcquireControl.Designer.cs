namespace AcquireControl
{
    partial class AcquireControl
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
            this.btn_OpenCam = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.btn_ColseAcquire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_OpenCam
            // 
            this.btn_OpenCam.Location = new System.Drawing.Point(582, 3);
            this.btn_OpenCam.Name = "btn_OpenCam";
            this.btn_OpenCam.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenCam.TabIndex = 1;
            this.btn_OpenCam.Text = "button1";
            this.btn_OpenCam.UseVisualStyleBackColor = true;
            this.btn_OpenCam.Click += new System.EventHandler(this.btn_OpenCam_Click);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(3, 3);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(573, 466);
            this.hWindowControl1.TabIndex = 2;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(573, 466);
            // 
            // btn_ColseAcquire
            // 
            this.btn_ColseAcquire.Location = new System.Drawing.Point(582, 58);
            this.btn_ColseAcquire.Name = "btn_ColseAcquire";
            this.btn_ColseAcquire.Size = new System.Drawing.Size(75, 23);
            this.btn_ColseAcquire.TabIndex = 3;
            this.btn_ColseAcquire.Text = "button1";
            this.btn_ColseAcquire.UseVisualStyleBackColor = true;
            this.btn_ColseAcquire.Click += new System.EventHandler(this.btn_ColseAcquire_Click);
            // 
            // AcquireControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_ColseAcquire);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.btn_OpenCam);
            this.Name = "AcquireControl";
            this.Size = new System.Drawing.Size(661, 469);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_OpenCam;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button btn_ColseAcquire;
    }
}
