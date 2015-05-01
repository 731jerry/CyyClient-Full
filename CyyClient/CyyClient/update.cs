using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CyyClient
{
    public partial class update : Form
    {
        private string urlName;

        Stream srm;
        StreamReader srmReader;

        public update(string name)
        {
            InitializeComponent();
            urlName = name;
        }

        public update(string name, string version, string updateLog)
        {
            InitializeComponent();
            urlName = name;
            textBox1.Text = updateLog;
            this.Text = "彩盈盈自动更新";
            updateLabel.Text = "正在更新版本" + version + ", 请勿关闭更新并稍等...";
        }

        public void GetNewVersion()
        {
            try
            {
                WebClient wcClient = new WebClient();

                long fileLength = 0;

                string updateFileUrl = urlName;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                srm = webRes.GetResponseStream();
                srmReader = new StreamReader(srm);

                byte[] bufferbyte = new byte[fileLength];
                int allByte = (int)bufferbyte.Length;
                int startByte = 0;
                while (fileLength > 0)
                {
                    Application.DoEvents();
                    int downByte = srm.Read(bufferbyte, startByte, allByte);
                    if (downByte == 0) { break; };
                    startByte += downByte;
                    allByte -= downByte;
                    pbDownFile.Value += downByte;

                    Text = "彩盈盈自动更新 [" + Convert.ToInt32(pbDownFile.Value / (float)pbDownFile.Maximum * 100) + "%]";

                    // float part = (float)startByte / 1024;
                    //float total = (float)bufferbyte.Length / 1024;
                    //int percent = Convert.ToInt32((part / total) * 100);

                }

                using (FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"\new.exe", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                }

                srm.Close();
                srmReader.Close();

                this.Close();
                CyyMain.cyyMainExit();

                Process.Start(System.Environment.CurrentDirectory + @"\new.exe");
            }
            catch (Exception e)
            {
                if (MessageBox.Show("(" + urlName + ")错误信息:" + e.Message, "更新出现错误", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    CyyMain.cyyMainExit();
                }
            }
        }

        private void update_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void update_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            GetNewVersion();
        }

        private void update_FormClosing(object sender, FormClosingEventArgs e)
        {
            //srm.Close();
            //srmReader.Close();
            //base.OnFormClosing(e);
            //this.Close();
        }

        private bool isDetailClicked = false;

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isDetailClicked)
            {
                button3.Text = "关闭查看";
                textBox1.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + 90);
                isDetailClicked = true;
            }
            else
            {
                button3.Text = "查看更新记录";
                textBox1.Visible = false;
                this.Size = new Size(this.Size.Width, this.Size.Height - 90);
                isDetailClicked = false;
            }
        }
    }
}
