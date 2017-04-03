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
            //
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
            Member m1 = new Member("JOHN", "123");
            Member m2 = new Member("BEN", "456");
            Member m3 = new Member("EVA", "789");
            Member.memberData.Add(m1);
            Member.memberData.Add(m2);
            Member.memberData.Add(m3);
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
            Application.Exit();
            Environment.Exit(0);
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            if(textboxUsername.Text == SUPERVISOR_USERNAME && textboxPassword.Text == SUPERVISOR_PASSWORD)
            {
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
            foreach(Member i in Member.memberData)
            {
                if(i.getUsername() == textboxUsername.Text && i.getPassword() == Member.hashSHA512(textboxPassword.Text))
                {
                    //textBox init
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
            {
                MessageBox.Show("Each letter of username is capitalized\nError for : "+ e.KeyChar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //System.Diagnostics.Debug.WriteLine(textboxUsername.Text.Length+"\n"+ textboxUsername.Text);
                isCapitalized = false;
            }
            else
            {
                isCapitalized = true;
            }
        }
    }
}
