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
        //public FormSignin formSignin = new FormSignin();
        public FormUser formUser;// = new FormUser(this);
        public FormSupervisor formSupervisor = new FormSupervisor();
        List<Member> memberData = new List<Member>();
        public FormSignin()
        {
            InitializeComponent();
        }
        private void FormSignin_Load(object sender, EventArgs e)
        {
            formUser = new FormUser(this);
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
            Member m1 = new Member("John", "123");
            Member m2 = new Member("Ben", "456");
            Member m3 = new Member("Eva", "789");
            memberData.Add(m1);
            memberData.Add(m2);
            memberData.Add(m3);
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
            foreach(Member i in memberData)
            {
                if(i.getUsername() == textboxUsername.Text && i.getPassword() == textboxPassword.Text)
                {
                    formUser = new FormUser(this);
                    formUser.Show();
                    this.Hide();
                }
            }
        }
    }
}
