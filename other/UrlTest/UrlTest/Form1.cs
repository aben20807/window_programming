using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace UrlTest
{
    public partial class Form1 : Form
    {
        List<string> url = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Wait...";
            string urlAddress = textBoxUrl.Text;
            if(urlAddress == "")
            {
                MessageBox.Show("Nothing in url", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();
                    textBoxStatus.Text += "HTML code load success"+ Environment.NewLine;
                    textBoxStatus.Text += "Finding...."+ Environment.NewLine;
                    for (int i = 0; i < checkedListBoxVideo.Items.Count; i++)
                    {
                        if(checkedListBoxVideo.GetItemChecked(i) == true)
                        {
                            url.Add(find(data, checkedListBoxVideo.GetItemText(checkedListBoxVideo.Items[i])));
                            //System.Diagnostics.Debug.WriteLine(checkedListBoxVideo.GetItemText(checkedListBoxVideo.Items[i]));
                        }
                    }

                    textBoxStatus.Text += "Finished"+ Environment.NewLine;
                    //string url = find(data, "mp4");
                    labelStatus.Text = "Finished";
                    
                    //System.Diagnostics.Debug.WriteLine(url);
                    response.Close();
                    readStream.Close();
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxStatus.Text = "Status";
        }

        private string find(string data, string key)
        {
            labelStatus.Text = "Wait....";
            string result = "";
            int wordCount = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if((data.ElementAt(i) >= 'a' && data.ElementAt(i) <= 'z') ||
                    (data.ElementAt(i) >= 'A' && data.ElementAt(i) <= 'Z') ||
                    (data.ElementAt(i) >= '0' && data.ElementAt(i) <= '9'))
                {
                    wordCount++;
                }
                else
                {
                    if(wordCount != 0 &&
                        data.ElementAt(i - 4) == '.' &&
                        data.ElementAt(i - 3) == key.ElementAt(0) &&
                        data.ElementAt(i - 2) == key.ElementAt(1) &&
                        data.ElementAt(i - 1) == key.ElementAt(2))
                    {
                        int start = -1;
                        for(int j = i-1; j >= 0; j--)
                        {
                            if(data.ElementAt(j) == '\'' || data.ElementAt(j) == '\"')
                            {
                                start = j;
                                break;
                            }
                        }
                        for(int j = start+1; data.ElementAt(j) != '\'' && data.ElementAt(j) != '\"'; j++)
                        {
                            result += data.ElementAt(j);
                        }
                    }
                    wordCount = 0;
                }
            }
            return result;
        }

        private void buttonOpenall_Click(object sender, EventArgs e)
        {
            foreach(string i in url)
            {
                if(i != "")
                {
                    System.Diagnostics.Process.Start('\"' + i + '\"');
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                for (int j = 0; j < checkedListBoxVideo.Items.Count; j++)
                    checkedListBoxVideo.SetItemChecked(j, true);
            }
            else
            {
                for (int j = 0; j < checkedListBoxVideo.Items.Count; j++)
                    checkedListBoxVideo.SetItemChecked(j, false);
            }
        }
    }
}
