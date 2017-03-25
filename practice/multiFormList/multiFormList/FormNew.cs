using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace multiFormList
{
    public partial class FormNew : Form
    {
        public static string name;
        public static bool newsucc;
        public FormNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                name = textBox1.Text;
                newsucc = true;
                textBox1.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("姓名不能為空", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            newsucc = false;
            this.Close();
        }

        private void FormNew_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
