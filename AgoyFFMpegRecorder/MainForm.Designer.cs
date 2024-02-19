using System.Windows.Forms;

namespace AgoyFFMpegRecorder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public event UpdateDelegate UpdateEventHandler;


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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartRec = new System.Windows.Forms.Button();
            this.btnStopRec = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectedVideoSrc = new System.Windows.Forms.Label();
            this.lblSelectedAudioSrc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIsCombineAudio = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.StatusMenu = new System.Windows.Forms.MenuItem();
            this.OpenMainWindowMenu = new System.Windows.Forms.MenuItem();
            this.startRecordMenu = new System.Windows.Forms.MenuItem();
            this.stopRecordMenu = new System.Windows.Forms.MenuItem();
            this.stopRecAfter = new System.Windows.Forms.MenuItem();
            this.stopAfter1Min = new System.Windows.Forms.MenuItem();
            this.stopAfter1Hour = new System.Windows.Forms.MenuItem();
            this.stopAfter2Hours = new System.Windows.Forms.MenuItem();
            this.updateRecordingNameMenu = new System.Windows.Forms.MenuItem();
            this.openRecDir = new System.Windows.Forms.MenuItem();
            this.exitApp = new System.Windows.Forms.MenuItem();
            this.IconContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startRec = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRec = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRecordingFor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWillStopAfter = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNextFileName = new System.Windows.Forms.TextBox();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.btnOpenRecDir = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.IconContexMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(503, 103);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(33, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Idle";
            // 
            // btnStartRec
            // 
            this.btnStartRec.Location = new System.Drawing.Point(26, 103);
            this.btnStartRec.Name = "btnStartRec";
            this.btnStartRec.Size = new System.Drawing.Size(130, 33);
            this.btnStartRec.TabIndex = 3;
            this.btnStartRec.Text = "Start Recording";
            this.btnStartRec.UseVisualStyleBackColor = true;
            this.btnStartRec.Click += new System.EventHandler(this.btnStartRec_Click);
            // 
            // btnStopRec
            // 
            this.btnStopRec.Location = new System.Drawing.Point(192, 103);
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.Size = new System.Drawing.Size(130, 33);
            this.btnStopRec.TabIndex = 3;
            this.btnStopRec.Text = "Stop Recording";
            this.btnStopRec.UseVisualStyleBackColor = true;
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioSourceToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // audioSourceToolStripMenuItem
            // 
            this.audioSourceToolStripMenuItem.Name = "audioSourceToolStripMenuItem";
            this.audioSourceToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.audioSourceToolStripMenuItem.Text = "Audio Source";
            this.audioSourceToolStripMenuItem.Click += new System.EventHandler(this.audioSourceToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoSourceToolStripMenuItem,
            this.recordingParametersToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // videoSourceToolStripMenuItem
            // 
            this.videoSourceToolStripMenuItem.Name = "videoSourceToolStripMenuItem";
            this.videoSourceToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.videoSourceToolStripMenuItem.Text = "Video Source";
            this.videoSourceToolStripMenuItem.Click += new System.EventHandler(this.videoSourceToolStripMenuItem_Click);
            // 
            // recordingParametersToolStripMenuItem
            // 
            this.recordingParametersToolStripMenuItem.Name = "recordingParametersToolStripMenuItem";
            this.recordingParametersToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.recordingParametersToolStripMenuItem.Text = "Recording Parameters";
            this.recordingParametersToolStripMenuItem.Click += new System.EventHandler(this.recordingParametersToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Video Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected Audio Source:";
            // 
            // lblSelectedVideoSrc
            // 
            this.lblSelectedVideoSrc.AutoSize = true;
            this.lblSelectedVideoSrc.Location = new System.Drawing.Point(214, 196);
            this.lblSelectedVideoSrc.Name = "lblSelectedVideoSrc";
            this.lblSelectedVideoSrc.Size = new System.Drawing.Size(149, 16);
            this.lblSelectedVideoSrc.TabIndex = 5;
            this.lblSelectedVideoSrc.Text = "Selected Video Source:";
            // 
            // lblSelectedAudioSrc
            // 
            this.lblSelectedAudioSrc.AutoSize = true;
            this.lblSelectedAudioSrc.Location = new System.Drawing.Point(215, 228);
            this.lblSelectedAudioSrc.Name = "lblSelectedAudioSrc";
            this.lblSelectedAudioSrc.Size = new System.Drawing.Size(148, 16);
            this.lblSelectedAudioSrc.TabIndex = 5;
            this.lblSelectedAudioSrc.Text = "Selected Audio Source:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Combine audio: ";
            // 
            // lblIsCombineAudio
            // 
            this.lblIsCombineAudio.AutoSize = true;
            this.lblIsCombineAudio.Location = new System.Drawing.Point(145, 257);
            this.lblIsCombineAudio.Name = "lblIsCombineAudio";
            this.lblIsCombineAudio.Size = new System.Drawing.Size(26, 16);
            this.lblIsCombineAudio.TabIndex = 6;
            this.lblIsCombineAudio.Text = "n/a";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Agoy Recorder - Idle";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StatusMenu,
            this.OpenMainWindowMenu,
            this.startRecordMenu,
            this.stopRecordMenu,
            this.stopRecAfter,
            this.updateRecordingNameMenu,
            this.openRecDir,
            this.exitApp});
            // 
            // StatusMenu
            // 
            this.StatusMenu.Index = 0;
            this.StatusMenu.Text = "Status: IDLE";
            // 
            // OpenMainWindowMenu
            // 
            this.OpenMainWindowMenu.Index = 1;
            this.OpenMainWindowMenu.Text = "Open Main Window";
            this.OpenMainWindowMenu.Click += new System.EventHandler(this.openMainWindow_Click);
            // 
            // startRecordMenu
            // 
            this.startRecordMenu.Index = 2;
            this.startRecordMenu.Text = "Start Recording";
            this.startRecordMenu.Click += new System.EventHandler(this.startRec_Click);
            // 
            // stopRecordMenu
            // 
            this.stopRecordMenu.Index = 3;
            this.stopRecordMenu.Text = "Stop Recording";
            this.stopRecordMenu.Click += new System.EventHandler(this.stopRec_Click);
            // 
            // stopRecAfter
            // 
            this.stopRecAfter.Index = 4;
            this.stopRecAfter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.stopAfter1Min,
            this.stopAfter1Hour,
            this.stopAfter2Hours});
            this.stopRecAfter.Text = "Stop Rec after ->";
            // 
            // stopAfter1Min
            // 
            this.stopAfter1Min.Index = 0;
            this.stopAfter1Min.Text = "1 min";
            this.stopAfter1Min.Click += new System.EventHandler(this.stopAfter_1min_Click);
            // 
            // stopAfter1Hour
            // 
            this.stopAfter1Hour.Index = 1;
            this.stopAfter1Hour.Text = "1 Hour";
            this.stopAfter1Hour.Click += new System.EventHandler(this.stopAfter_1hour_Click);
            // 
            // stopAfter2Hours
            // 
            this.stopAfter2Hours.Index = 2;
            this.stopAfter2Hours.Text = "2 Hours";
            this.stopAfter2Hours.Click += new System.EventHandler(this.stopAfter_2hours_Click);
            // 
            // updateRecordingNameMenu
            // 
            this.updateRecordingNameMenu.Index = 5;
            this.updateRecordingNameMenu.Text = "Rename cur/next recording";
            this.updateRecordingNameMenu.Click += new System.EventHandler(this.renameCurOrNextRecording);
            // 
            // openRecDir
            // 
            this.openRecDir.Index = 6;
            this.openRecDir.Text = "Open Recording Folder";
            this.openRecDir.Click += new System.EventHandler(this.btnOpenRecDir_Click);
            // 
            // exitApp
            // 
            this.exitApp.Index = 7;
            this.exitApp.Text = "Exit Agoy Recorder";
            this.exitApp.Click += new System.EventHandler(this.exitApp_Click);
            // 
            // IconContexMenu
            // 
            this.IconContexMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.IconContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRec,
            this.stopRec});
            this.IconContexMenu.Name = "IconContexMenu";
            this.IconContexMenu.Size = new System.Drawing.Size(182, 52);
            this.IconContexMenu.Opening += new System.ComponentModel.CancelEventHandler(this.IconContexMenu_Opening);
            // 
            // startRec
            // 
            this.startRec.Name = "startRec";
            this.startRec.Size = new System.Drawing.Size(181, 24);
            this.startRec.Text = "Start Recording";
            // 
            // stopRec
            // 
            this.stopRec.Name = "stopRec";
            this.stopRec.Size = new System.Drawing.Size(181, 24);
            this.stopRec.Text = "Stop Recording";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Recording for:";
            // 
            // lblRecordingFor
            // 
            this.lblRecordingFor.AutoSize = true;
            this.lblRecordingFor.Location = new System.Drawing.Point(540, 128);
            this.lblRecordingFor.Name = "lblRecordingFor";
            this.lblRecordingFor.Size = new System.Drawing.Size(26, 16);
            this.lblRecordingFor.TabIndex = 2;
            this.lblRecordingFor.Text = "n/a";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Will stop after:";
            // 
            // lblWillStopAfter
            // 
            this.lblWillStopAfter.AutoSize = true;
            this.lblWillStopAfter.Location = new System.Drawing.Point(540, 152);
            this.lblWillStopAfter.Name = "lblWillStopAfter";
            this.lblWillStopAfter.Size = new System.Drawing.Size(26, 16);
            this.lblWillStopAfter.TabIndex = 2;
            this.lblWillStopAfter.Text = "n/a";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Current/next file name:";
            // 
            // tbNextFileName
            // 
            this.tbNextFileName.Enabled = false;
            this.tbNextFileName.Location = new System.Drawing.Point(169, 295);
            this.tbNextFileName.Name = "tbNextFileName";
            this.tbNextFileName.Size = new System.Drawing.Size(323, 22);
            this.tbNextFileName.TabIndex = 7;
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(515, 294);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(75, 23);
            this.btnChangeName.TabIndex = 8;
            this.btnChangeName.Text = "Set Name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // btnOpenRecDir
            // 
            this.btnOpenRecDir.Location = new System.Drawing.Point(26, 338);
            this.btnOpenRecDir.Name = "btnOpenRecDir";
            this.btnOpenRecDir.Size = new System.Drawing.Size(160, 23);
            this.btnOpenRecDir.TabIndex = 9;
            this.btnOpenRecDir.Text = "Open Recording Dir";
            this.btnOpenRecDir.UseVisualStyleBackColor = true;
            this.btnOpenRecDir.Click += new System.EventHandler(this.btnOpenRecDir_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 560);
            this.Controls.Add(this.btnOpenRecDir);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.tbNextFileName);
            this.Controls.Add(this.lblIsCombineAudio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSelectedAudioSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSelectedVideoSrc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStopRec);
            this.Controls.Add(this.btnStartRec);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWillStopAfter);
            this.Controls.Add(this.lblRecordingFor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Agoy Recorder v0.21";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.IconContexMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartRec;
        private System.Windows.Forms.Button btnStopRec;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordingParametersToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectedVideoSrc;
        private System.Windows.Forms.Label lblSelectedAudioSrc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIsCombineAudio;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip IconContexMenu;
        private System.Windows.Forms.ToolStripMenuItem startRec;
        private System.Windows.Forms.ToolStripMenuItem stopRec;

        // mine
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem StatusMenu;
        private System.Windows.Forms.MenuItem OpenMainWindowMenu;
        private System.Windows.Forms.MenuItem startRecordMenu;
        private System.Windows.Forms.MenuItem stopRecordMenu;
        private System.Windows.Forms.MenuItem stopRecAfter;
        private System.Windows.Forms.MenuItem stopAfter1Min;
        private System.Windows.Forms.MenuItem stopAfter1Hour;
        private System.Windows.Forms.MenuItem stopAfter2Hours;
        private System.Windows.Forms.MenuItem updateRecordingNameMenu;
        private System.Windows.Forms.MenuItem openRecDir;



        private System.Windows.Forms.MenuItem exitApp;
        private Label label5;
        private Label lblRecordingFor;
        private Label label6;
        private Label lblWillStopAfter;
        private Label label7;
        private TextBox tbNextFileName;
        private Button btnChangeName;
        private Button btnOpenRecDir;
    }
}

