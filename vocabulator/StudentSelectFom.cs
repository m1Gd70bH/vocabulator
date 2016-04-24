using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocabulator
{
    public partial class StudentSelectForm : Form
    {
        int userid;
        Database db;

        public StudentSelectForm(int userid)
        {
            InitializeComponent();
            this.userid = userid;    
        }

        private void StudentSelectForm_Load(object sender, EventArgs e)
        {

            try
            {
                db = new Database();
            }
            catch
            {
                MessageBox.Show("Cant load database or database not found!",
                    "Vocabulator Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            toolStripStatusLabel.Text = ("Logged in as: " + db.getusername(userid));
            //Lessons
            UnitComBox.DropDownStyle = ComboBoxStyle.DropDownList; //no edit
            UnitComBox.Items.Clear(); //clear           
            foreach (string unit in db.getunits()) UnitComBox.Items.Add(unit); //add from db
            UnitComBox.SelectedIndex = 0; // erster eintrag gesetzt
            //Groups
            GroupComBox.DropDownStyle = ComboBoxStyle.DropDownList; //no edit
            GroupComBox.Items.Clear(); //clear
            foreach (string group in db.getgroups(UnitComBox.SelectedIndex+1)) GroupComBox.Items.Add(group); //add from db
            GroupComBox.SelectedIndex = 0;  // erster eintrag gesetzt
        }
    
        private void ReportButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formToShow = new ReportStudentForm(userid, db.getunitid(UnitComBox.SelectedItem.ToString()));
            formToShow.ShowDialog();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LessonComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //wenn neue Lesson gewählt wird
            GroupComBox.Items.Clear(); //clear
            foreach (string group in db.getgroups(UnitComBox.SelectedIndex + 1)) GroupComBox.Items.Add(group); //add from db
            GroupComBox.SelectedIndex = 0;  // erster eintrag gesetzt

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formToShow = new StudentForm(userid, 
                db.getunitid(UnitComBox.SelectedItem.ToString()), 
                db.getgroupid(GroupComBox.SelectedItem.ToString()));
            formToShow.ShowDialog();
            
        }
    }
}
