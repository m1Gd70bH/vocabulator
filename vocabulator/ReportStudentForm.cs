using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vocabulator
{
    public partial class ReportStudentForm : Form
    {
        Database db;
        int userid, groupid;
        public ReportStudentForm(int userid, int groupid)
        {
            InitializeComponent();
            this.userid = userid;
            this.groupid = groupid;           
        }
        private void ReportStudentForm_Load(object sender, EventArgs e)
        {
            //database init
            try
            {
                db = new Database();
            }
            catch
            {
                MessageBox.Show("Unable to load database.",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //Vokablen aus db holen...            
            db.GetProgress(userid, groupid); //funktioniert leider nicht...
            db.GetVocabLevel(0, userid);
            //demo...
            ReportChart.Series.Add("Level"); //Datenserie anlegen
            int[] pointsy = { 0, 1, 2, 3, 4, 5 }; //Demowerte
            int[] pointsx = { 8, 2, 4, 5, 7, 8 };
           
            for (int q = 0; q < 6; q++)
            {
                ReportChart.Series["Level"].Points.AddXY(pointsx[q], pointsy[q]);
                //Punkte hinzufügen
            }
           
        }
        private void ReportStudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form formToShow = new StudentSelectForm(userid);
            formToShow.ShowDialog();
        }
    }
}
