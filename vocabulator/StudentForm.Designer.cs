namespace Vocabulator
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.QuestionTextbox = new System.Windows.Forms.RichTextBox();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerTextBox = new System.Windows.Forms.RichTextBox();
            this.CorrectAnswerLabel = new System.Windows.Forms.Label();
            this.CorrectAnswerTextBox = new System.Windows.Forms.RichTextBox();
            this.SwitchQAChkBox = new System.Windows.Forms.CheckBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.PictureLabel = new System.Windows.Forms.Label();
            this.CheckAnswerButton = new System.Windows.Forms.Button();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.QuestionCounterLabel = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BackBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RightAnswerLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // QuestionTextbox
            // 
            this.QuestionTextbox.BackColor = System.Drawing.Color.White;
            this.QuestionTextbox.Location = new System.Drawing.Point(19, 163);
            this.QuestionTextbox.Name = "QuestionTextbox";
            this.QuestionTextbox.ReadOnly = true;
            this.QuestionTextbox.Size = new System.Drawing.Size(135, 72);
            this.QuestionTextbox.TabIndex = 1;
            this.QuestionTextbox.Text = "";
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Location = new System.Drawing.Point(157, 147);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(42, 13);
            this.AnswerLabel.TabIndex = 2;
            this.AnswerLabel.Text = "Answer";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(16, 147);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(49, 13);
            this.QuestionLabel.TabIndex = 3;
            this.QuestionLabel.Text = "Question";
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Location = new System.Drawing.Point(160, 163);
            this.AnswerTextBox.Multiline = false;
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.Size = new System.Drawing.Size(135, 72);
            this.AnswerTextBox.TabIndex = 4;
            this.AnswerTextBox.Text = "";
            this.AnswerTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnswerTextBox_MouseUp);
            // 
            // CorrectAnswerLabel
            // 
            this.CorrectAnswerLabel.AutoSize = true;
            this.CorrectAnswerLabel.Location = new System.Drawing.Point(298, 147);
            this.CorrectAnswerLabel.Name = "CorrectAnswerLabel";
            this.CorrectAnswerLabel.Size = new System.Drawing.Size(79, 13);
            this.CorrectAnswerLabel.TabIndex = 5;
            this.CorrectAnswerLabel.Text = "Correct Answer";
            // 
            // CorrectAnswerTextBox
            // 
            this.CorrectAnswerTextBox.BackColor = System.Drawing.Color.White;
            this.CorrectAnswerTextBox.Location = new System.Drawing.Point(301, 164);
            this.CorrectAnswerTextBox.Name = "CorrectAnswerTextBox";
            this.CorrectAnswerTextBox.ReadOnly = true;
            this.CorrectAnswerTextBox.Size = new System.Drawing.Size(135, 71);
            this.CorrectAnswerTextBox.TabIndex = 6;
            this.CorrectAnswerTextBox.Text = "";
            // 
            // SwitchQAChkBox
            // 
            this.SwitchQAChkBox.AutoSize = true;
            this.SwitchQAChkBox.Enabled = false;
            this.SwitchQAChkBox.Location = new System.Drawing.Point(20, 244);
            this.SwitchQAChkBox.Name = "SwitchQAChkBox";
            this.SwitchQAChkBox.Size = new System.Drawing.Size(88, 17);
            this.SwitchQAChkBox.TabIndex = 7;
            this.SwitchQAChkBox.Text = "Switch Q + A";
            this.SwitchQAChkBox.UseVisualStyleBackColor = true;
            this.SwitchQAChkBox.CheckedChanged += new System.EventHandler(this.SwitchQAChkBox_CheckedChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // PictureLabel
            // 
            this.PictureLabel.AutoSize = true;
            this.PictureLabel.Location = new System.Drawing.Point(16, 12);
            this.PictureLabel.Name = "PictureLabel";
            this.PictureLabel.Size = new System.Drawing.Size(40, 13);
            this.PictureLabel.TabIndex = 29;
            this.PictureLabel.Text = "Picture";
            // 
            // CheckAnswerButton
            // 
            this.CheckAnswerButton.Location = new System.Drawing.Point(301, 243);
            this.CheckAnswerButton.Name = "CheckAnswerButton";
            this.CheckAnswerButton.Size = new System.Drawing.Size(138, 23);
            this.CheckAnswerButton.TabIndex = 31;
            this.CheckAnswerButton.Text = "CheckAnswer";
            this.CheckAnswerButton.UseVisualStyleBackColor = true;
            this.CheckAnswerButton.Click += new System.EventHandler(this.CheckAnswerButton_Click);
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(299, 12);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(48, 13);
            this.LevelLabel.TabIndex = 32;
            this.LevelLabel.Text = "Level:  0";
            // 
            // QuestionCounterLabel
            // 
            this.QuestionCounterLabel.AutoSize = true;
            this.QuestionCounterLabel.Location = new System.Drawing.Point(299, 32);
            this.QuestionCounterLabel.Name = "QuestionCounterLabel";
            this.QuestionCounterLabel.Size = new System.Drawing.Size(64, 13);
            this.QuestionCounterLabel.TabIndex = 33;
            this.QuestionCounterLabel.Text = "Question:  1";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(302, 75);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(134, 63);
            this.axWindowsMediaPlayer1.TabIndex = 34;
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(231, 243);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(64, 23);
            this.BackBtn.TabIndex = 35;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 272);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // RightAnswerLabel
            // 
            this.RightAnswerLabel.AutoSize = true;
            this.RightAnswerLabel.Location = new System.Drawing.Point(298, 53);
            this.RightAnswerLabel.Name = "RightAnswerLabel";
            this.RightAnswerLabel.Size = new System.Drawing.Size(96, 13);
            this.RightAnswerLabel.TabIndex = 37;
            this.RightAnswerLabel.Text = "Correct Answers: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(19, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // StudentForm
            // 
            this.AcceptButton = this.CheckAnswerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 294);
            this.Controls.Add(this.RightAnswerLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.QuestionCounterLabel);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.CheckAnswerButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PictureLabel);
            this.Controls.Add(this.SwitchQAChkBox);
            this.Controls.Add(this.CorrectAnswerTextBox);
            this.Controls.Add(this.CorrectAnswerLabel);
            this.Controls.Add(this.AnswerTextBox);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.QuestionTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentForm_FormClosed);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox QuestionTextbox;
        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.RichTextBox AnswerTextBox;
        private System.Windows.Forms.Label CorrectAnswerLabel;
        private System.Windows.Forms.RichTextBox CorrectAnswerTextBox;
        private System.Windows.Forms.CheckBox SwitchQAChkBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button CheckAnswerButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label PictureLabel;
        private System.Windows.Forms.Label QuestionCounterLabel;
        private System.Windows.Forms.Label LevelLabel;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label RightAnswerLabel;
    }
}