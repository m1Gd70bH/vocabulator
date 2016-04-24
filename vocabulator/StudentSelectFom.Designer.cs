namespace Vocabulator
{
    partial class StudentSelectForm
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
            this.GroupComBox = new System.Windows.Forms.ComboBox();
            this.SelectGroupLabel = new System.Windows.Forms.Label();
            this.UnitComBox = new System.Windows.Forms.ComboBox();
            this.SelectLessonLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GroupComBox
            // 
            this.GroupComBox.FormattingEnabled = true;
            this.GroupComBox.Items.AddRange(new object[] {
            "Welcome",
            "Theme 1",
            "Theme 2",
            "Theme 3"});
            this.GroupComBox.Location = new System.Drawing.Point(11, 81);
            this.GroupComBox.Name = "GroupComBox";
            this.GroupComBox.Size = new System.Drawing.Size(172, 21);
            this.GroupComBox.TabIndex = 3;
            // 
            // SelectGroupLabel
            // 
            this.SelectGroupLabel.AutoSize = true;
            this.SelectGroupLabel.Location = new System.Drawing.Point(12, 62);
            this.SelectGroupLabel.Name = "SelectGroupLabel";
            this.SelectGroupLabel.Size = new System.Drawing.Size(66, 13);
            this.SelectGroupLabel.TabIndex = 4;
            this.SelectGroupLabel.Text = "SelectGroup";
            // 
            // UnitComBox
            // 
            this.UnitComBox.FormattingEnabled = true;
            this.UnitComBox.Location = new System.Drawing.Point(11, 30);
            this.UnitComBox.Name = "UnitComBox";
            this.UnitComBox.Size = new System.Drawing.Size(172, 21);
            this.UnitComBox.TabIndex = 5;
            this.UnitComBox.SelectedIndexChanged += new System.EventHandler(this.LessonComBox_SelectedIndexChanged);
            // 
            // SelectLessonLabel
            // 
            this.SelectLessonLabel.AutoSize = true;
            this.SelectLessonLabel.Location = new System.Drawing.Point(12, 9);
            this.SelectLessonLabel.Name = "SelectLessonLabel";
            this.SelectLessonLabel.Size = new System.Drawing.Size(71, 13);
            this.SelectLessonLabel.TabIndex = 6;
            this.SelectLessonLabel.Text = "SelectLesson";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(130, 109);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(53, 23);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(12, 109);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(53, 23);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "LogOut";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Enabled = false;
            this.ReportButton.Location = new System.Drawing.Point(71, 109);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(53, 23);
            this.ReportButton.TabIndex = 10;
            this.ReportButton.Text = "Report";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 139);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(196, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = true;
            this.toolStripStatusLabel.Location = new System.Drawing.Point(1, 143);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(10, 13);
            this.toolStripStatusLabel.TabIndex = 12;
            this.toolStripStatusLabel.Text = " ";
            // 
            // StudentSelectForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 161);
            this.Controls.Add(this.toolStripStatusLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SelectLessonLabel);
            this.Controls.Add(this.UnitComBox);
            this.Controls.Add(this.SelectGroupLabel);
            this.Controls.Add(this.GroupComBox);
            this.Name = "StudentSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulator";
            this.Load += new System.EventHandler(this.StudentSelectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GroupComBox;
        private System.Windows.Forms.Label SelectGroupLabel;
        private System.Windows.Forms.ComboBox UnitComBox;
        private System.Windows.Forms.Label SelectLessonLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label toolStripStatusLabel;

    }
}