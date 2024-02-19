namespace AgoyFFMpegRecorder
{
    partial class RenameRecFileForm
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
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnSetName = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 12);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(597, 22);
            this.tbFileName.TabIndex = 0;
            // 
            // btnSetName
            // 
            this.btnSetName.Location = new System.Drawing.Point(373, 47);
            this.btnSetName.Name = "btnSetName";
            this.btnSetName.Size = new System.Drawing.Size(75, 23);
            this.btnSetName.TabIndex = 1;
            this.btnSetName.Text = "Set Name";
            this.btnSetName.UseVisualStyleBackColor = true;
            this.btnSetName.Click += new System.EventHandler(this.btnSetName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(534, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RenameRecFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 82);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetName);
            this.Controls.Add(this.tbFileName);
            this.Name = "RenameRecFileForm";
            this.Text = "Rename current or next recording file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnSetName;
        private System.Windows.Forms.Button btnCancel;
    }
}