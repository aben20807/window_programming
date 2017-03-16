using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //to collect page item
        List<Control> all = new List<Control>();
        List<Control> pageStart = new List<Control>();
        List<Control> pageLogin = new List<Control>();
        List<Control> pageNew = new List<Control>();
        List<Control> pageFind = new List<Control>();
        List<Control> pageDelete = new List<Control>();
        List<TextBox> textBox = new List<TextBox>();

        //to store data
        List<String> id = new List<String>();
        List<String> gender = new List<String>();
        List<String> phone = new List<String>();
        List<String> address = new List<String>();

        private void button1_Click(object sender, EventArgs e)//login
        {
            if (textBox1.Text == "Supervi" && textBox2.Text == "123456")
            {
                MessageBox.Show("登入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";//clear account, password
                textBox2.Text = "";
                foreach (Control i in all)
                {
                    i.Visible = false;
                }
                foreach(Control i in pageLogin)
                {
                    i.Visible = true;
                }
                foreach (TextBox i in textBox)
                {
                    i.Text = "";
                }
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤\n試試\n帳號：Supervi\n密碼：123456", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)//change to new page
        {
            labelNew.Text = "";
            labelFind.Text = "";
            foreach (Control i in all)
            {
                i.Visible = false;
            }
            foreach (Control i in pageNew)
            {
                i.Visible = true;
            }
            foreach (TextBox i in textBox)
            {
                i.Text = "";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)//new data
        {
            labelNew.Text = "";
            labelFind.Text = "";
            if (textBoxId.Text == "" ||
                textBoxGender.Text == "" ||
                textBoxPhone.Text == "" ||
                textBoxAddress.Text == "")//check if any textBox is nothing
            {
                labelNew.Text = "各欄位不能為空，請重新輸入";
            }
            else
            {
                bool isExist = false;
                foreach (String i in id)//check if data exist
                {
                    if (i == textBoxId.Text)
                    {
                        labelNew.Text = "資料已存在";
                        isExist = true;
                    }
                }
                if (isExist == false)
                {
                    id.Add(textBoxId.Text);
                    gender.Add(textBoxGender.Text);
                    phone.Add(textBoxPhone.Text);
                    address.Add(textBoxAddress.Text);
                    labelNew.Text = "資料已存入\n目前已有" + id.Count + "筆資料!!";
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)//logout
        {
            labelNew.Text = "";
            labelFind.Text = "";
            foreach (Control i in all)
            {
                i.Visible = false;
            }
            foreach(Control i in pageStart)
            {
                i.Visible = true;
            }
            foreach (TextBox i in textBox)
            {
                i.Text = "";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)//change to find page
        {
            labelNew.Text = "";
            labelFind.Text = "";
            foreach (Control i in all)
            {
                i.Visible = false;
            }
            foreach (Control i in pageFind)
            {
                i.Visible = true;
            }
            labelGender.Visible = false;
            labelPhone.Visible = false;
            labelAddress.Visible = false;
            textBoxGender.Visible = false;
            textBoxPhone.Visible = false;
            textBoxAddress.Visible = false;
            foreach (TextBox i in textBox)
            {
                i.Text = "";
            }
        }

        private void btnFindData_Click(object sender, EventArgs e)//find data
        {
            labelNew.Text = "";
            labelFind.Text = "";
            if (textBoxId.Text == "")//check if input is nothing
            {
                labelFind.Text = "欄位不能為空!";
            }
            else
            {
                bool isFind = false;
                int count = 0;
                foreach(String i in id)
                {
                    if(i == textBoxId.Text)
                    {
                        isFind = true;
                        labelGender.Visible = true;
                        labelPhone.Visible = true;
                        labelAddress.Visible = true;
                        textBoxGender.Visible = true;
                        textBoxPhone.Visible = true;
                        textBoxAddress.Visible = true;
                        
                        textBoxGender.Text = gender.ElementAt(count);
                        textBoxPhone.Text = phone.ElementAt(count);
                        textBoxAddress.Text = address.ElementAt(count);
                    }
                    count++;
                }
                if(isFind == false)
                {
                    labelFind.Text = "無此筆資料";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)//change to delete page
        {
            labelNew.Text = "";
            labelFind.Text = "";
            foreach (Control i in all)
            {
                i.Visible = false;
            }
            foreach (Control i in pageDelete)
            {
                i.Visible = true;
            }
            foreach (TextBox i in textBox)
            {
                i.Text = "";
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)//delete data
        {
            bool isFind = false;
            int count = 0;
            foreach (String i in id)
            {
                if (i == textBoxId.Text)
                {
                    isFind = true;
                    labelGender.Visible = false;
                    labelPhone.Visible = false;
                    labelAddress.Visible = false;
                    textBoxGender.Visible = false;
                    textBoxPhone.Visible = false;
                    textBoxAddress.Visible = false;

                    gender.RemoveAt(count);
                    phone.RemoveAt(count);
                    address.RemoveAt(count);
                    id.RemoveAt(count);
                    break;
                }
                count++;
            }
            if (isFind == false)
            {
                labelFind.Text = "無此筆資料";
            }
            else
            {
                labelFind.Text = "刪除成功!!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)//collect item
        {
            //textBox
            textBox.Add(textBoxId);
            textBox.Add(textBoxGender);
            textBox.Add(textBoxPhone);
            textBox.Add(textBoxAddress);
            //pageStart
            pageStart.Add(label1);
            pageStart.Add(label2);
            pageStart.Add(textBox1);
            pageStart.Add(textBox2);
            pageStart.Add(button1);
            //pageLogin
            pageLogin.Add(btnNew);
            pageLogin.Add(btnFind);
            pageLogin.Add(btnDelete);
            pageLogin.Add(btnLogout);
            //pageNew
            pageNew.Add(labelId);
            pageNew.Add(labelGender);
            pageNew.Add(labelPhone);
            pageNew.Add(labelAddress);
            pageNew.Add(textBoxId);
            pageNew.Add(textBoxGender);
            pageNew.Add(textBoxPhone);
            pageNew.Add(textBoxAddress);
            pageNew.Add(btnOk);
            pageNew.Add(btnNew);
            pageNew.Add(btnFind);
            pageNew.Add(btnDelete);
            pageNew.Add(btnLogout);
            //pageFind
            pageFind.Add(btnNew);
            pageFind.Add(btnFind);
            pageFind.Add(btnDelete);
            pageFind.Add(btnLogout);
            pageFind.Add(labelId);
            pageFind.Add(labelGender);
            pageFind.Add(labelPhone);
            pageFind.Add(labelAddress);
            pageFind.Add(textBoxId);
            pageFind.Add(textBoxGender);
            pageFind.Add(textBoxPhone);
            pageFind.Add(textBoxAddress);
            pageFind.Add(btnFindData);
            //pageDelete
            pageDelete.Add(btnNew);
            pageDelete.Add(btnFind);
            pageDelete.Add(btnDelete);
            pageDelete.Add(btnLogout);
            pageDelete.Add(labelId);
            pageDelete.Add(textBoxId);
            pageDelete.Add(btnDeleteData);
            //all
            all.AddRange(pageStart);
            all.AddRange(pageLogin);
            all.AddRange(pageNew);
            all.AddRange(pageFind);
            all.AddRange(pageDelete);
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {//clear label
            labelNew.Text = "";
            labelFind.Text = "";
        }

        private void textBoxGender_TextChanged(object sender, EventArgs e)
        {//clear label
            labelNew.Text = "";
            labelFind.Text = "";
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {//clear label
            labelNew.Text = "";
            labelFind.Text = "";
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {//clear label
            labelNew.Text = "";
            labelFind.Text = "";
        }
    }
}
