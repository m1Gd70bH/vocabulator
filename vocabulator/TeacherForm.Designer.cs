using System.Windows.Forms;

namespace Vocabulator
{
    partial class TeacherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherForm));
            this.UnitSelectBox = new System.Windows.Forms.ComboBox();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.QuestionTextBox = new System.Windows.Forms.RichTextBox();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerTextBox = new System.Windows.Forms.RichTextBox();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.NextSaveButton = new System.Windows.Forms.Button();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.GroupSelectBox = new System.Windows.Forms.ComboBox();
            this.VocabComBoxLabel = new System.Windows.Forms.Label();
            this.VocabSelectBox = new System.Windows.Forms.ComboBox();
            this.PictureLabel = new System.Windows.Forms.Label();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.AddChangePictureBtn = new System.Windows.Forms.Button();
            this.SoundLabel = new System.Windows.Forms.Label();
            this.AddChangeSoundBtn = new System.Windows.Forms.Button();
            this.StudentResultsButton = new System.Windows.Forms.Button();
            this.ImportDataBtn = new System.Windows.Forms.Button();
            this.CreateTestBtn = new System.Windows.Forms.Button();
            this.WMPbox = new AxWMPLib.AxWindowsMediaPlayer();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeletePictureBtn = new System.Windows.Forms.Button();
            this.DeleteSoundBtn = new System.Windows.Forms.Button();
            this.DeleteVocabBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMPbox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnitSelectBox
            // 
            this.UnitSelectBox.FormattingEnabled = true;
            this.UnitSelectBox.Location = new System.Drawing.Point(325, 40);
            this.UnitSelectBox.Name = "UnitSelectBox";
            this.UnitSelectBox.Size = new System.Drawing.Size(230, 21);
            this.UnitSelectBox.TabIndex = 2;
            this.UnitSelectBox.SelectedIndexChanged += new System.EventHandler(this.UnitComBox_SelectedIndexChanged);
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(322, 24);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(26, 13);
            this.UnitLabel.TabIndex = 3;
            this.UnitLabel.Text = "Unit";
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.Location = new System.Drawing.Point(15, 40);
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.Size = new System.Drawing.Size(150, 100);
            this.QuestionTextBox.TabIndex = 4;
            this.QuestionTextBox.Text = "";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(12, 24);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(49, 13);
            this.QuestionLabel.TabIndex = 5;
            this.QuestionLabel.Text = "Question";
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Location = new System.Drawing.Point(171, 40);
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.Size = new System.Drawing.Size(150, 100);
            this.AnswerTextBox.TabIndex = 6;
            this.AnswerTextBox.Text = "";
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Location = new System.Drawing.Point(168, 24);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(42, 13);
            this.AnswerLabel.TabIndex = 7;
            this.AnswerLabel.Text = "Answer";
            // 
            // NextSaveButton
            // 
            this.NextSaveButton.Location = new System.Drawing.Point(483, 265);
            this.NextSaveButton.Name = "NextSaveButton";
            this.NextSaveButton.Size = new System.Drawing.Size(72, 23);
            this.NextSaveButton.TabIndex = 8;
            this.NextSaveButton.Text = "Next";
            this.NextSaveButton.UseVisualStyleBackColor = true;
            this.NextSaveButton.Click += new System.EventHandler(this.NextSaveButton_Click);
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(322, 61);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(36, 13);
            this.GroupLabel.TabIndex = 10;
            this.GroupLabel.Text = "Group";
            // 
            // GroupSelectBox
            // 
            this.GroupSelectBox.FormattingEnabled = true;
            this.GroupSelectBox.Location = new System.Drawing.Point(325, 74);
            this.GroupSelectBox.Name = "GroupSelectBox";
            this.GroupSelectBox.Size = new System.Drawing.Size(230, 21);
            this.GroupSelectBox.TabIndex = 9;
            this.GroupSelectBox.SelectedIndexChanged += new System.EventHandler(this.GroupSelectBox_SelectedIndexChanged);
            // 
            // VocabComBoxLabel
            // 
            this.VocabComBoxLabel.AutoSize = true;
            this.VocabComBoxLabel.Location = new System.Drawing.Point(322, 103);
            this.VocabComBoxLabel.Name = "VocabComBoxLabel";
            this.VocabComBoxLabel.Size = new System.Drawing.Size(86, 13);
            this.VocabComBoxLabel.TabIndex = 12;
            this.VocabComBoxLabel.Text = "Vocab (A and Q)";
            // 
            // VocabSelectBox
            // 
            this.VocabSelectBox.FormattingEnabled = true;
            this.VocabSelectBox.Location = new System.Drawing.Point(325, 119);
            this.VocabSelectBox.Name = "VocabSelectBox";
            this.VocabSelectBox.Size = new System.Drawing.Size(230, 21);
            this.VocabSelectBox.TabIndex = 11;
            this.VocabSelectBox.SelectedIndexChanged += new System.EventHandler(this.VocabSelectBox_SelectedIndexChanged);
            // 
            // PictureLabel
            // 
            this.PictureLabel.AutoSize = true;
            this.PictureLabel.Location = new System.Drawing.Point(12, 143);
            this.PictureLabel.Name = "PictureLabel";
            this.PictureLabel.Size = new System.Drawing.Size(40, 13);
            this.PictureLabel.TabIndex = 14;
            this.PictureLabel.Text = "Picture";
            // 
            // PicBox
            // 
            this.PicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBox.Location = new System.Drawing.Point(15, 159);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(150, 100);
            this.PicBox.TabIndex = 15;
            this.PicBox.TabStop = false;
            // 
            // AddChangePictureBtn
            // 
            this.AddChangePictureBtn.Location = new System.Drawing.Point(15, 265);
            this.AddChangePictureBtn.Name = "AddChangePictureBtn";
            this.AddChangePictureBtn.Size = new System.Drawing.Size(72, 23);
            this.AddChangePictureBtn.TabIndex = 16;
            this.AddChangePictureBtn.Text = "Add";
            this.AddChangePictureBtn.UseVisualStyleBackColor = true;
            this.AddChangePictureBtn.Click += new System.EventHandler(this.AddChangePictureBtn_Click);
            // 
            // SoundLabel
            // 
            this.SoundLabel.AutoSize = true;
            this.SoundLabel.Location = new System.Drawing.Point(168, 143);
            this.SoundLabel.Name = "SoundLabel";
            this.SoundLabel.Size = new System.Drawing.Size(38, 13);
            this.SoundLabel.TabIndex = 17;
            this.SoundLabel.Text = "Sound";
            // 
            // AddChangeSoundBtn
            // 
            this.AddChangeSoundBtn.Location = new System.Drawing.Point(171, 265);
            this.AddChangeSoundBtn.Name = "AddChangeSoundBtn";
            this.AddChangeSoundBtn.Size = new System.Drawing.Size(72, 23);
            this.AddChangeSoundBtn.TabIndex = 18;
            this.AddChangeSoundBtn.Text = "Add";
            this.AddChangeSoundBtn.UseVisualStyleBackColor = true;
            this.AddChangeSoundBtn.Click += new System.EventHandler(this.AddChangeSoundBtn_Click);
            // 
            // StudentResultsButton
            // 
            this.StudentResultsButton.Location = new System.Drawing.Point(327, 159);
            this.StudentResultsButton.Name = "StudentResultsButton";
            this.StudentResultsButton.Size = new System.Drawing.Size(111, 23);
            this.StudentResultsButton.TabIndex = 23;
            this.StudentResultsButton.Text = "Student Results";
            this.StudentResultsButton.UseVisualStyleBackColor = true;
            this.StudentResultsButton.Click += new System.EventHandler(this.StudnetResultsBtn_Click);
            // 
            // ImportDataBtn
            // 
            this.ImportDataBtn.Enabled = false;
            this.ImportDataBtn.Location = new System.Drawing.Point(445, 159);
            this.ImportDataBtn.Name = "ImportDataBtn";
            this.ImportDataBtn.Size = new System.Drawing.Size(110, 23);
            this.ImportDataBtn.TabIndex = 24;
            this.ImportDataBtn.Text = "Import Data";
            this.ImportDataBtn.UseVisualStyleBackColor = true;
            this.ImportDataBtn.Click += new System.EventHandler(this.ImportDataBtn_Click);
            // 
            // CreateTestBtn
            // 
            this.CreateTestBtn.Enabled = false;
            this.CreateTestBtn.Location = new System.Drawing.Point(327, 188);
            this.CreateTestBtn.Name = "CreateTestBtn";
            this.CreateTestBtn.Size = new System.Drawing.Size(111, 23);
            this.CreateTestBtn.TabIndex = 25;
            this.CreateTestBtn.Text = "Create Test";
            this.CreateTestBtn.UseVisualStyleBackColor = true;
            // 
            // WMPbox
            // 
            this.WMPbox.Enabled = true;
            this.WMPbox.Location = new System.Drawing.Point(171, 159);
            this.WMPbox.Name = "WMPbox";
            this.WMPbox.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMPbox.OcxState")));
            this.WMPbox.Size = new System.Drawing.Size(150, 100);
            this.WMPbox.TabIndex = 26;
            // 
            // PrevBtn
            // 
            this.PrevBtn.Location = new System.Drawing.Point(327, 265);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(72, 23);
            this.PrevBtn.TabIndex = 27;
            this.PrevBtn.Text = "Previous";
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Enabled = false;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(567, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 297);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(567, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 28;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // DeletePictureBtn
            // 
            this.DeletePictureBtn.Location = new System.Drawing.Point(93, 265);
            this.DeletePictureBtn.Name = "DeletePictureBtn";
            this.DeletePictureBtn.Size = new System.Drawing.Size(72, 23);
            this.DeletePictureBtn.TabIndex = 29;
            this.DeletePictureBtn.Text = "Delete";
            this.DeletePictureBtn.UseVisualStyleBackColor = true;
            this.DeletePictureBtn.Click += new System.EventHandler(this.DeletePictureBtn_Click);
            // 
            // DeleteSoundBtn
            // 
            this.DeleteSoundBtn.Location = new System.Drawing.Point(249, 265);
            this.DeleteSoundBtn.Name = "DeleteSoundBtn";
            this.DeleteSoundBtn.Size = new System.Drawing.Size(72, 23);
            this.DeleteSoundBtn.TabIndex = 30;
            this.DeleteSoundBtn.Text = "Delete";
            this.DeleteSoundBtn.UseVisualStyleBackColor = true;
            this.DeleteSoundBtn.Click += new System.EventHandler(this.DeleteSoundBtn_Click);
            // 
            // DeleteVocabBtn
            // 
            this.DeleteVocabBtn.Location = new System.Drawing.Point(405, 265);
            this.DeleteVocabBtn.Name = "DeleteVocabBtn";
            this.DeleteVocabBtn.Size = new System.Drawing.Size(72, 23);
            this.DeleteVocabBtn.TabIndex = 31;
            this.DeleteVocabBtn.Text = "Delete";
            this.DeleteVocabBtn.UseVisualStyleBackColor = true;
            this.DeleteVocabBtn.Click += new System.EventHandler(this.DeleteVocabBtn_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 319);
            this.Controls.Add(this.DeleteVocabBtn);
            this.Controls.Add(this.DeleteSoundBtn);
            this.Controls.Add(this.DeletePictureBtn);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.PrevBtn);
            this.Controls.Add(this.WMPbox);
            this.Controls.Add(this.CreateTestBtn);
            this.Controls.Add(this.ImportDataBtn);
            this.Controls.Add(this.StudentResultsButton);
            this.Controls.Add(this.AddChangeSoundBtn);
            this.Controls.Add(this.SoundLabel);
            this.Controls.Add(this.AddChangePictureBtn);
            this.Controls.Add(this.PicBox);
            this.Controls.Add(this.PictureLabel);
            this.Controls.Add(this.VocabComBoxLabel);
            this.Controls.Add(this.VocabSelectBox);
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.GroupSelectBox);
            this.Controls.Add(this.NextSaveButton);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.AnswerTextBox);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.QuestionTextBox);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.UnitSelectBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeacherForm_FormClosed);
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMPbox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox UnitSelectBox;
        private System.Windows.Forms.Label UnitLabel;
        private System.Windows.Forms.RichTextBox QuestionTextBox;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.RichTextBox AnswerTextBox;
        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.Button NextSaveButton;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.ComboBox GroupSelectBox;
        private System.Windows.Forms.Label VocabComBoxLabel;
        private System.Windows.Forms.ComboBox VocabSelectBox;
        private System.Windows.Forms.Label PictureLabel;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Button AddChangePictureBtn;
        private System.Windows.Forms.Label SoundLabel;
        private System.Windows.Forms.Button AddChangeSoundBtn;
        private System.Windows.Forms.Button StudentResultsButton;
        private System.Windows.Forms.Button ImportDataBtn;
        private System.Windows.Forms.Button CreateTestBtn;
        private AxWMPLib.AxWindowsMediaPlayer WMPbox;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Button DeletePictureBtn;
        private Button DeleteSoundBtn;
        private Button DeleteVocabBtn;
    }
}