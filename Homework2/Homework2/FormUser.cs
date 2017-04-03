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
        Button[] film = new Button[3];
        List<Button> seatInForm;
        Button[] seat = new Button[42];
        public static string[] filmName = new string[3];
        int thisFilmNumber;

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
            film[0] = btnFilm0;
            film[1] = btnFilm1;
            film[2] = btnFilm2;
            btnFilm1.Click += btnFilm1_Click;
            btnFilm2.Click += btnFilm1_Click;
            filmName[0] = "A Silent Voice";
            filmName[1] = "My Tomorrow, Your Yesterday";
            filmName[2] = "Ghost in the Shell";
            //Film image init
            Image imgFilm0 = Image.FromFile("../../pic/film/film0.jpg");
            btnFilm0.Text = "";
            btnFilm0.BackgroundImage = imgFilm0;
            btnFilm0.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm0.Cursor = Cursors.Hand;

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

            //trailer init
            ToolTip tooltip0 = new ToolTip();
            tooltip0.IsBalloon = true;
            tooltip0.SetToolTip(labelFilm0, "Trailer in YouTube");
            ToolTip tooltip1 = new ToolTip();
            tooltip1.IsBalloon = true;
            tooltip1.SetToolTip(labelFilm1, "Trailer in YouTube");
            ToolTip tooltip2 = new ToolTip();
            tooltip2.IsBalloon = true;
            tooltip2.SetToolTip(labelFilm2, "Trailer in YouTube");

            //seat init
            seatInForm = this.panelSeat.Controls.OfType<Button>().ToList();
            foreach(Button i in seatInForm)
            {//seat[i] = buttoni
                int seatNumber;
                int.TryParse(i.Name.Substring(6), out seatNumber);
                seat[seatNumber] = i;
                System.Diagnostics.Debug.WriteLine(seatNumber + "=" + i.Name);
                i.MouseDown += button0_MouseDown;
            }
            //page init
            panelSeat.Hide();
            panelFilm.Show();
            //Hello
            labelHello.Text = "Hello, " + FormSignin.signinUsername;
            //Notification
            if(Member.signinMember.getNotification() != "")
            {
                MessageBox.Show(Member.signinMember.getNotification(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Member.signinMember.setNotification("");//clear notification
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccountManagement formAccountManagement = new FormAccountManagement(this);
            formAccountManagement.Show();
            this.Hide();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Member.signinMember.getSeatNumber() == -1 && panelSeat.Visible == true)
            {
                DialogResult warning = MessageBox.Show("Not yet selected seat, cancel this booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(warning == DialogResult.Yes)
                {
                    Member.signinMember.setFilm(-1);
                    panelSeat.Hide();
                    panelFilm.Show();
                }
            }
            else
            {
                panelSeat.Hide();
                panelFilm.Show();
            }
        }

        private void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {//close, delete this form and call parent form
            Member.signinMember = null;
            getParent().Show();
            this.Dispose();
        }

        private void btnFilm1_Click(object sender, EventArgs e)
        {
            Button thisFilm = (Button)sender;
            thisFilmNumber = (int)thisFilm.Name.ElementAt(thisFilm.Name.Length - 1) - '0';
            changeSeatColor(thisFilmNumber);
            panelSeat.Show();
            panelFilm.Hide();
        }
        private void changeSeatColor(int film)
        {
            foreach (Button i in seatInForm)
            {
                i.BackColor = Color.LightGreen;
            }
            foreach (Member i in Member.memberData)
            {
                if (i.getSeatNumber() != -1 && i.getFilm() == film)
                {
                    seat[i.getSeatNumber()].BackColor = Color.Gray;
                    if (Member.signinMember != null && i.getUsername() == Member.signinMember.getUsername())
                    {
                        seat[i.getSeatNumber()].BackColor = Color.Red;
                    }
                    //System.Diagnostics.Debug.WriteLine(i.getSeatNumber());
                }
            }
        }
        private void button0_MouseDown(object sender, MouseEventArgs e)
        {//select seat
            Button thisSeat = (Button)sender;
            int thisSeatNumber;
            int.TryParse(thisSeat.Name.Substring(6), out thisSeatNumber);
            if (e.Button == MouseButtons.Left && thisSeat.BackColor == Color.LightGreen)
            {
                if (Member.signinMember.getFilm() != -1 && Member.signinMember.getFilm() != thisFilmNumber)
                {
                    DialogResult warning = MessageBox.Show("Has been chosen film, cancel last booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (warning == DialogResult.Yes)
                    {
                        Member.signinMember.setFilm(thisFilmNumber);
                        Member.signinMember.setSeatNumber(thisSeatNumber);
                        thisSeat.BackColor = Color.Red;
                        MessageBox.Show("Your movie is " + filmName[thisFilmNumber] + "\nYour seat is "+ (thisSeatNumber/14+1) + " row from the top, "+ (thisSeatNumber%14+1) + " from the right",
                            "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult check = MessageBox.Show("Are you sure to select this seat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (check == DialogResult.Yes)
                    {
                        foreach (Button i in seatInForm)
                        {//cancel other seat
                            if (i.BackColor == Color.Red)
                            {
                                i.BackColor = Color.LightGreen;
                            }
                        }
                        //System.Diagnostics.Debug.WriteLine(thisSeatNumber);
                        Member.signinMember.setFilm(thisFilmNumber);
                        Member.signinMember.setSeatNumber(thisSeatNumber);
                        thisSeat.BackColor = Color.Red;
                        MessageBox.Show("Your movie is " + filmName[thisFilmNumber] + "\nYour seat is " + (thisSeatNumber / 14 + 1) + " row from the top, " + (thisSeatNumber % 14 + 1) + " from the right",
                            "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if(e.Button == MouseButtons.Right && thisSeat.BackColor == Color.Red)
            {
                DialogResult check = MessageBox.Show("Are you sure to cancel this seat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    //System.Diagnostics.Debug.WriteLine(-1);
                    Member.signinMember.setFilm(-1);
                    Member.signinMember.setSeatNumber(-1);
                    thisSeat.BackColor = Color.LightGreen;
                }
            }
        }

        private void labelFilm0_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=LxdyE4dp2lE");
        }

        private void labelFilm1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=_Jks1gExvOw");
        }

        private void labelFilm2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=ci4w2fQ0fv0");
        }
    }
}
