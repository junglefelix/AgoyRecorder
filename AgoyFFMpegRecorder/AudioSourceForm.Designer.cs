namespace AgoyFFMpegRecorder
{
    partial class AudioSourceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAvailableAudioSources = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPreferredAudioSources = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAudioSourceOk = new System.Windows.Forms.Button();
            this.btnAudioSourceDiscard = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPreferredManualSource = new System.Windows.Forms.TextBox();
            this.btnAudioSrsAddManual = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.checkBoxMuxAudio = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblComputerAudioStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Audio sources: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxAvailableAudioSources
            // 
            this.listBoxAvailableAudioSources.FormattingEnabled = true;
            this.listBoxAvailableAudioSources.ItemHeight = 16;
            this.listBoxAvailableAudioSources.Location = new System.Drawing.Point(13, 64);
            this.listBoxAvailableAudioSources.Name = "listBoxAvailableAudioSources";
            this.listBoxAvailableAudioSources.Size = new System.Drawing.Size(305, 116);
            this.listBoxAvailableAudioSources.TabIndex = 2;
            this.listBoxAvailableAudioSources.SelectedIndexChanged += new System.EventHandler(this.listBoxAvailableAudioSources_SelectedIndexChanged);
            this.listBoxAvailableAudioSources.DoubleClick += new System.EventHandler(this.listBoxAvailableAudioSources_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "(Double-click to add to preferred sources)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBoxPreferredAudioSources
            // 
            this.listBoxPreferredAudioSources.FormattingEnabled = true;
            this.listBoxPreferredAudioSources.ItemHeight = 16;
            this.listBoxPreferredAudioSources.Location = new System.Drawing.Point(378, 63);
            this.listBoxPreferredAudioSources.Name = "listBoxPreferredAudioSources";
            this.listBoxPreferredAudioSources.Size = new System.Drawing.Size(305, 116);
            this.listBoxPreferredAudioSources.TabIndex = 3;
            this.listBoxPreferredAudioSources.SelectedIndexChanged += new System.EventHandler(this.listBoxPreferredAudioSources_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Preferred Audio sources: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnAudioSourceOk
            // 
            this.btnAudioSourceOk.Location = new System.Drawing.Point(572, 294);
            this.btnAudioSourceOk.Name = "btnAudioSourceOk";
            this.btnAudioSourceOk.Size = new System.Drawing.Size(111, 29);
            this.btnAudioSourceOk.TabIndex = 4;
            this.btnAudioSourceOk.Text = "OK";
            this.btnAudioSourceOk.UseVisualStyleBackColor = true;
            this.btnAudioSourceOk.Click += new System.EventHandler(this.btnAudioSourceOk_Click);
            // 
            // btnAudioSourceDiscard
            // 
            this.btnAudioSourceDiscard.Location = new System.Drawing.Point(416, 294);
            this.btnAudioSourceDiscard.Name = "btnAudioSourceDiscard";
            this.btnAudioSourceDiscard.Size = new System.Drawing.Size(111, 29);
            this.btnAudioSourceDiscard.TabIndex = 4;
            this.btnAudioSourceDiscard.Text = "Discard";
            this.btnAudioSourceDiscard.UseVisualStyleBackColor = true;
            this.btnAudioSourceDiscard.Click += new System.EventHandler(this.btnAudioSourceDiscard_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Add Preferred audio source manually:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbPreferredManualSource
            // 
            this.tbPreferredManualSource.Location = new System.Drawing.Point(12, 211);
            this.tbPreferredManualSource.Name = "tbPreferredManualSource";
            this.tbPreferredManualSource.Size = new System.Drawing.Size(306, 22);
            this.tbPreferredManualSource.TabIndex = 6;
            this.tbPreferredManualSource.TextChanged += new System.EventHandler(this.tbPreferredManualSource_TextChanged);
            // 
            // btnAudioSrsAddManual
            // 
            this.btnAudioSrsAddManual.Location = new System.Drawing.Point(12, 239);
            this.btnAudioSrsAddManual.Name = "btnAudioSrsAddManual";
            this.btnAudioSrsAddManual.Size = new System.Drawing.Size(91, 29);
            this.btnAudioSrsAddManual.TabIndex = 7;
            this.btnAudioSrsAddManual.Text = "Add";
            this.btnAudioSrsAddManual.UseVisualStyleBackColor = true;
            this.btnAudioSrsAddManual.Click += new System.EventHandler(this.btnAudioSrsAddManual_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "(First available source will be used)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(378, 188);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 29);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnAudioSrsAddManual_Click);
            this.btnClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseClick);
            // 
            // checkBoxMuxAudio
            // 
            this.checkBoxMuxAudio.AutoSize = true;
            this.checkBoxMuxAudio.Location = new System.Drawing.Point(8, 284);
            this.checkBoxMuxAudio.Name = "checkBoxMuxAudio";
            this.checkBoxMuxAudio.Size = new System.Drawing.Size(341, 20);
            this.checkBoxMuxAudio.TabIndex = 8;
            this.checkBoxMuxAudio.Text = "Combine Mic audio with computer audio (if available)";
            this.checkBoxMuxAudio.UseVisualStyleBackColor = true;
            this.checkBoxMuxAudio.CheckedChanged += new System.EventHandler(this.checkBoxMuxAudio_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Computer audio status: ";
            // 
            // lblComputerAudioStatus
            // 
            this.lblComputerAudioStatus.AutoSize = true;
            this.lblComputerAudioStatus.Location = new System.Drawing.Point(172, 313);
            this.lblComputerAudioStatus.Name = "lblComputerAudioStatus";
            this.lblComputerAudioStatus.Size = new System.Drawing.Size(44, 16);
            this.lblComputerAudioStatus.TabIndex = 9;
            this.lblComputerAudioStatus.Text = "Status";
            // 
            // AudioSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 346);
            this.Controls.Add(this.lblComputerAudioStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBoxMuxAudio);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAudioSrsAddManual);
            this.Controls.Add(this.tbPreferredManualSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAudioSourceDiscard);
            this.Controls.Add(this.btnAudioSourceOk);
            this.Controls.Add(this.listBoxPreferredAudioSources);
            this.Controls.Add(this.listBoxAvailableAudioSources);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AudioSourceForm";
            this.Text = "AudioSourceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAvailableAudioSources;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPreferredAudioSources;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAudioSourceOk;
        private System.Windows.Forms.Button btnAudioSourceDiscard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPreferredManualSource;
        private System.Windows.Forms.Button btnAudioSrsAddManual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox checkBoxMuxAudio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblComputerAudioStatus;
    }
}