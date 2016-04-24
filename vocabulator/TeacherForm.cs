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
    public partial class TeacherForm : Form
    {
        Database db;
        int vocabid;
        int unitid;
        int gourpid;
        //setup io helper
        Util utility;

        public TeacherForm()
        {
            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            //setup io helper
            utility = new Util();
            
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
            //setup design specific
            
            //Units
            UnitSelectBox.Items.Clear();
            foreach (string unit in db.getunits()) 
                UnitSelectBox.Items.Add(unit); //add from db
            UnitSelectBox.Items.Add("Add..."); //add last entry
            UnitSelectBox.SelectedIndex = 0; // set first entry
            
            //Groups
            GroupSelectBox.Items.Clear();
            foreach (string group in db.getgroups(UnitSelectBox.SelectedIndex + 1)) 
                GroupSelectBox.Items.Add(group); //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            GroupSelectBox.SelectedIndex = 0;  // set to first entry
            
            //Vocab
            VocabSelectBox.Items.Clear(); 
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex+1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german); //add from db
            VocabSelectBox.Items.Add("Add..."); //add last entry
            VocabSelectBox.SelectedIndex = 0; //set to first entry

            //Textbox init
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
            QuestionTextBox.Text = vocab.german;
            AnswerTextBox.Text = vocab.english;

            //Picturebox init          
            if (db.GetPicturePathByVocabId(vocab.id) != "")
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
            //Soundbox init
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

        private void StudnetResultsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form reportForm = new ReportTeacherForm();
            reportForm.ShowDialog();
            reportForm.Dispose();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //"Text files (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
             //openfiledialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //filecopy strings
                string oldFileName = Path.GetFileName(dialog.FileName);
                string newFileName = (vocab.id + ".Sound"); //hier dann Theme+Group adden
                    Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName);
                string destinationfilepath = Environment.CurrentDirectory + "/data/audio/";
                //setup tooltipp
                toolStripStatusLabel1.Text = ("Copy " + oldFileName + " from " + sourcefilepath +
                    " to " + destinationfilepath + newFileName);
                //filecopy function from Util.cs
                utility.Filecopy(sourcefilepath, destinationfilepath, oldFileName, newFileName);
                //media load sound
                WMPbox.URL = dialog.FileName;
                WMPLib.IWMPMedia media = WMPbox.newMedia(Path.GetFileName(dialog.FileName));
                WMPbox.currentPlaylist.appendItem(media);
                //refresh tooltip
                toolStripStatusLabel1.Text = "";
            }
        }

        private void AddPictureButton_Click(object sender, EventArgs e)
        {
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
            //openfiledialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "all files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //filecopy strings
                string oldFileName = Path.GetFileName(dialog.FileName);
                string newFileName = (vocab.id + ".Picture"); 
                    Path.GetExtension(dialog.FileName);
                string sourcefilepath = Path.GetDirectoryName(dialog.FileName);
                string destinationfilepath =  Environment.CurrentDirectory + "/data/picture/";
                //setup tooltipp
                toolStripStatusLabel1.Text = ("Copy " + oldFileName + " from " + sourcefilepath +
                    " to " + destinationfilepath + newFileName);
                //filecopy funtcion from Util.cs --> this maybe go online on server fileupload, for sync
                Util utility = new Util();
                utility.Filecopy(sourcefilepath, destinationfilepath, oldFileName, newFileName);
                //picbox load image
                PicBox.Image = Image.FromFile(destinationfilepath + newFileName);
                //autosize
                this.PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                //refresh tooltip
                toolStripStatusLabel1.Text = "";
                //save path into db
                db.SetPicture(vocab.id, destinationfilepath + newFileName);
                DeletePictureBtn.Enabled = true;
                AddChangePictureBtn.Text = "Change";
            }
        }
        private void TeacherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form formToShow = new LoginForm();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formToShow = new LoginForm();
        }

        private void NextSaveButton_Click(object sender, EventArgs e)
        {
            if(NextSaveButton.Text=="Save")
            {
                //generate new Vocab
                Vocab NewVocab = new Vocab();
                //read text box, set Vocab propertys
                NewVocab.english = AnswerTextBox.Text;
                NewVocab.german = QuestionTextBox.Text;
                //save to db
                db.SaveNewVocab(NewVocab,GroupSelectBox.SelectedIndex + 1, "", "");
                //settooltip
                toolStripStatusLabel1.Text = "Q: "+QuestionTextBox.Text + "A: "+ AnswerTextBox.Text+"saved";
                //clear vocablist
                VocabSelectBox.Items.Clear();
                //reload vocablist
                foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                    VocabSelectBox.Items.Add(German.german);
                //add last entry
                VocabSelectBox.Items.Add("Add...");
                //set index to last vocab
                VocabSelectBox.SelectedIndex = VocabSelectBox.Items.Count-2;
                //set btn to next
                NextSaveButton.Text = "Next";
            }
            else
            {
                if (VocabSelectBox.SelectedIndex +1< VocabSelectBox.Items.Count) //check if we have a next vocab
                {
                    //load next vocab in Textbox
                    Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
                    QuestionTextBox.Text = vocab.german;
                    AnswerTextBox.Text = vocab.english;
                    //load picture, set btns              
                    if (db.GetPicturePathByVocabId(vocab.id) != "")
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
                    //set VocabSelectBox
                    VocabSelectBox.SelectedIndex++;
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
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
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

        private void GroupSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vocab
            VocabSelectBox.Items.Clear(); //clear            
            foreach (Vocab German in db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin")))
                VocabSelectBox.Items.Add(German.german + "...");
            //set index
            VocabSelectBox.SelectedIndex = 0;
            //add last entry
            VocabSelectBox.Items.Add("Add...");
            //Textbox 
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
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

        private void VocabSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VocabSelectBox.Text == "Add...")
            {
                QuestionTextBox.Clear();
                AnswerTextBox.Clear();
                PicBox.Image = null;
                NextSaveButton.Text = "Save";
            }
            else
            {
                //load vocab
                Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
                QuestionTextBox.Text = vocab.german;
                AnswerTextBox.Text = vocab.english;
                //load picture              
                if (db.GetPicturePathByVocabId(vocab.id) != "")
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
                NextSaveButton.Text = "Next";
            }
            //set to previous btn
            if (VocabSelectBox.SelectedIndex == 0)
                PrevBtn.Enabled = false;
            else
                PrevBtn.Enabled = true;
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            //set to previous vocab
            if (VocabSelectBox.SelectedIndex==0)
            {
                PrevBtn.Enabled=false;
            }
            else
            {
                PrevBtn.Enabled=true;
                VocabSelectBox.SelectedIndex--;
                //load vocab
                Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
                QuestionTextBox.Text = vocab.german;
                AnswerTextBox.Text = vocab.english;
                //load picture           
                if (db.GetPicturePathByVocabId(vocab.id) != "")
                {
                    //picture
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
        }

        private void DeletePictureBtn_Click(object sender, EventArgs e)
        {
            //get vocab
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex];
            //set tooltip
            toolStripStatusLabel1.Text = "Delete " + db.GetPicturePathByVocabId(vocab.id);
            //clear picbox
            PicBox.Image.Dispose();
            PicBox.Image = null;
            //filecopy funtcion from Util.cs --> this maybe go online on server fileupload, for sync
            Util utility = new Util();
            if(!utility.FileDelete(db.GetPicturePathByVocabId(vocab.id)))
            {
                MessageBox.Show("Unable to delete File (invalid path or file not found)!",
                    "Vocabulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //delete path from db
            db.DeletePicture(vocab);
            //set btns
            DeletePictureBtn.Enabled = false;
            AddChangePictureBtn.Text = "Add";
            //refresh tooltip
            toolStripStatusLabel1.Text = "";
        }

        private void DeleteSoundBtn_Click(object sender, EventArgs e)
        {
            Vocab vocab = db.GetVocabs((GroupSelectBox.SelectedIndex + 1), db.getuserid("admin"))[VocabSelectBox.SelectedIndex]; //get vocab
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

        private void DeleteVocabBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
