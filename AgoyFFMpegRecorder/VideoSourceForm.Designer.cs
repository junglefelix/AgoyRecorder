namespace AgoyFFMpegRecorder
{
    partial class VideoSourceForm
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
            this.btnAudioSourceDiscard = new System.Windows.Forms.Button();
            this.btnAudioSourceOk = new System.Windows.Forms.Button();
            this.listBoxAvailableVideoSources = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSelectedVideoSource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAudioSourceDiscard
            // 
            this.btnAudioSourceDiscard.Location = new System.Drawing.Point(415, 250);
            this.btnAudioSourceDiscard.Name = "btnAudioSourceDiscard";
            this.btnAudioSourceDiscard.Size = new System.Drawing.Size(111, 29);
            this.btnAudioSourceDiscard.TabIndex = 14;
            this.btnAudioSourceDiscard.Text = "Discard";
            this.btnAudioSourceDiscard.UseVisualStyleBackColor = true;
            this.btnAudioSourceDiscard.Click += new System.EventHandler(this.btnAudioSourceDiscard_Click);
            // 
            // btnAudioSourceOk
            // 
            this.btnAudioSourceOk.Location = new System.Drawing.Point(571, 250);
            this.btnAudioSourceOk.Name = "btnAudioSourceOk";
            this.btnAudioSourceOk.Size = new System.Drawing.Size(111, 29);
            this.btnAudioSourceOk.TabIndex = 15;
            this.btnAudioSourceOk.Text = "OK";
            this.btnAudioSourceOk.UseVisualStyleBackColor = true;
            this.btnAudioSourceOk.Click += new System.EventHandler(this.btnAudioSourceOk_Click);
            // 
            // listBoxAvailableVideoSources
            // 
            this.listBoxAvailableVideoSources.FormattingEnabled = true;
            this.listBoxAvailableVideoSources.ItemHeight = 16;
            this.listBoxAvailableVideoSources.Location = new System.Drawing.Point(12, 74);
            this.listBoxAvailableVideoSources.Name = "listBoxAvailableVideoSources";
            this.listBoxAvailableVideoSources.Size = new System.Drawing.Size(305, 116);
            this.listBoxAvailableVideoSources.TabIndex = 12;
            this.listBoxAvailableVideoSources.SelectedIndexChanged += new System.EventHandler(this.listBoxAvailableVideoSources_SelectedIndexChanged);
            this.listBoxAvailableVideoSources.DoubleClick += new System.EventHandler(this.listBoxAvailableVideoSources_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "(Double-click to add to preferred sources)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selected Video source to record: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Available Video sources: ";
            // 
            // tbSelectedVideoSource
            // 
            this.tbSelectedVideoSource.Location = new System.Drawing.Point(384, 44);
            this.tbSelectedVideoSource.Name = "tbSelectedVideoSource";
            this.tbSelectedVideoSource.Size = new System.Drawing.Size(275, 22);
            this.tbSelectedVideoSource.TabIndex = 20;
            // 
            // VideoSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 291);
            this.Controls.Add(this.tbSelectedVideoSource);
            this.Controls.Add(this.btnAudioSourceDiscard);
            this.Controls.Add(this.btnAudioSourceOk);
            this.Controls.Add(this.listBoxAvailableVideoSources);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "VideoSourceForm";
            this.Text = "VideoSourceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAudioSourceDiscard;
        private System.Windows.Forms.Button btnAudioSourceOk;
        private System.Windows.Forms.ListBox listBoxAvailableVideoSources;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSelectedVideoSource;
    }
}