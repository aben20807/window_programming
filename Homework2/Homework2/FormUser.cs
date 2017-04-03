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
            //Film image init
            Image imgFilm0 = Image.FromFile("../../pic/film/film1.jpg");
            btnFilm0.Text = "";
            btnFilm0.BackgroundImage = imgFilm0;
            btnFilm0.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm0.Cursor = Cursors.Hand;

            Image imgFilm1 = Image.FromFile("../../pic/film/film2.jpg");
            btnFilm1.Text = "";
            btnFilm1.BackgroundImage = imgFilm1;
            btnFilm1.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm1.Cursor = Cursors.Hand;

            Image imgFilm2 = Image.FromFile("../../pic/film/film3.jpg");
            btnFilm2.Text = "";
            btnFilm2.BackgroundImage = imgFilm2;
            btnFilm2.BackgroundImageLayout = ImageLayout.Zoom;
            btnFilm2.Cursor = Cursors.Hand;

            //seat init
            seatInForm = this.panelSeat.Controls.OfType<Button>().ToList();
            foreach(Button i in seatInForm)
            {
                i.BackColor = Color.Green;
                i.MouseDown += button0_MouseDown;
            }
            seat[0] = button0;      seat[1] = button1;      seat[2] = button2;
            seat[3] = button3;      seat[4] = button4;      seat[5] = button5;
            seat[6] = button6;      seat[7] = button7;      seat[8] = button8;
            seat[9] = button9;      seat[10] = button10;    seat[11] = button11;
            seat[12] = button12;    seat[13] = button13;    seat[14] = button14;
            seat[15] = button15;    seat[16] = button16;    seat[17] = button17;
            seat[18] = button18;    seat[19] = button19;    seat[20] = button20;
            seat[21] = button21;    seat[22] = button22;    seat[23] = button23;
            seat[24] = button24;    seat[25] = button25;    seat[26] = button26;
            seat[27] = button27;    seat[28] = button28;    seat[29] = button29;
            seat[30] = button30;    seat[31] = button31;    seat[32] = button32;
            seat[33] = button33;    seat[34] = button34;    seat[35] = button35;
            seat[36] = button36;    seat[37] = button37;    seat[38] = button38;
            seat[39] = button39;    seat[40] = button40;    seat[41] = button41;

            //member init
            foreach (Member i in Member.memberData)
            {
                if(i.getSeatNumber() != -1)
                {
                    seat[i.getSeatNumber()].BackColor = Color.Gray;
                    if (i.getUsername() == Member.signinMember.getUsername())
                    {
                        seat[i.getSeatNumber()].BackColor = Color.Red;
                    }
                    System.Diagnostics.Debug.WriteLine(i.getSeatNumber());
                }
            }
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
            getParent().Show();
            this.Dispose();
        }

        private void btnFilm1_Click(object sender, EventArgs e)
        {
            Button thisFilm = (Button)sender;
            int thisFilmNumber = (int)thisFilm.Name.ElementAt(thisFilm.Name.Length - 1) - '0';
            if (Member.signinMember.getFilm() != -1 && Member.signinMember.getFilm() != thisFilmNumber)
            {
                DialogResult warning = MessageBox.Show("Has been chosen film, cancel last booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warning == DialogResult.Yes)
                {
                    Member.signinMember.setFilm(-1);
                    Member.signinMember.setSeatNumber(-1);
                    panelSeat.Show();
                    panelFilm.Hide();
                }
            }
            else
            {
                Member.signinMember.setFilm(thisFilmNumber);
                //chosen seat
                panelSeat.Show();
                panelFilm.Hide();
                //System.Diagnostics.Debug.WriteLine(Member.signinMember.getFilm());
            }
            
        }
        private void button0_MouseDown(object sender, MouseEventArgs e)
        {
            Button thisSeat = (Button)sender;
            if (e.Button == MouseButtons.Left && thisSeat.BackColor == Color.Green)
            {
                DialogResult check = MessageBox.Show("Are you sure to select this seat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    foreach (Button i in seatInForm)
                    {
                        if (i.BackColor == Color.Red)
                        {
                            i.BackColor = Color.Green;
                        }
                    }
                    int thisSeatNumber;
                    int.TryParse(thisSeat.Name.Substring(6), out thisSeatNumber);
                    System.Diagnostics.Debug.WriteLine(thisSeatNumber);
                    Member.signinMember.setSeatNumber(thisSeatNumber);
                    thisSeat.BackColor = Color.Red;
                }
            }
            else if(e.Button == MouseButtons.Right && thisSeat.BackColor == Color.Red)
            {
                DialogResult check = MessageBox.Show("Are you sure to cancel this seat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (check == DialogResult.Yes)
                {
                    //System.Diagnostics.Debug.WriteLine(-1);
                    Member.signinMember.setSeatNumber(-1);
                    thisSeat.BackColor = Color.Green;
                }
            }
        }
    }
}
