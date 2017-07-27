namespace NetDeviceScanControl
{
    partial class NetDeviceScanControl
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
			this.txtBox_GateWay = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btn_GetDeviceIP = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBox_MacAddress = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtBox_GateWay
			// 
			this.txtBox_GateWay.Location = new System.Drawing.Point(106, 44);
			this.txtBox_GateWay.Name = "txtBox_GateWay";
			this.txtBox_GateWay.Size = new System.Drawing.Size(100, 21);
			this.txtBox_GateWay.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(218, 81);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 21);
			this.textBox2.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(26, 126);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(235, 127);
			this.textBox3.TabIndex = 2;
			// 
			// btn_GetDeviceIP
			// 
			this.btn_GetDeviceIP.Location = new System.Drawing.Point(301, 223);
			this.btn_GetDeviceIP.Name = "btn_GetDeviceIP";
			this.btn_GetDeviceIP.Size = new System.Drawing.Size(75, 23);
			this.btn_GetDeviceIP.TabIndex = 3;
			this.btn_GetDeviceIP.Text = "button1";
			this.btn_GetDeviceIP.UseVisualStyleBackColor = true;
			this.btn_GetDeviceIP.Click += new System.EventHandler(this.btn_GetDeviceIP_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "GateWay:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "Destination IP address:";
			// 
			// txtBox_MacAddress
			// 
			this.txtBox_MacAddress.Location = new System.Drawing.Point(106, 18);
			this.txtBox_MacAddress.Name = "txtBox_MacAddress";
			this.txtBox_MacAddress.Size = new System.Drawing.Size(125, 21);
			this.txtBox_MacAddress.TabIndex = 6;
			this.txtBox_MacAddress.Text = "40490F231791";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "Mac Address:";
			// 
			// NetDeviceScanControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBox_MacAddress);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_GetDeviceIP);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.txtBox_GateWay);
			this.Name = "NetDeviceScanControl";
			this.Size = new System.Drawing.Size(389, 282);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.TextBox txtBox_GateWay;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button btn_GetDeviceIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBox_MacAddress;
		private System.Windows.Forms.Label label3;
	}
}
