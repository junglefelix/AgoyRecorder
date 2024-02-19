namespace AgoyRecrder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStartRec = new System.Windows.Forms.Button();
            this.btnStopRec = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAudio = new System.Windows.Forms.ComboBox();
            this.btnStartRecFiles = new System.Windows.Forms.Button();
            this.btnStopRecFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox1.Location = new System.Drawing.Point(12, 161);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(700, 443);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Camera:";
            // 
            // comboCamera
            // 
            this.comboCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Location = new System.Drawing.Point(12, 30);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(363, 24);
            this.comboCamera.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(727, 161);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Show";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(825, 161);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Close";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(938, 572);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStartRec
            // 
            this.btnStartRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartRec.Location = new System.Drawing.Point(12, 72);
            this.btnStartRec.Name = "btnStartRec";
            this.btnStartRec.Size = new System.Drawing.Size(75, 23);
            this.btnStartRec.TabIndex = 6;
            this.btnStartRec.Text = "Start Rec";
            this.btnStartRec.UseVisualStyleBackColor = true;
            this.btnStartRec.Click += new System.EventHandler(this.btnStartRec_Click);
            // 
            // btnStopRec
            // 
            this.btnStopRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopRec.Location = new System.Drawing.Point(124, 72);
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.Size = new System.Drawing.Size(75, 23);
            this.btnStopRec.TabIndex = 7;
            this.btnStopRec.Text = "Stop Rec";
            this.btnStopRec.UseVisualStyleBackColor = true;
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Audio:";
            // 
            // comboAudio
            // 
            this.comboAudio.FormattingEnabled = true;
            this.comboAudio.Location = new System.Drawing.Point(432, 31);
            this.comboAudio.Name = "comboAudio";
            this.comboAudio.Size = new System.Drawing.Size(370, 24);
            this.comboAudio.TabIndex = 8;
            // 
            // btnStartRecFiles
            // 
            this.btnStartRecFiles.Location = new System.Drawing.Point(12, 116);
            this.btnStartRecFiles.Name = "btnStartRecFiles";
            this.btnStartRecFiles.Size = new System.Drawing.Size(160, 25);
            this.btnStartRecFiles.TabIndex = 9;
            this.btnStartRecFiles.Text = "Start Recording Files";
            this.btnStartRecFiles.UseVisualStyleBackColor = true;
            this.btnStartRecFiles.Click += new System.EventHandler(this.btnStartRecFiles_Click);
            // 
            // btnStopRecFiles
            // 
            this.btnStopRecFiles.Location = new System.Drawing.Point(196, 118);
            this.btnStopRecFiles.Name = "btnStopRecFiles";
            this.btnStopRecFiles.Size = new System.Drawing.Size(130, 23);
            this.btnStopRecFiles.TabIndex = 10;
            this.btnStopRecFiles.Text = "Stop Rec Files";
            this.btnStopRecFiles.UseVisualStyleBackColor = true;
            this.btnStopRecFiles.Click += new System.EventHandler(this.btnStopRecFiles_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 616);
            this.Controls.Add(this.btnStopRecFiles);
            this.Controls.Add(this.btnStartRecFiles);
            this.Controls.Add(this.comboAudio);
            this.Controls.Add(this.btnStopRec);
            this.Controls.Add(this.btnStartRec);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.comboCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Agoy Recorder v 0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStartRec;
        private System.Windows.Forms.Button btnStopRec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAudio;
        private System.Windows.Forms.Button btnStartRecFiles;
        private System.Windows.Forms.Button btnStopRecFiles;
    }
}

