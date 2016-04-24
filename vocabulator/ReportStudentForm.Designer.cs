namespace Vocabulator
{
    partial class ReportStudentForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.ReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NrOfCorrectAnswersLabel = new System.Windows.Forms.Label();
            this.Level0Label = new System.Windows.Forms.Label();
            this.Level1Label = new System.Windows.Forms.Label();
            this.Level2Label = new System.Windows.Forms.Label();
            this.Level3Level = new System.Windows.Forms.Label();
            this.Level4Label = new System.Windows.Forms.Label();
            this.Level5Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportChart
            // 
            chartArea2.Name = "ChartArea1";
            this.ReportChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.ReportChart.Legends.Add(legend2);
            this.ReportChart.Location = new System.Drawing.Point(12, 12);
            this.ReportChart.Name = "ReportChart";
            this.ReportChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            this.ReportChart.Size = new System.Drawing.Size(380, 219);
            this.ReportChart.TabIndex = 0;
            this.ReportChart.Text = "ReportChart";
            // 
            // NrOfCorrectAnswersLabel
            // 
            this.NrOfCorrectAnswersLabel.AutoSize = true;
            this.NrOfCorrectAnswersLabel.Location = new System.Drawing.Point(398, 22);
            this.NrOfCorrectAnswersLabel.Name = "NrOfCorrectAnswersLabel";
            this.NrOfCorrectAnswersLabel.Size = new System.Drawing.Size(145, 13);
            this.NrOfCorrectAnswersLabel.TabIndex = 1;
            this.NrOfCorrectAnswersLabel.Text = "Number of Right Answers: 67";
            // 
            // Level0Label
            // 
            this.Level0Label.AutoSize = true;
            this.Level0Label.Location = new System.Drawing.Point(398, 52);
            this.Level0Label.Name = "Level0Label";
            this.Level0Label.Size = new System.Drawing.Size(60, 13);
            this.Level0Label.TabIndex = 2;
            this.Level0Label.Text = "Level 0: 20";
            // 
            // Level1Label
            // 
            this.Level1Label.AutoSize = true;
            this.Level1Label.Location = new System.Drawing.Point(398, 80);
            this.Level1Label.Name = "Level1Label";
            this.Level1Label.Size = new System.Drawing.Size(54, 13);
            this.Level1Label.TabIndex = 3;
            this.Level1Label.Text = "Level 1: 5";
            // 
            // Level2Label
            // 
            this.Level2Label.AutoSize = true;
            this.Level2Label.Location = new System.Drawing.Point(398, 108);
            this.Level2Label.Name = "Level2Label";
            this.Level2Label.Size = new System.Drawing.Size(54, 13);
            this.Level2Label.TabIndex = 4;
            this.Level2Label.Text = "Level 2: 8";
            // 
            // Level3Level
            // 
            this.Level3Level.AutoSize = true;
            this.Level3Level.Location = new System.Drawing.Point(398, 137);
            this.Level3Level.Name = "Level3Level";
            this.Level3Level.Size = new System.Drawing.Size(60, 13);
            this.Level3Level.TabIndex = 5;
            this.Level3Level.Text = "Level 3: 12";
            // 
            // Level4Label
            // 
            this.Level4Label.AutoSize = true;
            this.Level4Label.Location = new System.Drawing.Point(398, 166);
            this.Level4Label.Name = "Level4Label";
            this.Level4Label.Size = new System.Drawing.Size(60, 13);
            this.Level4Label.TabIndex = 6;
            this.Level4Label.Text = "Level 4: 16";
            // 
            // Level5Label
            // 
            this.Level5Label.AutoSize = true;
            this.Level5Label.Location = new System.Drawing.Point(398, 197);
            this.Level5Label.Name = "Level5Label";
            this.Level5Label.Size = new System.Drawing.Size(60, 13);
            this.Level5Label.TabIndex = 7;
            this.Level5Label.Text = "Level 5: 20";
            // 
            // ReportStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 243);
            this.Controls.Add(this.Level5Label);
            this.Controls.Add(this.Level4Label);
            this.Controls.Add(this.Level3Level);
            this.Controls.Add(this.Level2Label);
            this.Controls.Add(this.Level1Label);
            this.Controls.Add(this.Level0Label);
            this.Controls.Add(this.NrOfCorrectAnswersLabel);
            this.Controls.Add(this.ReportChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulator Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportStudentForm_FormClosed);
            this.Load += new System.EventHandler(this.ReportStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ReportChart;
        private System.Windows.Forms.Label NrOfCorrectAnswersLabel;
        private System.Windows.Forms.Label Level0Label;
        private System.Windows.Forms.Label Level1Label;
        private System.Windows.Forms.Label Level2Label;
        private System.Windows.Forms.Label Level3Level;
        private System.Windows.Forms.Label Level4Label;
        private System.Windows.Forms.Label Level5Label;
    }
}