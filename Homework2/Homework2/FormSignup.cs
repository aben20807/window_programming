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
    public partial class FormSignup : Form
    {
        private FormSignin _parent;
        private bool isCapitalized = true;
        public FormSignup(FormSignin parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        public FormSignin getParent()
        {
            return this._parent;
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            //button init
            Image imgSignup = Image.FromFile("../../pic/btn/btn_signUp.png");
            btnSignup.Text = "";
            btnSignup.Image = imgSignup;
            btnSignup.Height = imgSignup.Height + 4;
            btnSignup.Width = imgSignup.Width + 4;
            btnSignup.Cursor = Cursors.Hand;
            //textbox init
            textboxUsername.Text = "username";
            textboxUsername.ForeColor = Color.Gray;

            textboxPassword.Text = "password";
            textboxPassword.ForeColor = Color.Gray;
            textboxPassword.UseSystemPasswordChar = false;
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
                MessageBox.Show("Each letter of username is capitalized\nError for : " + e.KeyChar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //System.Diagnostics.Debug.WriteLine(textboxUsername.Text.Length+"\n"+ textboxUsername.Text);
                isCapitalized = false;
            }
            else
            {
                isCapitalized = true;
            }
        }

        private void FormSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            getParent().Show();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            bool isExist = false;
            foreach(Member i in Member.memberData)
            {
                if(textboxUsername.Text == i.getUsername())
                {
                    isExist = true;
                    break;
                }
            }
            if(isExist == true)
            {
                MessageBox.Show("This username has existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textboxUsername.Text = "";
            }
            else
            {
                Member.memberData.Add(new Member(textboxUsername.Text, textboxPassword.Text));
                MessageBox.Show("Sign up success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
