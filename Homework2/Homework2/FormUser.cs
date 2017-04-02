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
        {//use constructor to store parent
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
            panelSeat.Dock = DockStyle.Fill;
            panelFilm.Dock = DockStyle.Fill;
            
            //Film init
            Image imgFilm1 = Image.FromFile("../../pic/film/film1.jpg");
            btnFilm1.Text = "";
            btnFilm1.BackgroundImage = imgFilm1;
            btnFilm1.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm1.Cursor = Cursors.Hand;

            Image imgFilm2 = Image.FromFile("../../pic/film/film2.jpg");
            btnFilm2.Text = "";
            btnFilm2.BackgroundImage = imgFilm2;
            btnFilm2.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm2.Cursor = Cursors.Hand;

            Image imgFilm3 = Image.FromFile("../../pic/film/film3.jpg");
            btnFilm3.Text = "";
            btnFilm3.BackgroundImage = imgFilm3;
            btnFilm3.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm3.Cursor = Cursors.Hand;

            //page init
            panelSeat.Hide();
            panelFilm.Show();
            //Hello
            labelHello.Text = "Hello, " + FormSignin.signinUsername;
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
            panelSeat.Hide();
            panelFilm.Show();
        }

        private void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            getParent().Show();
        }
    }
}
