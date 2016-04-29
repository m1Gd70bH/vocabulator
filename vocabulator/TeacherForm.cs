using System;
using System.IO;
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
    /// <summary>
    /// class for TeacherForm
    /// </summary>
    public partial class TeacherForm : Form
    {
        Database db;
        Util utility;
        
        /// <summary>
        /// default constructor, init window
        /// </summary>
        public TeacherForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// fill window with first data from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            utility = new Util();   //setup io helper
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), //Vocab
                db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            QuestionTextBox.Text = vocab.german;
            AnswerTextBox.Text = vocab.english;
            if (db.GetPicturePathByVocabId(vocab.id) != "") //Picturebox init          
            {
                PicBox.Image = Image.FromFile(db.GetPicturePathByVocabId(vocab.id));    //picbox load image
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
            if (db.GetSoundPathByVocabId(vocab.id) != "") //Soundbox init, load sound
            {
                WMPLib.IWMPMedia media = WMPbox.newMedia(db.GetSoundPathByVocabId(vocab.id));
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
            //"Text files (*.txt)|*.txt|All files (*.*)|*.*";
        }

        /// <summary>
        /// opens file dialog for import of soundfile, copy/rename the file to root directory, save path into db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChangeSoundBtn_Click(object sender, EventArgs e)
        {
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            OpenFileDialog dialog = new OpenFileDialog();   //openfiledialog
            dialog.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string oldFileName = Path.GetFileName(dialog.FileName); //filecopy string
                string newFileName = (db.getunitid(UnitSelectBox.Text) + db.getgroupid(GroupSelectBox.Text) + vocab.id  + ".Sound");
                    Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName);
                string destinationfilepath = Environment.CurrentDirectory + "/data/audio/";
                toolStripStatusLabel1.Text = ("Copy " + oldFileName + " from " + sourcefilepath +   //setup tooltip
                    " to " + destinationfilepath + newFileName);
                utility.Filecopy(sourcefilepath, destinationfilepath, oldFileName, newFileName);    //filecopy function from Util.cs
                WMPbox.URL = dialog.FileName;   //media load sound
                WMPLib.IWMPMedia media = WMPbox.newMedia(Path.GetFileName(dialog.FileName));
                WMPbox.currentPlaylist.appendItem(media);
                toolStripStatusLabel1.Text = "";    //refresh tooltip
            }
        }

        /// <summary>
        /// /// opens file dialog for import of picutrefile, copy/rename the file to root directory, save path into db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChangePictureBtn_Click(object sender, EventArgs e)
        {
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1),
                db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            OpenFileDialog dialog = new OpenFileDialog();   //openfiledialog
            dialog.Filter = "all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string oldFileName = Path.GetFileName(dialog.FileName); //filecopy strings
                string newFileName = (vocab.id + ".Picture"); 
                    Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName);
                string destinationfilepath =  Environment.CurrentDirectory + "/data/picture/";
                toolStripStatusLabel1.Text = ("Copy " + oldFileName + " from " + sourcefilepath +
                    " to " + destinationfilepath + newFileName);    //setup tooltipp
                Util utility = new Util();  //filecopy funtcion from Util.cs --> this maybe go online on server fileupload, for sync
                utility.Filecopy(sourcefilepath, destinationfilepath, oldFileName, newFileName);
                PicBox.Image = Image.FromFile(destinationfilepath + newFileName);   //picbox load image
                this.PicBox.SizeMode = PictureBoxSizeMode.Zoom; //autosize
                toolStripStatusLabel1.Text = "";    //refresh tooltip
                db.SetPicture(vocab.id, destinationfilepath + newFileName); //save path into db
                DeletePictureBtn.Enabled = true;
                AddChangePictureBtn.Text = "Change";
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
            if(NextSaveButton.Text=="Save")
            {
                Vocab NewVocab = new Vocab();    //generate new Vocab
                NewVocab.english = AnswerTextBox.Text;  //read text box, set Vocab propertys
                NewVocab.german = QuestionTextBox.Text;
                db.SaveNewVocab(NewVocab,GroupSelectBox.SelectedIndex + 1, "", ""); //save to db
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
                    Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), 
                        db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //load next vocab in Textbox
                    QuestionTextBox.Text = vocab.german;
                    AnswerTextBox.Text = vocab.english;
                    if (db.GetPicturePathByVocabId(vocab.id) != "") //load picture, set btns              
                    {
                        PicBox.Image = Image.FromFile(db.GetPicturePathByVocabId(vocab.id)); //picbox load image
                        PicBox.SizeMode = PictureBoxSizeMode.Zoom; //autosize
                        AddChangePictureBtn.Text = "Change";
                        DeletePictureBtn.Enabled = true;
                    }
                    else
                    {
                        PicBox.Image = null;
                        AddChangePictureBtn.Text = "Add";
                        DeletePictureBtn.Enabled = false;
                    }
                    if (db.GetSoundPathByVocabId(vocab.id) != "") //load sound
                    {
                        WMPLib.IWMPMedia media = WMPbox.newMedia(db.GetSoundPathByVocabId(vocab.id));
                        WMPbox.currentPlaylist.appendItem(media);
                        AddChangeSoundBtn.Text = "Change";
                        DeleteSoundBtn.Enabled = true;
                    }
                    else
                    {
                        WMPbox.close(); //clear soundbox
                        AddChangeSoundBtn.Text = "Add";
                        DeleteSoundBtn.Enabled = false; //set btns
                        AddChangePictureBtn.Enabled = false;
                        AddChangeSoundBtn.Enabled = false;
                    }
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
        /// if unit index changed reinit affected data (vocab,pic,sound,btns)
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            QuestionTextBox.Text = vocab.german;
            AnswerTextBox.Text = vocab.english;
            if (db.GetPicturePathByVocabId(vocab.id) != "") //load picture    
            {
                PicBox.Image = Image.FromFile(db.GetPicturePathByVocabId(vocab.id)); //picbox load image
                PicBox.SizeMode = PictureBoxSizeMode.Zoom; //autosize
                AddChangePictureBtn.Text = "Change";
                DeletePictureBtn.Enabled = true;
            }
            else
            {
                PicBox.Image = null;
                AddChangePictureBtn.Text = "Add";
                DeletePictureBtn.Enabled = false;
            }
            if (db.GetSoundPathByVocabId(vocab.id) != "") //load sound
            {
                WMPLib.IWMPMedia media = WMPbox.newMedia(db.GetSoundPathByVocabId(vocab.id));
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
        }

        /// <summary>
        /// /// if unit index changed reinit affected data (vocab,pic,sound,btns)
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //Textbox 
            QuestionTextBox.Text = vocab.german;
            AnswerTextBox.Text = vocab.english;         
            if (db.GetPicturePathByVocabId(vocab.id) != "") //load picture
            {
                PicBox.Image = Image.FromFile(db.GetPicturePathByVocabId(vocab.id));    //picbox load image
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
            if (db.GetSoundPathByVocabId(vocab.id) != "")   //load sound
            {
                WMPLib.IWMPMedia media = WMPbox.newMedia(db.GetSoundPathByVocabId(vocab.id));
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
                AddChangePictureBtn.Enabled = false;
                AddChangeSoundBtn.Enabled = false;
                NextSaveButton.Text = "Save";
            }
            else
            {
                Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1),
                    db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //load vocab
                QuestionTextBox.Text = vocab.german;
                AnswerTextBox.Text = vocab.english;
                if (db.GetPicturePathByVocabId(vocab.id) != "") //load picture              
                {
                    PicBox.Image = Image.FromFile(db.GetPicturePathByVocabId(vocab.id));    //picbox load image
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
                if (db.GetSoundPathByVocabId(vocab.id) != "")   //load sound
                {
                    WMPLib.IWMPMedia media = WMPbox.newMedia(db.GetSoundPathByVocabId(vocab.id));
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
            }
            if (VocabSelectBox.SelectedIndex == 0)  //set to previous btn
                PrevBtn.Enabled = false;
            else
                PrevBtn.Enabled = true;
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), 
                db.getuserid("admin")))[VocabSelectBox.SelectedIndex];  //get vocab
            toolStripStatusLabel1.Text = "Delete " + db.GetPicturePathByVocabId(vocab.id);  //set tooltip
            PicBox.Image.Dispose(); //clear picbox
            PicBox.Image = null;
            Util utility = new Util();  //filecopy funtcion from Util.cs --> this maybe go online on server fileupload, for sync
            if (!utility.FileDelete(db.GetPicturePathByVocabId(vocab.id)))
            {
                MessageBox.Show("Unable to delete File (invalid path or file not found)!",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.DeletePicture(vocab);    //delete path from db
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))[VocabSelectBox.SelectedIndex]; //get vocab
            toolStripStatusLabel1.Text = "Delete " + db.GetSoundPathByVocabId(vocab.id); //set tooltip
            WMPbox.close(); //clear soundbox
            WMPbox.Dispose();                        
            Util utility = new Util(); //filecopy funtcion from Util.cs --> this maybe go online on server fileupload, for sync
            if (!utility.FileDelete(db.GetPicturePathByVocabId(vocab.id)))
                MessageBox.Show("Unable to delete File (invalid path or file not found)!",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            db.DeleteSound(vocab); //delete path from db
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
            Vocab vocab = (db.GetVocabs((GroupSelectBox.SelectedIndex + 1), //get vocab
                db.getuserid("admin")))[VocabSelectBox.SelectedIndex];
            db.DeleteVocab(vocab.id);   //delete vocab
            VocabSelectBox.Items.Clear();   //reload vocablist
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german); //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            if (temp != 0)  //set vocabselectlist to index -1;
                VocabSelectBox.SelectedIndex = temp - 1;
            else
                VocabSelectBox.SelectedIndex = 0;
        }
    }
}
