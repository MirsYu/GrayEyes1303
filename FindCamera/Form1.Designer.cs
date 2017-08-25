namespace FindCamera
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
			this.imageBox1 = new Emgu.CV.UI.ImageBox();
			this.btn_Find = new System.Windows.Forms.Button();
			this.btn_ThreadAbort = new System.Windows.Forms.Button();
			this.btn_Clean = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBox_Mac = new System.Windows.Forms.TextBox();
			this.txtBox_IP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBox_Thcount = new System.Windows.Forms.TextBox();
			this.txtBox_Gateway = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// imageBox1
			// 
			this.imageBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.imageBox1.Location = new System.Drawing.Point(3, 3);
			this.imageBox1.Name = "imageBox1";
			this.imageBox1.Size = new System.Drawing.Size(400, 400);
			this.imageBox1.TabIndex = 2;
			this.imageBox1.TabStop = false;
			// 
			// btn_Find
			// 
			this.btn_Find.Location = new System.Drawing.Point(494, 142);
			this.btn_Find.Name = "btn_Find";
			this.btn_Find.Size = new System.Drawing.Size(75, 23);
			this.btn_Find.TabIndex = 3;
			this.btn_Find.Text = "寻找相机";
			this.btn_Find.UseVisualStyleBackColor = true;
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			// 
			// btn_ThreadAbort
			// 
			this.btn_ThreadAbort.Location = new System.Drawing.Point(494, 171);
			this.btn_ThreadAbort.Name = "btn_ThreadAbort";
			this.btn_ThreadAbort.Size = new System.Drawing.Size(75, 23);
			this.btn_ThreadAbort.TabIndex = 4;
			this.btn_ThreadAbort.Text = "线程中断";
			this.btn_ThreadAbort.UseVisualStyleBackColor = true;
			this.btn_ThreadAbort.Click += new System.EventHandler(this.btn_ThreadAbort_Click);
			// 
			// btn_Clean
			// 
			this.btn_Clean.Location = new System.Drawing.Point(494, 200);
			this.btn_Clean.Name = "btn_Clean";
			this.btn_Clean.Size = new System.Drawing.Size(75, 23);
			this.btn_Clean.TabIndex = 5;
			this.btn_Clean.Text = "清理线程";
			this.btn_Clean.UseVisualStyleBackColor = true;
			this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(410, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Mac地址:";
			// 
			// txtBox_Mac
			// 
			this.txtBox_Mac.Location = new System.Drawing.Point(469, 12);
			this.txtBox_Mac.Name = "txtBox_Mac";
			this.txtBox_Mac.Size = new System.Drawing.Size(100, 21);
			this.txtBox_Mac.TabIndex = 7;
			this.txtBox_Mac.Text = "40490F231791";
			// 
			// txtBox_IP
			// 
			this.txtBox_IP.Location = new System.Drawing.Point(469, 72);
			this.txtBox_IP.Name = "txtBox_IP";
			this.txtBox_IP.ReadOnly = true;
			this.txtBox_IP.Size = new System.Drawing.Size(100, 21);
			this.txtBox_IP.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(410, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "IP地址:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(409, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 12);
			this.label3.TabIndex = 10;
			this.label3.Text = "线程数:";
			// 
			// txtBox_Thcount
			// 
			this.txtBox_Thcount.Location = new System.Drawing.Point(469, 109);
			this.txtBox_Thcount.Name = "txtBox_Thcount";
			this.txtBox_Thcount.ReadOnly = true;
			this.txtBox_Thcount.Size = new System.Drawing.Size(100, 21);
			this.txtBox_Thcount.TabIndex = 11;
			this.txtBox_Thcount.Text = "10";
			// 
			// txtBox_Gateway
			// 
			this.txtBox_Gateway.Location = new System.Drawing.Point(469, 42);
			this.txtBox_Gateway.Name = "txtBox_Gateway";
			this.txtBox_Gateway.ReadOnly = true;
			this.txtBox_Gateway.Size = new System.Drawing.Size(100, 21);
			this.txtBox_Gateway.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(410, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 12);
			this.label4.TabIndex = 14;
			this.label4.Text = "网关:";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 407);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBox_Gateway);
			this.Controls.Add(this.txtBox_Thcount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBox_IP);
			this.Controls.Add(this.txtBox_Mac);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_Clean);
			this.Controls.Add(this.btn_ThreadAbort);
			this.Controls.Add(this.btn_Find);
			this.Controls.Add(this.imageBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Emgu.CV.UI.ImageBox imageBox1;
		private System.Windows.Forms.Button btn_Find;
		private System.Windows.Forms.Button btn_ThreadAbort;
		private System.Windows.Forms.Button btn_Clean;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBox_Mac;
		private System.Windows.Forms.TextBox txtBox_IP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtBox_Thcount;
		private System.Windows.Forms.TextBox txtBox_Gateway;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Timer timer1;
	}
}

