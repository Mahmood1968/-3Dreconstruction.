namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1LeftImge = new System.Windows.Forms.PictureBox();
            this.pictureBox2Rightimg = new System.Windows.Forms.PictureBox();
            this.button1_Close = new System.Windows.Forms.Button();
            this.button1M1 = new System.Windows.Forms.Button();
            this.button1M2 = new System.Windows.Forms.Button();
            this.button1SaveM1 = new System.Windows.Forms.Button();
            this.button1SaveM2 = new System.Windows.Forms.Button();
            this.button1Epipolar = new System.Windows.Forms.Button();
            this.textBox1ZNCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1Right = new System.Windows.Forms.TextBox();
            this.textBox2Right = new System.Windows.Forms.TextBox();
            this.label2XR = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1LDM1 = new System.Windows.Forms.Button();
            this.textBox1XL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1YL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1XD3 = new System.Windows.Forms.TextBox();
            this.textBox1YD3 = new System.Windows.Forms.TextBox();
            this.textBox1ZD3 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1LeftImge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Rightimg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1LeftImge
            // 
            this.pictureBox1LeftImge.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1LeftImge.Image")));
            this.pictureBox1LeftImge.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1LeftImge.Name = "pictureBox1LeftImge";
            this.pictureBox1LeftImge.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1LeftImge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1LeftImge.TabIndex = 0;
            this.pictureBox1LeftImge.TabStop = false;
            this.pictureBox1LeftImge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1LeftImge_MouseDown);
            // 
            // pictureBox2Rightimg
            // 
            this.pictureBox2Rightimg.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2Rightimg.Image")));
            this.pictureBox2Rightimg.Location = new System.Drawing.Point(646, 2);
            this.pictureBox2Rightimg.Name = "pictureBox2Rightimg";
            this.pictureBox2Rightimg.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2Rightimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2Rightimg.TabIndex = 1;
            this.pictureBox2Rightimg.TabStop = false;
            this.pictureBox2Rightimg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2Rightimg_MouseDown);
            // 
            // button1_Close
            // 
            this.button1_Close.Location = new System.Drawing.Point(293, 481);
            this.button1_Close.Name = "button1_Close";
            this.button1_Close.Size = new System.Drawing.Size(83, 30);
            this.button1_Close.TabIndex = 3;
            this.button1_Close.Text = "CLOSE";
            this.button1_Close.UseVisualStyleBackColor = true;
            this.button1_Close.Click += new System.EventHandler(this.button1_Close_Click);
            // 
            // button1M1
            // 
            this.button1M1.Location = new System.Drawing.Point(10, 481);
            this.button1M1.Name = "button1M1";
            this.button1M1.Size = new System.Drawing.Size(100, 30);
            this.button1M1.TabIndex = 5;
            this.button1M1.Text = "CREAT M1";
            this.button1M1.UseVisualStyleBackColor = true;
            this.button1M1.Click += new System.EventHandler(this.button1M1_Click);
            // 
            // button1M2
            // 
            this.button1M2.Location = new System.Drawing.Point(646, 488);
            this.button1M2.Name = "button1M2";
            this.button1M2.Size = new System.Drawing.Size(82, 26);
            this.button1M2.TabIndex = 6;
            this.button1M2.Text = "CREAT M2";
            this.button1M2.UseVisualStyleBackColor = true;
            this.button1M2.Click += new System.EventHandler(this.button1M2_Click);
            // 
            // button1SaveM1
            // 
            this.button1SaveM1.Location = new System.Drawing.Point(116, 482);
            this.button1SaveM1.Name = "button1SaveM1";
            this.button1SaveM1.Size = new System.Drawing.Size(84, 30);
            this.button1SaveM1.TabIndex = 7;
            this.button1SaveM1.Text = "SAVE M1";
            this.button1SaveM1.UseVisualStyleBackColor = true;
            this.button1SaveM1.Click += new System.EventHandler(this.button1SaveM1_Click);
            // 
            // button1SaveM2
            // 
            this.button1SaveM2.Location = new System.Drawing.Point(734, 488);
            this.button1SaveM2.Name = "button1SaveM2";
            this.button1SaveM2.Size = new System.Drawing.Size(82, 26);
            this.button1SaveM2.TabIndex = 8;
            this.button1SaveM2.Text = "SAVE M2";
            this.button1SaveM2.UseVisualStyleBackColor = true;
            this.button1SaveM2.Click += new System.EventHandler(this.button1SaveM2_Click);
            // 
            // button1Epipolar
            // 
            this.button1Epipolar.Location = new System.Drawing.Point(203, 482);
            this.button1Epipolar.Name = "button1Epipolar";
            this.button1Epipolar.Size = new System.Drawing.Size(84, 28);
            this.button1Epipolar.TabIndex = 9;
            this.button1Epipolar.Text = "EPIPOLAR";
            this.button1Epipolar.UseVisualStyleBackColor = true;
            this.button1Epipolar.Click += new System.EventHandler(this.button1Epipolar_Click);
            // 
            // textBox1ZNCC
            // 
            this.textBox1ZNCC.Location = new System.Drawing.Point(64, 514);
            this.textBox1ZNCC.Name = "textBox1ZNCC";
            this.textBox1ZNCC.Size = new System.Drawing.Size(136, 20);
            this.textBox1ZNCC.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ZNCC";
            // 
            // textBox1Right
            // 
            this.textBox1Right.Location = new System.Drawing.Point(1024, 488);
            this.textBox1Right.Name = "textBox1Right";
            this.textBox1Right.Size = new System.Drawing.Size(72, 20);
            this.textBox1Right.TabIndex = 12;
            // 
            // textBox2Right
            // 
            this.textBox2Right.Location = new System.Drawing.Point(1026, 512);
            this.textBox2Right.Name = "textBox2Right";
            this.textBox2Right.Size = new System.Drawing.Size(68, 20);
            this.textBox2Right.TabIndex = 13;
            // 
            // label2XR
            // 
            this.label2XR.AutoSize = true;
            this.label2XR.Location = new System.Drawing.Point(983, 490);
            this.label2XR.Name = "label2XR";
            this.label2XR.Size = new System.Drawing.Size(17, 13);
            this.label2XR.TabIndex = 14;
            this.label2XR.Text = "Xr";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(985, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Yr";
            // 
            // button1LDM1
            // 
            this.button1LDM1.Location = new System.Drawing.Point(208, 512);
            this.button1LDM1.Name = "button1LDM1";
            this.button1LDM1.Size = new System.Drawing.Size(79, 25);
            this.button1LDM1.TabIndex = 16;
            this.button1LDM1.Text = "LOAD M1";
            this.button1LDM1.UseVisualStyleBackColor = true;
            this.button1LDM1.Click += new System.EventHandler(this.button1LDM1_Click);
            // 
            // textBox1XL
            // 
            this.textBox1XL.Location = new System.Drawing.Point(884, 490);
            this.textBox1XL.Name = "textBox1XL";
            this.textBox1XL.Size = new System.Drawing.Size(81, 20);
            this.textBox1XL.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(841, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "XL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "YL";
            // 
            // textBox1YL
            // 
            this.textBox1YL.Location = new System.Drawing.Point(884, 514);
            this.textBox1YL.Name = "textBox1YL";
            this.textBox1YL.Size = new System.Drawing.Size(80, 20);
            this.textBox1YL.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(824, 548);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "X";
            // 
            // textBox1XD3
            // 
            this.textBox1XD3.Location = new System.Drawing.Point(804, 564);
            this.textBox1XD3.Name = "textBox1XD3";
            this.textBox1XD3.Size = new System.Drawing.Size(79, 20);
            this.textBox1XD3.TabIndex = 22;
            // 
            // textBox1YD3
            // 
            this.textBox1YD3.Location = new System.Drawing.Point(896, 564);
            this.textBox1YD3.Name = "textBox1YD3";
            this.textBox1YD3.Size = new System.Drawing.Size(68, 20);
            this.textBox1YD3.TabIndex = 23;
            // 
            // textBox1ZD3
            // 
            this.textBox1ZD3.Location = new System.Drawing.Point(983, 566);
            this.textBox1ZD3.Name = "textBox1ZD3";
            this.textBox1ZD3.Size = new System.Drawing.Size(70, 20);
            this.textBox1ZD3.TabIndex = 24;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(900, 548);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(14, 13);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(987, 547);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Z";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 612);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.textBox1ZD3);
            this.Controls.Add(this.textBox1YD3);
            this.Controls.Add(this.textBox1XD3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1YL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1XL);
            this.Controls.Add(this.button1LDM1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label2XR);
            this.Controls.Add(this.textBox2Right);
            this.Controls.Add(this.textBox1Right);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1ZNCC);
            this.Controls.Add(this.button1Epipolar);
            this.Controls.Add(this.button1SaveM2);
            this.Controls.Add(this.button1SaveM1);
            this.Controls.Add(this.button1M2);
            this.Controls.Add(this.button1M1);
            this.Controls.Add(this.button1_Close);
            this.Controls.Add(this.pictureBox2Rightimg);
            this.Controls.Add(this.pictureBox1LeftImge);
            this.Name = "Form1";
            this.Text = "3D RECONSTUCTION";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1LeftImge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Rightimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1LeftImge;
        private System.Windows.Forms.PictureBox pictureBox2Rightimg;
        private System.Windows.Forms.Button button1_Close;
        private System.Windows.Forms.Button button1M1;
        private System.Windows.Forms.Button button1M2;
        private System.Windows.Forms.Button button1SaveM1;
        private System.Windows.Forms.Button button1SaveM2;
        private System.Windows.Forms.Button button1Epipolar;
        private System.Windows.Forms.TextBox textBox1ZNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1Right;
        private System.Windows.Forms.TextBox textBox2Right;
        private System.Windows.Forms.Label label2XR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1LDM1;
        private System.Windows.Forms.TextBox textBox1XL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1YL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1XD3;
        private System.Windows.Forms.TextBox textBox1YD3;
        private System.Windows.Forms.TextBox textBox1ZD3;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label label7;
    }
}

