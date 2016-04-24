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
    public partial class LoginForm : Form
    {
        Database db;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            db = new Database();
            /*try
            {
                db = new Database();
            }
            catch
            {
                MessageBox.Show("Cant load database or database not found!", 
                    "Vocabulator Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();              
            }*/
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(db.IsValidLogin(UserText.Text, PasswordText.Text))
            {
                this.Hide();
                Form formToShow;
                if (db.CheckRights(UserText.Text))
                {
                    formToShow = new TeacherForm();
                }
                else
                {
                    formToShow = new StudentSelectForm(db.getuserid(UserText.Text));
                }
                formToShow.ShowDialog();
                formToShow.Dispose();
                PasswordText.Text = "";
                this.Show(); 
            }
            else
            {
                PasswordText.Text = "";
			    string message = "Wrong Passwort/User!";
                string caption = "Vocabulator Login Error";
			    MessageBoxButtons buttons = MessageBoxButtons.OK;
			    DialogResult result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (UserText.Text == "")
            {
                DialogResult result = MessageBox.Show("Must enter a name.", 
                    "Vocabulator Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (db.UserExists(UserText.Text))
            {
                DialogResult result = MessageBox.Show("This user already exists.",
                    "Vocabulator Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                db.RegisterUser(UserText.Text, PasswordText.Text, false);
                DialogResult result = MessageBox.Show("Registration successful.",
                   "Vocabulator Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordText.Text = "";
            }          
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}