using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Vocabulator
{
    public partial class StudentForm : Form
    {
        Database db;
        int userId;
        int groupId;
        int lessonId;
        int lastShownVocab;
        int level;
        int correctAnswerCount;
        bool vocCheck;
        int amountVocabs;
        string langswitch;
        
        List<Vocab> vocabulary;
        //List<int> rightAnswerList;
        
        public StudentForm(int userId, int lessonId, int groupId)
        {
            InitializeComponent();
            this.userId = userId;
            this.groupId = groupId;
            this.lessonId = lessonId;
            langswitch = "german";
        }

        private void StudentForm_Load(object sender, EventArgs e)
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
            //getuserprogress
            // db.getprogress(userid);
            
            //debug
            lastShownVocab = 0;
            level = 0;
            correctAnswerCount = 0;
            
            //getdata
            vocabulary = db.GetVocabsByLevel(groupId, userId, level);
            amountVocabs = vocabulary.Count();
            //labels
            QuestionCounterLabel.Text = "Question:  " + (lastShownVocab + 1) + "/" 
                + vocabulary.Count().ToString();
            LevelLabel.Text = "Level:  " + level + "/6";
            //info
            toolStripStatusLabel.Text = ("Logged in as: " + db.getusername(userId) +
                " Lesson: \"" + db.getunitname(lessonId) + "\" Group: \"" + db.getgroupname(groupId) + "\"");
            vocCheck = false;

            axWindowsMediaPlayer1.BeginInit();
            axWindowsMediaPlayer1.EndInit();

            LoadNextVocab();
            
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form form = new StudentSelectForm(userId);
            form.ShowDialog();
        }

        private void CheckAnswerButton_Click(object sender, EventArgs e)
        {
            if (!vocCheck)
            {
                vocCheck = true;            
                //btn switch
                CheckAnswerButton.Text = "Next";
                //Antwort prüfen
                if (AnswerTextBox.Text == vocabulary[0 + lastShownVocab].english)
                {
                    db.SetProgress(userId, vocabulary[0 + lastShownVocab].id, level + 1);
                    vocabulary.RemoveAt(0 + lastShownVocab);//löscht eng. vokabel aus liste
                    CorrectAnswerTextBox.Text = "Correct!";
                    correctAnswerCount++;
                    RightAnswerLabel.Text = "Correct Answers: " + correctAnswerCount;
                }
                else
                {
                    CorrectAnswerTextBox.Text = "Sorry, wrong answer!\n" +
                        "The correct answer is:\n " + vocabulary[0 + lastShownVocab].english + ".";
                }
                if ((lastShownVocab ) < (vocabulary.Count()))
                {
                    lastShownVocab++;
                }
            }
            else
            {
                vocCheck= false;
                //lvl check
                if (correctAnswerCount == amountVocabs)
                {
                    //message
                    MessageBox.Show("Next Level!",
                        "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (level <= 6)
                    {
                        //lvl up!
                        level++;
                        //reload from db!
                        vocabulary = db.GetVocabsByLevel(groupId, userId, level);
                        //reset counters:
                        lastShownVocab = 0;
                        correctAnswerCount = 0;
                    }
                    else
                    {
                        level = 0;
                        MessageBox.Show("Max Level reached!",
                        "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //label init
                    LevelLabel.Text = "Level: " + level.ToString();
                    RightAnswerLabel.Text = "Correct Answers: " + correctAnswerCount;
                    //lvl to db!
                }
                //list end check
                if (lastShownVocab == (vocabulary.Count()))
                {
                    lastShownVocab = 0;
                }
                //btn switch
                CheckAnswerButton.Text = "CheckAnswer";
                LoadNextVocab();
                
            }
        }

        private void LoadNextVocab()
        {
            if (level == 0)
                CorrectAnswerTextBox.Text = vocabulary[0 + lastShownVocab].english;
            else
                CorrectAnswerTextBox.Text = "?";
            QuestionTextbox.Text = (vocabulary[0 + lastShownVocab].german);
            AnswerTextBox.Text = "";
            //label
            QuestionCounterLabel.Text = "Quesiton: " + (lastShownVocab + 1) + "/" + (vocabulary.Count());
            if (vocabulary[lastShownVocab].picturepath != "")
            {
                pictureBox1.Load("data/picture/" + vocabulary[lastShownVocab].picturepath);
            }
            else
            {
                pictureBox1.Image = null;
            }

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            if (vocabulary[lastShownVocab].soundpath != "")
            {
                axWindowsMediaPlayer1.URL = "data/audio/" + vocabulary[lastShownVocab].soundpath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new StudentSelectForm(userId);
            form.ShowDialog();
        }

        private void AnswerTextBox_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void SwitchQAChkBox_CheckedChanged(object sender, EventArgs e)
        {
            //property switch, i dont know???
            if (SwitchQAChkBox.Checked)
                langswitch = "German";
            else
                langswitch = "English";
        }

    }
}
