namespace Vocabulator
{
    partial class ReportTeacherForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 8D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 12D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 16D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 20D);
            this.Level5Label = new System.Windows.Forms.Label();
            this.Level4Label = new System.Windows.Forms.Label();
            this.Level3Level = new System.Windows.Forms.Label();
            this.Level2Label = new System.Windows.Forms.Label();
            this.Level1Label = new System.Windows.Forms.Label();
            this.Level0Label = new System.Windows.Forms.Label();
            this.NumberofRightAnswersLabel = new System.Windows.Forms.Label();
            this.ReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SelectStudentLabel = new System.Windows.Forms.Label();
            this.StudentListBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Level5Label
            // 
            this.Level5Label.AutoSize = true;
            this.Level5Label.Location = new System.Drawing.Point(401, 218);
            this.Level5Label.Name = "Level5Label";
            this.Level5Label.Size = new System.Drawing.Size(60, 13);
            this.Level5Label.TabIndex = 15;
            this.Level5Label.Text = "Level 5: 20";
            // 
            // Level4Label
            // 
            this.Level4Label.AutoSize = true;
            this.Level4Label.Location = new System.Drawing.Point(401, 187);
            this.Level4Label.Name = "Level4Label";
            this.Level4Label.Size = new System.Drawing.Size(60, 13);
            this.Level4Label.TabIndex = 14;
            this.Level4Label.Text = "Level 4: 16";
            // 
            // Level3Level
            // 
            this.Level3Level.AutoSize = true;
            this.Level3Level.Location = new System.Drawing.Point(401, 158);
            this.Level3Level.Name = "Level3Level";
            this.Level3Level.Size = new System.Drawing.Size(60, 13);
            this.Level3Level.TabIndex = 13;
            this.Level3Level.Text = "Level 3: 12";
            // 
            // Level2Label
            // 
            this.Level2Label.AutoSize = true;
            this.Level2Label.Location = new System.Drawing.Point(401, 129);
            this.Level2Label.Name = "Level2Label";
            this.Level2Label.Size = new System.Drawing.Size(54, 13);
            this.Level2Label.TabIndex = 12;
            this.Level2Label.Text = "Level 2: 8";
            // 
            // Level1Label
            // 
            this.Level1Label.AutoSize = true;
            this.Level1Label.Location = new System.Drawing.Point(401, 101);
            this.Level1Label.Name = "Level1Label";
            this.Level1Label.Size = new System.Drawing.Size(54, 13);
            this.Level1Label.TabIndex = 11;
            this.Level1Label.Text = "Level 1: 5";
            // 
            // Level0Label
            // 
            this.Level0Label.AutoSize = true;
            this.Level0Label.Location = new System.Drawing.Point(401, 73);
            this.Level0Label.Name = "Level0Label";
            this.Level0Label.Size = new System.Drawing.Size(60, 13);
            this.Level0Label.TabIndex = 10;
            this.Level0Label.Text = "Level 0: 20";
            // 
            // NumberofRightAnswersLabel
            // 
            this.NumberofRightAnswersLabel.AutoSize = true;
            this.NumberofRightAnswersLabel.Location = new System.Drawing.Point(401, 43);
            this.NumberofRightAnswersLabel.Name = "NumberofRightAnswersLabel";
            this.NumberofRightAnswersLabel.Size = new System.Drawing.Size(145, 13);
            this.NumberofRightAnswersLabel.TabIndex = 9;
            this.NumberofRightAnswersLabel.Text = "Number of Right Answers: 67";
            // 
            // ReportChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ReportChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.ReportChart.Legends.Add(legend1);
            this.ReportChart.Location = new System.Drawing.Point(15, 33);
            this.ReportChart.Name = "ReportChart";
            this.ReportChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.EmptyPointStyle.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series1.EmptyPointStyle.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top";
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.LegendText = "RightAnswers";
            series1.Name = "RightAnswers";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Turquoise;
            series1.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.Box;
            series1.XValueMember = "6";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueMembers = "20";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.ReportChart.Series.Add(series1);
            this.ReportChart.Size = new System.Drawing.Size(380, 219);
            this.ReportChart.TabIndex = 8;
            this.ReportChart.Text = "ReportChart";
            // 
            // SelectStudentLabel
            // 
            this.SelectStudentLabel.AutoSize = true;
            this.SelectStudentLabel.Location = new System.Drawing.Point(12, 9);
            this.SelectStudentLabel.Name = "SelectStudentLabel";
            this.SelectStudentLabel.Size = new System.Drawing.Size(74, 13);
            this.SelectStudentLabel.TabIndex = 19;
            this.SelectStudentLabel.Text = "SelectStudent";
            // 
            // StudentListBox
            // 
            this.StudentListBox.FormattingEnabled = true;
            this.StudentListBox.Items.AddRange(new object[] {
            "Kevin",
            "Marvin",
            "Chantalle"});
            this.StudentListBox.Location = new System.Drawing.Point(89, 6);
            this.StudentListBox.Name = "StudentListBox";
            this.StudentListBox.Size = new System.Drawing.Size(121, 21);
            this.StudentListBox.TabIndex = 18;
            // 
            // ReportTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 269);
            this.Controls.Add(this.SelectStudentLabel);
            this.Controls.Add(this.StudentListBox);
            this.Controls.Add(this.Level5Label);
            this.Controls.Add(this.Level4Label);
            this.Controls.Add(this.Level3Level);
            this.Controls.Add(this.Level2Label);
            this.Controls.Add(this.Level1Label);
            this.Controls.Add(this.Level0Label);
            this.Controls.Add(this.NumberofRightAnswersLabel);
            this.Controls.Add(this.ReportChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportTeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vocabulator Report";
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Level5Label;
        private System.Windows.Forms.Label Level4Label;
        private System.Windows.Forms.Label Level3Level;
        private System.Windows.Forms.Label Level2Label;
        private System.Windows.Forms.Label Level1Label;
        private System.Windows.Forms.Label Level0Label;
        private System.Windows.Forms.Label NumberofRightAnswersLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ReportChart;
        private System.Windows.Forms.Label SelectStudentLabel;
        private System.Windows.Forms.ComboBox StudentListBox;
    }
}