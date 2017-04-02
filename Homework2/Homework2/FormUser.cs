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
    public partial class FormUser : Form
    {
        private FormSignin _parent;
        public FormUser()
        {
            InitializeComponent();
        }

        public FormUser(FormSignin parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        public FormSignin getParent()
        {
            return this._parent;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            //panelSeat.Hide();
            panelMovie.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSeat.Show();
            panelMovie.Hide();
        }

        private void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            getParent().Show();
        }
    }
}
