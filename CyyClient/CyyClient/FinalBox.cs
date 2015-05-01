using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CyyClient
{
    public partial class FinalBox : Form
    {
        private string splite = " ";
        List<Lottery> lotterys;
        List<Lottery> backLottery;

        List<Lottery11_3> lotterys11_3;
        List<Lottery11_3> backLottery11_3;

        public FinalBox(List<Lottery> lotterys, string splite)
            : this()
        {
            this.splite = splite;
            this.lotterys = lotterys;
            display(lotterys);
        }
        public FinalBox(List<Lottery11_3> lotterys11_3, string splite)
            : this()
        {
            this.splite = splite;
            this.lotterys11_3 = lotterys11_3;
            display(lotterys11_3);
        }
        public FinalBox()
        {
            InitializeComponent();
        }

        private string choosingFlag;

        private bool isFanxiang = false;
        
        //11选5
        public void display(List<Lottery> lotterys)
        {
            choosingFlag = "11选5";
            if (!isFanxiang)
            {
                this.Text = "11选5 共生成号码： " + lotterys.Count.ToString() + " 注";
                button2.Text = "反向采集";
                isFanxiang = true;
            }
            else
            {
                this.Text = "11选5 反向采集号码： " + lotterys.Count.ToString() + " 注";
                button2.Text = "还原查看";
                isFanxiang = false;
            }
            txtOutPut.Clear();
            foreach (Lottery tmp in lotterys)
            {
                txtOutPut.Text += (
                    (new StringBuilder())
                    .Append(tmp[0].ToString("D2")).Append(splite)
                    .Append(tmp[1].ToString("D2")).Append(splite)
                    .Append(tmp[2].ToString("D2")).Append(splite)
                    .Append(tmp[3].ToString("D2")).Append(splite)
                    .Append(tmp[4].ToString("D2")).Append("\r\n").ToString());
            }

        }

        // 11选3
        public void display(List<Lottery11_3> lotterys11_3)
        {
            choosingFlag = "11选3";

            if (!isFanxiang)
            {
                this.Text = "11选3 共生成号码： " + lotterys11_3.Count.ToString() + " 注";
                button2.Text = "反向采集";
                isFanxiang = true;
            }
            else
            {
                this.Text = "11选3 反向采集号码： " + lotterys11_3.Count.ToString() + " 注";
                button2.Text = "还原查看";
                isFanxiang = false;
            }
            txtOutPut.Clear();
            foreach (Lottery11_3 tmp in lotterys11_3)
            {
                txtOutPut.Text += (
                    (new StringBuilder())
                    .Append(tmp[0].ToString("D2")).Append(splite)
                    .Append(tmp[1].ToString("D2")).Append(splite)
                    .Append(tmp[2].ToString("D2")).Append("\r\n").ToString());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (!File.Exists(saveFileDialog1.FileName))
                {
                    using (FileStream fs = File.Create(saveFileDialog1.FileName))
                    {
                        string tmp = txtOutPut.Text;

                        /*
                        foreach (string s in listBox1.Items)
                        {
                            tmp += s + "\n";
                        }
                         */

                        byte[] info = new UTF8Encoding(true).GetBytes(tmp);
                        fs.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    MessageBox.Show("该文件已经存在");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tmp = txtOutPut.Text;
            /*
            foreach (string s in listBox1.Items)
            {
                tmp += s + "\n";
            }
             */
            Clipboard.SetDataObject(tmp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (choosingFlag.Equals("11选5"))
            {
                //display(null);
                txtOutPut.Clear();
                backLottery = Algorithm11_5.GetBaseLotterys();

                backLottery.RemoveAll(
                        delegate(Lottery lt)
                        {
                            if (lotterys.Contains(lt))
                            {
                                return true;
                            }

                            return false;
                        });
                display(backLottery);

                lotterys = backLottery;
            }
            else if (choosingFlag.Equals("11选3"))
            {
                txtOutPut.Clear();
                backLottery11_3 = Algorithm11_3.GetBaseLotterys11_3();

                backLottery11_3.RemoveAll(
                        delegate(Lottery11_3 lt)
                        {
                            if (lotterys11_3.Contains(lt))
                            {
                                return true;
                            }

                            return false;
                        });
                display(backLottery11_3);

                lotterys11_3 = backLottery11_3;
            }
        }
    }
}