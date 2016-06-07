using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Vocabulator
{
    /// <summary>
    /// class for TeacherForm
    /// </summary>
    public partial class TeacherForm : Form
    {
        Database db;
        Util Utility;
        Vocab Vocab;
        /// <summary>
        /// default constructor, init window
        /// </summary>
        public TeacherForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// fill window with data from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            Utility = new Util();   //io helper, filecopy function from Util.cs --> this maybe go online on server fileupload, for sync
            Vocab = new Vocab();    //Vocab obj
            try
            {
                db = new Database();    //database init
            }
            catch
            {
                MessageBox.Show("Unable to load database.",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
            UnitSelectBox.Items.Clear();    //setup design specific, Lessons
            foreach (string unit in db.getunits()) 
                UnitSelectBox.Items.Add(unit);  //add from db
            UnitSelectBox.Items.Add("Add...");  //add last entry
            UnitSelectBox.SelectedIndex = 0;    // set first entry
            GroupSelectBox.Items.Clear();   //Groups
            foreach (string group in db.getgroups(UnitSelectBox.SelectedIndex + 1)) 
                GroupSelectBox.Items.Add(group);    //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            GroupSelectBox.SelectedIndex = 0;   // set to first entry
            VocabSelectBox.Items.Clear();   //Vocab
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex+1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german);    //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            VocabSelectBox.SelectedIndex = 0;   //set to first entry
            Vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), //load Vocab
                db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            QuestionTextBox.Text = Vocab.german;    //set Vocab atttib
            AnswerTextBox.Text = Vocab.english;
            if (Vocab.picturepath!="") //Picturebox init          
            {
                PicBox.Image = Image.FromFile(Vocab.picturepath);    //picbox load image
                PicBox.SizeMode = PictureBoxSizeMode.Zoom;  //autosize
                AddChangePictureBtn.Text = "Change";
                DeletePictureBtn.Enabled = true;
            }
            else
            {
                PicBox.Image = null;
                AddChangePictureBtn.Text = "Add";
                DeletePictureBtn.Enabled = false;
            }
            if (Vocab.soundpath != "") //Soundbox init, load sound
            {
                WMPLib.IWMPMedia media = WMPbox.newMedia(Vocab.soundpath);
                WMPbox.currentPlaylist.appendItem(media);
                AddChangeSoundBtn.Text = "Change";
                DeleteSoundBtn.Enabled = true;
            }
            else
            {
                WMPbox.close(); //clear soundbox
                AddChangeSoundBtn.Text = "Add"; //set btns
                DeleteSoundBtn.Enabled = false; 
            }
        }

        /// <summary>
        /// hide TeacherForm and show new ReportTeacherForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudnetResultsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form reportForm = new ReportTeacherForm();
            reportForm.ShowDialog();
            reportForm.Dispose();
            this.Show();
        }

        /// <summary>
        /// fornow inactive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataBtn_Click(object sender, EventArgs e)
        {
            //TODO
            //"Text files (*.txt)|*.txt|All files (*.*)|*.*";
        }

        /// <summary>
        /// opens file dialog for import of soundfile, copy/rename the file to root directory, save path into db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChangeSoundBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();   //openfiledialog
            dialog.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName) + @"/" + Path.GetFileName(dialog.FileName);
                Vocab.soundpath = Environment.CurrentDirectory + "/data/audio/"+
                    (db.getunitid(UnitSelectBox.Text)) + db.getgroupid(GroupSelectBox.Text) + Vocab.id + ".Sound";
                Utility.Filecopy(sourcefilepath, Vocab.soundpath);    //filecopy function from Util.cs
                WMPbox.URL = dialog.FileName;   //media load sound
                WMPLib.IWMPMedia media = WMPbox.newMedia(Path.GetFileName(dialog.FileName));
                WMPbox.currentPlaylist.appendItem(media);
                toolStripStatusLabel1.Text = "";    //refresh tooltip
                if (NextSaveButton.Text != "Save")   //check if new vocab
                {
                    db.SetSoundPath(Vocab.id, Vocab.soundpath); //save path to db
                }
            }

        }

        /// <summary>
        /// /// opens file dialog for import of picutrefile, copy/rename the file to root directory, save path into db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChangePictureBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();   //openfiledialog
            dialog.Filter = "all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName)+ @"/" + Path.GetFileName(dialog.FileName);
                Vocab.picturepath = Environment.CurrentDirectory + "/data/picture/" +
                    db.getunitid(UnitSelectBox.Text) + db.getgroupid(GroupSelectBox.Text) + Vocab.id + ".Picture";
                Utility.Filecopy(sourcefilepath, Vocab.picturepath);
                PicBox.Image = Image.FromFile(Vocab.picturepath);   //picbox load image
                PicBox.SizeMode = PictureBoxSizeMode.Zoom; //autosize
                DeletePictureBtn.Enabled = true;    //btns
                AddChangePictureBtn.Text = "Change";
                if(NextSaveButton.Text != "Save")   //check if new vocab
                {
                    db.SetPicturePath(Vocab.id, Vocab.picturepath); //save path to db
                }
            }
        }

        /// <summary>
        /// if teacherform closed, exit to new LoginForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form formToShow = new LoginForm();
        }

        /// <summary>
        /// exit App on close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// if clicked, exit to new LoginForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formToShow = new LoginForm();
        }

        /// <summary>
        /// Get next vocab or save new generated vocab to db (toogle "next"/"save" btn)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextSaveButton_Click(object sender, EventArgs e)
        {
            if (NextSaveButton.Text=="Save")
            {
                //get filepaths if allrdy set
                string picturepath = Vocab.picturepath;
                string soundpath = Vocab.soundpath;
                Vocab = new Vocab();    //generate new Vocab
                Vocab.english = AnswerTextBox.Text;  //read text box, set Vocab propertys
                Vocab.german = QuestionTextBox.Text;
                db.SaveNewVocab(Vocab,GroupSelectBox.SelectedIndex + 1, picturepath, soundpath); //save to db
                toolStripStatusLabel1.Text = "Q: "+QuestionTextBox.Text + "A: "+ AnswerTextBox.Text+"saved";    //settooltip
                VocabSelectBox.Items.Clear();   //clear vocablist
                foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))   //reload vocablist
                    VocabSelectBox.Items.Add(German.german);
                VocabSelectBox.Items.Add("Add..."); //add last entry
                VocabSelectBox.SelectedIndex = VocabSelectBox.Items.Count-2;    //set index to last vocab
                NextSaveButton.Text = "Next";
                AddChangePictureBtn.Enabled = true;
                AddChangeSoundBtn.Enabled = true;
            }
            else
            {
                if (VocabSelectBox.SelectedIndex +1< VocabSelectBox.Items.Count) //check if we have a next vocab
                {
                    Vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), 
                        db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //load next vocab in Textbox
                    VocabSelectBox.SelectedIndex++; //set VocabSelectBox
                }
                else //no next vocab
                {
                    //clear text box
                    QuestionTextBox.Clear();
                    AnswerTextBox.Clear();
                    //clear picturebox
                    PicBox.Image = null;
                    //set btns
                    DeletePictureBtn.Enabled = false;
                    AddChangePictureBtn.Text = "Add";
                    NextSaveButton.Text = "Save";       
                }
            }
        }

        /// <summary>
        /// if unit index changed reinit affected data (vocab)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnitComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Groups
            GroupSelectBox.Items.Clear(); //clear
            foreach (string group in db.getgroups(UnitSelectBox.SelectedIndex + 1))
                GroupSelectBox.Items.Add(group); //add from db
            GroupSelectBox.SelectedIndex = 0;  // first entry
            //Vocab
            VocabSelectBox.Items.Clear(); //clear            
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german + "...");
            //set index
            VocabSelectBox.SelectedIndex = 0;
            //add last entry
            VocabSelectBox.Items.Add("Add...");
            //Textbox
            Vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            QuestionTextBox.Text = Vocab.german;
            AnswerTextBox.Text = Vocab.english;
        }

        /// <summary>
        /// /// if unit index changed reinit affected data (vocab)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VocabSelectBox.Items.Clear(); //relaod Vocab, clear            
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german + "...");
            VocabSelectBox.SelectedIndex = 0;   //set index
            VocabSelectBox.Items.Add("Add..."); //add last entry
            Vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //Textbox 
            QuestionTextBox.Text = Vocab.german;
            AnswerTextBox.Text = Vocab.english;
        }

        /// <summary>
        /// /// if vocab index changed reinit affected data (vocab,pic,sound,btns)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VocabSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VocabSelectBox.Text == "Add...")
            {
                QuestionTextBox.Clear();
                AnswerTextBox.Clear();
                PicBox.Image = null;
                AddChangePictureBtn.Enabled = true;
                AddChangeSoundBtn.Enabled = true;
                DeleteVocabBtn.Enabled = false; 
                NextSaveButton.Text = "Save";
            }
            else
            {
                Vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1),
                    db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //load vocab
                QuestionTextBox.Text = Vocab.german;
                AnswerTextBox.Text = Vocab.english;
                if (Vocab.picturepath != "") //load picture              
                {
                    PicBox.Image = Image.FromFile(Vocab.picturepath);    //picbox load image
                    PicBox.SizeMode = PictureBoxSizeMode.Zoom;  //autosize
                    AddChangePictureBtn.Text = "Change";
                    DeletePictureBtn.Enabled = true;
                }
                else
                {
                    PicBox.Image = null;
                    AddChangePictureBtn.Text = "Add";
                    DeletePictureBtn.Enabled = false;
                }
                if (Vocab.soundpath != "")   //load sound
                {
                    WMPLib.IWMPMedia media = WMPbox.newMedia(Vocab.soundpath);
                    WMPbox.currentPlaylist.appendItem(media);
                    AddChangeSoundBtn.Text = "Change";
                    DeleteSoundBtn.Enabled = true;
                }
                else
                {
                    WMPbox.close(); //clear soundbox
                    AddChangeSoundBtn.Text = "Add";
                    DeleteSoundBtn.Enabled = false; //set btns
                }
                NextSaveButton.Text = "Next";
                AddChangePictureBtn.Enabled = true;
                AddChangeSoundBtn.Enabled = true;
                DeleteVocabBtn.Enabled = true;
            }
            if (VocabSelectBox.SelectedIndex == 0)  //set to previous btn
                PrevBtn.Enabled = false;
            else
                PrevBtn.Enabled = true;
            toolStripStatusLabel1.Text = "";    //refresh tooltip
        }

        /// <summary>
        /// load previous vocab if exists and set index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (VocabSelectBox.SelectedIndex==0) //set to previous vocab
            {
                PrevBtn.Enabled=false;
            }
            else
            {
                PrevBtn.Enabled=true;
                VocabSelectBox.SelectedIndex--;
            }
        }

        /// <summary>
        /// delete picture from filesystem and db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePictureBtn_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete " + db.GetPicturePathByVocabId(Vocab.id);  //set tooltip
            PicBox.Image.Dispose(); //clear picbox
            PicBox.Image = null;
            if (!Utility.FileDelete(Vocab.picturepath))
            {
                MessageBox.Show("Unable to delete File (invalid path or file not found)!",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.DeletePicture(Vocab);    //delete path from db
            Vocab.picturepath = "";
            DeletePictureBtn.Enabled = false;   //set btns
            AddChangePictureBtn.Text = "Add";
            toolStripStatusLabel1.Text = "";    //refresh tooltip
        }

        /// <summary>
        /// delete sound from filesystem and db, set btns and reset picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSoundBtn_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete " + Vocab.soundpath; //set tooltip
            WMPbox.close(); //clear soundbox
            WMPbox.Dispose();                        
            if (!Utility.FileDelete(Vocab.soundpath))
                MessageBox.Show("Unable to delete File (invalid path or file not found)!",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            db.DeleteSound(Vocab); //delete path from db
            Vocab.soundpath = "";
            DeleteSoundBtn.Enabled = false; //set btns
            AddChangeSoundBtn.Text = "Add";
            toolStripStatusLabel1.Text = ""; //refresh tooltip
        }

        /// <summary>
        /// delete vocab from db, set select index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteVocabBtn_Click(object sender, EventArgs e)
        {
            int temp = VocabSelectBox.SelectedIndex;    //save index to tempvar
            db.DeleteVocab(Vocab.id);   //delete vocab
            VocabSelectBox.Items.Clear();   //reload vocablist
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german); //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            if (temp != 0)  //set vocabselectlist to index -1;
                VocabSelectBox.SelectedIndex = temp - 1;
            else
                VocabSelectBox.SelectedIndex = 0;
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {//nothing to do here
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {//nothing to do here
        }
    }
}
