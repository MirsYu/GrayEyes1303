namespace HalconCalibrate
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
			this.hWindowControl1 = new HalconDotNet.HWindowControl();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_InCalibrate = new System.Windows.Forms.Button();
			this.btn_outCalibrate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.ImageX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ImageY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MachineX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MachineY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// hWindowControl1
			// 
			this.hWindowControl1.BackColor = System.Drawing.Color.Black;
			this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
			this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
			this.hWindowControl1.Location = new System.Drawing.Point(3, 2);
			this.hWindowControl1.Name = "hWindowControl1";
			this.hWindowControl1.Size = new System.Drawing.Size(416, 393);
			this.hWindowControl1.TabIndex = 0;
			this.hWindowControl1.WindowSize = new System.Drawing.Size(416, 393);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(435, 28);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(206, 21);
			this.textBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(435, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "内参图片文件夹";
			// 
			// btn_InCalibrate
			// 
			this.btn_InCalibrate.Location = new System.Drawing.Point(435, 70);
			this.btn_InCalibrate.Name = "btn_InCalibrate";
			this.btn_InCalibrate.Size = new System.Drawing.Size(75, 23);
			this.btn_InCalibrate.TabIndex = 4;
			this.btn_InCalibrate.Text = "内部标定";
			this.btn_InCalibrate.UseVisualStyleBackColor = true;
			this.btn_InCalibrate.Click += new System.EventHandler(this.btn_InCalibrate_Click);
			// 
			// btn_outCalibrate
			// 
			this.btn_outCalibrate.Location = new System.Drawing.Point(435, 111);
			this.btn_outCalibrate.Name = "btn_outCalibrate";
			this.btn_outCalibrate.Size = new System.Drawing.Size(75, 23);
			this.btn_outCalibrate.TabIndex = 5;
			this.btn_outCalibrate.Text = "外部标定";
			this.btn_outCalibrate.UseVisualStyleBackColor = true;
			this.btn_outCalibrate.Click += new System.EventHandler(this.btn_outCalibrate_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(435, 155);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "1毫米多少个像素点";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(435, 171);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 21);
			this.textBox2.TabIndex = 7;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(435, 222);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 21);
			this.textBox3.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(435, 206);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "1个像素点多少毫米";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(433, 274);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 21);
			this.textBox4.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(433, 258);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 12);
			this.label4.TabIndex = 10;
			this.label4.Text = "机械坐标X";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(433, 314);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 21);
			this.textBox5.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(433, 298);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "机械坐标Y";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(546, 274);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(100, 21);
			this.textBox6.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(546, 258);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 12);
			this.label6.TabIndex = 14;
			this.label6.Text = "标定板中心坐标X";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(548, 314);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(100, 21);
			this.textBox7.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(548, 298);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 12);
			this.label7.TabIndex = 16;
			this.label7.Text = "标定板中心坐标Y";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageX,
            this.ImageY,
            this.MachineX,
            this.MachineY});
			this.dataGridView1.Location = new System.Drawing.Point(550, 93);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(312, 141);
			this.dataGridView1.TabIndex = 18;
			// 
			// ImageX
			// 
			this.ImageX.FillWeight = 50F;
			this.ImageX.HeaderText = "ImageX";
			this.ImageX.Name = "ImageX";
			this.ImageX.Width = 50;
			// 
			// ImageY
			// 
			this.ImageY.FillWeight = 50F;
			this.ImageY.HeaderText = "ImageY";
			this.ImageY.Name = "ImageY";
			this.ImageY.Width = 50;
			// 
			// MachineX
			// 
			this.MachineX.FillWeight = 50F;
			this.MachineX.HeaderText = "MachineX";
			this.MachineX.Name = "MachineX";
			this.MachineX.Width = 80;
			// 
			// MachineY
			// 
			this.MachineY.FillWeight = 50F;
			this.MachineY.HeaderText = "MachineY";
			this.MachineY.Name = "MachineY";
			this.MachineY.Width = 80;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(435, 355);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 19;
			this.button3.Text = "添加进数组";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(516, 355);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 20;
			this.button4.Text = "删除数据";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(612, 355);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(125, 23);
			this.button5.TabIndex = 21;
			this.button5.Text = "计算并保存位姿文件";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(666, 314);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(100, 21);
			this.textBox8.TabIndex = 25;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(666, 298);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 12);
			this.label8.TabIndex = 24;
			this.label8.Text = "标定板任意mark坐标Y";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(664, 274);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(100, 21);
			this.textBox9.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(664, 258);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(131, 12);
			this.label9.TabIndex = 22;
			this.label9.Text = "标定板任意mark点坐标X";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(799, 314);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(100, 21);
			this.textBox10.TabIndex = 29;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(799, 298);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(83, 12);
			this.label10.TabIndex = 28;
			this.label10.Text = "求得机械坐标Y";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(797, 274);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(100, 21);
			this.textBox11.TabIndex = 27;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(797, 258);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(83, 12);
			this.label11.TabIndex = 26;
			this.label11.Text = "求得机械坐标X";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(770, 355);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(129, 23);
			this.button6.TabIndex = 30;
			this.button6.Text = "计算机械坐标并运动";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 399);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_outCalibrate);
			this.Controls.Add(this.btn_InCalibrate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.hWindowControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private HalconDotNet.HWindowControl hWindowControl1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_InCalibrate;
		private System.Windows.Forms.Button btn_outCalibrate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ImageX;
		private System.Windows.Forms.DataGridViewTextBoxColumn ImageY;
		private System.Windows.Forms.DataGridViewTextBoxColumn MachineX;
		private System.Windows.Forms.DataGridViewTextBoxColumn MachineY;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button6;
	}
}

