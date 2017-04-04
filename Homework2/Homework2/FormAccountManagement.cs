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
    public partial class FormAccountManagement : Form
    {
        private Form _parent;
        Dictionary<string, string> initString = new Dictionary<string, string>();

        public FormAccountManagement()
        {
            InitializeComponent();
        }
        public FormAccountManagement(Form parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        public Form getParent()
        {
            return this._parent;
        }

        private void FormAccountManagement_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Image imgDelete = Image.FromFile("../../pic/btn/btn_delete.png");
            btnDelete.Text = "";
            btnDelete.Image = imgDelete;
            btnDelete.Height = imgDelete.Height + 4;
            btnDelete.Width = imgDelete.Width + 4;
            btnDelete.Cursor = Cursors.Hand;

            //textbox init
            initString.Add(textBoxOld.Name, "old password");
            initString.Add(textBoxNew0.Name, "new password");
            initString.Add(textBoxNew1.Name, "confirm new password");
            textBoxOld.Text = "old password";
            textBoxOld.ForeColor = Color.Gray;
            textBoxNew0.UseSystemPasswordChar = false;

            textBoxNew0.Text = "new password";
            textBoxNew0.ForeColor = Color.Gray;
            textBoxNew0.UseSystemPasswordChar = false;
            textBoxNew0.Leave += textBoxOld_Leave;
            textBoxNew0.Enter += textBoxOld_Enter;

            textBoxNew1.Text = "confirm new password";
            textBoxNew1.ForeColor = Color.Gray;
            textBoxNew1.UseSystemPasswordChar = false;
            textBoxNew1.Leave += textBoxOld_Leave;
            textBoxNew1.Enter += textBoxOld_Enter;
        }

        private void textBoxOld_Leave(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            if (thisTextBox.Text == "")
            {
                foreach (var OneItem in initString)
                {
                    if(OneItem.Key == thisTextBox.Name)
                    {
                        thisTextBox.Text = OneItem.Value;
                    }
                }
                thisTextBox.ForeColor = Color.Gray;
                thisTextBox.UseSystemPasswordChar = false;
            }
        }

        private void textBoxOld_Enter(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            if (thisTextBox.Text == "old password" || thisTextBox.Text == "new password" || thisTextBox.Text == "confirm new password")
            {
                thisTextBox.Text = "";
                thisTextBox.ForeColor = Color.Black;
                thisTextBox.UseSystemPasswordChar = true;
            }
        }

        private void FormAccountManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            getParent().Show();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Member.hashSHA512(textBoxOld.Text) == Member.signinMember.getPassword() && textBoxNew0.Text == textBoxNew1.Text)
            {
                Member.signinMember.setPassword(textBoxNew1.Text);
                MessageBox.Show("Save success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult warning = MessageBox.Show("Delete this account?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warning == DialogResult.Yes)
            {
                Member.signinMember.setFilm(-1);
                Member.signinMember.setSeatNumber(-1);
                for(int index = 0; index < Member.memberData.Count; index++)
                {
                    if(Member.memberData.ElementAt(index) == Member.signinMember)
                    {
                        Member.memberData.RemoveAt(index);
                        break;
                    }
                }
                Member.signinMember = null;
                MessageBox.Show("Delete success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                getParent().Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
