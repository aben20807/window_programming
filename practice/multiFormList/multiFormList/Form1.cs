using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace multiFormList
{
    public partial class Form1 : Form
    {
        FormLogin fl = new FormLogin();
        FormNew fn = new FormNew();
        List<string> studentNumber = new List<string>();
        List<string> studentName = new List<string>();
        public Form1()
        {
            InitializeComponent();
            buttonLogin.Text = "登入";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            buttonNew.Enabled = false;
            buttonFind.Enabled = false;
            buttonDelete.Enabled = false;
            textBox1.Enabled = false;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(buttonLogin.Text == "登入")
            {
                fl.ShowDialog(this);
                String username = FormLogin.username;
                if (username != "")
                {
                    labelStatus.Text = "歡迎回來，" + username;
                    buttonNew.Enabled = true;
                    buttonFind.Enabled = true;
                    buttonDelete.Enabled = true;
                    textBox1.Enabled = true;
                    buttonLogin.Text = "登出";
                    textBox1.Focus();
                }
            }
            else
            {
                textBox1.Text = "";
                buttonNew.Enabled = false;
                buttonFind.Enabled = false;
                buttonDelete.Enabled = false;
                textBox1.Enabled = false;
                labelStatus.Text = "尚未登入";
                buttonLogin.Text = "登入";
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                fn.ShowDialog(this);
                int count = 0;
                foreach (String number in studentNumber)//check if data exist
                {
                    if (number == textBox1.Text)//delete exist data to overwrite
                    {
                        studentName.RemoveAt(count);
                        studentNumber.RemoveAt(count);  
                        break;
                    }
                    count++;
                }
                if(FormNew.newsucc == true)
                {
                    studentNumber.Add(textBox1.Text);
                    studentName.Add(FormNew.name);
                    MessageBox.Show("新增成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("學號不能為空", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool isFind = false;
                int count = 0;
                foreach(string number in studentNumber)
                {
                    if(number == textBox1.Text)
                    {
                        isFind = true;
                        MessageBox.Show("學號 "+ textBox1.Text+"對應的名字是 "+studentName[count], "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.None);
                        break;
                    }
                    count++;
                }
                if (isFind == false)
                {
                    MessageBox.Show("無此筆資料!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("學號不能為空", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool isFind = false;
                int count = 0;
                foreach (String number in studentNumber)
                {
                    if (number == textBox1.Text)
                    {
                        isFind = true;
                        studentName.RemoveAt(count);
                        studentNumber.RemoveAt(count);
                        MessageBox.Show("資料已刪除", "刪除成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                        break;
                    }
                    count++;
                }
                if (isFind == false)
                {
                    MessageBox.Show("無此筆資料!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("學號不能為空", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
