using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class FormSignin : Form
    {
        public FormUser formUser;
        public FormSupervisor formSupervisor;
        public FormSignup formSignup;
        const string SUPERVISOR_USERNAME = "ADMIN";
        const string SUPERVISOR_PASSWORD = "0000";
        public static string signinUsername = "";
        private bool isCapitalized = true;
        public FormSignin()
        {
            InitializeComponent();
        }
        private void FormSignin_Load(object sender, EventArgs e)
        {
            signinUsername = "";
            CenterToScreen();
            //button init
            Image imgSignup = Image.FromFile("../../pic/btn/btn_signUp.png");
            btnSignup.Text = "";
            btnSignup.Image = imgSignup;
            btnSignup.Height = imgSignup.Height + 4;
            btnSignup.Width = imgSignup.Width + 4;
            btnSignup.Cursor = Cursors.Hand;

            Image imgSignin = Image.FromFile("../../pic/btn/btn_signIn.png");
            btnSignin.Text = "";
            btnSignin.Image = imgSignin;
            btnSignin.Height = imgSignin.Height + 4;
            btnSignin.Width = imgSignin.Width + 4;
            btnSignin.Cursor = Cursors.Hand;

            btnCancel.Cursor = Cursors.Hand;
            //textbox init
            textboxUsername.Text = "username";
            textboxUsername.ForeColor = Color.Gray;

            textboxPassword.Text = "password";
            textboxPassword.ForeColor = Color.Gray;
            textboxPassword.UseSystemPasswordChar = false;
            //member data init
            Member.memberData.Add(new Member("TOM", "123"));
            Member.memberData.Add(new Member("BEN", "456"));
            Member.memberData.Add(new Member("EVA", "789"));
        }

        private void textboxUsername_Leave(object sender, EventArgs e)
        {
            if (textboxUsername.Text == "")
            {
                textboxUsername.Text = "username";
                textboxUsername.ForeColor = Color.Gray;
            }
        }

        private void textboxUsername_Enter(object sender, EventArgs e)
        {
            if (textboxUsername.Text == "username")
            {
                textboxUsername.Text = "";
                textboxUsername.ForeColor = Color.Black;
            }
        }

        private void textboxPassword_Leave(object sender, EventArgs e)
        {
            if (textboxPassword.Text == "")
            {
                textboxPassword.Text = "password";
                textboxPassword.ForeColor = Color.Gray;
                textboxPassword.UseSystemPasswordChar = false;
            }
        }

        private void textboxPassword_Enter(object sender, EventArgs e)
        {
            if (textboxPassword.Text == "password")
            {
                textboxPassword.Text = "";
                textboxPassword.ForeColor = Color.Black;
                textboxPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if(textboxUsername.Text == SUPERVISOR_USERNAME && textboxPassword.Text == SUPERVISOR_PASSWORD)
            {//sign in as supervisor
                signinUsername = "supervisor";
                Member.signinMember = null;
                textboxPassword.Text = "password";
                textboxPassword.ForeColor = Color.Gray;
                textboxPassword.UseSystemPasswordChar = false;
                textboxUsername.Text = "username";
                textboxUsername.ForeColor = Color.Gray;
                //open form to manage
                formSupervisor = new FormSupervisor(this);
                formSupervisor.Show();
                this.Hide();
            }
            else
            {
                bool isFind = false;
                foreach (Member i in Member.memberData)
                {//find member
                    if (i.getUsername() == textboxUsername.Text && i.getPassword() == Member.hashSHA512(textboxPassword.Text))
                    {
                        //textBox init
                        isFind = true;
                        signinUsername = textboxUsername.Text;
                        Member.signinMember = i;
                        textboxPassword.Text = "password";
                        textboxPassword.ForeColor = Color.Gray;
                        textboxPassword.UseSystemPasswordChar = false;
                        textboxUsername.Text = "username";
                        textboxUsername.ForeColor = Color.Gray;
                        //open form to book film
                        formUser = new FormUser(this);
                        formUser.Show();
                        this.Hide();
                    }
                }
                if(isFind == false)
                {
                    MessageBox.Show("Something wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void textboxUsername_TextChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("C"+textboxUsername.Text.Length + "\n" + textboxUsername.Text);
            if (isCapitalized == false && textboxUsername.Text.Length > 0)
            {
                textboxUsername.Text = "";
                isCapitalized = true;
                //System.Diagnostics.Debug.WriteLine(isCapitalized.ToString()+textboxUsername.Text.ElementAt(textboxUsername.Text.Length - 1)+ l);
                //System.Diagnostics.Debug.WriteLine("D"+textboxUsername.Text.Length + "\n" + textboxUsername.Text);
            }
        }

        private void textboxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {//detect if press a~z
                MessageBox.Show("Each letter of username is capitalized\nError for : "+ e.KeyChar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //System.Diagnostics.Debug.WriteLine(textboxUsername.Text.Length+"\n"+ textboxUsername.Text);
                isCapitalized = false;
            }
            else
            {
                isCapitalized = true;
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            formSignup = new FormSignup(this);
            formSignup.Show();
            this.Hide();
        }

        private void FormSignin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit this program
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
