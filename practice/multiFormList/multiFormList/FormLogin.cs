using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace multiFormList
{
    public partial class FormLogin : Form
    {
        const string USERNAME = "admin";
        const string PASSWORD = "0000";
        public static string username;
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            username = "";
            textBox1.Text = "";
            textBox2.Text = "";
            CenterToScreen();
            textBox2.UseSystemPasswordChar = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == USERNAME && textBox2.Text == PASSWORD)
            {
                username = USERNAME;
                this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username = "";
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username = "";
            textBox1.Text = "";
            textBox2.Text = "";
            this.Close();
        }
    }
}
