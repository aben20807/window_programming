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
    public partial class FormSupervisor : Form
    {
        private FormSignin _parent;
        Button[] film = new Button[3];
        List<Button> seatInForm;
        Button[] seat = new Button[42];
        int thisFilmNumber;
        public FormSupervisor(FormSignin parent)
        {
            InitializeComponent();
            this._parent = parent;
        }
        public FormSignin getParent()
        {
            return this._parent;
        }

        private void FormSupervisor_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            panelSeat.Dock = DockStyle.Fill;
            

            //Film btn init
            film[0] = btnFilm0;
            film[1] = btnFilm1;
            film[2] = btnFilm2;
            btnFilm1.Click += btnFilm0_Click;
            btnFilm2.Click += btnFilm0_Click;

            FormUser.filmName[0] = "A Silent Voice";
            FormUser.filmName[1] = "My Tomorrow, Your Yesterday";
            FormUser.filmName[2] = "Ghost in the Shell";

            //seat init
            seatInForm = this.panelSeat.Controls.OfType<Button>().ToList();
            for(int index = 0; index < seatInForm.Count(); index++)
            {//seat[i] = buttoni
                Button i = seatInForm.ElementAt(index);
                if (i.Name == "btnFilm0" || i.Name == "btnFilm1" || i.Name == "btnFilm2")
                {
                    seatInForm.RemoveAt(index);
                    index--;
                    continue;
                }
                int seatNumber;
                int.TryParse(i.Name.Substring(6), out seatNumber);
                seat[seatNumber] = i;
                //System.Diagnostics.Debug.WriteLine(seatNumber + "=" + i.Name);
                i.MouseDown += button0_MouseDown;
            }
            changeSeatColor(0);
        }

        private void btnFilm0_Click(object sender, EventArgs e)
        {
            Button thisFilm = (Button)sender;
            thisFilmNumber = (int)thisFilm.Name.ElementAt(thisFilm.Name.Length - 1) - '0';
            changeSeatColor(thisFilmNumber);
        }

        private void button0_MouseDown(object sender, MouseEventArgs e)
        {
            Button thisSeat = (Button)sender;
            if (thisSeat.BackColor == Color.Gray)
            {
                int thisSeatNumber;
                int.TryParse(thisSeat.Name.Substring(6), out thisSeatNumber);
                DialogResult warning = MessageBox.Show("Cancel this booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warning == DialogResult.Yes)
                {
                    foreach(Member i in Member.memberData)
                    {
                        if(i.getFilm() == thisFilmNumber && i.getSeatNumber() == thisSeatNumber)
                        {
                            i.setFilm(-1);
                            i.setSeatNumber(-1);
                            i.setNotification("Your movie " + FormUser.filmName[thisFilmNumber] + "\nand seat is " + (thisSeatNumber / 14 + 1) + " row from the top, " + (thisSeatNumber % 14 + 1) + " from the right\nhad been cancelled. Please check.");
                            thisSeat.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void changeSeatColor(int film)
        {
            labelPlaying.Text = "Playing : " + FormUser.filmName[film];
            foreach (Button i in seatInForm)
            {
                i.BackColor = Color.LightGreen;
            }
            foreach (Member i in Member.memberData)
            {
                if (i.getSeatNumber() != -1 && i.getFilm() == film)
                {
                    seat[i.getSeatNumber()].BackColor = Color.Gray;
                    //add tooltip
                    ToolTip tooltip = new ToolTip();
                    tooltip.IsBalloon = true;
                    tooltip.SetToolTip(seat[i.getSeatNumber()], i.getUsername());
                    //System.Diagnostics.Debug.WriteLine(i.getSeatNumber());
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSupervisor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Member.signinMember = null;
            getParent().Show();
            this.Dispose();
        }

        private void bookingManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSeat.Show();
        }
    }
}
