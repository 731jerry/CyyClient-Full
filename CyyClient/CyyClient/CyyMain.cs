using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Skybound.Gecko;
using System.Drawing.Drawing2D;
using ControlExs;
using System.Net;
using System.Linq;

//using mshtml;
//using SHDocVw;

namespace CyyClient
{
    public partial class CyyMain : ControlExs.FormEx
    {
        #region Public setting
        public int topbarHeight = 120;
        public float productVersion = 2.2f;
        public int mainPageHeight = 580;

        #endregion

        #region Override

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    cp.ExStyle |= (int)WindowStyle.WS_CLIPCHILDREN;
                }
                return cp;
            }
        }

        /*
         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);
           //  DrawFromAlphaMainPart(this, e.Graphics);
             //DrawControlPanel(this.tabPage1, this.tabPage1.CreateGraphics());
         }
         */
        #endregion

        #region Private

        public static void cyyMainExit()
        {
            CyyDatabase.cyyDB.DeleteDateNow(USERID);
            CyyDatabase.cyyDB.DbClose();
            Application.Exit();
        }
        public static void DrawControlPanel(TabPage tabPage, Graphics g)
        {
            Color[] colors = 
            {
                Color.FromArgb(5, Color.Black),
                Color.FromArgb(30, Color.Black),
                Color.FromArgb(145, Color.Black),
                Color.FromArgb(150, Color.Black),
                Color.FromArgb(30, Color.Black),
                Color.FromArgb(5, Color.Black)
            };

            float[] pos = 
            {
                0.0f,
                0.04f,
                0.10f,
                0.90f,
                0.97f,
                1.0f      
            };

            ColorBlend colorBlend = new ColorBlend(6);
            colorBlend.Colors = colors;
            colorBlend.Positions = pos;

            RectangleF destRect = new RectangleF(0, 0, tabPage.Width, tabPage.Height);
            using (LinearGradientBrush lBrush = new LinearGradientBrush(destRect, colors[0], colors[5], LinearGradientMode.Vertical))
            {
                lBrush.InterpolationColors = colorBlend;
                g.FillRectangle(lBrush, destRect);
            }
        }
        /// <summary>
        /// 绘制窗体主体部分白色透明层
        /// </summary>
        /// <param name="form"></param>
        /// <param name="g"></param>
        public static void DrawFromAlphaMainPart(Form form, Graphics g)
        {
            /*
            Color[] colors = 
            {
                Color.FromArgb(5, Color.White),
                Color.FromArgb(30, Color.White),
                Color.FromArgb(145, Color.White),
                Color.FromArgb(150, Color.White),
                Color.FromArgb(30, Color.White),
                Color.FromArgb(5, Color.White)
            };
            */

            Color[] colors = 
            {
                Color.FromArgb(0, Color.White),
                Color.FromArgb(0, Color.White),
                Color.FromArgb(0, Color.White),
                Color.FromArgb(0, Color.White),
                Color.FromArgb(0, Color.White),
                Color.FromArgb(0, Color.White)
            };

            float[] pos = 
            {
                0.0f,
                0.04f,
                0.10f,
                0.90f,
                0.97f,
                1.0f      
            };

            ColorBlend colorBlend = new ColorBlend(6);
            colorBlend.Colors = colors;
            colorBlend.Positions = pos;

            RectangleF destRect = new RectangleF(0, 0, form.Width, form.Height);
            using (LinearGradientBrush lBrush = new LinearGradientBrush(destRect, colors[0], colors[5], LinearGradientMode.Vertical))
            {
                lBrush.InterpolationColors = colorBlend;
                g.FillRectangle(lBrush, destRect);
            }
        }


        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        #endregion

        public static string USERID { get; set; }

        GeckoWebBrowser Browser = new GeckoWebBrowser();
        GeckoWebBrowser Browser11_3 = new GeckoWebBrowser();

        private int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private CyyDatabase CyyDb = CyyDatabase.GetDatabase();
        private CyyLogin cyyLogin;

        /*
        List<TwoNum> SelectTwoNums = new List<TwoNum>();
        List<TwoNum> NotSelectTwoNums = new List<TwoNum>();
        */

        Microsoft.Win32.RegistryKey productKey;

        public static string productKeyNameString = ""; // 彩盈盈
        public static string productKeyVersionNameString = ""; // 精华版
        public static string proudctVersionString = ""; // 2.9

        public static string currentIP = "127.0.0.1";
        public static string currentAddress = "本地";

        List<string> LiangMaZuHeSelecteds = new List<string>();

        Algorithm11_5 A11_5 = new Algorithm11_5();
        Algorithm11_3 A11_3 = new Algorithm11_3();

        #region 表格编辑前 data值
        private string preDataOfLotteryInfo;
        #endregion

        #region 往期彩票信息
        public List<LotteryInfo> LotteryInfos { get; private set; }
        #endregion

        #region 当前彩票类型
        //11_5
        private CurrentLotteryTypeInfo11_5 currentLotteryTypeInfo11_5 { get; set; }
        private class CurrentLotteryTypeInfo11_5
        {
            private LotteryType11_5 lotteryType;
            public LotteryType11_5 Lottery_Type
            {
                get
                {
                    return lotteryType;
                }
                set
                {
                    lotteryType = value;

                    FileName = System.Environment.CurrentDirectory + @"\data\" + USERID + lotteryType.ToString() + @".dll";
                }
            }
            public string FileName { get; private set; }
            public CurrentLotteryTypeInfo11_5(LotteryType11_5 lotteryType)
            {
                Lottery_Type = lotteryType;
            }

            public int getCurrentTypeInt(LotteryType11_5 lt)
            {
                //SD_11_5 = 1, GD_11_5, JX_11_5, CQ_11_5, JS_11_5, ZJ_11_5, SH_11_5
                int type = 0;
                switch (lt)
                {
                    default:
                    case LotteryType11_5.SD_11_5:
                        type = 1;
                        break;
                    case LotteryType11_5.GD_11_5:
                        type = 2;
                        break;
                    case LotteryType11_5.JX_11_5:
                        type = 3;
                        break;
                    case LotteryType11_5.CQ_11_5:
                        type = 4;
                        break;
                    case LotteryType11_5.JS_11_5:
                        type = 5;
                        break;
                    case LotteryType11_5.ZJ_11_5:
                        type = 6;
                        break;
                    case LotteryType11_5.SH_11_5:
                        type = 7;
                        break;
                }
                return type;
            }
        }

        //11_3
        private CurrentLotteryTypeInfo11_3 currentLotteryTypeInfo11_3 { get; set; }
        private class CurrentLotteryTypeInfo11_3
        {
            private LotteryType11_3 lotteryType;
            public LotteryType11_3 Lottery_Type
            {
                get
                {
                    return lotteryType;
                }
                set
                {
                    lotteryType = value;

                    FileName = System.Environment.CurrentDirectory + @"\data\" + USERID + lotteryType.ToString() + @".dll";
                }
            }
            public string FileName { get; private set; }
            public CurrentLotteryTypeInfo11_3(LotteryType11_3 lotteryType)
            {
                Lottery_Type = lotteryType;
            }
            public int getCurrentTypeInt(LotteryType11_3 lt)
            {
                //SD_11_3 = 1, GD_11_3, JX_11_3, CQ_11_3, JS_11_3, ZJ_11_3, SH_11_3
                int type = 0;
                switch (lt)
                {
                    default:
                    case LotteryType11_3.SD_11_3:
                        type = 1;
                        break;
                    case LotteryType11_3.GD_11_3:
                        type = 2;
                        break;
                    case LotteryType11_3.JX_11_3:
                        type = 3;
                        break;
                    case LotteryType11_3.CQ_11_3:
                        type = 4;
                        break;
                    case LotteryType11_3.JS_11_3:
                        type = 5;
                        break;
                    case LotteryType11_3.ZJ_11_3:
                        type = 6;
                        break;
                    case LotteryType11_3.SH_11_3:
                        type = 7;
                        break;
                }
                return type;
            }
        }
        #endregion

        #region 彩票分隔符
        public string LotterySplite { get; set; }
        #endregion

        #region 登录状态
        private bool loginstate = false;
        public bool LoginState
        {
            set
            {
                loginstate = value;
            }

            get
            {
                return loginstate;
            }
        }
        #endregion


        public int back = -1;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                CyyDb.Logout(USERID);
                back = 0;
                cyyLogin.Show(this);
                this.Hide();
                cyyLogin.LoadCyy.PerformClick();
            }
            catch
            {
                CyyMain.cyyMainExit();
                //Application.Exit();
            }
        }

        #region 显示登录窗口
        private void CyyMain_VisibleChanged(object sender, EventArgs e)
        {
            if (cyyLogin != null)
            {
                if (back == 0)
                {
                    back = 1;
                }
                else
                    if (back == 1)
                    {
                        // back = false;
                        Visible = true;
                    }
                    else
                    {
                        try
                        {
                            cyyLogin.ShowDialog(this);
                        }
                        catch (Exception exc)
                        {
                            CyyClose();
                        }

                        if (!LoginState)
                        {
                            CyyClose();
                        }
                        else
                        {
                            //lblUser.Text = CyyDb.userInfo["UserName"].ToString();
                            lblSHOWS.Text = CyyDb.GetShows();
                            lblSHOWS2.Text = lblSHOWS.Text;

                            //this.ShowIcon = false;

                            tmrShows.Enabled = true;

                            if (lblSHOWS.Width < panel17.Width)
                            {
                                lblSHOWS2.Left = lblSHOWS.Left + panel17.Width;
                            }
                            else
                            {
                                lblSHOWS2.Left = lblSHOWS.Left + lblSHOWS.Width;
                            }

                            tmrLoginDate.Enabled = true;
                            tmrUpdate.Enabled = true;
                            tmrAutoRefresh.Enabled = true;
                            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                            this.MaximizeBox = false;

                            if (File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
                            {
                                readCertainFile(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll");
                                txtLotteryDates.Text = (int.Parse(LotteryInfos[0].Day) + 1).ToString();
                                dgvLotteryInfos.Rows.Clear();

                                foreach (LotteryInfo tmp in LotteryInfos)
                                {
                                    dgvLotteryInfos.Rows.Add(tmp.Day, tmp.Data);
                                }
                            }

                            if (File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + ".dll"))
                            {
                                readCertainFile(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + ".dll");
                                textBox2.Text = (int.Parse(LotteryInfos[0].Day) + 1).ToString();
                                dataGridView1.Rows.Clear();

                                foreach (LotteryInfo tmp in LotteryInfos)
                                {
                                    dataGridView1.Rows.Add(tmp.Day, tmp.Data);
                                }
                            }
                        }

                    }
            }
        }
        #endregion

        public void readCertainFile(string certainFileName)
        {
            using (FileStream fs = File.OpenRead(certainFileName))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                StringBuilder sb = new StringBuilder();
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    sb.Append(temp.GetString(b));
                }

                string datas = sb.ToString();

                /*string[] datasArr = datas.Split('\n');
                string[] tmpArr;

                List<LotteryInfo> lis = new List<LotteryInfo>();

                foreach (string tmp in datasArr)
                {
                    tmpArr = tmp.Split(',');
                    lis.Add(new LotteryInfo { Day = tmpArr[0], Data = tmpArr[1] });
                }
                
                */
                string[] datasArr = datas.Split('\n');
                List<LotteryInfo> lis = new List<LotteryInfo>();

                for (int i = 0; i < datasArr.Length; i++)
                {

                    if (i % 2 == 0)
                    {
                        lis.Add(new LotteryInfo { Day = datasArr[i], Data = datasArr[i + 1] });
                    }
                }

                LotteryInfos = lis;
            }
        }
        public CyyMain()
            : base()
        {
            cyyLogin = new CyyLogin();
            currentLotteryTypeInfo11_5 = new CurrentLotteryTypeInfo11_5(LotteryType11_5.GD_11_5);
            currentLotteryTypeInfo11_3 = new CurrentLotteryTypeInfo11_3(LotteryType11_3.GD_11_3);
            InitializeComponent();

            Browser.Parent = pnlcccc;
            Browser.Dock = DockStyle.Fill;

            Browser11_3.Parent = panel11_3;
            Browser11_3.Dock = DockStyle.Fill;


        }

        #region 关闭窗口
        public void CyyClose()
        {
            CyyDb.DbClose();
            Close();
        }
        #endregion

        private void CyyMain_Load(object sender, EventArgs e)
        {
            productKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\彩盈盈彩票做号系统\");
            try
            {
                productKeyNameString = productKey.GetValue("DisplayName").ToString();
                productKeyVersionNameString = productKey.GetValue("VersionName").ToString(); ;
                proudctVersionString = productKey.GetValue("DisplayVersion").ToString();

                cyyLogin.Text = productKeyNameString + "(" + productKeyVersionNameString + ")v" + proudctVersionString;

                productNameLabel.Text = productKeyVersionNameString + " v" + proudctVersionString;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            CbbLotterySplite.SelectedIndex = 0;
            cbbLotteryTypes.SelectedIndex = 0;

            CbbLotterySplite11_3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            cbbBeiCheng.SelectedIndex = 0;
            cbbBeiJia.SelectedIndex = 0;

            ClickEvent(grpBileCode, new EventHandler(this.chkD1_01_Click), "chkD1_");
            ClickEvent(grpBileCode, new EventHandler(this.chkD2_01_Click), "chkD2_");
            ClickEvent(grpBileCode, new EventHandler(this.chkD3_01_Click), "chkD3_");
            ClickEvent(grpBileCode, new EventHandler(this.chkD4_01_Click), "chkD4_");
            ClickEvent(grpBileCode, new EventHandler(this.chkD5_01_Click), "chkD5_");

            // 设置初始tab page
            SetTabState(button2, true);

            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;

            clr0 = true;
            clr1 = true;
            clr2 = true;
            clr3 = true;
            clr4 = true;
            clr5 = true;
            clr6 = true;
            clr7 = true;
            clr8 = true;
            clr9 = true;
            clr10 = true;
            clr11 = true;
            clr12 = true;
            clr13 = true;
            clr14 = true;
            clr15 = true;

            panel2.Height = mainPageHeight;
        }


        private void ClickEvent(GroupBox grp, EventHandler handler, string preName)
        {
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    if (cb.Name.StartsWith(preName))
                    {
                        cb.Click += handler;
                    }
                }
            }
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
        }


        private bool BaseNumAllBool = true;
        private void BaseNumAll_CheckedChanged(object sender, EventArgs e)
        {/*
            BaseNum1.Checked = BaseNumAll.Checked;
            BaseNum2.Checked = BaseNumAll.Checked;
            BaseNum3.Checked = BaseNumAll.Checked;
            BaseNum4.Checked = BaseNumAll.Checked;
            BaseNum5.Checked = BaseNumAll.Checked;
            BaseNum6.Checked = BaseNumAll.Checked;
            BaseNum7.Checked = BaseNumAll.Checked;
            BaseNum8.Checked = BaseNumAll.Checked;
            BaseNum9.Checked = BaseNumAll.Checked;
            BaseNum10.Checked = BaseNumAll.Checked;
            BaseNum11.Checked = BaseNumAll.Checked;
             */
            //
            if (BaseNumAllBool)
            {
                BaseNumAllBool = false;
                SetCheckboxState(grpBaseNums, false);
            }
            else
            {
                SetCheckboxState(grpBaseNums, true);
                BaseNumAllBool = true;
            }

        }

        private void cbbLotteryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbLotteryTypes.SelectedIndex)
            {
                default:
                case 0:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.SD_11_5;
                    break;
                case 1:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.GD_11_5;
                    break;
                case 2:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.JX_11_5;
                    break;
                case 3:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.CQ_11_5;
                    break;
                case 4:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.JS_11_5;
                    break;
                case 5:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.ZJ_11_5;
                    break;
                case 6:
                    currentLotteryTypeInfo11_5.Lottery_Type = LotteryType11_5.SH_11_5;
                    break;

            }

            if (LoginState)
            {
                if (!File.Exists(currentLotteryTypeInfo11_5.FileName))
                {
                    btnGetLotteryInfo_Click(sender, e);
                }
                else
                {
                    ReadLotteryInfosFromFile(currentLotteryTypeInfo11_5.FileName);

                    dgvLotteryInfos.Rows.Clear();

                    foreach (LotteryInfo tmp in LotteryInfos)
                    {
                        dgvLotteryInfos.Rows.Add(tmp.Day, tmp.Data);
                    }
                }

                if (LotteryInfos.Count > 0)
                {
                    txtLotteryDates.Text = (int.Parse(LotteryInfos[0].Day) + 1).ToString();
                }
            }
        }

        private void CbbLotterySplite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region 读取文件 往期彩票信息

        private void ReadLotteryInfosFromFile(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                StringBuilder sb = new StringBuilder();
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    sb.Append(temp.GetString(b));
                }

                string datas = sb.ToString();
                /*

                string[] datasArr = datas.Split('\n');
                string[] tmpArr;

                List<LotteryInfo> lis = new List<LotteryInfo>();

                foreach (string tmp in datasArr)
                {
                    tmpArr = tmp.Split(',');
                    lis.Add(new LotteryInfo { Day = tmpArr[0], Data = tmpArr[1] });
                }

                 */

                string[] datasArr = datas.Split('\n');
                List<LotteryInfo> lis = new List<LotteryInfo>();

                for (int i = 0; i < datasArr.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        lis.Add(new LotteryInfo { Day = datasArr[i], Data = datasArr[i + 1] });
                    }
                }

                LotteryInfos = lis;
            }
        }

        #endregion

        private void SoundPlay(string filename)
        {
            System.Media.SoundPlayer media = new System.Media.SoundPlayer(filename);
            media.Play();
        }

        #region 保存文件 往期彩票信息

        private void AddText(FileStream fs, List<LotteryInfo> cpdatas)
        {
            if (cpdatas.Count != 0)
            {
                string splite = ",";
                string wrap = "\n";
                StringBuilder sb = new StringBuilder();
                foreach (LotteryInfo lotteryInfo in cpdatas)
                {
                    sb.Append(lotteryInfo.Day + splite + lotteryInfo.Data + wrap);
                }

                sb.Remove(sb.Length - 1, 1);

                string tmp = sb.ToString();


                byte[] info = new UTF8Encoding(true).GetBytes(tmp);
                fs.Write(info, 0, info.Length);
            }
            else
            {
                MessageBox.Show("数据库中没有彩种数据");
            }
        }

        private void AddTextChart(FileStream fs, List<LotteryInfo> cpdatas)
        {
            if (cpdatas.Count != 0)
            {
                string wrap = "\n";
                StringBuilder sb = new StringBuilder();
                foreach (LotteryInfo lotteryInfo in cpdatas)
                {
                    sb.Append(lotteryInfo.Day + wrap + lotteryInfo.Data + wrap);
                }

                sb.Remove(sb.Length - 1, 1);

                string tmp = sb.ToString();


                byte[] info = new UTF8Encoding(true).GetBytes(tmp);
                fs.Write(info, 0, info.Length);
            }
            else
            {
                MessageBox.Show("数据库中没有彩种数据");
            }
        }


        private void SaveLotteryInfosToFile(string fileName, string type)
        {
            //  if (!File.Exists(currentLotteryTypeInfo11_5.FileName))
            //  {
            using (FileStream fs = File.Create(fileName))
            {
                AddText(fs, LotteryInfos);
            }
            // currentLotteryTypeInfo11_3.FileName
            using (FileStream fs = File.Create(
                System.Environment.CurrentDirectory + @"\data\" + USERID + type + @".dll"))
            {
                AddTextChart(fs, LotteryInfos);
            }
            //   }
        }

        #endregion


        private void SetCheckState(GroupBox grp, int count, string autoPreName)
        {
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {

                    CheckBox cb = (CheckBox)cc;
                    if (cb.Name.StartsWith(autoPreName))
                    {
                        cb.Enabled = true;

                        //if(!cb.Checked){
                        //    //cb.Checked = true;
                        //} else {
                        //    cb.Checked = true;
                        //}
                        cb.Enabled = false;
                    }

                }
            }

            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Name.StartsWith(autoPreName))
                    {
                        string Nindex = cb.Name.Substring(autoPreName.Length, cb.Name.Length - autoPreName.Length);

                        if (int.Parse(Nindex) <= count)
                        {
                            cb.Enabled = true;

                            if (count == 0 && int.Parse(Nindex) == 0)
                            {
                                cb.Enabled = false;
                                cb.Checked = false;
                            }
                        }
                        else
                        {
                            cb.Enabled = false;
                            cb.Checked = false;
                        }
                    }
                }
            }
        }

        private void SetCheckState(GroupBox grp, string selPreName, string autoProName)
        {
            int count = 0;
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Name.StartsWith(selPreName) && cb.Checked)
                    {
                        count++;
                    }
                }

                if (cc is CheckBox)
                {

                    CheckBox cb = (CheckBox)cc;

                    if (cb.Name.StartsWith(autoProName))
                    {
                        cb.Enabled = false;
                    }
                }
            }

            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Name.StartsWith(autoProName))
                    {
                        string Nindex = cb.Name.Substring(autoProName.Length, cb.Name.Length - autoProName.Length);

                        if (int.Parse(Nindex) <= count)
                        {
                            cb.Enabled = true;
                            //cb.Checked = true;

                            if (count == 0 && int.Parse(Nindex) == 0)
                            {
                                cb.Enabled = false;
                                cb.Checked = false;
                            }
                        }
                        else
                        {
                            cb.Checked = false;
                            cb.Enabled = false;
                        }
                    }
                }
            }
        }

        private bool SetCheckState(GroupBox grp, int count, object sender)
        {
            int ccc = 0;
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Checked)
                    {
                        ccc++;
                    }
                }
            }

            if (ccc > count)
            {
                if (sender is CheckBox)
                {
                    (sender as CheckBox).Checked = false;
                }
            }

            if (ccc != 0)
            {
                return true;
            }

            return false;
        }

        private bool SetCheckState(GroupBox grp, int count, object sender, string preName)
        {
            int ccc = 0;
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Checked && cb.Name.StartsWith(preName))
                    {
                        ccc++;
                    }
                }
            }

            if (ccc > count)
            {
                if (sender is CheckBox)
                {
                    (sender as CheckBox).Checked = false;
                }
            }

            if (ccc != 0)
            {
                return true;
            }
            return false;
        }

        private void getCPData11_5(bool isAuto)
        {
            LotteryInfos = CyyDb.GetLotteryInfos(currentLotteryTypeInfo11_5.getCurrentTypeInt(currentLotteryTypeInfo11_5.Lottery_Type), 1, 1);

            if (isAuto)
            {
                if (int.Parse(LotteryInfos[0].Day.ToString()) < int.Parse(txtLotteryDates.Text))
                {
                    return;
                }
            }
            dgvLotteryInfos.Rows.Clear();

            foreach (LotteryInfo li in LotteryInfos)
            {
                dgvLotteryInfos.Rows.Add(li.Day, li.Data);
            }

            if (LotteryInfos.Count != 0)
            {
                txtLotteryDates.Text = (int.Parse(dgvLotteryInfos.CurrentRow.Cells["clnQiHao"].Value.ToString()) + 1).ToString();
                txtWinNum.Text = "";
                SaveLotteryInfosToFile(currentLotteryTypeInfo11_5.FileName, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
                SoundPlay(System.Environment.CurrentDirectory + @"\config\complete.wav");
            }
            else
            {
                MessageBox.Show("数据库中没有该彩种信息");
            }
        }

        private void btnGetLotteryInfo_Click(object sender, EventArgs e)
        {
            getCPData11_5(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (LotteryInfos == null)
            {
                LotteryInfos = new List<LotteryInfo>();
                LotteryInfos.Add(new LotteryInfo
                {
                    Day = txtLotteryDates.Text.Trim(),
                    Data = txtWinNum.Text.Trim()
                });
                dgvLotteryInfos.Rows.Insert(0, new string[] { txtLotteryDates.Text, txtWinNum.Text });
            }
            else
            {
                int lotteryDates = LotteryInfos.FindLastIndex(
                    delegate(LotteryInfo lotteryInfo)
                    {
                        return lotteryInfo.Day == txtLotteryDates.Text.Trim();
                    });

                if (lotteryDates != -1)
                {
                    dgvLotteryInfos.FirstDisplayedScrollingRowIndex = lotteryDates;
                    dgvLotteryInfos.Rows[lotteryDates].Selected = true;
                }
                else
                {
                    if (Regex.IsMatch(txtWinNum.Text, @"^\d{10}$"))
                    {

                        dgvLotteryInfos.Rows.Insert(0, new string[] { txtLotteryDates.Text, txtWinNum.Text });
                        LotteryInfos.Insert(0, new LotteryInfo() { Day = txtLotteryDates.Text, Data = txtWinNum.Text });

                        dgvLotteryInfos.FirstDisplayedScrollingRowIndex = 0;
                        dgvLotteryInfos.Rows[0].Selected = true;
                        dgvLotteryInfos.Rows[1].Selected = false;

                        txtLotteryDates.Text = (Convert.ToInt32(txtLotteryDates.Text) + 1).ToString();
                        SaveLotteryInfosToFile(currentLotteryTypeInfo11_5.FileName, currentLotteryTypeInfo11_5.Lottery_Type.ToString());


                        button11_Click_2(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("彩票输入错误");

                    }
                    txtWinNum.Text = "";
                }
            }
        }

        private void dgvLotteryInfos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            preDataOfLotteryInfo = dgvLotteryInfos[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvLotteryInfos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nowDataOfLotteryInfo = dgvLotteryInfos[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (!Regex.IsMatch(nowDataOfLotteryInfo, @"^\d{10}$"))
            {
                MessageBox.Show("彩票输入错误");

                dgvLotteryInfos[e.ColumnIndex, e.RowIndex].Value = preDataOfLotteryInfo;
            }
            else
            {
                for (int i = 0; i < LotteryInfos.Count; i++)
                {
                    if (LotteryInfos[i].Day.Equals(dgvLotteryInfos[0, e.RowIndex].Value.ToString()))
                    {
                        LotteryInfo li = new LotteryInfo() { Day = LotteryInfos[i].Day, Data = nowDataOfLotteryInfo };

                        LotteryInfos[i] = li;
                        break;
                    }
                }


                SaveLotteryInfosToFile(currentLotteryTypeInfo11_5.FileName, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
            }
        }

        // 基础号码 11_5
        private void SetBaseNums()
        {
            int length = 0;
            int[] baseNums = new int[11];

            int notLength = 0;
            int[] notBaseNums = new int[11];
            if (grpBaseNums.HasChildren)
            {
                foreach (Control cc in grpBaseNums.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox cb = (CheckBox)cc;
                        string cbIndex = cb.Name.Substring(7, cb.Name.Length - 7); //BaseNumX

                        if (!cbIndex.Equals("All"))
                        {
                            if (cb.Checked)
                            {
                                baseNums[length] = int.Parse(cbIndex);
                                length++;
                            }
                            else
                            {
                                notBaseNums[notLength] = int.Parse(cbIndex);
                                notLength++;

                            }
                        }
                    }
                }

                A11_5.NotBaseNums = AlgorithmTools.GetSubArray(notBaseNums, notLength);
                A11_5.BaseNums = AlgorithmTools.GetSubArray(baseNums, length);
            }
        }

        private int[] GetCheckedArray(GroupBox grp, string checkBoxPreName, bool bCheckState, int defaultArrLength = 35)
        {

            int[] temp = new int[defaultArrLength];
            int length = 0;

            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    //if (cb.Checked) //Jerry
                    //{
                    if (cb.Name.StartsWith(checkBoxPreName)) //Jerry
                    {
                        string cbIndex = cb.Name.Substring(checkBoxPreName.Length, cb.Name.Length - checkBoxPreName.Length); //chkRePassBaseNumX

                        if (!Regex.IsMatch(cbIndex, "^[0-9]+$"))
                        {
                            continue;
                        }

                        if (cb.Checked == bCheckState && cb.Name.Substring(0, checkBoxPreName.Length).Equals(checkBoxPreName))
                        {
                            temp[length] = int.Parse(cbIndex);
                            length++;
                        }

                    }
                    //}
                }
            }


            return AlgorithmTools.GetSubArray(temp, length);
        }

        // 重号传号 -
        private void SetReNoAndPassNo()
        {
            ReNoAndPassNo rapn = new ReNoAndPassNo();

            rapn.BaseNums = GetCheckedArray(grpReNoPassNo, "chkRePassBaseNum", true);

            rapn.ReNoCounts = GetCheckedArray(grpReNoCount, "chkReNoCount", true);
            rapn.PassSmallCounts = GetCheckedArray(grpPassSmallCount, "chkPassSmallCount", true);
            rapn.PassBigCounts = GetCheckedArray(grpPassBigCount, "chkPassBigCount", true);

            rapn.NotReNoCounts = GetCheckedArray(grpReNoCount, "chkReNoCount", false);
            rapn.NotPassSmallCounts = GetCheckedArray(grpPassSmallCount, "chkPassSmallCount", false);
            rapn.NotPassBigCounts = GetCheckedArray(grpPassBigCount, "chkPassBigCount", false);




            A11_5._ReNoAndPassNo = rapn;

        }

        // 胆码列表 -
        private void SetBileCodes()
        {
            List<BileCode> bileCodes = new List<BileCode>();
            for (int i = 0; i < 5; i++)
            {
                int[] bileCode = GetCheckedArray(grpBileCode, "chkD" + (i + 1).ToString() + "_", true);
                int[] appearCounts = GetCheckedArray(grpBileCode, "chkD" + Char.ToString((char)('A' + i)) + "_", true);
                int[] notAppearCounts = GetCheckedArray(grpBileCode, "chkD" + Char.ToString((char)('A' + i)) + "_", false);
                BileCode bc =
                    new BileCode()
                    {
                        IsSelect = bileCode.Length == 0 ? false : true,
                        _BileCode = bileCode,
                        AppearCounts = appearCounts,
                        NotAppearCounts = notAppearCounts,
                    };

                bileCodes.Add(bc);
            }

            A11_5.BileCodes = bileCodes;
        }

        // 综合属性 -
        private void SetSynthesizedAttribute()
        {
            SynthesizedAttribute syattr = new SynthesizedAttribute()
            {
                EvenCounts = GetCheckedArray(grpEven, "chkEven", true),
                SmallCounts = GetCheckedArray(grpSmall, "chkSmall", true),
                SumCounts = GetCheckedArray(grpSum, "chkSum", true),
                LinkedCounts = GetCheckedArray(grpLinked, "chkLink", true),
                AppearCounts = GetCheckedArray(grpSynthesizedAttribute, "chkSA", true)
            };

            A11_5._SynthesizedAttribute = syattr;
        }

        // 前后比例 -
        private void SetSixLeft()
        {
            A11_5.SixLeft = GetCheckedArray(grpLeftNums, "chkLeft", true);
            A11_5.SixRight = GetCheckedArray(grpLeftNums, "chkRight", true);
        }

        // 平衡指数 -
        private void SetBalanceIndex()
        {
            List<BalanceState> balanceStates = new List<BalanceState>();
            //List<AppearState> appearStates = new List<AppearState>();

            if (chkLeftMore.Checked)
            {
                balanceStates.Add(BalanceState.LeftMore);
            }

            if (chkRightMore.Checked)
            {
                balanceStates.Add(BalanceState.RightMore);
            }

            if (chkLeftEqualRight.Checked)
            {
                balanceStates.Add(BalanceState.Equal);
            }

            /*
            if (chkAppear0.Checked)
            {
                appearStates.Add(AppearState.NotAppear);
            }

            if (chkAppear1.Checked)
            {
                appearStates.Add(AppearState.Appear);
            }
             */


            BalanceIndex bi = new BalanceIndex()
            {
                BalanceStates = balanceStates
            };



            A11_5._BalanceIndex = bi;
        }

        // 龙头凤尾 单数双数 -
        private void SetFaucetAndPterisEven()
        {
            List<FPState> fps1 = new List<FPState>();
            if (chkLongtouDan.Checked)
            {
                fps1.Add(FPState.IsSingular);
            }

            if (chkLongtouShuang.Checked)
            {
                fps1.Add(FPState.IsEven);
            }


            List<FPState> fps2 = new List<FPState>();
            if (chkFengweiDan.Checked)
            {
                fps2.Add(FPState.IsSingular);
            }
            if (chkFengweiShuang.Checked)
            {
                fps2.Add(FPState.IsEven);
            }

            FaucetAndPteris fp = new FaucetAndPteris() { Faucent = fps1, Peris = fps2, AppearCounts = GetCheckedArray(grpLongFengBig, "chkLongfengDanshuangChuxian", true) };
            A11_5._FaucetAndPterisEven = fp;
        }

        // 龙头凤尾 质数和数 -
        private void SetFaucetAndPterisPrimer()
        {
            List<FPState> fps1 = new List<FPState>();
            if (chkLongtouZhi.Checked)
            {
                fps1.Add(FPState.IsPrimes);
            }

            if (chkLongtouHe.Checked)
            {
                fps1.Add(FPState.IsSums);
            }


            List<FPState> fps2 = new List<FPState>();
            if (chkFengweiZhi.Checked)
            {
                fps2.Add(FPState.IsPrimes);
            }
            if (chkFengweiHe.Checked)
            {
                fps2.Add(FPState.IsSums);
            }

            FaucetAndPteris fp = new FaucetAndPteris() { Faucent = fps1, Peris = fps2, AppearCounts = GetCheckedArray(grpLongFengBig, "chkLongfengZhiheChuxian", true) };


            A11_5._FaucetAndPterisPrimer = fp;
        }

        // 龙头凤尾 0，1，2路 -
        private void SetFaucet012()
        {
            A11_5.Faucet012 = GetCheckedArray(grpLongtou012Lu, "chkLongtouLu", true);
        }

        private void SetPteris012()
        {
            A11_5.Pteris012 = GetCheckedArray(grpFengwei012Lu, "chkFengweiLu", true);

            A11_5.FPAppears = GetCheckedArray(grpLTFW012, "chkLTFW012_", true);
        }

        // 集临个数 、溃临个数 -
        private void SetMaxLinkNum()
        {
            A11_5.MaxLinkNum = GetCheckedArray(grpMaxLinkNum, "chkLinkNum", true);
            A11_5.NotMaxLinkNum = GetCheckedArray(grpMaxNotLinkNum, "chkNotLinkNum", true);
        }

        // 临群码 临码号 -
        private void SetLinkCounts()
        {
            A11_5.LinkCounts = GetCheckedArray(grpLingmahao, "chkLingmahaoChuxian", true);
        }

        // 和值 -
        private void SetSumOfLotterys()
        {
            A11_5.SumOfLotterys = GetCheckedArray(grpHezhi, "chkHezhi", true, 40);
        }

        // 合值 -
        private void SetSmallBitValue()
        {
            A11_5.SmallBitValue = GetCheckedArray(grpHezhidown, "chkHezhidown", true);
        }

        // 跨度 -
        private void SetSpans()
        {
            A11_5.Spans = GetCheckedArray(grpKuadu, "chkGuadu", true);
        }
        // 临码和 -
        private void SetMaxMinusSmallMinus4s()
        {
            A11_5.MaxMinusSmallMinus4s = GetCheckedArray(grpLingmahe, "chkLingmahe", true);
        }

        // 最大临码距离 -
        private void SetMaxNearestNumDiss()
        {
            A11_5.MaxNearestNumDiss = GetCheckedArray(grpZuidalingmakuaju, "chkZuidalingmakuaju", true);
        }

        // 反边球距离 -
        private void SetSmallerBigerLengths()
        {
            A11_5.SmallerBigerLengths = GetCheckedArray(grpFanbianqiujuli, "chkFanbianqiujuli", true);
        }

        // 边临和 -
        private void SetSmallBiggerLenAddMaxNearestDiss()
        {
            A11_5.SmallBiggerLenAddMaxNearestDiss = GetCheckedArray(grpBianlinghe, "chkBianlinghe", true);
        }

        // 首尾邻码最大间距 -
        private void SetHeadTailMaxSkip()
        {
            A11_5.HeadTailMaxSkip = GetCheckedArray(grpShouweilingmazuidajianju, "chkShouweilingmazuidajianju", true);
        }

        // 朱佳峰
        // 两码差 -
        private void SetTwoNumDiss()
        {
            List<TwoNumDis> tnd = new List<TwoNumDis>();
            tnd.Add(new TwoNumDis()
            {
                _TwoNumDis = GetCheckedArray(grpLiangmacha, "chkLiangmacha1_", true),
                AppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian1_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian1_", false),
            });
            tnd.Add(new TwoNumDis()
            {
                _TwoNumDis = GetCheckedArray(grpLiangmacha, "chkLiangmacha2_", true),
                AppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian2_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian2_", false),
            });
            tnd.Add(new TwoNumDis()
            {
                _TwoNumDis = GetCheckedArray(grpLiangmacha, "chkLiangmacha3_", true),
                AppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian3_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian3_", false),
            });
            tnd.Add(new TwoNumDis()
            {
                _TwoNumDis = GetCheckedArray(grpLiangmacha, "chkLiangmacha4_", true),
                AppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian4_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian4_", false),
            });
            tnd.Add(new TwoNumDis()
            {
                _TwoNumDis = GetCheckedArray(grpLiangmacha, "chkLiangmacha5_", true),
                AppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian5_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmacha, "chkLiangmachaChuxian5_", false),
            });

            A11_5.TwoNumDiss = tnd;
        }

        // 差临值 -
        private void SetTwoNumDissCounts()
        {
            A11_5.TwoNumDissCounts = GetCheckedArray(grpLingchazhi, "chkLingchazhi", true);
        }

        // 跨码 -
        private void SetSkipNum()
        {
            A11_5._SkipNum = new SkipNum()
            {
                skipNums = GetCheckedArray(grpKuama, "chkKuama", true),
                AppearNums = GetCheckedArray(grpKuama, "chkKuamaChuxian", true)
            };
        }

        // 邻码间距 -
        private void SetNearSkipCount()
        {
            A11_5._NearSkipCount = new NearSkipCount()
            {
                ns0 = GetCheckedArray(grpLingmajianju, "chkLingmajianju0_", true),
                ns1 = GetCheckedArray(grpLingmajianju, "chkLingmajianju1_", true),
                ns2 = GetCheckedArray(grpLingmajianju, "chkLingmajianju2_", true),
                ns3 = GetCheckedArray(grpLingmajianju, "chkLingmajianju3_", true),
                ns4 = GetCheckedArray(grpLingmajianju, "chkLingmajianju4_", true),
                ns5 = GetCheckedArray(grpLingmajianju, "chkLingmajianju5_", true),
                ns6 = GetCheckedArray(grpLingmajianju, "chkLingmajianju6_", true),
                AppearCounts = GetCheckedArray(grpLingmajianju, "chkLingmajianjuChuxian", true),
            };
        }

        // 定位组选 -
        private void SetLocateIndexNum()
        {
            A11_5._LocateIndexNum = new LocateIndexNum()
            {
                index1 = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuan1_", true),
                index2 = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuan2_", true),
                index3 = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuan3_", true),
                index4 = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuan4_", true),
                index5 = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuan5_", true),
                AppearCounts = GetCheckedArray(grpDingweizuxuan, "chkDingweizuxuanChuxian", true),
            };
        }

        // 智能数据 -
        private void SetAiData()
        {
            A11_5.aiData = new AIData()
            {
                AI_A = GetCheckedArray(grpZhinengA, "chkZhinengA", true),
                AI_B = GetCheckedArray(grpZhinengB, "chkZhinengB", true),
                AI_C = GetCheckedArray(grpZhinengC, "chkZhinengC", true),
                AI_D = GetCheckedArray(grpZhinengD, "chkZhinengD", true),
                AppearCount = GetCheckedArray(grpZhinengShuju, "chkZhinengShujuChuxian", true),
            };
        }

        // 012路 -
        private void SetCountsOf012()
        {
            A11_5.countsOf012 = new CountsOf012
            {
                countOf0 = GetCheckedArray(groupBox9, "chk0lugeshu", true),
                countOf1 = GetCheckedArray(groupBox11, "chk1lugeshu", true),
                countOf2 = GetCheckedArray(groupBox12, "chk2lugeshu", true),
                AppearCount = GetCheckedArray(grp012lugeshu, "chk012lugeshuChuxian", true),
            };
        }

        // 两码和 -
        private void SetTwoNumPluss()
        {
            List<TwoNumPlus> tnp = new List<TwoNumPlus>();
            tnp.Add(new TwoNumPlus()
            {
                _TwoNumPlus = GetCheckedArray(grpLiangmahe, "chkLiangmahe1_", true, 210),
                AppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian1_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian1_", false)
            });
            tnp.Add(new TwoNumPlus()
            {
                _TwoNumPlus = GetCheckedArray(grpLiangmahe, "chkLiangmahe2_", true, 210),
                AppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian2_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian2_", false)
            });
            tnp.Add(new TwoNumPlus()
            {
                _TwoNumPlus = GetCheckedArray(grpLiangmahe, "chkLiangmahe3_", true, 210),
                AppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian3_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian3_", false)
            });
            tnp.Add(new TwoNumPlus()
            {
                _TwoNumPlus = GetCheckedArray(grpLiangmahe, "chkLiangmahe4_", true, 210),
                AppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian4_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian4_", false)
            });
            tnp.Add(new TwoNumPlus()
            {
                _TwoNumPlus = GetCheckedArray(grpLiangmahe, "chkLiangmahe5_", true, 210),
                AppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian5_", true),
                NotAppearCounts = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian5_", false)
            });

            A11_5._TwoNumPluss = tnp;

            // 出现个数
            //A11_5.TwoNumAppears = GetCheckedArray(grpLiangmahe, "chkLiangmaheChuxian", true);
        }

        // 两码组合 -
        private void SettwoNums()
        {
            List<TwoNum> tns = new List<TwoNum>();

            foreach (Control cc in grpLiangmazuhe.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    string preName = "chkLiangmazuhe";
                    int preNameLength = preName.Length;

                    string sign = cb.Name.Substring(preNameLength, cb.Name.Length - preNameLength); //chkRePassBaseNumX

                    if (cb.Checked && cb.Name.Substring(0, preNameLength).Equals(preName))
                    {
                        string[] nums = cb.Text.Split('-');
                        TwoNum tn = new TwoNum() { State = cb.Name.StartsWith("chkLiangmazuheR") ? false : true, Num1 = int.Parse(nums[0]), Num2 = int.Parse(nums[1]) };

                        tns.Add(tn);
                    }
                }
            }


            A11_5.twoNums = tns;
        }

        // 012路比例 -
        private void Setrate012s()
        {
            List<Rate012> rt = new List<Rate012>();

            string checkBoxPreName = "chk012lubili";
            foreach (Control cc in grp012lubili.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    if (cb.Checked)
                    {
                        string temp = cb.Name;
                        if (!cb.Name.StartsWith("chk012lubiliChuxian"))
                        {
                            rt.Add(new Rate012()
                            {
                                count0 = Convert.ToInt32(cb.Name.Substring(checkBoxPreName.Length + 0, 1)),
                                count1 = Convert.ToInt32(cb.Name.Substring(checkBoxPreName.Length + 1, 1)),
                                count2 = Convert.ToInt32(cb.Name.Substring(checkBoxPreName.Length + 2, 1)),
                            });
                        }
                    }
                }
            }
            A11_5.rate012s = rt;
            // 出现次数
            A11_5.Rate012AppearCount = GetCheckedArray(grp012lubili, "chk012lubiliChuxian", true);
        }


        // 断临 -
        /*
        private void SetkillNears()
        {
            A11_5.killNears = GetCheckedArray(grpDuanling, "chkDuanling", true);
        }
         */

        // 隔位合 -
        private void SetSkipBitSum()
        {
            List<int[]> tmp = new List<int[]>();
            tmp.Add(
                GetCheckedArray(grpGeweihe, "chkGeweihe1_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihe, "chkGeweihe2_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihe, "chkGeweihe3_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihe, "chkGeweihe4_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihe, "chkGeweihe5_", true)
            );

            A11_5.SkipBitSum = tmp;

            // 出现个数
            A11_5.SkipBitCounts = GetCheckedArray(grpGeweihe, "chkGeweiheChuxian", true);
        }

        // 隔位差 -
        private void SetSkipBitDis()
        {
            List<int[]> tmp = new List<int[]>();
            tmp.Add(
                GetCheckedArray(grpGeweicha, "chkGeweicha1_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweicha, "chkGeweicha2_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweicha, "chkGeweicha3_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweicha, "chkGeweicha4_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweicha, "chkGeweicha5_", true)
            );

            A11_5.SkipBitDis = tmp;
            // 出现个数
            A11_5.SkipBitDisCounts = GetCheckedArray(grpGeweicha, "chkGeweichaChuxian", true);
        }

        // 隔位合 分序
        private void SetSkipBitSumFenxu()
        {
            List<int[]> tmp = new List<int[]>();
            tmp.Add(
                GetCheckedArray(grpGeweihefengxuzuxuan, "chkGeweihefengxuzuxuan1_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihefengxuzuxuan, "chkGeweihefengxuzuxuan2_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweihefengxuzuxuan, "chkGeweihefengxuzuxuan3_", true)
            );

            A11_5.SkipBitSumFenxu = tmp;

            // 出现个数
            A11_5.SkipBitSumFenxuCounts = GetCheckedArray(grpGeweihefengxuzuxuan, "chkGeweihefengxuzuxuanChuxian", true);
        }

        // 隔位差 分序
        private void SetSkipBitDisFenxu()
        {
            List<int[]> tmp = new List<int[]>();
            tmp.Add(
                GetCheckedArray(grpGeweichafengxuzuxuan, "chkGeweichafengxuzuxuan1_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweichafengxuzuxuan, "chkGeweichafengxuzuxuan2_", true)
            );
            tmp.Add(
                GetCheckedArray(grpGeweichafengxuzuxuan, "chkGeweichafengxuzuxuan3_", true)
            );

            A11_5.SkipBitDisFenxu = tmp;
            // 出现个数
            A11_5.SkipBitDisFenxuCounts = GetCheckedArray(grpGeweichafengxuzuxuan, "chkGeweichafengxuzuxuanChuxian", true);
        }
        // 智能值 -
        private void SetAIValues()
        {
            A11_5._AIValues = new AIValues()
            {
                AI_A = GetCheckedArray(grpZhinengzhiA, "chkZhinengzhiA", true),
                AI_B = GetCheckedArray(grpZhinengzhiB, "chkZhinengzhiB", true),
                AI_C = GetCheckedArray(grpZhinengzhiC, "chkZhinengzhiC", true),
                AI_D = GetCheckedArray(grpZhinengzhiD, "chkZhinengzhiD", true),
                AI_E = GetCheckedArray(grpZhinengzhiE, "chkZhinengzhiE", true),
                AI_F = GetCheckedArray(grpZhinengzhiF, "chkZhinengzhiF", true),
                AppearCount = GetCheckedArray(grpZhinengzhi, "chkZhinengzhi", true),
            };
        }

        // 智能平衡 -
        private void SetAIBalance()
        {
            A11_5._AIBalance = new AIBalance()
            {
                bsA = GetCheckedArray(grpZhinengpinghengA, "chkZhinengpinghengA", true),
                bsB = GetCheckedArray(grpZhinengpinghengB, "chkZhinengpinghengB", true),
                bsC = GetCheckedArray(grpZhinengpinghengC, "chkZhinengpinghengC", true),
                AppearCounts = GetCheckedArray(grpZhinengpingheng, "chkZhinengpinghengChuxian", true),
            };
        }

        // 连号轨迹
        private void SetLianHaoGuiJi()
        {
            A11_5._LianHaoGuiJi = new LianHaoGuiJi()
            {
                guiji = GetCheckedArray(grpLianhaoguiji, "chkLianhao", true),
                /*
                AppearCounts = GetCheckedArray(grpLianhaoguiji, "chkLianhaoChuxian", true),
                 */
            };
        }

        FinalBox final;
        private void Generate11_5_Click(object sender, EventArgs e)
        {
            if (final != null)
            {
                final.Close();
            }

            SetBaseNums();  //基础号码
            SetReNoAndPassNo(); //重号传号
            SetBileCodes(); //胆码
            SetSynthesizedAttribute();//综合属性
            SetSixLeft(); // 前后比例
            SetBalanceIndex(); // 设置平衡指数
            SetMaxLinkNum(); // 设置集临个数 、溃临个数
            SetLianHaoGuiJi();// 连号轨迹
            SetFaucetAndPterisPrimer(); // 设置龙头凤尾质数，和数
            SetFaucetAndPterisEven();//设置龙头凤尾 单数、双数
            SetFaucet012();//龙头 012路
            SetPteris012();//凤尾 012路
            SetLinkCounts();//设置临码号
            SetSumOfLotterys();// 设置和值
            SetSmallBitValue();//设置合值
            SetSpans();//设置跨度
            SetMaxMinusSmallMinus4s();//设置临码和
            SetMaxNearestNumDiss();//设置最大临码距离
            SetSmallerBigerLengths();//设置反编球距离
            SetSmallBiggerLenAddMaxNearestDiss();//设置边临和
            SetHeadTailMaxSkip();//首尾邻码最大间距
            SetTwoNumDiss(); // 两码差
            SetSkipNum(); // 跨码
            SettwoNums(); // 两码组合
            SetTwoNumDissCounts(); //差临值
            SetNearSkipCount(); //邻码间距
            SetLocateIndexNum(); //定位组选
            SetCountsOf012(); // 012路 
            SetTwoNumPluss();// 两码和
            Setrate012s(); // 012路比例
            //SetkillNears(); // 断临
            SetSkipBitSum(); // 隔位合
            SetSkipBitDis(); // 隔位差

            SetAiData(); //智能数据
            SetAIValues(); // 智能值
            SetAIBalance(); //智能平衡

            SetSkipBitSumFenxu(); // 隔位合 分序
            SetSkipBitDisFenxu();// 隔位差 分序
            A11_5.ReGetBaseLotterys();
            A11_5.Calc();

            string splieString = "";
            switch (CbbLotterySplite.SelectedIndex)
            {
                default:
                case 0:
                    splieString = " ";
                    break;
                case 1:
                    splieString = "，";
                    break;
                case 2:
                    splieString = ",";
                    break;
                case 3:
                    splieString = "；";
                    break;
                case 4:
                    splieString = ";";
                    break;
            }


            final = new FinalBox(A11_5.Lotterys, splieString);
            final.Show();
        }




        private void btnRePassBaseNumClear_Click(object sender, EventArgs e)
        {
            chkRePassBaseNum1.Checked = false;
            chkRePassBaseNum2.Checked = false;
            chkRePassBaseNum3.Checked = false;
            chkRePassBaseNum4.Checked = false;
            chkRePassBaseNum5.Checked = false;
            chkRePassBaseNum6.Checked = false;
            chkRePassBaseNum7.Checked = false;
            chkRePassBaseNum8.Checked = false;
            chkRePassBaseNum9.Checked = false;
            chkRePassBaseNum10.Checked = false;
            chkRePassBaseNum11.Checked = false;
        }

        private void btnReNoCountClear_Click(object sender, EventArgs e)
        {
            chkReNoCount0.Checked = false;
            chkReNoCount1.Checked = false;
            chkReNoCount2.Checked = false;
            chkReNoCount3.Checked = false;
            chkReNoCount4.Checked = false;
            chkReNoCount5.Checked = false;
        }

        private void btnPassSmallCount_Click(object sender, EventArgs e)
        {
            chkPassSmallCount0.Checked = false;
            chkPassSmallCount1.Checked = false;
            chkPassSmallCount2.Checked = false;
            chkPassSmallCount3.Checked = false;
            chkPassSmallCount4.Checked = false;
            chkPassSmallCount5.Checked = false;
        }

        private void btnPassBigCount_Click(object sender, EventArgs e)
        {
            chkPassBigCount0.Checked = false;
            chkPassBigCount1.Checked = false;
            chkPassBigCount2.Checked = false;
            chkPassBigCount3.Checked = false;
            chkPassBigCount4.Checked = false;
            chkPassBigCount5.Checked = false;
        }

        private void btnD1Clear_Click(object sender, EventArgs e)
        {
            chkD1_01.Checked = false;
            chkD1_02.Checked = false;
            chkD1_03.Checked = false;
            chkD1_04.Checked = false;
            chkD1_05.Checked = false;
            chkD1_06.Checked = false;
            chkD1_07.Checked = false;
            chkD1_08.Checked = false;
            chkD1_09.Checked = false;
            chkD1_10.Checked = false;
            chkD1_11.Checked = false;

            chkDA_0.Checked = false;
            chkDA_1.Checked = false;
            chkDA_2.Checked = false;
            chkDA_3.Checked = false;
            chkDA_4.Checked = false;
            chkDA_5.Checked = false;

            chkDA_0.Enabled = false;
            chkDA_1.Enabled = false;
            chkDA_2.Enabled = false;
            chkDA_3.Enabled = false;
            chkDA_4.Enabled = false;
            chkDA_5.Enabled = false;
        }

        private void btnD2Clear_Click(object sender, EventArgs e)
        {
            chkD2_01.Checked = false;
            chkD2_02.Checked = false;
            chkD2_03.Checked = false;
            chkD2_04.Checked = false;
            chkD2_05.Checked = false;
            chkD2_06.Checked = false;
            chkD2_07.Checked = false;
            chkD2_08.Checked = false;
            chkD2_09.Checked = false;
            chkD2_10.Checked = false;
            chkD2_11.Checked = false;

            chkDB_0.Checked = false;
            chkDB_1.Checked = false;
            chkDB_2.Checked = false;
            chkDB_3.Checked = false;
            chkDB_4.Checked = false;
            chkDB_5.Checked = false;

            chkDB_0.Enabled = false;
            chkDB_1.Enabled = false;
            chkDB_2.Enabled = false;
            chkDB_3.Enabled = false;
            chkDB_4.Enabled = false;
            chkDB_5.Enabled = false;
        }

        private void btnD3Clear_Click(object sender, EventArgs e)
        {
            chkD3_01.Checked = false;
            chkD3_02.Checked = false;
            chkD3_03.Checked = false;
            chkD3_04.Checked = false;
            chkD3_05.Checked = false;
            chkD3_06.Checked = false;
            chkD3_07.Checked = false;
            chkD3_08.Checked = false;
            chkD3_09.Checked = false;
            chkD3_10.Checked = false;
            chkD3_11.Checked = false;

            chkDC_0.Checked = false;
            chkDC_1.Checked = false;
            chkDC_2.Checked = false;
            chkDC_3.Checked = false;
            chkDC_4.Checked = false;
            chkDC_5.Checked = false;

            chkDC_0.Enabled = false;
            chkDC_1.Enabled = false;
            chkDC_2.Enabled = false;
            chkDC_3.Enabled = false;
            chkDC_4.Enabled = false;
            chkDC_5.Enabled = false;
        }

        private void btnD4Clear_Click(object sender, EventArgs e)
        {
            chkD4_01.Checked = false;
            chkD4_02.Checked = false;
            chkD4_03.Checked = false;
            chkD4_04.Checked = false;
            chkD4_05.Checked = false;
            chkD4_06.Checked = false;
            chkD4_07.Checked = false;
            chkD4_08.Checked = false;
            chkD4_09.Checked = false;
            chkD4_10.Checked = false;
            chkD4_11.Checked = false;

            chkDD_0.Checked = false;
            chkDD_1.Checked = false;
            chkDD_2.Checked = false;
            chkDD_3.Checked = false;
            chkDD_4.Checked = false;
            chkDD_5.Checked = false;

            chkDD_0.Enabled = false;
            chkDD_1.Enabled = false;
            chkDD_2.Enabled = false;
            chkDD_3.Enabled = false;
            chkDD_4.Enabled = false;
            chkDD_5.Enabled = false;
        }

        private void btnD5Clear_Click(object sender, EventArgs e)
        {
            chkD5_01.Checked = false;
            chkD5_02.Checked = false;
            chkD5_03.Checked = false;
            chkD5_04.Checked = false;
            chkD5_05.Checked = false;
            chkD5_06.Checked = false;
            chkD5_07.Checked = false;
            chkD5_08.Checked = false;
            chkD5_09.Checked = false;
            chkD5_10.Checked = false;
            chkD5_11.Checked = false;

            chkDE_0.Checked = false;
            chkDE_1.Checked = false;
            chkDE_2.Checked = false;
            chkDE_3.Checked = false;
            chkDE_4.Checked = false;
            chkDE_5.Checked = false;

            chkDE_0.Enabled = false;
            chkDE_1.Enabled = false;
            chkDE_2.Enabled = false;
            chkDE_3.Enabled = false;
            chkDE_4.Enabled = false;
            chkDE_5.Enabled = false;
        }

        private void btnSAClear_Click(object sender, EventArgs e)
        {
            chkEven0.Checked = false;
            chkEven1.Checked = false;
            chkEven2.Checked = false;
            chkEven3.Checked = false;
            chkEven4.Checked = false;
            chkEven5.Checked = false;
            chkSmall0.Checked = false;
            chkSmall1.Checked = false;
            chkSmall2.Checked = false;
            chkSmall3.Checked = false;
            chkSmall4.Checked = false;
            chkSmall5.Checked = false;
            chkSum0.Checked = false;
            chkSum1.Checked = false;
            chkSum2.Checked = false;
            chkSum3.Checked = false;
            chkSum4.Checked = false;
            chkSum5.Checked = false;
            chkLink0.Checked = false;
            chkLink1.Checked = false;
            chkLink2.Checked = false;
            chkLink3.Checked = false;
            chkLink4.Checked = false;

            chkSA0.Checked = false;
            chkSA1.Checked = false;
            chkSA2.Checked = false;
            chkSA3.Checked = false;
            chkSA4.Checked = false;

            chkSA0.Enabled = false;
            chkSA1.Enabled = false;
            chkSA2.Enabled = false;
            chkSA3.Enabled = false;
            chkSA4.Enabled = false;
        }

        private void chkLeftRightClear_Click(object sender, EventArgs e)
        {
            chkLeft0.Checked = false;
            chkLeft1.Checked = false;
            chkLeft2.Checked = false;
            chkLeft3.Checked = false;
            chkLeft4.Checked = false;
            chkLeft5.Checked = false;
            chkRight0.Checked = false;
            chkRight1.Checked = false;
            chkRight2.Checked = false;
            chkRight3.Checked = false;
            chkRight4.Checked = false;
            chkRight5.Checked = false;
        }

        private void btnBalanceClear_Click(object sender, EventArgs e)
        {
            chkLeftEqualRight.Checked = false;
            chkLeftMore.Checked = false;
            chkRightMore.Checked = false;

            /*
            chkAppear0.Checked = false;
            chkAppear1.Checked = false;

            chkAppear0.Enabled = false;
            chkAppear1.Enabled = false;
             */
        }

        private void chkRePassBaseNum1_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckState(grpReNoPassNo, 5, sender);
        }

        private void btnLinkNumClear_Click(object sender, EventArgs e)
        {
            chkLinkNum1.Checked = false;
            chkLinkNum2.Checked = false;
            chkLinkNum3.Checked = false;
            chkLinkNum4.Checked = false;
            chkLinkNum5.Checked = false;
        }

        private void btnNotLinkNumClear_Click(object sender, EventArgs e)
        {
            chkNotLinkNum1.Checked = false;
            chkNotLinkNum2.Checked = false;
            chkNotLinkNum3.Checked = false;
            chkNotLinkNum4.Checked = false;
            chkNotLinkNum5.Checked = false;
            chkNotLinkNum6.Checked = false;
        }

        private void checkBox812_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

            int condition = -1;

            if (chkLiRunLv.Checked)
            {
                condition = 0;
            }
            else if (chkLiRun.Checked)
            {
                condition = 1;
            }
            else if (chkGeCheng.Checked)
            {
                condition = 2;
            }
            else if (chkGeJia.Checked)
            {
                condition = 3;
            }


            List<AlgorithmTools.BeiLvCalc> bcs = AlgorithmTools.CalcBeiLv(
                int.Parse(txtDanZhuJinE.Text), int.Parse(txtZhongJiangJinE.Text), int.Parse(txtJiHuaTouZhu.Text),
                int.Parse(txtQiShiBeiLv.Text), int.Parse(txtZhuiHaoQiShu.Text), condition,
                int.Parse(txtLiRun.Text), int.Parse(txtLiRunLv.Text), int.Parse(txtQiCheng.Text), int.Parse(cbbBeiCheng.Text), int.Parse(txtQiJia.Text), int.Parse(cbbBeiJia.Text));

            dgvCalc.Rows.Clear();
            for (int i = 0; i < bcs.Count; i++)
            {
                dgvCalc.Rows.Add((i + 1)
                    , bcs[i].BeiLv
                    , bcs[i].ZhuShu
                    , bcs[i].TouRu
                    , bcs[i].LeiJi
                    , bcs[i].ZhongJiang
                    , bcs[i].LiRun
                    , Math.Round(bcs[i].LiRunLv * 100).ToString() + "%"
                    );
            }
        }

        private void chkLiRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiRun.Checked)
            {
                chkLiRunLv.Checked = !chkLiRun.Checked;
                chkGeCheng.Checked = !chkLiRun.Checked;
                chkGeJia.Checked = !chkLiRun.Checked;
            }

        }

        private void chkLiRunLv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiRunLv.Checked)
            {
                chkLiRun.Checked = !chkLiRunLv.Checked;
                chkGeCheng.Checked = !chkLiRunLv.Checked;
                chkGeJia.Checked = !chkLiRunLv.Checked;
            }

        }

        private void chkGeCheng_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGeCheng.Checked)
            {
                chkLiRun.Checked = !chkGeCheng.Checked;
                chkLiRunLv.Checked = !chkGeCheng.Checked;
                chkGeJia.Checked = !chkGeCheng.Checked;
            }

        }

        private void chkGeJia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGeJia.Checked)
            {
                chkLiRun.Checked = !chkGeJia.Checked;
                chkLiRunLv.Checked = !chkGeJia.Checked;
                chkGeCheng.Checked = !chkGeJia.Checked;
            }

        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (CyyDb.CheckCountOfSameOnlineUserLogin(USERID) <= 0)
            {
                tmrUpdate.Enabled = false;
                if (MessageBox.Show("系统检测到您的软件出现异常,请重新登录!", "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    CyyMain.cyyMainExit();
                }
            }
        }

        private void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (AutoGetCPDataCheckBox.Checked)
            {
                getCPData11_5(true);
            }

            if (autoGetCP11x3DataCheckBox.Checked)
            {
                getCPData11_3(true);
            }
        }

        private void chkLianhaoChuxianQing_Click(object sender, EventArgs e)
        {
            chkLianhao0.Checked = false;
            chkLianhao1.Checked = false;
            chkLianhao2.Checked = false;

            /*
            chkLianhaoChuxian0.Checked = false;
            chkLianhaoChuxian1.Checked = false;

            chkLianhaoChuxian0.Enabled = false;
            chkLianhaoChuxian1.Enabled = false;
             */
        }

        private void chkLingmahaoChuxianQing_Click(object sender, EventArgs e)
        {
            chkLingmahaoChuxian0.Checked = false;
            chkLingmahaoChuxian1.Checked = false;
            chkLingmahaoChuxian2.Checked = false;
        }

        private void btnLongfengZhiheQing_Click(object sender, EventArgs e)
        {
            chkLongtouZhi.Checked = false;
            chkLongtouHe.Checked = false;

            chkFengweiZhi.Checked = false;
            chkFengweiHe.Checked = false;

            chkLongfengZhiheChuxian0.Checked = false;
            chkLongfengZhiheChuxian1.Checked = false;
            chkLongfengZhiheChuxian2.Checked = false;

            chkLongfengZhiheChuxian0.Enabled = false;
            chkLongfengZhiheChuxian1.Enabled = false;
            chkLongfengZhiheChuxian2.Enabled = false;
        }

        private void btnLongfengDanshuangChuxianQing_Click(object sender, EventArgs e)
        {
            chkLongtouDan.Checked = false;
            chkLongtouShuang.Checked = false;

            chkFengweiDan.Checked = false;
            chkFengweiShuang.Checked = false;

            chkLongfengDanshuangChuxian0.Checked = false;
            chkLongfengDanshuangChuxian1.Checked = false;
            chkLongfengDanshuangChuxian2.Checked = false;

            chkLongfengDanshuangChuxian0.Enabled = false;
            chkLongfengDanshuangChuxian1.Enabled = false;
            chkLongfengDanshuangChuxian2.Enabled = false;
        }

        private void chkGuaduQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpKuadu, false);
        }



        private void SetCheckboxState(GroupBox grp, bool b)
        {

            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    cb.Checked = b;
                }
            }

        }

        private void chkLingmaheQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLingmahe, false);
        }

        private void chkHezhidownQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpHezhidown, false);
        }

        private void bntLiangmachaChuxianQing1_Click(object sender, EventArgs e)
        {

            chkLiangmacha1_1.Checked = false;
            chkLiangmacha1_2.Checked = false;
            chkLiangmacha1_3.Checked = false;
            chkLiangmacha1_4.Checked = false;
            chkLiangmacha1_5.Checked = false;
            chkLiangmacha1_6.Checked = false;
            chkLiangmacha1_7.Checked = false;
            chkLiangmacha1_8.Checked = false;
            chkLiangmacha1_9.Checked = false;
            chkLiangmacha1_10.Checked = false;

            chkLiangmachaChuxian1_0.Checked = false;
            chkLiangmachaChuxian1_1.Checked = false;
            chkLiangmachaChuxian1_2.Checked = false;
            chkLiangmachaChuxian1_3.Checked = false;
            chkLiangmachaChuxian1_4.Checked = false;
            chkLiangmachaChuxian1_5.Checked = false;
        }

        private void bntLiangmachaChuxianQing2_Click(object sender, EventArgs e)
        {

            chkLiangmacha2_1.Checked = false;
            chkLiangmacha2_2.Checked = false;
            chkLiangmacha2_3.Checked = false;
            chkLiangmacha2_4.Checked = false;
            chkLiangmacha2_5.Checked = false;
            chkLiangmacha2_6.Checked = false;
            chkLiangmacha2_7.Checked = false;
            chkLiangmacha2_8.Checked = false;
            chkLiangmacha2_9.Checked = false;
            chkLiangmacha2_10.Checked = false;

            chkLiangmachaChuxian2_0.Checked = false;
            chkLiangmachaChuxian2_1.Checked = false;
            chkLiangmachaChuxian2_2.Checked = false;
            chkLiangmachaChuxian2_3.Checked = false;
            chkLiangmachaChuxian2_4.Checked = false;
            chkLiangmachaChuxian2_5.Checked = false;
        }

        private void bntLiangmachaChuxianQing3_Click(object sender, EventArgs e)
        {

            chkLiangmacha3_1.Checked = false;
            chkLiangmacha3_2.Checked = false;
            chkLiangmacha3_3.Checked = false;
            chkLiangmacha3_4.Checked = false;
            chkLiangmacha3_5.Checked = false;
            chkLiangmacha3_6.Checked = false;
            chkLiangmacha3_7.Checked = false;
            chkLiangmacha3_8.Checked = false;
            chkLiangmacha3_9.Checked = false;
            chkLiangmacha3_10.Checked = false;

            chkLiangmachaChuxian3_0.Checked = false;
            chkLiangmachaChuxian3_1.Checked = false;
            chkLiangmachaChuxian3_2.Checked = false;
            chkLiangmachaChuxian3_3.Checked = false;
            chkLiangmachaChuxian3_4.Checked = false;
            chkLiangmachaChuxian3_5.Checked = false;
        }

        private void bntLiangmachaChuxianQing4_Click(object sender, EventArgs e)
        {

            chkLiangmacha4_1.Checked = false;
            chkLiangmacha4_2.Checked = false;
            chkLiangmacha4_3.Checked = false;
            chkLiangmacha4_4.Checked = false;
            chkLiangmacha4_5.Checked = false;
            chkLiangmacha4_6.Checked = false;
            chkLiangmacha4_7.Checked = false;
            chkLiangmacha4_8.Checked = false;
            chkLiangmacha4_9.Checked = false;
            chkLiangmacha4_10.Checked = false;

            chkLiangmachaChuxian4_0.Checked = false;
            chkLiangmachaChuxian4_1.Checked = false;
            chkLiangmachaChuxian4_2.Checked = false;
            chkLiangmachaChuxian4_3.Checked = false;
            chkLiangmachaChuxian4_4.Checked = false;
            chkLiangmachaChuxian4_5.Checked = false;
        }

        private void bntLiangmachaChuxianQing5_Click(object sender, EventArgs e)
        {

            chkLiangmacha5_1.Checked = false;
            chkLiangmacha5_2.Checked = false;
            chkLiangmacha5_3.Checked = false;
            chkLiangmacha5_4.Checked = false;
            chkLiangmacha5_5.Checked = false;
            chkLiangmacha5_6.Checked = false;
            chkLiangmacha5_7.Checked = false;
            chkLiangmacha5_8.Checked = false;
            chkLiangmacha5_9.Checked = false;
            chkLiangmacha5_10.Checked = false;

            chkLiangmachaChuxian5_0.Checked = false;
            chkLiangmachaChuxian5_1.Checked = false;
            chkLiangmachaChuxian5_2.Checked = false;
            chkLiangmachaChuxian5_3.Checked = false;
            chkLiangmachaChuxian5_4.Checked = false;
            chkLiangmachaChuxian5_5.Checked = false;
        }

        private void chkFanbianqiujuliQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpFanbianqiujuli, false);
        }

        private void bntZuidalingmakuajuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZuidalingmakuaju, false);
        }

        private void bntBianlingheQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpBianlinghe, false);
        }

        private void chkKuamaChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpKuama, false);

            chkKuamaChuxian0.Enabled = false;
            chkKuamaChuxian1.Enabled = false;
            chkKuamaChuxian2.Enabled = false;
            chkKuamaChuxian3.Enabled = false;
            chkKuamaChuxian4.Enabled = false;
        }

        private void chkLingmajianjuChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLingmajianju, false);
            chkLingmajianjuChuxian0.Enabled = false;
            chkLingmajianjuChuxian1.Enabled = false;
            chkLingmajianjuChuxian2.Enabled = false;
            chkLingmajianjuChuxian3.Enabled = false;
            chkLingmajianjuChuxian4.Enabled = false;
            chkLingmajianjuChuxian5.Enabled = false;
            chkLingmajianjuChuxian6.Enabled = false;
            chkLingmajianjuChuxian7.Enabled = false;
        }

        private void chkShouweilingmazuidajianjuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpShouweilingmazuidajianju, false);
        }

        private void chkLingchazhiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLingchazhi, false);
        }

        // 断临
        /*
        private void bntDuanlingQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpDuanling, false);
        }
         */

        private void chkLiangmaheChuxianQing_Click(object sender, EventArgs e)
        {
            chkLiangmahe1_3.Checked = false;
            chkLiangmahe1_4.Checked = false;
            chkLiangmahe1_5.Checked = false;
            chkLiangmahe1_6.Checked = false;
            chkLiangmahe1_7.Checked = false;
            chkLiangmahe1_8.Checked = false;
            chkLiangmahe1_9.Checked = false;
            chkLiangmahe1_10.Checked = false;
            chkLiangmahe1_11.Checked = false;
            chkLiangmahe1_12.Checked = false;
            chkLiangmahe1_13.Checked = false;
            chkLiangmahe1_14.Checked = false;
            chkLiangmahe1_15.Checked = false;
            chkLiangmahe1_16.Checked = false;
            chkLiangmahe1_17.Checked = false;
            chkLiangmahe1_18.Checked = false;
            chkLiangmahe1_19.Checked = false;
            chkLiangmahe1_20.Checked = false;
            chkLiangmahe1_21.Checked = false;

            chkLiangmaheChuxian1_0.Checked = false;
            chkLiangmaheChuxian1_1.Checked = false;
            chkLiangmaheChuxian1_2.Checked = false;
            chkLiangmaheChuxian1_3.Checked = false;
            chkLiangmaheChuxian1_4.Checked = false;
            chkLiangmaheChuxian1_5.Checked = false;

            chkLiangmaheChuxian1_0.Enabled = false;
            chkLiangmaheChuxian1_1.Enabled = false;
            chkLiangmaheChuxian1_2.Enabled = false;
            chkLiangmaheChuxian1_3.Enabled = false;
            chkLiangmaheChuxian1_4.Enabled = false;
            chkLiangmaheChuxian1_5.Enabled = false;
        }

        private void bnt012lugeshuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(groupBox9, false);
            SetCheckboxState(groupBox11, false);
            SetCheckboxState(groupBox12, false);

            chk012lugeshuChuxian0.Checked = false;
            chk012lugeshuChuxian1.Checked = false;
            chk012lugeshuChuxian2.Checked = false;
            chk012lugeshuChuxian3.Checked = false;

            chk012lugeshuChuxian0.Enabled = false;
            chk012lugeshuChuxian1.Enabled = false;
            chk012lugeshuChuxian2.Enabled = false;
            chk012lugeshuChuxian3.Enabled = false;
        }

        private void bnt012lubiliChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp012lubili, false);
            chk012lubiliChuxian0.Enabled = false;
            chk012lubiliChuxian1.Enabled = false;
            /*
            chk012lubiliChuxian2.Enabled = false;
            chk012lubiliChuxian3.Enabled = false;
            chk012lubiliChuxian4.Enabled = false;
            chk012lubiliChuxian5.Enabled = false;
            chk012lubiliChuxian6.Enabled = false;
             */
        }

        private void chkKuaisupipeiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpKuaisupipei, false);
        }

        private void bntGeweiheChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpGeweihe, false);
            chkGeweiheChuxian0.Enabled = false;
            chkGeweiheChuxian1.Enabled = false;
            chkGeweiheChuxian2.Enabled = false;
            chkGeweiheChuxian3.Enabled = false;
            chkGeweiheChuxian4.Enabled = false;
            chkGeweiheChuxian5.Enabled = false;
        }

        private void bntGeweichaChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpGeweicha, false);
            chkGeweichaChuxian0.Enabled = false;
            chkGeweichaChuxian1.Enabled = false;
            chkGeweichaChuxian2.Enabled = false;
            chkGeweichaChuxian3.Enabled = false;
            chkGeweichaChuxian4.Enabled = false;
            chkGeweichaChuxian5.Enabled = false;
        }

        private void bntGeweihefengxuzuxuanChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpGeweihefengxuzuxuan, false);
            chkGeweihefengxuzuxuanChuxian1.Enabled = false;
            chkGeweihefengxuzuxuanChuxian2.Enabled = false;
            chkGeweihefengxuzuxuanChuxian3.Enabled = false;
        }

        private void bntGeweichafengxuzuxuanChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpGeweichafengxuzuxuan, false);
            chkGeweichafengxuzuxuanChuxian1.Enabled = false;
            chkGeweichafengxuzuxuanChuxian2.Enabled = false;
            chkGeweichafengxuzuxuanChuxian3.Enabled = false;
        }

        private void chkZhinengShujuChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengShuju, false);
            SetCheckboxState(grpZhinengA, false);
            SetCheckboxState(grpZhinengB, false);
            SetCheckboxState(grpZhinengC, false);
            SetCheckboxState(grpZhinengD, false);

            chkZhinengShujuChuxian0.Enabled = false;
            chkZhinengShujuChuxian1.Enabled = false;
            chkZhinengShujuChuxian2.Enabled = false;
            chkZhinengShujuChuxian3.Enabled = false;
            chkZhinengShujuChuxian4.Enabled = false;
        }

        private void bntZhinengzhiAQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiA, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiBQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiB, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiCQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiC, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiDQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiD, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiEQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiE, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiFQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhiF, false);
            chkZhinengzhiA0_Click(sender, e);
        }
        private void bntZhinengzhiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengzhi, false);

            chkZhinengzhi0.Enabled = false;
            chkZhinengzhi1.Enabled = false;
            chkZhinengzhi2.Enabled = false;
            chkZhinengzhi3.Enabled = false;
            chkZhinengzhi4.Enabled = false;
            chkZhinengzhi5.Enabled = false;
            chkZhinengzhi6.Enabled = false;

            bntZhinengzhiAQing_Click(sender, e);
            bntZhinengzhiBQing_Click(sender, e);
            bntZhinengzhiCQing_Click(sender, e);
            bntZhinengzhiDQing_Click(sender, e);
            bntZhinengzhiEQing_Click(sender, e);
            bntZhinengzhiFQing_Click(sender, e);
        }

        private void bntZhinengpinghengAQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengpinghengA, false);
            chkZhinengpinghengA0_Click(sender, e);
        }

        private void bntZhinengpinghengBQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengpinghengB, false);
            chkZhinengpinghengA0_Click(sender, e);
        }

        private void bntZhinengpinghengCQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengpinghengC, false);
            chkZhinengpinghengA0_Click(sender, e);
        }

        private void bntZhinengpinghengChuxianQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpZhinengpingheng, false);

            chkZhinengpinghengChuxian0.Enabled = false;
            chkZhinengpinghengChuxian1.Enabled = false;
            chkZhinengpinghengChuxian2.Enabled = false;
            chkZhinengpinghengChuxian3.Enabled = false;

            bntZhinengpinghengAQing_Click(sender, e);
            bntZhinengpinghengBQing_Click(sender, e);
            bntZhinengpinghengCQing_Click(sender, e);
        }

        private void chkRePassBaseNum1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpReNoPassNo, 5, sender);
        }

        private void chkRePassBaseNum2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkD1_01_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkD2_02_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkD1_01_Click(object sender, EventArgs e)
        {
            SetCheckState(grpBileCode, "chkD1_", "chkDA_");
            //SetCheckState(grpBileCode, 5, sender, "chkD1_");
        }

        private void chkD2_01_Click(object sender, EventArgs e)
        {
            SetCheckState(grpBileCode, "chkD2_", "chkDB_");
            //SetCheckState(grpBileCode, 5, sender, "chkD2_");
        }

        private void chkD3_01_Click(object sender, EventArgs e)
        {
            SetCheckState(grpBileCode, "chkD3_", "chkDC_");
            //SetCheckState(grpBileCode, 5, sender, "chkD3_");
        }

        private void chkD4_01_Click(object sender, EventArgs e)
        {
            SetCheckState(grpBileCode, "chkD4_", "chkDD_");
            //SetCheckState(grpBileCode, 5, sender, "chkD4_");
        }

        private void chkD5_01_Click(object sender, EventArgs e)
        {
            SetCheckState(grpBileCode, "chkD5_", "chkDE_");
            //SetCheckState(grpBileCode, 5, sender, "chkD5_");
        }

        private void chkLeftMore_Click(object sender, EventArgs e)
        {
            int count = (chkLeftMore.Checked ? 1 : 0)
                + (chkRightMore.Checked ? 1 : 0) + (chkLeftEqualRight.Checked ? 1 : 0);


            SetCheckState(grpBalanceIndex, count, "chkAppear");


        }

        private void chkLianhao0_Click(object sender, EventArgs e)
        {
            int count = (chkLianhao0.Checked ? 1 : 0)
    + (chkLianhao1.Checked ? 1 : 0) + (chkLianhao2.Checked ? 1 : 0);


            SetCheckState(grpLianhaoguiji, count, "chkLianhaoChuxian");
        }

        private void chkSmall0_Click(object sender, EventArgs e)
        {
            int count = ((chkSmall0.Checked || chkSmall1.Checked || chkSmall2.Checked || chkSmall3.Checked || chkSmall4.Checked || chkSmall5.Checked) ? 1 : 0)
                + ((chkEven0.Checked || chkEven1.Checked || chkEven2.Checked || chkEven3.Checked || chkEven4.Checked || chkEven5.Checked) ? 1 : 0)
                + ((chkSum0.Checked || chkSum1.Checked || chkSum2.Checked || chkSum3.Checked || chkSum4.Checked || chkSum5.Checked) ? 1 : 0)
                + ((chkLink0.Checked || chkLink1.Checked || chkLink2.Checked || chkLink3.Checked || chkLink4.Checked) ? 1 : 0);

            SetCheckState(grpSynthesizedAttribute, count, "chkSA");
        }

        private void chkLongtouZhi_Click(object sender, EventArgs e)
        {
            int count = ((chkLongtouZhi.Checked || chkLongtouHe.Checked) ? 1 : 0)
               + ((chkFengweiZhi.Checked || chkFengweiHe.Checked) ? 1 : 0);
            SetCheckState(grpLongFengBig, count, "chkLongfengZhiheChuxian");

        }

        private void chkLongtouDan_Click(object sender, EventArgs e)
        {
            int count = ((chkLongtouDan.Checked || chkLongtouShuang.Checked) ? 1 : 0)
               + ((chkFengweiDan.Checked || chkFengweiShuang.Checked) ? 1 : 0);
            SetCheckState(grpLongFengBig, count, "chkLongfengDanshuangChuxian");

        }

        private void chkLiangmacha1_0_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmacha, "chkLiangmacha1_", "chkLiangmachaChuxian1_");
            // SetCheckState(grpLiangmacha, 5, sender, "chkLiangmachaChuxian1_");
        }

        private void chkLiangmacha2_0_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmacha, "chkLiangmacha2_", "chkLiangmachaChuxian2_");
            // SetCheckState(grpLiangmacha, 5, sender, "chkLiangmachaChuxian2_");
        }

        private void chkLiangmacha3_0_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmacha, "chkLiangmacha3_", "chkLiangmachaChuxian3_");
            //SetCheckState(grpLiangmacha, 5, sender, "chkLiangmachaChuxian3_");
        }

        private void chkLiangmacha4_0_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmacha, "chkLiangmacha4_", "chkLiangmachaChuxian4_");
            //SetCheckState(grpLiangmacha, 5, sender, "chkLiangmachaChuxian4_");
        }

        private void chkLiangmacha5_0_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmacha, "chkLiangmacha5_", "chkLiangmachaChuxian5_");
            //SetCheckState(grpLiangmacha, 5, sender, "chkLiangmachaChuxian5_");
        }

        private void chkKuama1_Click(object sender, EventArgs e)
        {
            int count = (chkKuama1.Checked ? 1 : 0)
                + (chkKuama2.Checked ? 1 : 0)
                + (chkKuama3.Checked ? 1 : 0)
                + (chkKuama4.Checked ? 1 : 0)
                + (chkKuama5.Checked ? 1 : 0)
                + (chkKuama6.Checked ? 1 : 0)
                + (chkKuama7.Checked ? 1 : 0)
                + (chkKuama8.Checked ? 1 : 0)
                + (chkKuama9.Checked ? 1 : 0);

            SetCheckState(grpKuama, count, "chkKuamaChuxian");
        }


        private void chkDingweizuxuan1_1_Click(object sender, EventArgs e)
        {
            int count = ((chkDingweizuxuan1_1.Checked || chkDingweizuxuan1_2.Checked || chkDingweizuxuan1_3.Checked || chkDingweizuxuan1_4.Checked || chkDingweizuxuan1_5.Checked || chkDingweizuxuan1_6.Checked || chkDingweizuxuan1_7.Checked) ? 1 : 0)
                + ((chkDingweizuxuan2_2.Checked || chkDingweizuxuan2_3.Checked || chkDingweizuxuan2_4.Checked || chkDingweizuxuan2_5.Checked || chkDingweizuxuan2_6.Checked || chkDingweizuxuan2_7.Checked || chkDingweizuxuan2_8.Checked) ? 1 : 0)
                + ((chkDingweizuxuan3_3.Checked || chkDingweizuxuan3_4.Checked || chkDingweizuxuan3_5.Checked || chkDingweizuxuan3_6.Checked || chkDingweizuxuan3_7.Checked || chkDingweizuxuan3_8.Checked || chkDingweizuxuan3_9.Checked) ? 1 : 0)
                + ((chkDingweizuxuan4_4.Checked || chkDingweizuxuan4_5.Checked || chkDingweizuxuan4_6.Checked || chkDingweizuxuan4_7.Checked || chkDingweizuxuan4_8.Checked || chkDingweizuxuan4_9.Checked || chkDingweizuxuan4_10.Checked) ? 1 : 0)
                + ((chkDingweizuxuan5_5.Checked || chkDingweizuxuan5_6.Checked || chkDingweizuxuan5_7.Checked || chkDingweizuxuan5_8.Checked || chkDingweizuxuan5_9.Checked || chkDingweizuxuan5_10.Checked || chkDingweizuxuan5_11.Checked) ? 1 : 0);

            SetCheckState(grpDingweizuxuan, count, "chkDingweizuxuanChuxian");
        }

        private void chkLingmajianju0_0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkLingmajianju0_0.Checked || chkLingmajianju0_1.Checked || chkLingmajianju0_2.Checked || chkLingmajianju0_3.Checked || chkLingmajianju0_4.Checked) ? 1 : 0)
                + ((chkLingmajianju1_0.Checked || chkLingmajianju1_1.Checked || chkLingmajianju1_2.Checked || chkLingmajianju1_3.Checked || chkLingmajianju1_4.Checked) ? 1 : 0)
                + ((chkLingmajianju2_0.Checked || chkLingmajianju2_1.Checked || chkLingmajianju2_2.Checked || chkLingmajianju2_3.Checked) ? 1 : 0)
                + ((chkLingmajianju3_0.Checked || chkLingmajianju3_1.Checked || chkLingmajianju3_2.Checked) ? 1 : 0)
                + ((chkLingmajianju4_0.Checked || chkLingmajianju4_1.Checked) ? 1 : 0)
                + ((chkLingmajianju5_0.Checked || chkLingmajianju5_1.Checked) ? 1 : 0)
                + ((chkLingmajianju6_0.Checked || chkLingmajianju6_1.Checked) ? 1 : 0);

            SetCheckState(grpLingmajianju, count, "chkLingmajianjuChuxian");
        }

        private void chkLiangmahe1_3_Click(object sender, EventArgs e)
        {
            /*
            int count =
            ((chkLiangmahe1_3.Checked || chkLiangmahe1_4.Checked || chkLiangmahe1_5.Checked || chkLiangmahe1_6.Checked || chkLiangmahe1_7.Checked || chkLiangmahe1_8.Checked || chkLiangmahe1_9.Checked || chkLiangmahe1_10.Checked || chkLiangmahe1_11.Checked || chkLiangmahe1_12.Checked || chkLiangmahe1_13.Checked || chkLiangmahe1_14.Checked || chkLiangmahe1_15.Checked || chkLiangmahe1_16.Checked || chkLiangmahe1_17.Checked || chkLiangmahe1_18.Checked || chkLiangmahe1_19.Checked || chkLiangmahe1_20.Checked || chkLiangmahe1_21.Checked) ? 1 : 0)
            + ((chkLiangmahe2_3.Checked || chkLiangmahe2_4.Checked || chkLiangmahe2_5.Checked || chkLiangmahe2_6.Checked || chkLiangmahe2_7.Checked || chkLiangmahe2_8.Checked || chkLiangmahe2_9.Checked || chkLiangmahe2_10.Checked || chkLiangmahe2_11.Checked || chkLiangmahe2_12.Checked || chkLiangmahe2_13.Checked || chkLiangmahe2_14.Checked || chkLiangmahe2_15.Checked || chkLiangmahe2_16.Checked || chkLiangmahe2_17.Checked || chkLiangmahe2_18.Checked || chkLiangmahe2_19.Checked || chkLiangmahe2_20.Checked || chkLiangmahe2_21.Checked) ? 1 : 0)
            + ((chkLiangmahe3_3.Checked || chkLiangmahe3_4.Checked || chkLiangmahe3_5.Checked || chkLiangmahe3_6.Checked || chkLiangmahe3_7.Checked || chkLiangmahe3_8.Checked || chkLiangmahe3_9.Checked || chkLiangmahe3_10.Checked || chkLiangmahe3_11.Checked || chkLiangmahe3_12.Checked || chkLiangmahe3_13.Checked || chkLiangmahe3_14.Checked || chkLiangmahe3_15.Checked || chkLiangmahe3_16.Checked || chkLiangmahe3_17.Checked || chkLiangmahe3_18.Checked || chkLiangmahe3_19.Checked || chkLiangmahe3_20.Checked || chkLiangmahe3_21.Checked) ? 1 : 0)
            + ((chkLiangmahe4_3.Checked || chkLiangmahe4_4.Checked || chkLiangmahe4_5.Checked || chkLiangmahe4_6.Checked || chkLiangmahe4_7.Checked || chkLiangmahe4_8.Checked || chkLiangmahe4_9.Checked || chkLiangmahe4_10.Checked || chkLiangmahe4_11.Checked || chkLiangmahe4_12.Checked || chkLiangmahe4_13.Checked || chkLiangmahe4_14.Checked || chkLiangmahe4_15.Checked || chkLiangmahe4_16.Checked || chkLiangmahe4_17.Checked || chkLiangmahe4_18.Checked || chkLiangmahe4_19.Checked || chkLiangmahe4_20.Checked || chkLiangmahe4_21.Checked) ? 1 : 0)
            + ((chkLiangmahe5_3.Checked || chkLiangmahe5_4.Checked || chkLiangmahe5_5.Checked || chkLiangmahe5_6.Checked || chkLiangmahe5_7.Checked || chkLiangmahe5_8.Checked || chkLiangmahe5_9.Checked || chkLiangmahe5_10.Checked || chkLiangmahe5_11.Checked || chkLiangmahe5_12.Checked || chkLiangmahe5_13.Checked || chkLiangmahe5_14.Checked || chkLiangmahe5_15.Checked || chkLiangmahe5_16.Checked || chkLiangmahe5_17.Checked || chkLiangmahe5_18.Checked || chkLiangmahe5_19.Checked || chkLiangmahe5_20.Checked || chkLiangmahe5_21.Checked) ? 1 : 0);
           
            SetCheckState(grpLiangmahe, count, "chkLiangmaheChuxian"); */

            SetCheckState(grpLiangmahe, "chkLiangmahe1_", "chkLiangmaheChuxian1_");
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //chkLiangmaheChuxianQing1.PerformClick();
            //chkLiangmaheChuxianQing2.PerformClick();
            //chkLiangmaheChuxianQing3.PerformClick();
            //chkLiangmaheChuxianQing4.PerformClick();
            //chkLiangmaheChuxianQing5.PerformClick();
            chkLiangmaheChuxianQing_Click(sender, e);
            chkLiangmaheChuxianQing2_Click(sender, e);
            chkLiangmaheChuxianQing3_Click(sender, e);
            chkLiangmaheChuxianQing4_Click(sender, e);
            chkLiangmaheChuxianQing5_Click(sender, e);
            button8.PerformClick();
            btnRePassBaseNumClear_Click(sender, e);
            btnReNoCountClear_Click(sender, e);
            btnPassSmallCount_Click(sender, e);
            btnPassBigCount_Click(sender, e);
            btnD1Clear_Click(sender, e);
            btnD2Clear_Click(sender, e);
            btnD3Clear_Click(sender, e);
            btnD4Clear_Click(sender, e);
            btnD5Clear_Click(sender, e);
            btnSAClear_Click(sender, e);
            chkLeftRightClear_Click(sender, e);
            btnBalanceClear_Click(sender, e);
            btnLinkNumClear_Click(sender, e);
            btnNotLinkNumClear_Click(sender, e);
            chkLianhaoChuxianQing_Click(sender, e);
            chkLingmahaoChuxianQing_Click(sender, e);
            btnLongfengZhiheQing_Click(sender, e);
            btnLongfengDanshuangChuxianQing_Click(sender, e);
            chkGuaduQing_Click(sender, e);
            chkLingmaheQing_Click(sender, e);
            chkHezhidownQing_Click(sender, e);
            bntLiangmachaChuxianQing1_Click(sender, e);
            bntLiangmachaChuxianQing2_Click(sender, e);
            bntLiangmachaChuxianQing3_Click(sender, e);
            bntLiangmachaChuxianQing4_Click(sender, e);
            bntLiangmachaChuxianQing5_Click(sender, e);
            chkFanbianqiujuliQing_Click(sender, e);
            bntZuidalingmakuajuQing_Click(sender, e);
            bntBianlingheQing_Click(sender, e);
            chkKuamaChuxianQing_Click(sender, e);
            chkLingmajianjuChuxianQing_Click(sender, e);
            chkShouweilingmazuidajianjuQing_Click(sender, e);
            chkLingchazhiQing_Click(sender, e);
            //bntDuanlingQing_Click(sender, e); // 断临
            chkLiangmaheChuxianQing_Click(sender, e);
            bnt012lugeshuQing_Click(sender, e);
            bnt012lubiliChuxianQing_Click(sender, e);
            chkKuaisupipeiQing_Click(sender, e);
            bntGeweiheChuxianQing_Click(sender, e);
            bntGeweichaChuxianQing_Click(sender, e);
            bntGeweihefengxuzuxuanChuxianQing_Click(sender, e);
            bntGeweichafengxuzuxuanChuxianQing_Click(sender, e);
            chkZhinengShujuChuxianQing_Click(sender, e);
            bntZhinengzhiAQing_Click(sender, e);
            bntZhinengzhiQing_Click(sender, e);
            bntZhinengpinghengAQing_Click(sender, e);
            bntZhinengpinghengBQing_Click(sender, e);
            bntZhinengpinghengCQing_Click(sender, e);
            bntZhinengpinghengChuxianQing_Click(sender, e);
            //
            SetCheckboxState(grpHezhi, false);
            ClearDingweizuxuan();
            SetCheckboxState(grpLongtou012Lu, false);
            SetCheckboxState(grpFengwei012Lu, false);
            button9_Click(sender, e);
            button10_Click_1(sender, e);
        }

        private void ClearDingweizuxuan()
        {
            SetCheckboxState(grpDingweizuxuan, false);
            chkDingweizuxuanChuxian0.Enabled = false;
            chkDingweizuxuanChuxian1.Enabled = false;
            chkDingweizuxuanChuxian2.Enabled = false;
            chkDingweizuxuanChuxian3.Enabled = false;
            chkDingweizuxuanChuxian4.Enabled = false;
            chkDingweizuxuanChuxian5.Enabled = false;
        }

        private bool chkKuamaSelectAllBool = false;
        private void chkKuamaSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //chkKuama1_Click(sender,e);

            if (!chkKuamaSelectAllBool)
            {
                chkKuamaSelectAllBool = true;
                chkKuama1.Checked = true;
                chkKuama2.Checked = true;
                chkKuama3.Checked = true;
                chkKuama4.Checked = true;
                chkKuama5.Checked = true;
                chkKuama6.Checked = true;
                chkKuama7.Checked = true;
                chkKuama8.Checked = true;
                chkKuama9.Checked = true;
            }
            else
            {
                chkKuamaSelectAllBool = false;
                chkKuama1.Checked = false;
                chkKuama2.Checked = false;
                chkKuama3.Checked = false;
                chkKuama4.Checked = false;
                chkKuama5.Checked = false;
                chkKuama6.Checked = false;
                chkKuama7.Checked = false;
                chkKuama8.Checked = false;
                chkKuama9.Checked = false;
            }
            chkKuama1_Click(sender, e);

        }

        private bool chkShouweilingmazuidajianjuSelectAllBool = false;
        private void chkShouweilingmazuidajianjuSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShouweilingmazuidajianjuSelectAllBool)
            {
                chkShouweilingmazuidajianjuSelectAllBool = true;
                SetCheckboxState(grpShouweilingmazuidajianju, true);

            }
            else
            {
                SetCheckboxState(grpShouweilingmazuidajianju, false);
                chkShouweilingmazuidajianjuSelectAllBool = false;
            }

        }

        private bool checkBox234Bool = false;
        private void checkBox234_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox234Bool)
            {
                checkBox234Bool = true;
                SetCheckboxState(grpHezhi, true);

            }
            else
            {
                SetCheckboxState(grpHezhi, false);
                checkBox234Bool = false;
            }
        }

        private bool chkZhinengASelectAllBool = false;
        private void chkZhinengASelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkZhinengASelectAllBool)
            {
                chkZhinengASelectAllBool = true;
                SetCheckboxState(grpZhinengA, true);

            }
            else
            {
                SetCheckboxState(grpZhinengA, false);
                chkZhinengASelectAllBool = false;
            }
        }

        private bool chkZhinengBSelectAllBool = false;
        private void chkZhinengBSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkZhinengBSelectAllBool)
            {
                chkZhinengBSelectAllBool = true;
                SetCheckboxState(grpZhinengB, true);

            }
            else
            {
                SetCheckboxState(grpZhinengB, false);
                chkZhinengBSelectAllBool = false;
            }
        }

        private bool chkZhinengCSelectAllBool = false;
        private void chkZhinengCSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkZhinengCSelectAllBool)
            {
                chkZhinengCSelectAllBool = true;
                SetCheckboxState(grpZhinengC, true);

            }
            else
            {
                SetCheckboxState(grpZhinengC, false);
                chkZhinengCSelectAllBool = false;
            }
        }

        private bool chkZhinengDSelectAllBool = false;
        private void chkZhinengDSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkZhinengDSelectAllBool)
            {
                chkZhinengDSelectAllBool = true;
                SetCheckboxState(grpZhinengD, true);

            }
            else
            {
                SetCheckboxState(grpZhinengD, false);
                chkZhinengDSelectAllBool = false;
            }
        }

        private void chk0lugeshu0_Click(object sender, EventArgs e)
        {
            int count =
                ((chk0lugeshu0.Checked || chk0lugeshu1.Checked || chk0lugeshu2.Checked || chk0lugeshu3.Checked) ? 1 : 0)
                + ((chk1lugeshu0.Checked || chk1lugeshu1.Checked || chk1lugeshu2.Checked || chk1lugeshu3.Checked || chk1lugeshu4.Checked) ? 1 : 0)
                + ((chk2lugeshu0.Checked || chk2lugeshu1.Checked || chk2lugeshu2.Checked || chk2lugeshu3.Checked || chk2lugeshu4.Checked) ? 1 : 0);
            SetCheckState(grp012lugeshu, count, "chk012lugeshuChuxian");
        }

        private void chk012lubili320_Click(object sender, EventArgs e)
        {
            int count = (chk012lubili320.Checked ? 1 : 0)
                + (chk012lubili203.Checked ? 1 : 0)
                + (chk012lubili104.Checked ? 1 : 0)
                + (chk012lubili041.Checked ? 1 : 0)
                + (chk012lubili302.Checked ? 1 : 0)
                + (chk012lubili221.Checked ? 1 : 0)
                + (chk012lubili131.Checked ? 1 : 0)
                + (chk012lubili014.Checked ? 1 : 0)
                + (chk012lubili311.Checked ? 1 : 0)
                + (chk012lubili212.Checked ? 1 : 0)
                + (chk012lubili113.Checked ? 1 : 0)
                + (chk012lubili032.Checked ? 1 : 0)
                + (chk012lubili230.Checked ? 1 : 0)
                + (chk012lubili140.Checked ? 1 : 0)
                + (chk012lubili122.Checked ? 1 : 0)
                + (chk012lubili023.Checked ? 1 : 0)
                ;
            SetCheckState(grp012lubili, count, "chk012lubiliChuxian");
        }

        private void chkGeweihe1_0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkGeweihe1_0.Checked || chkGeweihe1_1.Checked || chkGeweihe1_2.Checked || chkGeweihe1_3.Checked || chkGeweihe1_4.Checked || chkGeweihe1_5.Checked || chkGeweihe1_6.Checked || chkGeweihe1_7.Checked || chkGeweihe1_8.Checked || chkGeweihe1_9.Checked) ? 1 : 0)
                + ((chkGeweihe2_0.Checked || chkGeweihe2_1.Checked || chkGeweihe2_2.Checked || chkGeweihe2_3.Checked || chkGeweihe2_4.Checked || chkGeweihe2_5.Checked || chkGeweihe2_6.Checked || chkGeweihe2_7.Checked || chkGeweihe2_8.Checked || chkGeweihe2_9.Checked) ? 1 : 0)
                + ((chkGeweihe3_0.Checked || chkGeweihe3_1.Checked || chkGeweihe3_2.Checked || chkGeweihe3_3.Checked || chkGeweihe3_4.Checked || chkGeweihe3_5.Checked || chkGeweihe3_6.Checked || chkGeweihe3_7.Checked || chkGeweihe3_8.Checked || chkGeweihe3_9.Checked) ? 1 : 0)
                + ((chkGeweihe4_0.Checked || chkGeweihe4_1.Checked || chkGeweihe4_2.Checked || chkGeweihe4_3.Checked || chkGeweihe4_4.Checked || chkGeweihe4_5.Checked || chkGeweihe4_6.Checked || chkGeweihe4_7.Checked || chkGeweihe4_8.Checked || chkGeweihe4_9.Checked) ? 1 : 0)
                + ((chkGeweihe5_0.Checked || chkGeweihe5_1.Checked || chkGeweihe5_2.Checked || chkGeweihe5_3.Checked || chkGeweihe5_4.Checked || chkGeweihe5_5.Checked || chkGeweihe5_6.Checked || chkGeweihe5_7.Checked || chkGeweihe5_8.Checked || chkGeweihe5_9.Checked) ? 1 : 0)
                ;
            SetCheckState(grpGeweihe, count, "chkGeweiheChuxian");
        }

        private void chkGeweicha1_0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkGeweicha1_2.Checked || chkGeweicha1_3.Checked || chkGeweicha1_4.Checked || chkGeweicha1_5.Checked || chkGeweicha1_6.Checked || chkGeweicha1_7.Checked || chkGeweicha1_8.Checked) ? 1 : 0)
                + ((chkGeweicha2_2.Checked || chkGeweicha2_3.Checked || chkGeweicha2_4.Checked || chkGeweicha2_5.Checked || chkGeweicha2_6.Checked || chkGeweicha2_7.Checked || chkGeweicha2_8.Checked) ? 1 : 0)
                + ((chkGeweicha3_2.Checked || chkGeweicha3_3.Checked || chkGeweicha3_4.Checked || chkGeweicha3_5.Checked || chkGeweicha3_6.Checked || chkGeweicha3_7.Checked || chkGeweicha3_8.Checked) ? 1 : 0)
                + ((chkGeweicha4_2.Checked || chkGeweicha4_3.Checked || chkGeweicha4_4.Checked || chkGeweicha4_5.Checked || chkGeweicha4_6.Checked || chkGeweicha4_7.Checked || chkGeweicha4_8.Checked) ? 1 : 0)
                + ((chkGeweicha5_2.Checked || chkGeweicha5_3.Checked || chkGeweicha5_4.Checked || chkGeweicha5_5.Checked || chkGeweicha5_6.Checked || chkGeweicha5_7.Checked || chkGeweicha5_8.Checked) ? 1 : 0)
                ;
            SetCheckState(grpGeweicha, count, "chkGeweichaChuxian");
        }

        // 合 分序
        private void chkGeweihefengxuzuxuanFenxu1_0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkGeweihefengxuzuxuan1_0.Checked || chkGeweihefengxuzuxuan1_1.Checked || chkGeweihefengxuzuxuan1_2.Checked || chkGeweihefengxuzuxuan1_3.Checked || chkGeweihefengxuzuxuan1_4.Checked || chkGeweihefengxuzuxuan1_5.Checked || chkGeweihefengxuzuxuan1_6.Checked || chkGeweihefengxuzuxuan1_7.Checked || chkGeweihefengxuzuxuan1_8.Checked || chkGeweihefengxuzuxuan1_9.Checked) ? 1 : 0)
                + ((chkGeweihefengxuzuxuan2_0.Checked || chkGeweihefengxuzuxuan2_1.Checked || chkGeweihefengxuzuxuan2_2.Checked || chkGeweihefengxuzuxuan2_3.Checked || chkGeweihefengxuzuxuan2_4.Checked || chkGeweihefengxuzuxuan2_5.Checked || chkGeweihefengxuzuxuan2_6.Checked || chkGeweihefengxuzuxuan2_7.Checked || chkGeweihefengxuzuxuan2_8.Checked || chkGeweihefengxuzuxuan2_9.Checked) ? 1 : 0)
                + ((chkGeweihefengxuzuxuan3_0.Checked || chkGeweihefengxuzuxuan3_1.Checked || chkGeweihefengxuzuxuan3_2.Checked || chkGeweihefengxuzuxuan3_3.Checked || chkGeweihefengxuzuxuan3_4.Checked || chkGeweihefengxuzuxuan3_5.Checked || chkGeweihefengxuzuxuan3_6.Checked || chkGeweihefengxuzuxuan3_7.Checked || chkGeweihefengxuzuxuan3_8.Checked || chkGeweihefengxuzuxuan3_9.Checked) ? 1 : 0)
                ;
            SetCheckState(grpGeweihefengxuzuxuan, count, "chkGeweihefengxuzuxuanChuxian");
        }

        // 差 分序
        private void chkGeweichafengxuzuxuanFenxu1_0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkGeweichafengxuzuxuan1_2.Checked || chkGeweichafengxuzuxuan1_3.Checked || chkGeweichafengxuzuxuan1_4.Checked || chkGeweichafengxuzuxuan1_5.Checked || chkGeweichafengxuzuxuan1_6.Checked || chkGeweichafengxuzuxuan1_7.Checked || chkGeweichafengxuzuxuan1_8.Checked) ? 1 : 0)
                + ((chkGeweichafengxuzuxuan2_2.Checked || chkGeweichafengxuzuxuan2_3.Checked || chkGeweichafengxuzuxuan2_4.Checked || chkGeweichafengxuzuxuan2_5.Checked || chkGeweichafengxuzuxuan2_6.Checked || chkGeweichafengxuzuxuan2_7.Checked || chkGeweichafengxuzuxuan2_8.Checked) ? 1 : 0)
                + ((chkGeweichafengxuzuxuan3_2.Checked || chkGeweichafengxuzuxuan3_3.Checked || chkGeweichafengxuzuxuan3_4.Checked || chkGeweichafengxuzuxuan3_5.Checked || chkGeweichafengxuzuxuan3_6.Checked || chkGeweichafengxuzuxuan3_7.Checked || chkGeweichafengxuzuxuan3_8.Checked) ? 1 : 0)
                ;
            SetCheckState(grpGeweichafengxuzuxuan, count, "chkGeweichafengxuzuxuanChuxian");
        }

        private void chkZhinengA1_Click(object sender, EventArgs e)
        {
            int count =
                ((chkZhinengA1.Checked || chkZhinengA2.Checked || chkZhinengA3.Checked || chkZhinengA4.Checked) ? 1 : 0)
                + ((chkZhinengB1.Checked || chkZhinengB2.Checked || chkZhinengB3.Checked || chkZhinengB4.Checked) ? 1 : 0)
                + ((chkZhinengC1.Checked || chkZhinengC2.Checked || chkZhinengC3.Checked || chkZhinengC4.Checked) ? 1 : 0)
                + ((chkZhinengD1.Checked || chkZhinengD2.Checked || chkZhinengD3.Checked || chkZhinengD4.Checked) ? 1 : 0)
                ;
            SetCheckState(grpZhinengShuju, count, "chkZhinengShujuChuxian");
        }

        private void chkZhinengzhiA0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkZhinengzhiA0.Checked || chkZhinengzhiA1.Checked || chkZhinengzhiA2.Checked || chkZhinengzhiA3.Checked || chkZhinengzhiA4.Checked || chkZhinengzhiA5.Checked || chkZhinengzhiA6.Checked || chkZhinengzhiA7.Checked || chkZhinengzhiA8.Checked || chkZhinengzhiA9.Checked) ? 1 : 0)
                + ((chkZhinengzhiB0.Checked || chkZhinengzhiB1.Checked || chkZhinengzhiB2.Checked || chkZhinengzhiB3.Checked || chkZhinengzhiB4.Checked || chkZhinengzhiB5.Checked || chkZhinengzhiB6.Checked || chkZhinengzhiB7.Checked || chkZhinengzhiB8.Checked || chkZhinengzhiB9.Checked) ? 1 : 0)
                + ((chkZhinengzhiC0.Checked || chkZhinengzhiC1.Checked || chkZhinengzhiC2.Checked || chkZhinengzhiC3.Checked || chkZhinengzhiC4.Checked || chkZhinengzhiC5.Checked || chkZhinengzhiC6.Checked || chkZhinengzhiC7.Checked) ? 1 : 0)
                + ((chkZhinengzhiD0.Checked || chkZhinengzhiD1.Checked || chkZhinengzhiD2.Checked || chkZhinengzhiD3.Checked || chkZhinengzhiD4.Checked || chkZhinengzhiD5.Checked) ? 1 : 0)
                + ((chkZhinengzhiE0.Checked || chkZhinengzhiE1.Checked || chkZhinengzhiE2.Checked || chkZhinengzhiE3.Checked || chkZhinengzhiE4.Checked) ? 1 : 0)
                + ((chkZhinengzhiF1.Checked || chkZhinengzhiF2.Checked || chkZhinengzhiF3.Checked || chkZhinengzhiF4.Checked || chkZhinengzhiF5.Checked) ? 1 : 0);
            SetCheckState(grpZhinengzhi, count, "chkZhinengzhi");
        }

        private void chkZhinengpinghengA0_Click(object sender, EventArgs e)
        {
            int count =
                ((chkZhinengpinghengA0.Checked || chkZhinengpinghengA1.Checked || chkZhinengpinghengA2.Checked) ? 1 : 0)
                + ((chkZhinengpinghengB0.Checked || chkZhinengpinghengB1.Checked || chkZhinengpinghengB2.Checked) ? 1 : 0)
                + ((chkZhinengpinghengC0.Checked || chkZhinengpinghengC1.Checked || chkZhinengpinghengC2.Checked) ? 1 : 0);
            SetCheckState(grpZhinengpingheng, count, "chkZhinengpinghengChuxian");
        }

        private List<TwoNum> GetKuaiSuPiPeiGroup()
        {
            int[] kspps = GetCheckedArray(grpKuaisupipei, "chkKuaisupipei", true, 36);

            Array.Sort<int>(kspps);

            List<int> tempints = new List<int>();

            if (chkKuaisupipeiDa.Checked)
            {
                tempints.AddRange(new int[] { 6, 7, 8, 9, 10, 11 });
            }
            if (chkKuaisupipeiXiao.Checked)
            {
                tempints.AddRange(new int[] { 1, 2, 3, 4, 5 });
            }
            if (chkKuaisupipeiDan.Checked)
            {
                tempints.AddRange(new int[] { 1, 3, 5, 7, 9, 11 });
            }
            if (chkKuaisupipeiShuang.Checked)
            {
                tempints.AddRange(new int[] { 2, 4, 6, 8, 10 });
            }
            if (chkKuaisupipeiZhi.Checked)
            {
                tempints.AddRange(new int[] { 1, 2, 3, 5, 7, 11 });
            }
            if (chkKuaisupipeiHe.Checked)
            {
                tempints.AddRange(new int[] { 4, 6, 8, 9, 10 });
            }

            List<int> retInt = new List<int>();

            foreach (int i in tempints)
            {
                if (!retInt.Contains(i))
                {
                    retInt.Add(i);
                }
            }

            retInt.Sort();

            List<TwoNum> tns = new List<TwoNum>();

            foreach (int i in kspps)
            {

                foreach (int ii in retInt)
                {
                    if (ii > i)
                        tns.Add(new TwoNum() { Num1 = i, Num2 = ii });
                    else
                        if (i > ii)
                            tns.Add(new TwoNum() { Num1 = ii, Num2 = i });
                }
            }

            return tns;
        }

        private void SetKuaiSuPiPeiCheckState(bool b, List<TwoNum> tns, bool check)
        {
            string tail = b ? "B" : "R";

            foreach (TwoNum tn in tns)
            {
                foreach (Control cc in grpLiangmazuhe.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox cb = (CheckBox)cc;
                        if (cb.Name.Equals("chkLiangmazuhe" + tail + tn.Num1.ToString() + "_" + tn.Num2.ToString()))
                        {
                            if (!LiangMaZuHeSelecteds.Contains(cb.Name))
                            {
                                cb.Checked = check;
                                LiangMaZuHeSelecteds.Add(cb.Name);
                            }
                        }

                    }
                }
            }
        }

        private void chkKuaisupipei1_Click(object sender, EventArgs e)
        {
            foreach (Control cc in grpLiangmazuhe.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (!LiangMaZuHeSelecteds.Contains(cb.Name))
                    {
                        //cb.Checked = false;
                    }
                }
            }

            List<TwoNum> tns = GetKuaiSuPiPeiGroup();

            if (chkKuaisupipeiChu.Checked)
            {
                SetKuaiSuPiPeiCheckState(true, tns, true);
            }
            else
            {
                // SetKuaiSuPiPeiCheckState(true, tns, false);
            }
            if (chkKuaisupipeiSha.Checked)
            {
                SetKuaiSuPiPeiCheckState(false, tns, true);
            }
            else
            {
                // SetKuaiSuPiPeiCheckState(false, tns, false);
            }
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;

            e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,
             System.Windows.Forms.SystemInformation.MenuFont,
             new SolidBrush(Color.Black),
             e.Bounds, sf);
        }

        private void SetTabState(Button bt, bool isSelected)
        {
            if (isSelected)
            {
                bt.FlatAppearance.BorderColor = Color.RoyalBlue;
                bt.FlatAppearance.BorderSize = 1;
                //bt.BackColor = Color.Gray;
                bt.ForeColor = Color.RoyalBlue;
            }
            else
            {
                bt.FlatAppearance.BorderColor = Color.Gray;
                bt.FlatAppearance.BorderSize = 1;
                //bt.BackColor = Color.White;
                bt.ForeColor = Color.Black;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetTabState(button2, true);
            SetTabState(button3, false);
            SetTabState(button4, false);
            SetTabState(button5, false);
            SetTabState(button6, false);
            SetTabState(button7, false);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, true);
            SetTabState(button4, false);
            SetTabState(button5, false);
            SetTabState(button6, false);
            SetTabState(button7, false);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, false);
            SetTabState(button4, true);
            SetTabState(button5, false);
            SetTabState(button6, false);
            SetTabState(button7, false);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, false);
            SetTabState(button4, false);
            SetTabState(button5, true);
            SetTabState(button6, false);
            SetTabState(button7, false);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, false);
            SetTabState(button4, false);
            SetTabState(button5, false);
            SetTabState(button6, true);
            SetTabState(button7, false);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, false);
            SetTabState(button4, false);
            SetTabState(button5, false);
            SetTabState(button6, false);
            SetTabState(button7, true);
            //SetTabState(button8, false);
            tabControl2.SelectedIndex = 5;
        }
        /*
        private void button8_Click(object sender, EventArgs e)
        {
            SetTabState(button2, false);
            SetTabState(button3, false);
            SetTabState(button4, false);
            SetTabState(button5, false);
            SetTabState(button6, false);
            SetTabState(button7, false);
            SetTabState(button8, true);
            tabControl2.SelectedIndex = 6;
        }
        */

        [DllImport("CyyChartDll.dll", EntryPoint = "GetBaseChart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetBaseChart(string usrName, string lotteryType);

        [DllImport("CyyChartDll.dll", EntryPoint = "ZongHeChart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ZongHeChart(string usrName, string lotteryType);

        [DllImport("CyyChartDll.dll", EntryPoint = "LiangMaHeCha", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LiangMaHeCha(string usrName, string lotteryType);

        [DllImport("CyyChartDll.dll", EntryPoint = "HeZhiChart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HeZhiChart(string usrName, string lotteryType);

        [DllImport("CyyChartDll.dll", EntryPoint = "HeZhi2Chart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HeZhi2Chart(string usrName, string lotteryType);

        [DllImport("CyyChartDll.dll", EntryPoint = "JiLinChart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void JiLinChart(string usrName, string lotteryType);


        private void viewErrorChart(GeckoWebBrowser wb)
        {
            wb.Navigate(System.Environment.CurrentDirectory + @"\chart\error.html");
        }


        // 11选5
        private List<Lottery> GetCPDllInfos(string userId, string cptype, List<string> days)
        {
            readCertainFile(System.Environment.CurrentDirectory + @"\data\" + userId + cptype + ".dll");



            List<Lottery> lotterys = new List<Lottery>();

            foreach (LotteryInfo li in LotteryInfos)
            {
                lotterys.Add(new Lottery(li.Data.ToString()));
                days.Add(li.Day.ToString());
            }

            return lotterys;
        }

        // 11选3
        private List<Lottery11_3> GetCPDllInfos11_3(string userId, string cptype, List<string> days)
        {
            readCertainFile(System.Environment.CurrentDirectory + @"\data\" + userId + cptype + ".dll");

            List<Lottery11_3> lotterys = new List<Lottery11_3>();

            foreach (LotteryInfo li in LotteryInfos)
            {
                lotterys.Add(new Lottery11_3(li.Data.ToString()));
                days.Add(li.Day.ToString());
            }

            return lotterys;
        }

        object CurrentSender = null;
        int btnIndex = -1;

        string currentHtml = "error.html";

        private void DeleteFile(string filename)
        {
            string fn = System.Environment.CurrentDirectory + @"\chart\" + filename;
            if (File.Exists(fn))
            {
                if (!filename.Equals("error.html"))
                {
                    File.Delete(fn);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)  //基本走势图
        {

            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }

            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, true);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            //tcccc.SelectedIndex = 0;
            CurrentSender = sender;

            btnIndex = 0;


            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr0)
                // {
                clr0 = false;
                List<string> days = new List<string>();

                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                days.Reverse();
                lotterys.Reverse();

                string html = CyyChart.GetHtmlJiBenZouShi(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_01.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }

                //}
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_01.html");
            }

            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_01.html";

            /*SetTabState(btnBaseChart, true);
            SetTabState(btnZongHe, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
             */
        }
        private void button10_Click(object sender, EventArgs e) //综合
        {

            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, true);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            btnIndex = 1;
            // tcccc.SelectedIndex = 1;
            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_02.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr1)
                //{
                List<string> days = new List<string>();

                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);
                days.Reverse();
                lotterys.Reverse();
                string html = CyyChart.GetHtmlZongHeZouShi(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_02.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }

                clr1 = false;
                //}

                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_02.html");
            }
            /*
            ZongHeChart(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
            Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_02.html");
            CurrentSender = sender;

            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, true);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
             */
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                default:
                case 0: //选项条件
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    //this.Size = new Size(1101, 638);
                    //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                    this.MaximizeBox = false;
                    this.UpdateSystemButtonRect();
                    break;
                case 1: //走势图
                    if (CurrentSender == null)
                    {
                        if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
                        {
                            viewErrorChart(Browser);
                        }
                        else
                        {
                            //(CurrentSender as Button).PerformClick();
                            button11_Click(btnBaseChart, e);
                            SetTabState(btnBaseChart, true);
                        }
                    }
                    else
                    {
                        (CurrentSender as Button).PerformClick();
                        SetTabState((CurrentSender as Button), true);
                    }
                    //this.MaximizeBox = true; 暂时取消
                    this.UpdateSystemButtonRect();
                    //this.BackgroundImage.Size = new Size(this.Size.Width, this.BackgroundImage.Size.Height);
                    //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    break;

            }
        }


        private void btnLiangMaHeCha_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);

            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, true);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);

            /*
            LiangMaHeCha(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
            Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_03.html");
            
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnLiangMaHeCha, true);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
          */
            CurrentSender = sender;

            btnIndex = 3;
            //tcccc.SelectedIndex = 3;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_04.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr3)
                //{
                clr3 = false;
                List<string> days = new List<string>();
                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);
                days.Reverse();
                lotterys.Reverse();
                string html = CyyChart.GetHtmlLiangMaHeCha(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_04.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }
                //}
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_04.html");
            }

        }
        private void btnHe1_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, true);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);

            /*
            HeZhiChart(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
            Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_04.html");
            CurrentSender = sender;

            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnHe1, true);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
          */
            //tcccc.SelectedIndex = 5;

            btnIndex = 5;
            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_06.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr5)
                //{
                clr5 = false;
                List<string> days = new List<string>();

                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);
                days.Reverse();
                lotterys.Reverse();
                string html = CyyChart.GetHtmlHe1ZouShi(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_06.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }
                //}
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_06.html");
            }
        }

        private void btnHe2_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, true);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);

            //tcccc.SelectedIndex = 6;

            btnIndex = 6;
            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_07.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr6)
                //{
                clr6 = false;
                List<string> days = new List<string>();

                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                days.Reverse();
                lotterys.Reverse();
                string html = CyyChart.GetHtmlHZ_KD_LMHZoushiTu(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_07.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }
                //}
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_07.html");

                /*HeZhi2Chart(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_05.html");
                CurrentSender = sender;

                SetTabState(btnBaseChart, false);
                SetTabState(btnZongHe, false);
                SetTabState(btnLiangMaHeCha, false);
                SetTabState(btnHe1, false);
                SetTabState(btnHe2, true);
                SetTabState(btnJiLin, false);
                 */
            }
        }
        private void btnJiLin_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, true);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);

            btnIndex = 7;
            //tcccc.SelectedIndex = 7;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_08.html";
            CurrentSender = sender;
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                //if (clr7)
                //{
                clr7 = false;
                List<string> days = new List<string>();

                List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                days.Reverse();
                lotterys.Reverse();
                string html = CyyChart.GetHtmlJKDL012(lotterys, days);

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_08.html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }
                /*
                JiLinChart(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString());
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_06.html");
                CurrentSender = sender;
                SetTabState(btnBaseChart, false);
                SetTabState(btnZongHe, false);
                SetTabState(btnLiangMaHeCha, false);
                SetTabState(btnHe1, false);
                SetTabState(btnHe2, false);
                SetTabState(btnJiLin, true);
                 */
                //}
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_08.html");
            }
        }

        // 两码组合 清
        private void button9_Click(object sender, EventArgs e)
        {
            LiangMaZuHeSelecteds.Clear();
            SetCheckboxState(grpLiangmazuhe, false);
            SetCheckboxState(grpKuaisupipei, false);
        }

        // 定位组选 清
        private void button10_Click_1(object sender, EventArgs e)
        {
            SetCheckboxState(grpDingweizuxuan, false);
            chkDingweizuxuanChuxian0.Enabled = false;
            chkDingweizuxuanChuxian1.Enabled = false;
            chkDingweizuxuanChuxian2.Enabled = false;
            chkDingweizuxuanChuxian3.Enabled = false;
            chkDingweizuxuanChuxian4.Enabled = false;
            chkDingweizuxuanChuxian5.Enabled = false;

        }

        private void tmrLoginDate_Tick(object sender, EventArgs e)
        {
            CyyDb.UpdateOnlineUserData(USERID);
        }

        private void CyyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loginstate)
            {
                if (!USERID.Equals(""))
                {
                    CyyDb.DeleteDateNow(USERID);
                }
                else
                {

                }
            }
        }

        private void chkD1_01_Paint(object sender, PaintEventArgs e)
        {

        }


        private TwoNum GetTwoNum(string chkNames, string preName)
        {
            string twonums = chkNames.Substring(preName.Length, chkNames.Length - preName.Length);
            string[] strs = twonums.Split('_');

            return new TwoNum() { Num1 = int.Parse(strs[0]), Num2 = int.Parse(strs[1]) };
        }

        private void chkLiangmazuheR1_11_Click(object sender, EventArgs e)
        {

            LiangMaZuHeSelecteds.Clear();

            foreach (Control cc in grpLiangmazuhe.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Checked)
                    {
                        LiangMaZuHeSelecteds.Add(cb.Name);
                    }
                }
            }


            /*
            SelectTwoNums.Clear();
            NotSelectTwoNums.Clear();
            
            foreach (Control cc in grpLiangmazuhe.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Checked)
                    {
                        if (cb.Name.StartsWith("chkLiangmazuheB"))
                        {
                            TwoNum tn = GetTwoNum(cb.Name, "chkLiangmazuheB");
                            SelectTwoNums.Add(tn);
                        }
                        else if (cb.Name.StartsWith("chkLiangmazuheR"))
                        {
                            TwoNum tn = GetTwoNum(cb.Name, "chkLiangmazuheR");
                            NotSelectTwoNums.Add(tn);
                        }
                    }
                }
            }
             */
        }

        private void tmrShows_Tick(object sender, EventArgs e)
        {
            lblSHOWS.Left--;
            lblSHOWS2.Left--;

            if (lblSHOWS.Left < -lblSHOWS.Width)
            {
                if (lblSHOWS.Width < panel17.Width)
                    lblSHOWS.Left = panel17.Width + lblSHOWS2.Left;
                else
                    lblSHOWS.Left = lblSHOWS.Width + lblSHOWS2.Left;
            }

            if (lblSHOWS2.Left < -lblSHOWS2.Width)
            {
                if (lblSHOWS2.Width < panel17.Width)
                    lblSHOWS2.Left = panel17.Width + lblSHOWS.Left;
                else
                    lblSHOWS2.Left = lblSHOWS2.Width + lblSHOWS.Left;
            }

        }

        private void panel18_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void CyyMain_Resize(object sender, EventArgs e)
        {
            panel2.Height = this.Height - topbarHeight;
            this.Size = new Size(1000, 700);

            //this.OnSizeChanged(e);
            //this.UpdateSystemButtonRect();
            //this.OnPaint((PaintEventArgs)e);

            /*
            if (CurrentSender != null) {
                (CurrentSender as Button).PerformClick();
            }
             */
        }

        private void CyyMain_ResizeBegin(object sender, EventArgs e)
        {
            //MessageBox.Show("窗口大小不可拖拽");

        }
        private void CyyMain_ResizeEnd(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 700);

            //this.UpdateSystemButtonRect();
            //this.OnSizeChanged(e);
            //this.OnPaint((PaintEventArgs)e);
        }

        private void CyyMain_MaximumSizeChanged(object sender, EventArgs e)
        {
            //panel2.Height = this.Height - topbarHeight;
            this.UpdateSystemButtonRect();
        }

        private void btnDingwei_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, true);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            // tcccc.SelectedIndex = 2;

            btnIndex = 2;
            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_03.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr2)
                {
                    clr2 = false;
                    List<string> days = new List<string>();

                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);


                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtmlDingWeiZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_03.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_03.html");
            }
        }

        private void btnCMZSLCZ_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, true);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            // tcccc.SelectedIndex = 4;

            btnIndex = 4;
            CurrentSender = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_05.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr4)
                {
                    clr4 = false;
                    List<string> days = new List<string>();

                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtmlDMZS_LCZZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_05.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_05.html");
            }
        }

        private void btn012RateTu_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, true);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            CurrentSender = sender;
            // tcccc.SelectedIndex = 8;

            btnIndex = 8;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_09.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr8)
                {
                    clr8 = false;
                    List<string> days = new List<string>();

                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtml012RateZoushi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_09.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_09.html");
            }
        }

        private void btnKuaMa_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, true);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            CurrentSender = sender;
            //tcccc.SelectedIndex = 9;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_10.html";
            btnIndex = 9;
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr9)
                {
                    clr9 = false;
                    List<string> days = new List<string>();

                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);
                    days.Reverse();
                    lotterys.Reverse();

                    string html = CyyChart.GetHtmlKuaMaZoushi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_10.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_10.html");
            }
        }
        private void btnLMJJ_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, true);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            CurrentSender = sender;
            //tcccc.SelectedIndex = 10;

            btnIndex = 10;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_11.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr10)
                {
                    clr10 = false;
                    List<string> days = new List<string>();
                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();

                    string html = CyyChart.GetHtmlLMJGZoushi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_11.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_11.html");
            }
        }
        private void btnGWLMH_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, true);
            SetTabState(btnGWLMC, false);
            CurrentSender = sender;
            //tcccc.SelectedIndex = 11;

            btnIndex = 11;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_12.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr11)
                {
                    clr11 = false;
                    List<string> days = new List<string>();
                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();

                    string html = CyyChart.GetHtmlGWLMHZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_12.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_12.html");
            }
        }

        private void btnGWLMC_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, true);
            CurrentSender = sender;

            btnIndex = 12;
            //tcccc.SelectedIndex = 12;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_13.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr12)
                {
                    clr12 = false;
                    List<string> days = new List<string>();
                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtmlGWLMCZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_13.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_13.html");

            }
        }


        bool clr0 = false;
        bool clr1 = false;
        bool clr2 = false;
        bool clr3 = false;
        bool clr4 = false;
        bool clr5 = false;
        bool clr6 = false;
        bool clr7 = false;
        bool clr8 = false;
        bool clr9 = false;
        bool clr10 = false;
        bool clr11 = false;
        bool clr12 = false;
        bool clr13 = false;
        bool clr14 = false;
        bool clr15 = false;
        private void button11_Click_2(object sender, EventArgs e)
        {
            clr0 = true;
            clr1 = true;
            clr2 = true;
            clr3 = true;
            clr4 = true;
            clr5 = true;
            clr6 = true;
            clr7 = true;
            clr8 = true;
            clr9 = true;
            clr10 = true;
            clr11 = true;
            clr12 = true;
            clr13 = true;
            clr14 = true;
            clr15 = true;

            button13.PerformClick();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button13.PerformClick();
            //(CurrentSender as Button).PerformClick();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            switch (btnIndex)
            {
                default:
                case 0:
                    clr0 = true;
                    break;
                case 1:
                    clr1 = true;
                    break;
                case 2:
                    clr2 = true;
                    break;
                case 3:
                    clr3 = true;
                    break;
                case 4:
                    clr4 = true;
                    break;
                case 5:
                    clr5 = true;
                    break;
                case 6:
                    clr6 = true;
                    break;
                case 7:
                    clr7 = true;
                    break;
                case 8:
                    clr8 = true;
                    break;
                case 9:
                    clr9 = true;
                    break;
                case 10:
                    clr10 = true;
                    break;
                case 11:
                    clr11 = true;
                    break;
                case 12:
                    clr12 = true;
                    break;
                case 13:
                    clr13 = true;
                    break;
                case 14:
                    clr14 = true;
                    break;

            }


            (CurrentSender as Button).PerformClick();
        }

        private void btnZhiNengZhi_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnzhinengshuju, false);
            SetTabState(btnZhiNengZhi, true);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            //tcccc.SelectedIndex = 13;

            btnIndex = 13;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_14.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr13)
                {
                    clr13 = false;
                    List<string> days = new List<string>();
                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtmlZhinengZhiZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_14.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_14.html");

            }
        }

        private void btnzhinengshuju_Click(object sender, EventArgs e)
        {
            if (CurrentSender != null)
            {
                DeleteFile(currentHtml);
                Browser.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            SetTabState(btnBaseChart, false);
            SetTabState(btnZongHe, false);
            SetTabState(btnDingwei, false);
            SetTabState(btnLiangMaHeCha, false);
            SetTabState(btnCMZSLCZ, false);
            SetTabState(btnHe1, false);
            SetTabState(btnHe2, false);
            SetTabState(btnzhinengshuju, true);
            SetTabState(btnZhiNengZhi, false);
            SetTabState(btnJiLin, false);
            SetTabState(btn012RateTu, false);
            SetTabState(btnKuaMa, false);
            SetTabState(btnLMJJ, false);
            SetTabState(btnGWLMH, false);
            SetTabState(btnGWLMC, false);
            //tcccc.SelectedIndex = 14;

            btnIndex = 14;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_15.html";
            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser);
            }
            else
            {
                if (clr14)
                {
                    clr14 = false;
                    List<string> days = new List<string>();
                    List<Lottery> lotterys = GetCPDllInfos(USERID, currentLotteryTypeInfo11_5.Lottery_Type.ToString(), days);

                    days.Reverse();
                    lotterys.Reverse();
                    string html = CyyChart.GetHtmlZHInengShuJUZouShi(lotterys, days);

                    using (FileStream fs = File.Create(
                      System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_15.html"))
                    {
                        StringBuilder sb = new StringBuilder();
                        byte[] info = new UTF8Encoding().GetBytes(html);
                        fs.Write(info, 0, info.Length);
                    }
                }
                Browser.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + "_15.html");

            }
        }

        // 比较版本是否需要更新
        private bool compareVersion(string currentVersion, string newVersion, int versionBit)
        {
            string[] currentVersionArray = currentVersion.Split('.');
            string[] newVersionArray = newVersion.Split('.');

            for (int i = 0; i < currentVersionArray.Length; i++)
            {
                if (currentVersionArray[i].Length < versionBit)
                {
                    currentVersionArray[i] = "0" + currentVersionArray[i];
                }
                if (newVersionArray[i].Length < versionBit)
                {
                    newVersionArray[i] = "0" + newVersionArray[i];
                }
            }
            string currentVersionString = currentVersionArray[0] + currentVersionArray[1] + currentVersionArray[2];
            string newVersionString = newVersionArray[0] + newVersionArray[1] + newVersionArray[2];
            if (int.Parse(currentVersionString) < int.Parse(newVersionString))
            {
                return true;
            }
            return false;
        }

        private string getOnlineFile(string fileUrl)
        {

            WebClient wcClient = new WebClient();

            long fileLength = 0;

            string updateFileUrl = fileUrl;

            WebRequest webReq = WebRequest.Create(updateFileUrl);
            WebResponse webRes = null;
            Stream srm = null;
            StreamReader srmReader = null;
            string ss = "";
            try
            {
                webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

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

                    float part = (float)startByte / 1024;
                    float total = (float)bufferbyte.Length / 1024;
                    int percent = Convert.ToInt32((part / total) * 100);

                }
                ss = Encoding.Default.GetString(bufferbyte).Trim();

                srm.Close();
                srmReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取信息异常: " + ex.Message);
                //throw;
                return "";
            }
            return ss;
        }

        private void tmr_updateVersion_Tick(object sender, EventArgs e)
        {
            /*
            if (loginstate)
            {
                tmr_updateVersion.Enabled = false;
            }
            else
            {
                return;
            }
            */
            tmr_updateVersion.Enabled = false;
            string ss = getOnlineFile(@"http://www.caiyingying.com/products/cyy/full/Version.txt");

            /*
            string ssss = string.Empty;

            using (FileStream fszz = File.OpenRead(System.Environment.CurrentDirectory + @"\Version.txt"))
            {
                byte[] bytes = new byte[fszz.Length];
                fszz.Read(bytes, 0, bytes.Length);

                ssss = Encoding.Default.GetString(bytes);
            }
             */
            if (!ss.Equals(""))
            {
                bool ok = false;
                if (!proudctVersionString.Equals(""))
                {
                    string localVersionString = "";
                    if (proudctVersionString.Split('.').Length == 2)
                    {
                        localVersionString = proudctVersionString + ".0";
                    }
                    else
                    {
                        localVersionString = proudctVersionString;
                    }

                    if (compareVersion(localVersionString, ss, 2))
                    {
                        ok = true;
                        /* using (FileStream fs = new FileStream(System.Environment.CurrentDirectory + @"\Version.txt", FileMode.OpenOrCreate, FileAccess.Write))
                        / {
                             fs.Write(bufferbyte, 0, bufferbyte.Length);
                         }  
                         */
                    }

                    //fs.Close();
                    if (ok)
                    {
                        string updateLog = getOnlineFile(@"http://www.caiyingying.com/products/cyy/full/updateLog.txt");

                        //if (!st.Equals(""))
                        //{
                        //    UpdateNotification unf = new UpdateNotification("彩盈盈做号系统有新版本了(" + productKeyNameString + ss + ")，是否需要更新？", st, @"http://www.caiyingying.com/products/cyy/full/" + productKeyNameString + productKeyVersionNameString + @"v" + ss + @".exe");
                        //    unf.ShowDialog();
                        //}

                        if (!updateLog.Equals(""))
                        {
                            update ud = new update(@"http://www.caiyingying.com/products/cyy/full/" + productKeyNameString + productKeyVersionNameString + @"v" + ss + ".exe", ss, updateLog);
                            ud.ShowDialog(this);
                        }

                        /*
                        if (MessageBox.Show("彩盈盈做号系统有新版本了(" + productKeyNameString + ss + ")，是否需要更新？", "软件更新", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            //Visible = false;
                            //彩盈盈彩票做号系统精华版2.7.exe
                            update ud = new update(@"http://www.caiyingying.com/products/cyy/full/" + productKeyNameString + productKeyVersionNameString + ss + ".exe");

                            ud.ShowDialog(this);
                        }
                        */

                        /*
                        DialogResult resault = MessageBox.Show("确定退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxButtons.button1);
                        if (resault == DialogResult.OK)
                        {
                            this.Close();
                        }
                         */
                    }
                }

            }
        }

        public void getExe(string name)
        {


        }

        private void button8_Click(object sender, EventArgs e)
        {
            chkLongtouLu0.Checked = false;
            chkLongtouLu1.Checked = false;
            chkLongtouLu2.Checked = false;

            chkFengweiLu0.Checked = false;
            chkFengweiLu1.Checked = false;
            chkFengweiLu2.Checked = false;

            chkLTFW012_0.Checked = false;
            chkLTFW012_1.Checked = false;
            chkLTFW012_2.Checked = false;

            chkLTFW012_0.Enabled = false;
            chkLTFW012_1.Enabled = false;
            chkLTFW012_2.Enabled = false;
        }

        private void chkLongtouLu0_Click(object sender, EventArgs e)
        {
            int count = ((chkLongtouLu0.Checked || chkLongtouLu1.Checked || chkLongtouLu2.Checked) ? 1 : 0)
                + ((chkFengweiLu0.Checked || chkFengweiLu1.Checked || chkFengweiLu2.Checked) ? 1 : 0);


            SetCheckState(grpLTFW012, count, "chkLTFW012_");
        }

        private void chkLiangmahe2_21_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmahe, "chkLiangmahe2_", "chkLiangmaheChuxian2_");
        }

        private void chkLiangmahe3_21_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmahe, "chkLiangmahe3_", "chkLiangmaheChuxian3_");
        }

        private void chkLiangmahe4_21_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmahe, "chkLiangmahe4_", "chkLiangmaheChuxian4_");
        }

        private void chkLiangmahe5_21_Click(object sender, EventArgs e)
        {
            SetCheckState(grpLiangmahe, "chkLiangmahe5_", "chkLiangmaheChuxian5_");
        }

        private void chkLiangmahe1_12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkLiangmaheChuxianQing2_Click(object sender, EventArgs e)
        {
            chkLiangmahe2_3.Checked = false;
            chkLiangmahe2_4.Checked = false;
            chkLiangmahe2_5.Checked = false;
            chkLiangmahe2_6.Checked = false;
            chkLiangmahe2_7.Checked = false;
            chkLiangmahe2_8.Checked = false;
            chkLiangmahe2_9.Checked = false;
            chkLiangmahe2_10.Checked = false;
            chkLiangmahe2_11.Checked = false;
            chkLiangmahe2_12.Checked = false;
            chkLiangmahe2_13.Checked = false;
            chkLiangmahe2_14.Checked = false;
            chkLiangmahe2_15.Checked = false;
            chkLiangmahe2_16.Checked = false;
            chkLiangmahe2_17.Checked = false;
            chkLiangmahe2_18.Checked = false;
            chkLiangmahe2_19.Checked = false;
            chkLiangmahe2_20.Checked = false;
            chkLiangmahe2_21.Checked = false;

            chkLiangmaheChuxian2_0.Checked = false;
            chkLiangmaheChuxian2_1.Checked = false;
            chkLiangmaheChuxian2_2.Checked = false;
            chkLiangmaheChuxian2_3.Checked = false;
            chkLiangmaheChuxian2_4.Checked = false;
            chkLiangmaheChuxian2_5.Checked = false;

            chkLiangmaheChuxian2_0.Enabled = false;
            chkLiangmaheChuxian2_1.Enabled = false;
            chkLiangmaheChuxian2_2.Enabled = false;
            chkLiangmaheChuxian2_3.Enabled = false;
            chkLiangmaheChuxian2_4.Enabled = false;
            chkLiangmaheChuxian2_5.Enabled = false;
        }

        private void chkLiangmaheChuxianQing3_Click(object sender, EventArgs e)
        {
            chkLiangmahe3_3.Checked = false;
            chkLiangmahe3_4.Checked = false;
            chkLiangmahe3_5.Checked = false;
            chkLiangmahe3_6.Checked = false;
            chkLiangmahe3_7.Checked = false;
            chkLiangmahe3_8.Checked = false;
            chkLiangmahe3_9.Checked = false;
            chkLiangmahe3_10.Checked = false;
            chkLiangmahe3_11.Checked = false;
            chkLiangmahe3_12.Checked = false;
            chkLiangmahe3_13.Checked = false;
            chkLiangmahe3_14.Checked = false;
            chkLiangmahe3_15.Checked = false;
            chkLiangmahe3_16.Checked = false;
            chkLiangmahe3_17.Checked = false;
            chkLiangmahe3_18.Checked = false;
            chkLiangmahe3_19.Checked = false;
            chkLiangmahe3_20.Checked = false;
            chkLiangmahe3_21.Checked = false;

            chkLiangmaheChuxian3_0.Checked = false;
            chkLiangmaheChuxian3_1.Checked = false;
            chkLiangmaheChuxian3_2.Checked = false;
            chkLiangmaheChuxian3_3.Checked = false;
            chkLiangmaheChuxian3_4.Checked = false;
            chkLiangmaheChuxian3_5.Checked = false;

            chkLiangmaheChuxian3_0.Enabled = false;
            chkLiangmaheChuxian3_1.Enabled = false;
            chkLiangmaheChuxian3_2.Enabled = false;
            chkLiangmaheChuxian3_3.Enabled = false;
            chkLiangmaheChuxian3_4.Enabled = false;
            chkLiangmaheChuxian3_5.Enabled = false;
        }

        private void chkLiangmaheChuxianQing4_Click(object sender, EventArgs e)
        {
            chkLiangmahe4_3.Checked = false;
            chkLiangmahe4_4.Checked = false;
            chkLiangmahe4_5.Checked = false;
            chkLiangmahe4_6.Checked = false;
            chkLiangmahe4_7.Checked = false;
            chkLiangmahe4_8.Checked = false;
            chkLiangmahe4_9.Checked = false;
            chkLiangmahe4_10.Checked = false;
            chkLiangmahe4_11.Checked = false;
            chkLiangmahe4_12.Checked = false;
            chkLiangmahe4_13.Checked = false;
            chkLiangmahe4_14.Checked = false;
            chkLiangmahe4_15.Checked = false;
            chkLiangmahe4_16.Checked = false;
            chkLiangmahe4_17.Checked = false;
            chkLiangmahe4_18.Checked = false;
            chkLiangmahe4_19.Checked = false;
            chkLiangmahe4_20.Checked = false;
            chkLiangmahe4_21.Checked = false;

            chkLiangmaheChuxian4_0.Checked = false;
            chkLiangmaheChuxian4_1.Checked = false;
            chkLiangmaheChuxian4_2.Checked = false;
            chkLiangmaheChuxian4_3.Checked = false;
            chkLiangmaheChuxian4_4.Checked = false;
            chkLiangmaheChuxian4_5.Checked = false;

            chkLiangmaheChuxian4_0.Enabled = false;
            chkLiangmaheChuxian4_1.Enabled = false;
            chkLiangmaheChuxian4_2.Enabled = false;
            chkLiangmaheChuxian4_3.Enabled = false;
            chkLiangmaheChuxian4_4.Enabled = false;
            chkLiangmaheChuxian4_5.Enabled = false;
        }

        private void chkLiangmaheChuxianQing5_Click(object sender, EventArgs e)
        {
            chkLiangmahe5_3.Checked = false;
            chkLiangmahe5_4.Checked = false;
            chkLiangmahe5_5.Checked = false;
            chkLiangmahe5_6.Checked = false;
            chkLiangmahe5_7.Checked = false;
            chkLiangmahe5_8.Checked = false;
            chkLiangmahe5_9.Checked = false;
            chkLiangmahe5_10.Checked = false;
            chkLiangmahe5_11.Checked = false;
            chkLiangmahe5_12.Checked = false;
            chkLiangmahe5_13.Checked = false;
            chkLiangmahe5_14.Checked = false;
            chkLiangmahe5_15.Checked = false;
            chkLiangmahe5_16.Checked = false;
            chkLiangmahe5_17.Checked = false;
            chkLiangmahe5_18.Checked = false;
            chkLiangmahe5_19.Checked = false;
            chkLiangmahe5_20.Checked = false;
            chkLiangmahe5_21.Checked = false;

            chkLiangmaheChuxian5_0.Checked = false;
            chkLiangmaheChuxian5_1.Checked = false;
            chkLiangmaheChuxian5_2.Checked = false;
            chkLiangmaheChuxian5_3.Checked = false;
            chkLiangmaheChuxian5_4.Checked = false;
            chkLiangmaheChuxian5_5.Checked = false;

            chkLiangmaheChuxian5_0.Enabled = false;
            chkLiangmaheChuxian5_1.Enabled = false;
            chkLiangmaheChuxian5_2.Enabled = false;
            chkLiangmaheChuxian5_3.Enabled = false;
            chkLiangmaheChuxian5_4.Enabled = false;
            chkLiangmaheChuxian5_5.Enabled = false;
        }


        private void SetChecked(GroupBox grp, bool chkState, string checkBoxPreName, Func<int, bool> function)
        {
            foreach (Control cc in grp.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Name.StartsWith(checkBoxPreName))
                    {
                        string cbIndex = cb.Name.Substring(checkBoxPreName.Length, cb.Name.Length - checkBoxPreName.Length); //chkRePassBaseNumX

                        if (!Regex.IsMatch(cbIndex, "^[0-9]+$"))
                        {
                            continue;
                        }
                        int index = Convert.ToInt32(cbIndex);

                        if (function(index))
                        {
                            cb.Checked = chkState;
                        }
                    }
                }
            }

        }

        private void chk0_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpHezhi, chkHe0.Checked, "chkHezhi",
                (n) => { if ((n >= 31) && (n <= 45)) { return true; } return false; });

        }
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpHezhi, chkHe1.Checked, "chkHezhi",
                (n) => { if ((n >= 15) && (n <= 30)) { return true; } return false; });

        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpHezhi, chkHe2.Checked, "chkHezhi",
                (n) => { if (n % 2 == 1) { return true; } return false; });

        }

        private void chkHe3_CheckedChanged(object sender, EventArgs e)
        {

            SetChecked(grpHezhi, chkHe3.Checked, "chkHezhi",
                (n) => { if (n % 2 == 0) { return true; } return false; });


        }

        private void chkHe4_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpHezhi, chkHe4.Checked, "chkHezhi",
                (n) =>
                {
                    bool isprime = true;
                    // 判断是否为质数
                    for (int i = 2; i <= n / 2; i++)
                    {
                        if ((n % i) == 0)
                        {
                            isprime = false;
                        }
                    }

                    return isprime;
                });

        }

        private void chkHe5_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpHezhi, chkHe5.Checked, "chkHezhi",
                    (n) =>
                    {
                        bool isprime = true;

                        for (int i = 2; i <= n / 2; i++)
                        {
                            if ((n % i) == 0)
                            {
                                isprime = false;
                            }
                        }

                        return !isprime;
                    });
        }

        private void chkHe6_CheckedChanged(object sender, EventArgs e)
        {

            SetChecked(grpHezhi, chkHe6.Checked, "chkHezhi",
                   (n) =>
                   {
                       return true;
                   });

        }

        private void chkHeQing_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxState(grpHezhi, false);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpHezhi, false);
        }

        private void chkZDJJ0_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpShouweilingmazuidajianju, chkZDJJ0.Checked, "chkShouweilingmazuidajianju",
                    (n) => { if ((n >= 4) && (n <= 6)) { return true; } return false; });
        }
        private void chkZDJJ1_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpShouweilingmazuidajianju, chkZDJJ1.Checked, "chkShouweilingmazuidajianju",
                    (n) => { if ((n >= 0) && (n <= 3)) { return true; } return false; });
        }
        private void chkZDJJ2_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpShouweilingmazuidajianju, chkZDJJ2.Checked, "chkShouweilingmazuidajianju",
                    (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkZDJJ3_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpShouweilingmazuidajianju, chkZDJJ3.Checked, "chkShouweilingmazuidajianju",
        (n) => { if (n % 2 == 0) { return true; } return false; });
        }

        private void chkZDJJ4_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpShouweilingmazuidajianju, chkZDJJ4.Checked, "chkShouweilingmazuidajianju",
               (n) =>
               {
                   return true;
               });
        }

        private void chkD1_08_CheckedChanged(object sender, EventArgs e)
        {

        }
        //=============================================================================================================================
        // 基础号码 11_3
        private void SetJichuhaoma11_3()
        {
            int[] length = new int[] { 0, 0, 0 };
            int[,] baseNums = new int[3, 11];

            int[] notLength = new int[] { 0, 0, 0 };
            int[,] notBaseNums = new int[3, 11];

            if (grpJichuhaoma.HasChildren)
            {
                foreach (Control cc in grpJichuhaoma.Controls)
                {
                    if (cc is WDCheckBoxPNG)
                    {
                        WDCheckBoxPNG cb = (WDCheckBoxPNG)cc;
                        string cbIndex = cb.Name.Substring(13, cb.Name.Length - 13); //chkJichuhaoma 1_1

                        string[] cbIndexArray = cbIndex.Split('_');
                        if (int.Parse(cbIndexArray[0]) == 1)
                        {
                            if (cb.Checked)
                            {
                                baseNums[int.Parse(cbIndexArray[0]) - 1, length[0]] = int.Parse(cbIndexArray[1]);
                                length[0]++;

                            }
                            else
                            {
                                notBaseNums[int.Parse(cbIndexArray[0]) - 1, notLength[0]] = int.Parse(cbIndexArray[1]);
                                notLength[0]++;
                            }
                        }
                        else if (int.Parse(cbIndexArray[0]) == 2)
                        {
                            if (cb.Checked)
                            {
                                baseNums[int.Parse(cbIndexArray[0]) - 1, length[1]] = int.Parse(cbIndexArray[1]);
                                length[1]++;
                            }
                            else
                            {
                                notBaseNums[int.Parse(cbIndexArray[0]) - 1, notLength[1]] = int.Parse(cbIndexArray[1]);
                                notLength[1]++;
                            }
                        }
                        else if (int.Parse(cbIndexArray[0]) == 3)
                        {
                            if (cb.Checked)
                            {
                                baseNums[int.Parse(cbIndexArray[0]) - 1, length[2]] = int.Parse(cbIndexArray[1]);
                                length[2]++;
                            }
                            else
                            {
                                notBaseNums[int.Parse(cbIndexArray[0]) - 1, notLength[2]] = int.Parse(cbIndexArray[1]);
                                notLength[2]++;
                            }
                        }
                    }
                }


                A11_3.BaseNums = AlgorithmTools.GetSubArray11_3(baseNums, length);
                A11_3.NotBaseNums = AlgorithmTools.GetSubArray11_3(notBaseNums, notLength);
            }
        }

        FinalBox fb;
        // 11选3 生成
        private void Generate11_3_Click(object sender, EventArgs e)
        {
            if (final != null)
            {
                final.Close();
            }

            SetJichuhaoma11_3(); // 基础号码 11_3
            SetDanma11_3();  // 胆码
            SetLocateIndexNum11_3(); // 定位胆码 
            SetLocateIndexNumFenu11_3(); // 分序组选 
            SetHaomaxingtai11_3(); // 号码形态
            SetPinghengzhishu11_3(); // 平衡指数
            SetZongheshuxing(); // 偶小质 综合属性
            SetSumOfLottery11_3(); // 和值
            SetHeZhi11_3(); // 合值
            SetLongtouFengwei11_3(); // 龙头凤尾
            SetFZBQ012lu11_3(); // 012路
            SetSpanKuadu(); // 跨度
            SetSmallerBiggerLength11_3(); // 反边球距离
            SetMaxNearestNumDiss11_3(); // 最大临码跨距
            SetSmallBiggerLenAddMaxNearestDiss11_3(); // 边临和
            SetLiangmachahe11_3(); // 两码差和
            SetQianhouguiji11_3(); // 前后轨迹
            SetDaxiaoxingtai11_3(); // 大小形态
            SetDanshuangxingtai11_3(); //单双形态
            SetZhihexingtai11_3(); // 质和形态
            SetLiangmahecha11_3(); // 两码合差

            SetRenyiliangmaheYi1_3(); // 任意两码合 一
            SetRenyiliangmaheEr1_3(); // 任意两码合 二
            SetLiangmahezuidajianju1_3(); // 两码合最大间距
            SetLiangmahefenxuzuxuan1_3(); // 两码合分序组选
            SetDingweiliangmahe1_3(); // 定位两码合

            SetRenyiliangmachaYi1_3(); // 任意两码差 一
            SetRenyiliangmachaEr1_3(); // 任意两码差 二
            SetLiangmachazuidajianju1_3(); // 两码差最大间距
            SetLiangmachafenxuzuxuan1_3(); // 两码差分序组选
            SetDingweiliangmacha1_3(); // 定位两码差


            //A11_3.ReGetBaseLotterys11_3();
            // 根据基础号码获得全部可能性
            A11_3.GetBaseLotterysConditional11_3Public();
            // 计算
            A11_3.Calc();

            string splieString = "";
            switch (CbbLotterySplite11_3.SelectedIndex)
            {
                default:
                case 0:
                    splieString = " ";
                    break;
                case 1:
                    splieString = "，";
                    break;
                case 2:
                    splieString = ",";
                    break;
                case 3:
                    splieString = "；";
                    break;
                case 4:
                    splieString = ";";
                    break;
            }
            final = new FinalBox(A11_3.Lotterys, splieString);
            final.Show();
        }

        // 清除所有选项
        private void clearAll11_3_Click(object sender, EventArgs e)
        {
            // 胆码
            //chkDanmaQing1.PerformClick();
            //chkDanmaQing2.PerformClick();
            //chkDanmaQing3.PerformClick();
            //chkDanmaQing4.PerformClick();
            //chkDanmaQing5.PerformClick();
            chkDanmaQing1_Click(sender, e);
            chkDanmaQing2_Click(sender, e);
            chkDanmaQing3_Click(sender, e);
            chkDanmaQing4_Click(sender, e);
            chkDanmaQing5_Click(sender, e);

            // 定位胆码
            //chkDingweidanmaQing.PerformClick();
            chkDingweidanmaQing_Click(sender, e);
            // 定位组选
            //chkFenxuzuxuanQing.PerformClick();
            chkFenxuzuxuanQing_Click(sender, e);
            // 号码形态
            //chkHaomaxingtaiQing.PerformClick();
            chkHaomaxingtaiQing_Click(sender, e);
            // 平衡指数
            //PinghengzhishuQing.PerformClick();
            PinghengzhishuQing_Click(sender, e);
            // 偶小质 综合属性
            //chkOuxiaozhiQing.PerformClick();
            chkOuxiaozhiQing_Click(sender, e);
            // AB分解
            chkABfengjieQing_Click(sender, e);
            // 和值
            //chk11_3HeZhiQing_Click(sender, e);
            chk11_3HeZhiQing_CheckedChanged(sender, e);
            // 合值
            chk11_3HeHeZhiQing_Click(sender, e);
            // 龙头凤尾
            chkLongtoufengweiQing_Click(sender, e);
            // 012路
            chkFZBQ012luQing_Click(sender, e);
            // 跨度
            chk11_3KuaduQing_Click(sender, e);
            // 反边球距离
            chk11_3FanbianqiujuliQing_Click(sender, e);
            // 最大邻码间距
            chk11_3ZuidalinmakuajuQing_Click(sender, e);
            // 边临和
            chk11_3BianLinheQing_Click(sender, e);
            // 两码差和
            chk11_3LiangmachaheQing_Click(sender, e);
            // 前后轨迹
            chk11_3QianhouguijiQing_Click(sender, e);
            // 大小形态
            chk11_3DaxiaoxingtaiQing_CheckedChanged(sender, e);
            // 单双形态
            chk11_3DanshuangxingtaiQing_CheckedChanged(sender, e);
            // 质和形态
            chk11_3ZhihexingtaiQing_CheckedChanged(sender, e);
            // 两码合差
            chkLiangmahechaQing_Click(sender, e);

            // 任意两码合 一
            chkRenyiliangmaheYiQing_Click(sender, e);
            // 任意两码合 二
            chkRenyiliangmaheErQing_Click(sender, e);
            // 两码合最大间距
            chkLiangmahezuidajianjuQing_Click(sender, e);
            // 两码合分序组选
            chkLiangmahefenxuzuxuanQing_Click(sender, e);
            // 定位两码合
            chkDingweiliangmaheQing_Click(sender, e);

            // 任意两码差 一
            chkRenyiliangmachaYiQing_Click(sender, e);
            // 任意两码差 二
            chkRenyiliangmachaErQing_Click(sender, e);
            // 两码差最大间距
            chkLiangmachazuidajianjuQing_Click(sender, e);
            // 两码差分序组选
            chkLiangmachafenxuzuxuanQing_Click(sender, e);
            // 定位两码差
            chkDingweiliangmachaQing_Click(sender, e);
        }

        private void makeChkAllinGroup(GroupBox gb, string chkPrefix, bool isChecked)
        {
            foreach (Control cc in gb.Controls)
            {
                if (cc is WDCheckBoxPNG)
                {
                    WDCheckBoxPNG cb = (WDCheckBoxPNG)cc;
                    if (cb.Name.StartsWith(chkPrefix))
                    {
                        cb.Checked = isChecked;
                    }
                }
            }
        }

        private void chkJichuhaomaAll1_CheckedChanged(object sender, EventArgs e)
        {
            makeChkAllinGroup(grpJichuhaoma, "chkJichuhaoma1_", chkJichuhaomaAll1.Checked);
        }

        private void chkJichuhaomaAll2_CheckedChanged(object sender, EventArgs e)
        {
            makeChkAllinGroup(grpJichuhaoma, "chkJichuhaoma2_", chkJichuhaomaAll2.Checked);
        }

        private void chkJichuhaomaAll3_CheckedChanged(object sender, EventArgs e)
        {
            makeChkAllinGroup(grpJichuhaoma, "chkJichuhaoma3_", chkJichuhaomaAll3.Checked);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                default:
                case 0:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.SD_11_3;
                    break;
                case 1:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.GD_11_3;
                    break;
                case 2:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.JX_11_3;
                    break;
                case 3:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.CQ_11_3;
                    break;
                case 4:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.JS_11_3;
                    break;
                case 5:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.ZJ_11_3;
                    break;
                case 6:
                    currentLotteryTypeInfo11_3.Lottery_Type = LotteryType11_3.SH_11_3;
                    break;

            }

            if (LoginState)
            {
                if (!File.Exists(currentLotteryTypeInfo11_3.FileName))
                {
                    button15_Click(sender, e);
                }
                else
                {
                    ReadLotteryInfosFromFile(currentLotteryTypeInfo11_3.FileName);

                    dataGridView1.Rows.Clear();

                    foreach (LotteryInfo tmp in LotteryInfos)
                    {
                        dataGridView1.Rows.Add(tmp.Day, tmp.Data);
                    }
                }

                if (LotteryInfos.Count > 0)
                {
                    textBox2.Text = (int.Parse(LotteryInfos[0].Day) + 1).ToString();
                }
            }
        }

        // 获得彩票信息
        private void getCPData11_3(bool isAuto)
        {
            LotteryInfos = CyyDb.GetLotteryInfos(currentLotteryTypeInfo11_3.getCurrentTypeInt(currentLotteryTypeInfo11_3.Lottery_Type), 1, 2);

            if (isAuto)
            {
                if (int.Parse(LotteryInfos[0].Day.ToString()) < int.Parse(txtLotteryDates.Text))
                {
                    return;
                }
            }

            dataGridView1.Rows.Clear();

            foreach (LotteryInfo li in LotteryInfos)
            {
                dataGridView1.Rows.Add(li.Day, li.Data);
            }

            if (LotteryInfos.Count != 0)
            {
                textBox2.Text = (int.Parse(dataGridView1.CurrentRow.Cells["clnQiHao11_3"].Value.ToString()) + 1).ToString();
                textBox1.Text = "";
                SaveLotteryInfosToFile(currentLotteryTypeInfo11_3.FileName, currentLotteryTypeInfo11_3.Lottery_Type.ToString());
                SoundPlay(System.Environment.CurrentDirectory + @"\config\complete.wav");
            }
            else
            {
                MessageBox.Show("数据库中没有该彩种信息");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            getCPData11_3(false);
        }

        // 确定
        private void button16_Click(object sender, EventArgs e)
        {
            if (LotteryInfos == null)
            {
                LotteryInfos = new List<LotteryInfo>();
                LotteryInfos.Add(new LotteryInfo
                {
                    Day = textBox2.Text.Trim(),
                    Data = textBox1.Text.Trim()
                });
                dataGridView1.Rows.Insert(0, new string[] { textBox2.Text, textBox1.Text });
            }
            else
            {
                int lotteryDates = LotteryInfos.FindLastIndex(
                    delegate(LotteryInfo lotteryInfo)
                    {
                        return lotteryInfo.Day == textBox2.Text.Trim();
                    });

                if (lotteryDates != -1)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = lotteryDates;
                    dataGridView1.Rows[lotteryDates].Selected = true;
                }
                else
                {
                    if (Regex.IsMatch(textBox1.Text, @"^\d{6}$"))
                    {

                        dataGridView1.Rows.Insert(0, new string[] { textBox2.Text, textBox1.Text });
                        LotteryInfos.Insert(0, new LotteryInfo() { Day = textBox2.Text, Data = textBox1.Text });

                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                        dataGridView1.Rows[0].Selected = true;
                        dataGridView1.Rows[1].Selected = false;

                        textBox2.Text = (Convert.ToInt32(textBox2.Text) + 1).ToString();
                        SaveLotteryInfosToFile(currentLotteryTypeInfo11_3.FileName, currentLotteryTypeInfo11_3.Lottery_Type.ToString());


                        //button11_Click_2(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("彩票输入错误");

                    }
                    textBox1.Text = "";
                }
            }
        }

        // 胆码列表 -
        private void SetDanma11_3()
        {
            List<DanmaStruct> bileCodes = new List<DanmaStruct>();
            for (int i = 0; i < 5; i++)
            {
                int[] bileCode = GetCheckedArray(grpDanma, "chkDanma" + (i + 1).ToString() + "_", true);
                int[] appearCounts = GetCheckedArray(grpDanma, "chkDanmaChuxian" + (i + 1).ToString() + "_", true);
                int[] notAppearCounts = GetCheckedArray(grpDanma, "chkDanmaChuxian" + (i + 1).ToString() + "_", false);
                DanmaStruct bc =
                    new DanmaStruct()
                    {
                        IsSelect = bileCode.Length == 0 ? false : true,
                        _danma = bileCode,
                        AppearCounts = appearCounts,
                        NotAppearCounts = notAppearCounts,
                    };

                bileCodes.Add(bc);
            }

            A11_3.danmaStruct = bileCodes;
        }

        private void chkDanma1_1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanma, "chkDanma1_", "chkDanmaChuxian1_");
        }

        private void chkDanma2_1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanma, "chkDanma2_", "chkDanmaChuxian2_");
        }

        private void chkDanma3_1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanma, "chkDanma3_", "chkDanmaChuxian3_");
        }

        private void chkDanma4_1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanma, "chkDanma4_", "chkDanmaChuxian4_");
        }

        private void chkDanma5_1_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanma, "chkDanma5_", "chkDanmaChuxian5_");
        }

        private void chkDanmaQing1_Click(object sender, EventArgs e)
        {
            chkDanma1_1.Checked = false;
            chkDanma1_2.Checked = false;
            chkDanma1_3.Checked = false;
            chkDanma1_4.Checked = false;
            chkDanma1_5.Checked = false;
            chkDanma1_6.Checked = false;
            chkDanma1_7.Checked = false;
            chkDanma1_8.Checked = false;
            chkDanma1_9.Checked = false;
            chkDanma1_10.Checked = false;
            chkDanma1_11.Checked = false;

            chkDanmaChuxian1_0.Checked = false;
            chkDanmaChuxian1_1.Checked = false;
            chkDanmaChuxian1_2.Checked = false;
            chkDanmaChuxian1_3.Checked = false;

            chkDanmaChuxian1_0.Enabled = false;
            chkDanmaChuxian1_1.Enabled = false;
            chkDanmaChuxian1_2.Enabled = false;
            chkDanmaChuxian1_3.Enabled = false;
        }

        private void chkDanmaQing2_Click(object sender, EventArgs e)
        {
            chkDanma2_1.Checked = false;
            chkDanma2_2.Checked = false;
            chkDanma2_3.Checked = false;
            chkDanma2_4.Checked = false;
            chkDanma2_5.Checked = false;
            chkDanma2_6.Checked = false;
            chkDanma2_7.Checked = false;
            chkDanma2_8.Checked = false;
            chkDanma2_9.Checked = false;
            chkDanma2_10.Checked = false;
            chkDanma2_11.Checked = false;

            chkDanmaChuxian2_0.Checked = false;
            chkDanmaChuxian2_1.Checked = false;
            chkDanmaChuxian2_2.Checked = false;
            chkDanmaChuxian2_3.Checked = false;

            chkDanmaChuxian2_0.Enabled = false;
            chkDanmaChuxian2_1.Enabled = false;
            chkDanmaChuxian2_2.Enabled = false;
            chkDanmaChuxian2_3.Enabled = false;
        }

        private void chkDanmaQing3_Click(object sender, EventArgs e)
        {
            chkDanma3_1.Checked = false;
            chkDanma3_2.Checked = false;
            chkDanma3_3.Checked = false;
            chkDanma3_4.Checked = false;
            chkDanma3_5.Checked = false;
            chkDanma3_6.Checked = false;
            chkDanma3_7.Checked = false;
            chkDanma3_8.Checked = false;
            chkDanma3_9.Checked = false;
            chkDanma3_10.Checked = false;
            chkDanma3_11.Checked = false;

            chkDanmaChuxian3_0.Checked = false;
            chkDanmaChuxian3_1.Checked = false;
            chkDanmaChuxian3_2.Checked = false;
            chkDanmaChuxian3_3.Checked = false;

            chkDanmaChuxian3_0.Enabled = false;
            chkDanmaChuxian3_1.Enabled = false;
            chkDanmaChuxian3_2.Enabled = false;
            chkDanmaChuxian3_3.Enabled = false;
        }

        private void chkDanmaQing4_Click(object sender, EventArgs e)
        {
            chkDanma4_1.Checked = false;
            chkDanma4_2.Checked = false;
            chkDanma4_3.Checked = false;
            chkDanma4_4.Checked = false;
            chkDanma4_5.Checked = false;
            chkDanma4_6.Checked = false;
            chkDanma4_7.Checked = false;
            chkDanma4_8.Checked = false;
            chkDanma4_9.Checked = false;
            chkDanma4_10.Checked = false;
            chkDanma4_11.Checked = false;

            chkDanmaChuxian4_0.Checked = false;
            chkDanmaChuxian4_1.Checked = false;
            chkDanmaChuxian4_2.Checked = false;
            chkDanmaChuxian4_3.Checked = false;

            chkDanmaChuxian4_0.Enabled = false;
            chkDanmaChuxian4_1.Enabled = false;
            chkDanmaChuxian4_2.Enabled = false;
            chkDanmaChuxian4_3.Enabled = false;
        }

        private void chkDanmaQing5_Click(object sender, EventArgs e)
        {
            chkDanma5_1.Checked = false;
            chkDanma5_2.Checked = false;
            chkDanma5_3.Checked = false;
            chkDanma5_4.Checked = false;
            chkDanma5_5.Checked = false;
            chkDanma5_6.Checked = false;
            chkDanma5_7.Checked = false;
            chkDanma5_8.Checked = false;
            chkDanma5_9.Checked = false;
            chkDanma5_10.Checked = false;
            chkDanma5_11.Checked = false;

            chkDanmaChuxian5_0.Checked = false;
            chkDanmaChuxian5_1.Checked = false;
            chkDanmaChuxian5_2.Checked = false;
            chkDanmaChuxian5_3.Checked = false;

            chkDanmaChuxian5_0.Enabled = false;
            chkDanmaChuxian5_1.Enabled = false;
            chkDanmaChuxian5_2.Enabled = false;
            chkDanmaChuxian5_3.Enabled = false;
        }

        // 定位胆码
        private void SetLocateIndexNum11_3()
        {
            A11_3._LocateIndexNum = new LocateIndexNum11_3()
            {
                index1 = GetCheckedArray(grpDingweidanma, "chkDingweidanma1_", true),
                index2 = GetCheckedArray(grpDingweidanma, "chkDingweidanma2_", true),
                index3 = GetCheckedArray(grpDingweidanma, "chkDingweidanma3_", true),
                AppearCounts = GetCheckedArray(grpDingweidanma, "chkDingweidanmaChuxian", true),
            };
        }

        private void chkDingweidanma1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkDingweidanma1_1.Checked || chkDingweidanma1_2.Checked || chkDingweidanma1_3.Checked || chkDingweidanma1_4.Checked || chkDingweidanma1_5.Checked || chkDingweidanma1_6.Checked || chkDingweidanma1_7.Checked || chkDingweidanma1_8.Checked || chkDingweidanma1_9.Checked || chkDingweidanma1_10.Checked || chkDingweidanma1_11.Checked) ? 1 : 0)
                + ((chkDingweidanma2_1.Checked || chkDingweidanma2_2.Checked || chkDingweidanma2_3.Checked || chkDingweidanma2_4.Checked || chkDingweidanma2_5.Checked || chkDingweidanma2_6.Checked || chkDingweidanma2_7.Checked || chkDingweidanma2_8.Checked || chkDingweidanma2_9.Checked || chkDingweidanma2_10.Checked || chkDingweidanma2_11.Checked) ? 1 : 0)
                + ((chkDingweidanma3_1.Checked || chkDingweidanma3_2.Checked || chkDingweidanma3_3.Checked || chkDingweidanma3_4.Checked || chkDingweidanma3_5.Checked || chkDingweidanma3_6.Checked || chkDingweidanma3_7.Checked || chkDingweidanma3_8.Checked || chkDingweidanma3_9.Checked || chkDingweidanma3_10.Checked || chkDingweidanma3_11.Checked) ? 1 : 0);

            SetCheckState(grpDingweidanma, count, "chkDingweidanmaChuxian");
        }

        private void chkDingweidanmaQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpDingweidanma, false);
            chkDingweidanmaChuxian0.Enabled = false;
            chkDingweidanmaChuxian1.Enabled = false;
            chkDingweidanmaChuxian2.Enabled = false;
            chkDingweidanmaChuxian3.Enabled = false;
        }

        // 分序组选 -
        private void SetLocateIndexNumFenu11_3()
        {
            A11_3._LocateIndexNumFenxu = new LocateIndexNumFenxu11_3()
            {
                index1 = GetCheckedArray(grpFenxuzuxuan, "chkFenxuzuxuan1_", true),
                index2 = GetCheckedArray(grpFenxuzuxuan, "chkFenxuzuxuan2_", true),
                index3 = GetCheckedArray(grpFenxuzuxuan, "chkFenxuzuxuan3_", true),
                AppearCounts = GetCheckedArray(grpFenxuzuxuan, "chkFenxuzuxuanChuxian", true),
            };
        }

        private void chkFenxuzuxuan1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkFenxuzuxuan1_1.Checked || chkFenxuzuxuan1_2.Checked || chkFenxuzuxuan1_3.Checked || chkFenxuzuxuan1_4.Checked || chkFenxuzuxuan1_5.Checked || chkFenxuzuxuan1_6.Checked || chkFenxuzuxuan1_7.Checked || chkFenxuzuxuan1_8.Checked || chkFenxuzuxuan1_9.Checked) ? 1 : 0)
                + ((chkFenxuzuxuan2_2.Checked || chkFenxuzuxuan2_3.Checked || chkFenxuzuxuan2_4.Checked || chkFenxuzuxuan2_5.Checked || chkFenxuzuxuan2_6.Checked || chkFenxuzuxuan2_7.Checked || chkFenxuzuxuan2_8.Checked || chkFenxuzuxuan2_9.Checked || chkFenxuzuxuan2_10.Checked) ? 1 : 0)
                + ((chkFenxuzuxuan3_3.Checked || chkFenxuzuxuan3_4.Checked || chkFenxuzuxuan3_5.Checked || chkFenxuzuxuan3_6.Checked || chkFenxuzuxuan3_7.Checked || chkFenxuzuxuan3_8.Checked || chkFenxuzuxuan3_9.Checked || chkFenxuzuxuan3_10.Checked || chkFenxuzuxuan3_11.Checked) ? 1 : 0);

            SetCheckState(grpFenxuzuxuan, count, "chkFenxuzuxuanChuxian");
        }

        private void chkFenxuzuxuanQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpFenxuzuxuan, false);
            chkFenxuzuxuanChuxian0.Enabled = false;
            chkFenxuzuxuanChuxian1.Enabled = false;
            chkFenxuzuxuanChuxian2.Enabled = false;
            chkFenxuzuxuanChuxian3.Enabled = false;
        }

        // 号码形态
        private void SetHaomaxingtai11_3()
        {
            A11_3._HaomaxingtaiStruct = new HaomaxingtaiStruct()
            {
                isAo = chkHaomaxingtaiAo.Checked,
                isTu = chkHaomaxingtaiTu.Checked,
                isSheng = chkHaomaxingtaiSheng.Checked,
                isJiang = chkHaomaxingtaiJiang.Checked,
            };
        }

        private void chkHaomaxingtaiQing_Click(object sender, EventArgs e)
        {
            chkHaomaxingtaiAo.Checked = false;
            chkHaomaxingtaiTu.Checked = false;
            chkHaomaxingtaiSheng.Checked = false;
            chkHaomaxingtaiJiang.Checked = false;
        }

        // 平衡指数
        private void SetPinghengzhishu11_3()
        {
            A11_3._PinghengzhishuStruct = new PinghengzhishuStruct()
            {
                isJia = chkPinghengzhishuJia.Checked,
                isDeng = chkPinghengzhishuDeng.Checked,
                isJian = chkPinghengzhishuJian.Checked,
            };
        }

        private void PinghengzhishuQing_Click(object sender, EventArgs e)
        {
            chkPinghengzhishuJia.Checked = false;
            chkPinghengzhishuDeng.Checked = false;
            chkPinghengzhishuJian.Checked = false;
        }

        // 偶小质 综合属性
        private void SetZongheshuxing()
        {
            ZongheshuxingStruct syattr = new ZongheshuxingStruct()
            {
                OddCounts = GetCheckedArray(grpOushugeshu, "chkOushugeshu", true),
                SmallCounts = GetCheckedArray(grpXiaoshugeshu, "chkXiaoshugeshu", true),
                ZhiCounts = GetCheckedArray(grpZhishugeshu, "chkZhishugeshu", true),
                AppearCounts = GetCheckedArray(grpOuxiaozhi, "chkOuxiaozhiChuxian", true)
            };

            A11_3._ZongheshuxingStruct11_3 = syattr;
        }

        private void chkOushugeshu0_Click(object sender, EventArgs e)
        {
            int count = ((chkXiaoshugeshu0.Checked || chkXiaoshugeshu1.Checked || chkXiaoshugeshu2.Checked || chkXiaoshugeshu3.Checked) ? 1 : 0)
                + ((chkOushugeshu0.Checked || chkOushugeshu1.Checked || chkOushugeshu2.Checked || chkOushugeshu3.Checked) ? 1 : 0)
                + ((chkZhishugeshu0.Checked || chkZhishugeshu1.Checked || chkZhishugeshu2.Checked || chkZhishugeshu3.Checked) ? 1 : 0);

            SetCheckState(grpOuxiaozhi, count, "chkOuxiaozhiChuxian");
        }

        private void chkOuxiaozhiQing_Click(object sender, EventArgs e)
        {
            chkXiaoshugeshu0.Checked = false;
            chkXiaoshugeshu1.Checked = false;
            chkXiaoshugeshu2.Checked = false;
            chkXiaoshugeshu3.Checked = false;
            chkOushugeshu0.Checked = false;
            chkOushugeshu1.Checked = false;
            chkOushugeshu2.Checked = false;
            chkOushugeshu3.Checked = false;
            chkZhishugeshu0.Checked = false;
            chkZhishugeshu1.Checked = false;
            chkZhishugeshu2.Checked = false;
            chkZhishugeshu3.Checked = false;

            chkOuxiaozhiChuxian0.Checked = false;
            chkOuxiaozhiChuxian1.Checked = false;
            chkOuxiaozhiChuxian2.Checked = false;
            chkOuxiaozhiChuxian3.Checked = false;

            chkOuxiaozhiChuxian0.Enabled = false;
            chkOuxiaozhiChuxian1.Enabled = false;
            chkOuxiaozhiChuxian2.Enabled = false;
            chkOuxiaozhiChuxian3.Enabled = false;
        }

        // 大小形态
        private void SetDaxiaoxingtai11_3()
        {
            A11_3._Daxiaoxingtai = new Daxiaoxingtai()
            {
                isQuanda = chkDaxiaoQuanda.Checked,
                isQuanxiao = chkDaxiaoQuanxiao.Checked,
                isDadaxiao = chkDaxiaoDadaxiao.Checked,
                isXiaoxiaoda = chkDaxiaoXiaoxiaoda.Checked,
                isXiaodada = chkDaxiaoXiaodada.Checked,
                isDaxiaoxiao = chkDaxiaoDaxiaoxiao.Checked,
                isDaxiaoda = chkDaxiaoDaxiaoda.Checked,
                isXiaodaxiao = chkDaxiaoXiaodaxiao.Checked,
                AppearCounts = GetCheckedArray(grpDaxiaoxingtai, "chkDaxiaoChuxian", true)
            };
        }

        private void chk11_3Daxiaoxingtai_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDaxiaoxingtai, "chkDaxiao", "chkDaxiaoChuxian");
        }
        // 清
        private void chk11_3DaxiaoxingtaiQing_CheckedChanged(object sender, EventArgs e)
        {
            chkDaxiaoQuanda.Checked = false;
            chkDaxiaoQuanxiao.Checked = false;
            chkDaxiaoDadaxiao.Checked = false;
            chkDaxiaoXiaoxiaoda.Checked = false;
            chkDaxiaoXiaodada.Checked = false;
            chkDaxiaoDaxiaoxiao.Checked = false;
            chkDaxiaoDaxiaoda.Checked = false;
            chkDaxiaoXiaodaxiao.Checked = false;

            chkDaxiaoChuxian0.Checked = false;
            chkDaxiaoChuxian1.Checked = false;

            chkDaxiaoChuxian0.Enabled = false;
            chkDaxiaoChuxian1.Enabled = false;
        }

        // 单双形态
        private void SetDanshuangxingtai11_3()
        {
            A11_3._Danshuangxingtai = new Danshuangxingtai()
            {
                isQuandan = chkDanshuangQuandan.Checked,
                isQuanshuang = chkDanshuangQuanshuang.Checked,
                isDandanshuang = chkDanshuangDandanshuang.Checked,
                isShuangshuangdan = chkDanshuangShuangshuangdan.Checked,
                isShuangdandan = chkDanshuangShuangdandan.Checked,
                isDanshuangshuang = chkDanshuangDanshuangshuang.Checked,
                isDanshuangdan = chkDanshuangDanshuangdan.Checked,
                isShuangdanshuang = chkDanshuangShuangdanshuang.Checked,
                AppearCounts = GetCheckedArray(grpDanshuangxingtai, "chkDanshuangChuxian", true)
            };
        }

        private void chk11_3Danshuangxingtai_Click(object sender, EventArgs e)
        {
            SetCheckState(grpDanshuangxingtai, "chkDanshuang", "chkDanshuangChuxian");
        }
        // 清
        private void chk11_3DanshuangxingtaiQing_CheckedChanged(object sender, EventArgs e)
        {
            chkDanshuangQuandan.Checked = false;
            chkDanshuangQuanshuang.Checked = false;
            chkDanshuangDandanshuang.Checked = false;
            chkDanshuangShuangshuangdan.Checked = false;
            chkDanshuangShuangdandan.Checked = false;
            chkDanshuangDanshuangshuang.Checked = false;
            chkDanshuangDanshuangdan.Checked = false;
            chkDanshuangShuangdanshuang.Checked = false;

            chkDanshuangChuxian0.Checked = false;
            chkDanshuangChuxian1.Checked = false;

            chkDanshuangChuxian0.Enabled = false;
            chkDanshuangChuxian1.Enabled = false;
        }

        // 质合形态
        private void SetZhihexingtai11_3()
        {
            A11_3._Zhihexingtai = new Zhihexingtai()
            {
                isQuanzhi = chkZhiheQuanzhi.Checked,
                isQuanhe = chkZhiheQuanhe.Checked,
                isZhizhihe = chkZhiheZhizhihe.Checked,
                isHehezhi = chkZhiheHehezhi.Checked,
                isHezhizhi = chkZhiheHezhizhi.Checked,
                isZhihehe = chkZhiheZhihehe.Checked,
                isZhihezhi = chkZhiheZhihezhi.Checked,
                isHezhihe = chkZhiheHezhihe.Checked,
                AppearCounts = GetCheckedArray(grpZhihexingtai, "chkZhiheChuxian", true)
            };
        }

        private void chk11_3Zhihexingtai_Click(object sender, EventArgs e)
        {
            SetCheckState(grpZhihexingtai, "chkZhihe", "chkZhiheChuxian");
        }
        // 清
        private void chk11_3ZhihexingtaiQing_CheckedChanged(object sender, EventArgs e)
        {
            chkZhiheQuanzhi.Checked = false;
            chkZhiheQuanhe.Checked = false;
            chkZhiheZhizhihe.Checked = false;
            chkZhiheHehezhi.Checked = false;
            chkZhiheHezhizhi.Checked = false;
            chkZhiheZhihehe.Checked = false;
            chkZhiheZhihezhi.Checked = false;
            chkZhiheHezhihe.Checked = false;

            chkZhiheChuxian0.Checked = false;
            chkZhiheChuxian1.Checked = false;

            chkZhiheChuxian0.Enabled = false;
            chkZhiheChuxian1.Enabled = false;
        }

        // 和值 chk11_3HeZhi
        private void SetSumOfLottery11_3()
        {
            A11_3.SumOfLotterys = GetCheckedArray(grp11_3HeZhi, "chk11_3HeZhi", true, 40);
        }

        // 大
        private void chk11_3HeZhiDa_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeZhi, chk11_3HeZhiDa.Checked, "chk11_3HeZhi",
                (n) => { if ((n >= 19) && (n <= 30)) { return true; } return false; });
        }

        // 小
        private void chk11_3HeZhiXiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeZhi, chk11_3HeZhiXiao.Checked, "chk11_3HeZhi",
                (n) => { if ((n >= 6) && (n <= 18)) { return true; } return false; });
        }

        // 单
        private void chk11_3HeZhiDan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeZhi, chk11_3HeZhiDan.Checked, "chk11_3HeZhi",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        // 双
        private void chk11_3HeZhiShuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeZhi, chk11_3HeZhiShuang.Checked, "chk11_3HeZhi",
                (n) => { if (n % 2 == 0) { return true; } return false; });
        }

        // 全
        private void chk11_3HeZhiQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeZhi, chk11_3HeZhiQuan.Checked, "chk11_3HeZhi",
                 (n) => { if ((n >= 6) && (n <= 30)) { return true; } return false; });
        }

        // 清
        private void chk11_3HeZhiQing_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3HeZhi, false);
            chk11_3HeZhiDa.Checked = false;
            chk11_3HeZhiXiao.Checked = false;
            chk11_3HeZhiDan.Checked = false;
            chk11_3HeZhiShuang.Checked = false;
            chk11_3HeZhiQuan.Checked = false;
        }

        // 合值 chk11_3HeHeZhi
        private void SetHeZhi11_3()
        {
            A11_3.HeZhi11_3 = GetCheckedArray(grp11_3HeHeZhi, "chk11_3HeHeZhi", true);
        }

        private void chk11_3HeHeZhiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3HeHeZhi, false);
        }

        private void chk11_3HeHeZhiQuan_Click(object sender, EventArgs e)
        {
            SetChecked(grp11_3HeHeZhi, chk11_3HeHeZhiQuan.Checked, "chk11_3HeHeZhi",
                 (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }
        // 跨度
        private void SetSpanKuadu()
        {
            A11_3.Spans = GetCheckedArray(grp11_3Kuadu, "chk11_3Kuadu", true);
        }

        private void chk11_3KuaduQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3Kuadu, false);
        }

        private void chk11_3KuaduQuan_Click(object sender, EventArgs e)
        {
            SetChecked(grp11_3Kuadu, chk11_3KuaduQuan.Checked, "chk11_3Kuadu",
                    (n) => { if ((n >= 2) && (n <= 10)) { return true; } return false; });
        }

        // 龙头凤尾 
        private void SetLongtouFengwei11_3()
        {
            LongtouFengwei11_3 syattr = new LongtouFengwei11_3()
            {
                LongtouDan = chk11_3LongtouDan.Checked,
                LongtouShuang = chk11_3LongtouShuang.Checked,
                LongtouZhi = chk11_3LongtouZhi.Checked,
                LongtouHe = chk11_3LongtouHe.Checked,
                LongtouDa = chk11_3LongtouDa.Checked,
                LongtouXiao = chk11_3LongtouXiao.Checked,

                FengweiDan = chk11_3FengweiDan.Checked,
                FengweiShuang = chk11_3FengweiShuang.Checked,
                FengweiZhi = chk11_3FengweiZhi.Checked,
                FengweiHe = chk11_3FengweiHe.Checked,
                FengweiDa = chk11_3FengweiDa.Checked,
                FengweiXiao = chk11_3FengweiXiao.Checked,

                AppearCounts = GetCheckedArray(grpLongtoufengwei, "chkLongtoufengweiChuxian", true)
            };

            A11_3._LongtouFengwei11_3 = syattr;
        }

        private void chkLongtouFengweidszh_Click(object sender, EventArgs e)
        {
            int count = ((chk11_3LongtouZhi.Checked || chk11_3LongtouHe.Checked) ? 1 : 0)
               + ((chk11_3LongtouDan.Checked || chk11_3LongtouShuang.Checked) ? 1 : 0)
               + ((chk11_3LongtouDa.Checked || chk11_3LongtouXiao.Checked) ? 1 : 0)
               + ((chk11_3FengweiDan.Checked || chk11_3FengweiShuang.Checked) ? 1 : 0)
               + ((chk11_3FengweiZhi.Checked || chk11_3FengweiHe.Checked) ? 1 : 0)
               + ((chk11_3FengweiDa.Checked || chk11_3FengweiXiao.Checked) ? 1 : 0);

            SetCheckState(grpLongtoufengwei, count, "chkLongtoufengweiChuxian");
        }

        private void chkLongtoufengweiQing_Click(object sender, EventArgs e)
        {
            chk11_3LongtouZhi.Checked = false;
            chk11_3LongtouHe.Checked = false;
            chk11_3LongtouDan.Checked = false;
            chk11_3LongtouShuang.Checked = false;
            chk11_3LongtouDa.Checked = false;
            chk11_3LongtouXiao.Checked = false;
            chk11_3FengweiDan.Checked = false;
            chk11_3FengweiShuang.Checked = false;
            chk11_3FengweiZhi.Checked = false;
            chk11_3FengweiHe.Checked = false;
            chk11_3FengweiDa.Checked = false;
            chk11_3FengweiXiao.Checked = false;

            chkLongtoufengweiChuxian0.Checked = false;
            chkLongtoufengweiChuxian1.Checked = false;
            chkLongtoufengweiChuxian2.Checked = false;
            chkLongtoufengweiChuxian3.Checked = false;
            chkLongtoufengweiChuxian4.Checked = false;
            chkLongtoufengweiChuxian5.Checked = false;
            chkLongtoufengweiChuxian6.Checked = false;

            chkLongtoufengweiChuxian0.Enabled = false;
            chkLongtoufengweiChuxian1.Enabled = false;
            chkLongtoufengweiChuxian2.Enabled = false;
            chkLongtoufengweiChuxian3.Enabled = false;
            chkLongtoufengweiChuxian4.Enabled = false;
            chkLongtoufengweiChuxian5.Enabled = false;
            chkLongtoufengweiChuxian6.Enabled = false;
        }

        //  反边球距离
        private void SetSmallerBiggerLength11_3()
        {
            A11_3.SmallerBigerLengths = GetCheckedArray(grp11_3Fanbianqiujuli, "chk11_3Fanbianqiujuli", true);
        }

        // 大
        private void chk11_3FanbianqiujuliDa_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Fanbianqiujuli, chk11_3FanbianqiujuliDa.Checked, "chk11_3Fanbianqiujuli",
                (n) => { if ((n >= 11) && (n <= 20)) { return true; } return false; });
        }
        // 小
        private void chk11_3FanbianqiujuliXiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Fanbianqiujuli, chk11_3FanbianqiujuliXiao.Checked, "chk11_3Fanbianqiujuli",
                (n) => { if ((n >= 0) && (n <= 10)) { return true; } return false; });
        }
        // 全
        private void chk11_3FanbianqiujuliQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Fanbianqiujuli, chk11_3FanbianqiujuliQuan.Checked, "chk11_3Fanbianqiujuli",
                 (n) => { if ((n >= 0) && (n <= 20)) { return true; } return false; });
        }
        // 单
        private void chk11_3FanbianqiujuliDan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Fanbianqiujuli, chk11_3FanbianqiujuliDan.Checked, "chk11_3Fanbianqiujuli",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }
        // 双
        private void chk11_3FanbianqiujuliShuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Fanbianqiujuli, chk11_3FanbianqiujuliShuang.Checked, "chk11_3Fanbianqiujuli",
                (n) => { if (n % 2 == 0) { return true; } return false; });
        }
        // 清
        private void chk11_3FanbianqiujuliQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3Fanbianqiujuli, false);
            chk11_3FanbianqiujuliDa.Checked = false;
            chk11_3FanbianqiujuliXiao.Checked = false;
            chk11_3FanbianqiujuliDan.Checked = false;
            chk11_3FanbianqiujuliShuang.Checked = false;
            chk11_3FanbianqiujuliQuan.Checked = false;
        }

        // 最大临码跨距
        private void SetMaxNearestNumDiss11_3()
        {
            A11_3.MaxNearestNumDiss = GetCheckedArray(grp11_3Zuidalinmakuaju, "chk11_3Zuidalinmakuaju", true); ;
        }
        // 大
        private void chk11_3ZuidalinmakuajuDa_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Zuidalinmakuaju, chk11_3ZuidalinmakuajuDa.Checked, "chk11_3Zuidalinmakuaju",
                (n) => { if ((n >= 13) && (n <= 20)) { return true; } return false; });
        }
        // 小
        private void chk11_3ZuidalinmakuajuXiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Zuidalinmakuaju, chk11_3ZuidalinmakuajuXiao.Checked, "chk11_3Zuidalinmakuaju",
                (n) => { if ((n >= 5) && (n <= 12)) { return true; } return false; });
        }
        // 全
        private void chk11_3ZuidalinmakuajuQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Zuidalinmakuaju, chk11_3ZuidalinmakuajuQuan.Checked, "chk11_3Zuidalinmakuaju",
                 (n) => { if ((n >= 5) && (n <= 20)) { return true; } return false; });
        }
        // 单
        private void chk11_3ZuidalinmakuajuDan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Zuidalinmakuaju, chk11_3ZuidalinmakuajuDan.Checked, "chk11_3Zuidalinmakuaju",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }
        // 双
        private void chk11_3ZuidalinmakuajuShuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Zuidalinmakuaju, chk11_3ZuidalinmakuajuShuang.Checked, "chk11_3Zuidalinmakuaju",
                (n) => { if (n % 2 == 0) { return true; } return false; });
        }
        // 清
        private void chk11_3ZuidalinmakuajuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3Zuidalinmakuaju, false);
            chk11_3ZuidalinmakuajuDa.Checked = false;
            chk11_3ZuidalinmakuajuXiao.Checked = false;
            chk11_3ZuidalinmakuajuDan.Checked = false;
            chk11_3ZuidalinmakuajuShuang.Checked = false;
            chk11_3ZuidalinmakuajuQuan.Checked = false;
        }

        // 边临和
        private void SetSmallBiggerLenAddMaxNearestDiss11_3()
        {
            A11_3.SmallBiggerLenAddMaxNearestDiss = GetCheckedArray(grp11_3BianLinhe, "chk11_3BianLinhe", true); ;
        }

        // 大
        private void chk11_3BianLinheDa_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3BianLinhe, chk11_3BianLinheDa.Checked, "chk11_3BianLinhe",
                (n) => { if ((n >= 23) && (n <= 30)) { return true; } return false; });
        }
        // 小
        private void chk11_3BianLinheXiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3BianLinhe, chk11_3BianLinheXiao.Checked, "chk11_3BianLinhe",
                (n) => { if ((n >= 15) && (n <= 22)) { return true; } return false; });
        }
        // 全
        private void chk11_3BianLinheQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3BianLinhe, chk11_3BianLinheQuan.Checked, "chk11_3BianLinhe",
                 (n) => { if ((n >= 15) && (n <= 30)) { return true; } return false; });
        }
        // 单
        private void chk11_3BianLinheDan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3BianLinhe, chk11_3BianLinheDan.Checked, "chk11_3BianLinhe",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }
        // 双
        private void chk11_3BianLinheShuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3BianLinhe, chk11_3BianLinheShuang.Checked, "chk11_3BianLinhe",
                (n) => { if (n % 2 == 0) { return true; } return false; });
        }
        // 清
        private void chk11_3BianLinheQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3BianLinhe, false);
            chk11_3BianLinheDa.Checked = false;
            chk11_3BianLinheXiao.Checked = false;
            chk11_3BianLinheDan.Checked = false;
            chk11_3BianLinheShuang.Checked = false;
            chk11_3BianLinheQuan.Checked = false;
        }

        // 两码合差
        private void SetLiangmahecha11_3()
        {
            A11_3._LiangmahechaStruct = new LiangmahechaStruct()
            {
                _Liangmahecha1 = GetCheckedArray(grpLiangmahecha, "chkLiangmahecha1_", true),
                _Liangmahecha2 = GetCheckedArray(grpLiangmahecha, "chkLiangmahecha2_", true),
                _Liangmahecha3 = GetCheckedArray(grpLiangmahecha, "chkLiangmahecha3_", true),
                _Liangmahecha4 = GetCheckedArray(grpLiangmahecha, "chkLiangmahecha4_", true),
                _Liangmahecha5 = GetCheckedArray(grpLiangmahecha, "chkLiangmahecha5_", true),
                AppearCounts = GetCheckedArray(grpLiangmahecha, "chkLiangmahechaChuxian", true)
            };
        }

        // 个数
        private void chkLiangmahecha1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkLiangmahecha1_0.Checked || chkLiangmahecha1_1.Checked || chkLiangmahecha1_2.Checked || chkLiangmahecha1_3.Checked || chkLiangmahecha1_4.Checked || chkLiangmahecha1_5.Checked || chkLiangmahecha1_6.Checked || chkLiangmahecha1_7.Checked || chkLiangmahecha1_8.Checked || chkLiangmahecha1_9.Checked) ? 1 : 0)
                + ((chkLiangmahecha2_0.Checked || chkLiangmahecha2_1.Checked || chkLiangmahecha2_2.Checked || chkLiangmahecha2_3.Checked || chkLiangmahecha2_4.Checked || chkLiangmahecha2_5.Checked || chkLiangmahecha2_6.Checked || chkLiangmahecha2_7.Checked || chkLiangmahecha2_8.Checked || chkLiangmahecha2_9.Checked) ? 1 : 0)
                + ((chkLiangmahecha3_0.Checked || chkLiangmahecha3_1.Checked || chkLiangmahecha3_2.Checked || chkLiangmahecha3_3.Checked || chkLiangmahecha3_4.Checked || chkLiangmahecha3_5.Checked || chkLiangmahecha3_6.Checked || chkLiangmahecha3_7.Checked || chkLiangmahecha3_8.Checked || chkLiangmahecha3_9.Checked) ? 1 : 0)
                + ((chkLiangmahecha4_0.Checked || chkLiangmahecha4_1.Checked || chkLiangmahecha4_2.Checked || chkLiangmahecha4_3.Checked || chkLiangmahecha4_4.Checked || chkLiangmahecha4_5.Checked || chkLiangmahecha4_6.Checked || chkLiangmahecha4_7.Checked || chkLiangmahecha4_8.Checked || chkLiangmahecha4_9.Checked) ? 1 : 0)
                + ((chkLiangmahecha5_0.Checked || chkLiangmahecha5_1.Checked || chkLiangmahecha5_2.Checked || chkLiangmahecha5_3.Checked || chkLiangmahecha5_4.Checked || chkLiangmahecha5_5.Checked || chkLiangmahecha5_6.Checked || chkLiangmahecha5_7.Checked || chkLiangmahecha5_8.Checked || chkLiangmahecha5_9.Checked) ? 1 : 0);

            SetCheckState(grpLiangmahecha, count, "chkLiangmahechaChuxian");
        }

        private void chkLiangmahecha1All_CheckedChanged(object sender, EventArgs e)
        {
            chkLiangmahecha1_0.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_1.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_2.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_3.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_4.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_5.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_6.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_7.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_8.Checked = chkLiangmahecha1All.Checked;
            chkLiangmahecha1_9.Checked = chkLiangmahecha1All.Checked;
        }

        private void chkLiangmahecha2All_CheckedChanged(object sender, EventArgs e)
        {
            chkLiangmahecha2_0.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_1.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_2.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_3.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_4.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_5.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_6.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_7.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_8.Checked = chkLiangmahecha2All.Checked;
            chkLiangmahecha2_9.Checked = chkLiangmahecha2All.Checked;
        }

        private void chkLiangmahecha3All_CheckedChanged(object sender, EventArgs e)
        {
            chkLiangmahecha3_0.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_1.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_2.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_3.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_4.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_5.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_6.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_7.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_8.Checked = chkLiangmahecha3All.Checked;
            chkLiangmahecha3_9.Checked = chkLiangmahecha3All.Checked;
        }

        private void chkLiangmahecha4All_CheckedChanged(object sender, EventArgs e)
        {
            chkLiangmahecha4_0.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_1.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_2.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_3.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_4.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_5.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_6.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_7.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_8.Checked = chkLiangmahecha4All.Checked;
            chkLiangmahecha4_9.Checked = chkLiangmahecha4All.Checked;
        }

        private void chkLiangmahecha5All_CheckedChanged(object sender, EventArgs e)
        {
            chkLiangmahecha5_0.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_1.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_2.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_3.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_4.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_5.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_6.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_7.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_8.Checked = chkLiangmahecha5All.Checked;
            chkLiangmahecha5_9.Checked = chkLiangmahecha5All.Checked;
        }

        // 清
        private void chkLiangmahechaQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLiangmahecha, false);
            chkLiangmahechaChuxian0.Enabled = false;
            chkLiangmahechaChuxian1.Enabled = false;
            chkLiangmahechaChuxian2.Enabled = false;
            chkLiangmahechaChuxian3.Enabled = false;
            chkLiangmahechaChuxian4.Enabled = false;
            chkLiangmahechaChuxian5.Enabled = false;
        }

        // 两码差和
        private void SetLiangmachahe11_3()
        {
            A11_3.Liangmachahe = GetCheckedArray(grp11_3Liangmachahe, "chk11_3Liangmachahe", true);
        }

        // 全
        private void chk11_3LiangmachaheQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Liangmachahe, chk11_3AllLiangmachahe.Checked, "chk11_3Liangmachahe",
                 (n) => { if ((n >= 4) && (n <= 20)) { return true; } return false; });
        }
        // 清
        private void chk11_3LiangmachaheQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3Liangmachahe, false);
        }

        // 前后轨迹
        private void SetQianhouguiji11_3()
        {
            A11_3.Qianhouguiji = GetCheckedArray(grp11_3Qianhouguiji, "chk11_3Qianhouguiji", true);
        }

        // 大
        private void chk11_3QianhouguijiDa_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Qianhouguiji, chk11_3QianhouguijiDa.Checked, "chk11_3Qianhouguiji",
                (n) => { if ((n >= 11) && (n <= 20)) { return true; } return false; });
        }
        // 小
        private void chk11_3QianhouguijiXiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Qianhouguiji, chk11_3QianhouguijiXiao.Checked, "chk11_3Qianhouguiji",
                (n) => { if ((n >= 0) && (n <= 10)) { return true; } return false; });
        }
        // 全
        private void chk11_3QianhouguijiQuan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Qianhouguiji, chk11_3QianhouguijiQuan.Checked, "chk11_3Qianhouguiji",
                 (n) => { if ((n >= 0) && (n <= 20)) { return true; } return false; });
        }
        // 单
        private void chk11_3QianhouguijiDan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Qianhouguiji, chk11_3QianhouguijiDan.Checked, "chk11_3Qianhouguiji",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }
        // 双
        private void chk11_3QianhouguijiShuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grp11_3Qianhouguiji, chk11_3QianhouguijiShuang.Checked, "chk11_3Qianhouguiji",
                (n) => { if (n % 2 == 0) { return true; } return false; });
        }
        // 清
        private void chk11_3QianhouguijiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp11_3Qianhouguiji, false);
            chk11_3QianhouguijiDa.Checked = false;
            chk11_3QianhouguijiXiao.Checked = false;
            chk11_3QianhouguijiDan.Checked = false;
            chk11_3QianhouguijiShuang.Checked = false;
            chk11_3QianhouguijiQuan.Checked = false;
        }

        // 012路
        private void SetFZBQ012lu11_3()
        {
            FZBQ012Lu syattr = new FZBQ012Lu()
            {
                fanbianqiujuli = GetCheckedArray(grp012luFanbianqiujuli, "chk012luFanbianqiujuli", true),
                zuidalinmakuaju = GetCheckedArray(grp012luZuidalinmakuaju, "chk012luZuidalinmakuaju", true),
                bianlinhe = GetCheckedArray(grp012luBianlinhe, "chk012luBianlinhe", true),
                qianhouguiji = GetCheckedArray(grp012Qianhouguiji, "chk012Qianhouguiji", true),

                AppearCounts = GetCheckedArray(grp012Lu, "chk012LuChuxian", true)
            };

            A11_3._FZBQ012Lu = syattr;
        }

        private void chkFZBQ012lu_Click(object sender, EventArgs e)
        {
            int count = ((chk012luFanbianqiujuli0.Checked || chk012luFanbianqiujuli1.Checked || chk012luFanbianqiujuli2.Checked) ? 1 : 0)
                      + ((chk012luZuidalinmakuaju0.Checked || chk012luZuidalinmakuaju1.Checked || chk012luZuidalinmakuaju2.Checked) ? 1 : 0)
                      + ((chk012luBianlinhe0.Checked || chk012luBianlinhe1.Checked || chk012luBianlinhe2.Checked) ? 1 : 0)
                      + ((chk012Qianhouguiji0.Checked || chk012Qianhouguiji1.Checked || chk012Qianhouguiji2.Checked) ? 1 : 0);

            SetCheckState(grp012Lu, count, "chk012LuChuxian");
        }

        private void chkFZBQ012luQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grp012luFanbianqiujuli, false);
            SetCheckboxState(grp012luZuidalinmakuaju, false);
            SetCheckboxState(grp012luBianlinhe, false);
            SetCheckboxState(grp012Qianhouguiji, false);


            chk012LuChuxian0.Checked = false;
            chk012LuChuxian1.Checked = false;
            chk012LuChuxian2.Checked = false;
            chk012LuChuxian3.Checked = false;
            chk012LuChuxian4.Checked = false;

            chk012LuChuxian0.Enabled = false;
            chk012LuChuxian1.Enabled = false;
            chk012LuChuxian2.Enabled = false;
            chk012LuChuxian3.Enabled = false;
            chk012LuChuxian4.Enabled = false;
        }

        // AB分解
        private void InpABfenjie2_TextChanged(object sender, EventArgs e)
        {
            if (InpABfenjie2.Text.Equals(""))
            {
                InpABfenjie1.Text = "0102030405060708091011";
                A11_3._ABfenjie = new ABfenjie()
                {
                    Afengjie = null,
                    Bfenjie = null,
                    isEnabled = false
                };
                return;
            }

            List<string> baseNumberList = new List<string>();
            baseNumberList.Add("01");
            baseNumberList.Add("02");
            baseNumberList.Add("03");
            baseNumberList.Add("04");
            baseNumberList.Add("05");
            baseNumberList.Add("06");
            baseNumberList.Add("07");
            baseNumberList.Add("08");
            baseNumberList.Add("09");
            baseNumberList.Add("10");
            baseNumberList.Add("11");

            //if (Regex.IsMatch(InpABfenjie2.Text, @"^\d{22}$") && ((InpABfenjie2.Text.Length % 2) == 0))
            if (((InpABfenjie2.Text.Length % 2) == 0))
            //if (true)
            {
                string[] InpABfenjie2Array = new string[InpABfenjie2.Text.Length / 2];

                string temp = InpABfenjie2.Text.ToString();

                for (int i = 0; i < InpABfenjie2Array.Length; i++)
                {
                    if (temp.Length >= 2)
                    {
                        InpABfenjie2Array[i] = temp.Substring(temp.Length - 2);
                        temp = temp.Remove(temp.Length - 2);
                    }

                    else
                    {
                        InpABfenjie2Array[i] = temp.Substring(0);
                    }
                }

                for (int n = 0; n < InpABfenjie2Array.Length; n++)
                {
                    if (baseNumberList.Contains(InpABfenjie2Array[n]))
                    {
                        baseNumberList.Remove(InpABfenjie2Array[n]);
                        InpABfenjie1.Text = string.Join("", baseNumberList);
                    }
                }

                A11_3._ABfenjie = new ABfenjie()
                {
                    Afengjie = txtStringToIntArray(InpABfenjie1.Text),
                    Bfenjie = txtStringToIntArray(InpABfenjie2.Text),
                    isEnabled = true
                };
            }
            else
            {
                //InpABfenjie1.Text = "";
                //InpABfenjie2.Text = "";
                //MessageBox.Show("输入错误，请重新输入");
            }
        }

        private int[] txtStringToIntArray(string txt)
        {
            int[] txtArray = new int[txt.Length / 2];

            string temp = txt.ToString();

            for (int i = 0; i < txtArray.Length; i++)
            {
                if (temp.Length >= 2)
                {
                    txtArray[i] = int.Parse(temp.Substring(temp.Length - 2));
                    temp = temp.Remove(temp.Length - 2);
                }

                else
                {
                    txtArray[i] = int.Parse(temp.Substring(0));
                }
            }
            return txtArray;
        }

        private void chkABfengjieQing_Click(object sender, EventArgs e)
        {
            InpABfenjie1.Text = "0102030405060708091011";
            InpABfenjie2.Text = "";

            A11_3._ABfenjie = new ABfenjie()
            {
                Afengjie = null,
                Bfenjie = null,
                isEnabled = false
            };
        }

        // 任意两码合 一
        private void SetRenyiliangmaheYi1_3()
        {
            A11_3._RenyiliangmaheYi = new RenyiliangmaheYiStruct()
            {
                renyiliangmaheYi = GetCheckedArray(grpRenyiliangmaheYi, "chkRenyiliangmaheYi", true),
                AppearNums = GetCheckedArray(grpRenyiliangmaheYi, "chkRenyiliangmaheYiChuxian", true)
            };
        }

        private void chkRenyiliangmaheYiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpRenyiliangmaheYi, false);
            chkRenyiliangmaheYiChuxian0.Checked = false;
            chkRenyiliangmaheYiChuxian1.Checked = false;
            chkRenyiliangmaheYiChuxian2.Checked = false;
            chkRenyiliangmaheYiChuxian3.Checked = false;

            chkRenyiliangmaheYiChuxian0.Enabled = false;
            chkRenyiliangmaheYiChuxian1.Enabled = false;
            chkRenyiliangmaheYiChuxian2.Enabled = false;
            chkRenyiliangmaheYiChuxian3.Enabled = false;
        }

        private void chkRenyiliangmaheYi1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkRenyiliangmaheYi0.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi1.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi2.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi3.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi4.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi5.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi6.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi7.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi8.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheYi9.Checked) ? 1 : 0);

            SetCheckState(grpRenyiliangmaheYi, count, "chkRenyiliangmaheYiChuxian");
        }

        // 任意两码合 二
        private void SetRenyiliangmaheEr1_3()
        {
            A11_3._RenyiliangmaheEr = new RenyiliangmaheErStruct()
            {
                renyiliangmaheEr1 = GetCheckedArray(grpRenyiliangmaheEr, "chkRenyiliangmaheEr1_", true),
                renyiliangmaheEr2 = GetCheckedArray(grpRenyiliangmaheEr, "chkRenyiliangmaheEr2_", true),
                AppearNums = GetCheckedArray(grpRenyiliangmaheEr, "chkRenyiliangmaheErChuxian", true)
            };
        }

        // 清
        private void chkRenyiliangmaheErQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpRenyiliangmaheEr, false);
            chkRenyiliangmaheErChuxian0.Enabled = false;
            chkRenyiliangmaheErChuxian1.Enabled = false;
            chkRenyiliangmaheErChuxian2.Enabled = false;
        }

        private void chkRenyiliangmaheEr1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkRenyiliangmaheEr1_0.Checked || chkRenyiliangmaheEr1_1.Checked || chkRenyiliangmaheEr1_2.Checked || chkRenyiliangmaheEr1_3.Checked || chkRenyiliangmaheEr1_4.Checked || chkRenyiliangmaheEr1_5.Checked || chkRenyiliangmaheEr1_6.Checked || chkRenyiliangmaheEr1_7.Checked || chkRenyiliangmaheEr1_8.Checked || chkRenyiliangmaheEr1_9.Checked) ? 1 : 0)
                + ((chkRenyiliangmaheEr2_0.Checked || chkRenyiliangmaheEr2_1.Checked || chkRenyiliangmaheEr2_2.Checked || chkRenyiliangmaheEr2_3.Checked || chkRenyiliangmaheEr2_4.Checked || chkRenyiliangmaheEr2_5.Checked || chkRenyiliangmaheEr2_6.Checked || chkRenyiliangmaheEr2_7.Checked || chkRenyiliangmaheEr2_8.Checked || chkRenyiliangmaheEr2_9.Checked) ? 1 : 0);

            SetCheckState(grpRenyiliangmaheEr, count, "chkRenyiliangmaheErChuxian");
        }

        private void chkRenyiliangmaheEr1All_CheckedChanged(object sender, EventArgs e)
        {
            chkRenyiliangmaheEr1_0.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_1.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_2.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_3.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_4.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_5.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_6.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_7.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_8.Checked = chkRenyiliangmaheEr1Quan.Checked;
            chkRenyiliangmaheEr1_9.Checked = chkRenyiliangmaheEr1Quan.Checked;
        }

        private void chkRenyiliangmaheEr2All_CheckedChanged(object sender, EventArgs e)
        {
            chkRenyiliangmaheEr2_0.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_1.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_2.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_3.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_4.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_5.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_6.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_7.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_8.Checked = chkRenyiliangmaheEr2Quan.Checked;
            chkRenyiliangmaheEr2_9.Checked = chkRenyiliangmaheEr2Quan.Checked;
        }

        // 两码合最大间距
        private void SetLiangmahezuidajianju1_3()
        {
            A11_3.Liangmahezuidajianju = GetCheckedArray(grpLiangmahezuidajianju, "chkLiangmahezuidajianju", true);
        }

        private void chkLiangmahezuidajianjuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLiangmahezuidajianju, false);
        }

        // 定位两码合
        private void SetDingweiliangmahe1_3()
        {
            A11_3._Dingweiliangmahe = new Dingweiliangmahe()
            {
                dingweiliangmahe1 = GetCheckedArray(grpDingweiliangmahe, "chkDingweiliangmahe1_", true),
                dingweiliangmahe2 = GetCheckedArray(grpDingweiliangmahe, "chkDingweiliangmahe2_", true),
                dingweiliangmahe3 = GetCheckedArray(grpDingweiliangmahe, "chkDingweiliangmahe3_", true),
                AppearNums = GetCheckedArray(grpDingweiliangmahe, "chkDingweiliangmaheChuxian", true)
            };
        }

        // 清
        private void chkDingweiliangmaheQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpDingweiliangmahe, false);
            chkDingweiliangmaheChuxian0.Enabled = false;
            chkDingweiliangmaheChuxian1.Enabled = false;
            chkDingweiliangmaheChuxian2.Enabled = false;
            chkDingweiliangmaheChuxian3.Enabled = false;
        }

        private void chkDingweiliangmahe1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkDingweiliangmahe1_0.Checked || chkDingweiliangmahe1_1.Checked || chkDingweiliangmahe1_2.Checked || chkDingweiliangmahe1_3.Checked || chkDingweiliangmahe1_4.Checked || chkDingweiliangmahe1_5.Checked || chkDingweiliangmahe1_6.Checked || chkDingweiliangmahe1_7.Checked || chkDingweiliangmahe1_8.Checked || chkDingweiliangmahe1_9.Checked) ? 1 : 0)
                + ((chkDingweiliangmahe2_0.Checked || chkDingweiliangmahe2_1.Checked || chkDingweiliangmahe2_2.Checked || chkDingweiliangmahe2_3.Checked || chkDingweiliangmahe2_4.Checked || chkDingweiliangmahe2_5.Checked || chkDingweiliangmahe2_6.Checked || chkDingweiliangmahe2_7.Checked || chkDingweiliangmahe2_8.Checked || chkDingweiliangmahe2_9.Checked) ? 1 : 0)
                + ((chkDingweiliangmahe3_0.Checked || chkDingweiliangmahe3_1.Checked || chkDingweiliangmahe3_2.Checked || chkDingweiliangmahe3_3.Checked || chkDingweiliangmahe3_4.Checked || chkDingweiliangmahe3_5.Checked || chkDingweiliangmahe3_6.Checked || chkDingweiliangmahe3_7.Checked || chkDingweiliangmahe3_8.Checked || chkDingweiliangmahe3_9.Checked) ? 1 : 0);

            SetCheckState(grpDingweiliangmahe, count, "chkDingweiliangmaheChuxian");
        }



        // 两码合分序组选
        private void SetLiangmahefenxuzuxuan1_3()
        {
            A11_3._Liangmahefenxuzuxuan = new Liangmahefenxuzuxuan()
            {
                liangmahefenxuzuxuan1 = GetCheckedArray(grpLiangmahefenxuzuxuan, "chkLiangmahefenxuzuxuan1_", true),
                liangmahefenxuzuxuan2 = GetCheckedArray(grpLiangmahefenxuzuxuan, "chkLiangmahefenxuzuxuan2_", true),
                liangmahefenxuzuxuan3 = GetCheckedArray(grpLiangmahefenxuzuxuan, "chkLiangmahefenxuzuxuan3_", true),
                AppearNums = GetCheckedArray(grpLiangmahefenxuzuxuan, "chkLiangmahefenxuzuxuanChuxian", true)
            };
        }

        // 清
        private void chkLiangmahefenxuzuxuanQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLiangmahefenxuzuxuan, false);
            chkLiangmahefenxuzuxuanChuxian0.Enabled = false;
            chkLiangmahefenxuzuxuanChuxian1.Enabled = false;
            chkLiangmahefenxuzuxuanChuxian2.Enabled = false;
            chkLiangmahefenxuzuxuanChuxian3.Enabled = false;
        }

        // 1
        private void chkDingweiliangmahe1Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe1Da.Checked, "chkDingweiliangmahe1_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmahe1Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe1Xiao.Checked, "chkDingweiliangmahe1_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmahe1Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe1Dan.Checked, "chkDingweiliangmahe1_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe1Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe1Shuang.Checked, "chkDingweiliangmahe1_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe1Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe1Quan.Checked, "chkDingweiliangmahe1_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }

        // 2
        private void chkDingweiliangmahe2Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe2Da.Checked, "chkDingweiliangmahe2_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmahe2Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe2Xiao.Checked, "chkDingweiliangmahe2_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmahe2Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe2Dan.Checked, "chkDingweiliangmahe2_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe2Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe2Shuang.Checked, "chkDingweiliangmahe2_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe2Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe2Quan.Checked, "chkDingweiliangmahe2_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }

        // 3
        private void chkDingweiliangmahe3Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe3Da.Checked, "chkDingweiliangmahe3_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmahe3Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe3Xiao.Checked, "chkDingweiliangmahe3_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmahe3Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe3Dan.Checked, "chkDingweiliangmahe3_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe3Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe3Shuang.Checked, "chkDingweiliangmahe3_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmahe3Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmahe, chkDingweiliangmahe3Quan.Checked, "chkDingweiliangmahe3_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }


        private void chkLiangmahefenxuzuxuan1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkLiangmahefenxuzuxuan1_0.Checked || chkLiangmahefenxuzuxuan1_1.Checked || chkLiangmahefenxuzuxuan1_2.Checked || chkLiangmahefenxuzuxuan1_3.Checked || chkLiangmahefenxuzuxuan1_4.Checked || chkLiangmahefenxuzuxuan1_5.Checked || chkLiangmahefenxuzuxuan1_6.Checked || chkLiangmahefenxuzuxuan1_7.Checked || chkLiangmahefenxuzuxuan1_8.Checked || chkLiangmahefenxuzuxuan1_9.Checked) ? 1 : 0)
                + ((chkLiangmahefenxuzuxuan2_0.Checked || chkLiangmahefenxuzuxuan2_1.Checked || chkLiangmahefenxuzuxuan2_2.Checked || chkLiangmahefenxuzuxuan2_3.Checked || chkLiangmahefenxuzuxuan2_4.Checked || chkLiangmahefenxuzuxuan2_5.Checked || chkLiangmahefenxuzuxuan2_6.Checked || chkLiangmahefenxuzuxuan2_7.Checked || chkLiangmahefenxuzuxuan2_8.Checked || chkLiangmahefenxuzuxuan2_9.Checked) ? 1 : 0)
                + ((chkLiangmahefenxuzuxuan3_0.Checked || chkLiangmahefenxuzuxuan3_1.Checked || chkLiangmahefenxuzuxuan3_2.Checked || chkLiangmahefenxuzuxuan3_3.Checked || chkLiangmahefenxuzuxuan3_4.Checked || chkLiangmahefenxuzuxuan3_5.Checked || chkLiangmahefenxuzuxuan3_6.Checked || chkLiangmahefenxuzuxuan3_7.Checked || chkLiangmahefenxuzuxuan3_8.Checked || chkLiangmahefenxuzuxuan3_9.Checked) ? 1 : 0);

            SetCheckState(grpLiangmahefenxuzuxuan, count, "chkLiangmahefenxuzuxuanChuxian");
        }

        // 任意两码差 一
        private void SetRenyiliangmachaYi1_3()
        {
            A11_3._RenyiliangmachaYi = new RenyiliangmachaYiStruct()
            {
                renyiliangmachaYi = GetCheckedArray(grpRenyiliangmachaYi, "chkRenyiliangmachaYi", true),
                AppearNums = GetCheckedArray(grpRenyiliangmachaYi, "chkRenyiliangmachaYiChuxian", true)
            };
        }

        private void chkRenyiliangmachaYiQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpRenyiliangmachaYi, false);
            chkRenyiliangmachaYiChuxian0.Checked = false;
            chkRenyiliangmachaYiChuxian1.Checked = false;
            chkRenyiliangmachaYiChuxian2.Checked = false;
            chkRenyiliangmachaYiChuxian3.Checked = false;

            chkRenyiliangmachaYiChuxian0.Enabled = false;
            chkRenyiliangmachaYiChuxian1.Enabled = false;
            chkRenyiliangmachaYiChuxian2.Enabled = false;
            chkRenyiliangmachaYiChuxian3.Enabled = false;
        }

        private void chkRenyiliangmachaYi1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkRenyiliangmachaYi10.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi1.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi2.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi3.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi4.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi5.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi6.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi7.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi8.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaYi9.Checked) ? 1 : 0);

            SetCheckState(grpRenyiliangmachaYi, count, "chkRenyiliangmachaYiChuxian");
        }

        // 任意两码差 二
        private void SetRenyiliangmachaEr1_3()
        {
            A11_3._RenyiliangmachaEr = new RenyiliangmachaErStruct()
            {
                renyiliangmachaEr1 = GetCheckedArray(grpRenyiliangmachaEr, "chkRenyiliangmachaEr1_", true),
                renyiliangmachaEr2 = GetCheckedArray(grpRenyiliangmachaEr, "chkRenyiliangmachaEr2_", true),
                AppearNums = GetCheckedArray(grpRenyiliangmachaEr, "chkRenyiliangmachaErChuxian", true)
            };
        }

        // 清
        private void chkRenyiliangmachaErQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpRenyiliangmachaEr, false);
            chkRenyiliangmachaErChuxian0.Enabled = false;
            chkRenyiliangmachaErChuxian1.Enabled = false;
            chkRenyiliangmachaErChuxian2.Enabled = false;
        }

        private void chkRenyiliangmachaEr1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkRenyiliangmachaEr1_10.Checked || chkRenyiliangmachaEr1_1.Checked || chkRenyiliangmachaEr1_2.Checked || chkRenyiliangmachaEr1_3.Checked || chkRenyiliangmachaEr1_4.Checked || chkRenyiliangmachaEr1_5.Checked || chkRenyiliangmachaEr1_6.Checked || chkRenyiliangmachaEr1_7.Checked || chkRenyiliangmachaEr1_8.Checked || chkRenyiliangmachaEr1_9.Checked) ? 1 : 0)
                + ((chkRenyiliangmachaEr2_10.Checked || chkRenyiliangmachaEr2_1.Checked || chkRenyiliangmachaEr2_2.Checked || chkRenyiliangmachaEr2_3.Checked || chkRenyiliangmachaEr2_4.Checked || chkRenyiliangmachaEr2_5.Checked || chkRenyiliangmachaEr2_6.Checked || chkRenyiliangmachaEr2_7.Checked || chkRenyiliangmachaEr2_8.Checked || chkRenyiliangmachaEr2_9.Checked) ? 1 : 0);

            SetCheckState(grpRenyiliangmachaEr, count, "chkRenyiliangmachaErChuxian");
        }

        private void chkRenyiliangmachaEr1All_CheckedChanged(object sender, EventArgs e)
        {
            chkRenyiliangmachaEr1_10.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_1.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_2.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_3.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_4.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_5.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_6.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_7.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_8.Checked = chkRenyiliangmachaEr1Quan.Checked;
            chkRenyiliangmachaEr1_9.Checked = chkRenyiliangmachaEr1Quan.Checked;
        }

        private void chkRenyiliangmachaEr2All_CheckedChanged(object sender, EventArgs e)
        {
            chkRenyiliangmachaEr2_1.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_2.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_3.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_4.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_5.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_6.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_7.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_8.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_9.Checked = chkRenyiliangmachaEr2Quan.Checked;
            chkRenyiliangmachaEr2_10.Checked = chkRenyiliangmachaEr2Quan.Checked;
        }

        // 两码差最大间距
        private void SetLiangmachazuidajianju1_3()
        {
            A11_3.Liangmachazuidajianju = GetCheckedArray(grpLiangmachazuidajianju, "chkLiangmachazuidajianju", true);
        }

        private void chkLiangmachazuidajianjuQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLiangmachazuidajianju, false);
        }

        // 定位两码差
        private void SetDingweiliangmacha1_3()
        {
            A11_3._Dingweiliangmacha = new Dingweiliangmacha()
            {
                dingweiliangmacha1 = GetCheckedArray(grpDingweiliangmacha, "chkDingweiliangmacha1_", true),
                dingweiliangmacha2 = GetCheckedArray(grpDingweiliangmacha, "chkDingweiliangmacha2_", true),
                dingweiliangmacha3 = GetCheckedArray(grpDingweiliangmacha, "chkDingweiliangmacha3_", true),
                AppearNums = GetCheckedArray(grpDingweiliangmacha, "chkDingweiliangmachaChuxian", true)
            };
        }

        // 清
        private void chkDingweiliangmachaQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpDingweiliangmacha, false);
            chkDingweiliangmachaChuxian0.Enabled = false;
            chkDingweiliangmachaChuxian1.Enabled = false;
            chkDingweiliangmachaChuxian2.Enabled = false;
            chkDingweiliangmachaChuxian3.Enabled = false;
        }

        private void chkDingweiliangmacha1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkDingweiliangmacha1_1.Checked || chkDingweiliangmacha1_2.Checked || chkDingweiliangmacha1_3.Checked || chkDingweiliangmacha1_4.Checked || chkDingweiliangmacha1_5.Checked || chkDingweiliangmacha1_6.Checked || chkDingweiliangmacha1_7.Checked || chkDingweiliangmacha1_8.Checked || chkDingweiliangmacha1_9.Checked || chkDingweiliangmacha1_10.Checked) ? 1 : 0)
                + ((chkDingweiliangmacha2_1.Checked || chkDingweiliangmacha2_2.Checked || chkDingweiliangmacha2_3.Checked || chkDingweiliangmacha2_4.Checked || chkDingweiliangmacha2_5.Checked || chkDingweiliangmacha2_6.Checked || chkDingweiliangmacha2_7.Checked || chkDingweiliangmacha2_8.Checked || chkDingweiliangmacha2_9.Checked || chkDingweiliangmacha2_10.Checked) ? 1 : 0)
                + ((chkDingweiliangmacha3_1.Checked || chkDingweiliangmacha3_2.Checked || chkDingweiliangmacha3_3.Checked || chkDingweiliangmacha3_4.Checked || chkDingweiliangmacha3_5.Checked || chkDingweiliangmacha3_6.Checked || chkDingweiliangmacha3_7.Checked || chkDingweiliangmacha3_8.Checked || chkDingweiliangmacha3_9.Checked || chkDingweiliangmacha3_10.Checked) ? 1 : 0);

            SetCheckState(grpDingweiliangmacha, count, "chkDingweiliangmachaChuxian");
        }

        // 1
        private void chkDingweiliangmacha1Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha1Da.Checked, "chkDingweiliangmacha1_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmacha1Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha1Xiao.Checked, "chkDingweiliangmacha1_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmacha1Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha1Dan.Checked, "chkDingweiliangmacha1_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha1Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha1Shuang.Checked, "chkDingweiliangmacha1_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha1Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha1Quan.Checked, "chkDingweiliangmacha1_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }

        // 2
        private void chkDingweiliangmacha2Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha2Da.Checked, "chkDingweiliangmacha2_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmacha2Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha2Xiao.Checked, "chkDingweiliangmacha2_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmacha2Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha2Dan.Checked, "chkDingweiliangmacha2_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha2Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha2Shuang.Checked, "chkDingweiliangmacha2_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha2Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha2Quan.Checked, "chkDingweiliangmacha2_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }

        // 3
        private void chkDingweiliangmacha3Da_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha3Da.Checked, "chkDingweiliangmacha3_",
               (n) => { if ((n >= 5) && (n <= 9)) { return true; } return false; });
        }

        private void chkDingweiliangmacha3Xiao_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha3Xiao.Checked, "chkDingweiliangmacha3_",
               (n) => { if ((n >= 0) && (n <= 4)) { return true; } return false; });
        }

        private void chkDingweiliangmacha3Dan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha3Dan.Checked, "chkDingweiliangmacha3_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha3Shuang_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha3Shuang.Checked, "chkDingweiliangmacha3_",
                (n) => { if (n % 2 == 1) { return true; } return false; });
        }

        private void chkDingweiliangmacha3Quan_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(grpDingweiliangmacha, chkDingweiliangmacha3Quan.Checked, "chkDingweiliangmacha3_",
               (n) => { if ((n >= 0) && (n <= 9)) { return true; } return false; });
        }

        // 两码差分序组选
        private void SetLiangmachafenxuzuxuan1_3()
        {
            A11_3._Liangmachafenxuzuxuan = new Liangmachafenxuzuxuan()
            {
                liangmachafenxuzuxuan1 = GetCheckedArray(grpLiangmachafenxuzuxuan, "chkLiangmachafenxuzuxuan1_", true),
                liangmachafenxuzuxuan2 = GetCheckedArray(grpLiangmachafenxuzuxuan, "chkLiangmachafenxuzuxuan2_", true),
                liangmachafenxuzuxuan3 = GetCheckedArray(grpLiangmachafenxuzuxuan, "chkLiangmachafenxuzuxuan3_", true),
                AppearNums = GetCheckedArray(grpLiangmachafenxuzuxuan, "chkLiangmachafenxuzuxuanChuxian", true)
            };
        }

        // 清
        private void chkLiangmachafenxuzuxuanQing_Click(object sender, EventArgs e)
        {
            SetCheckboxState(grpLiangmachafenxuzuxuan, false);
            chkLiangmachafenxuzuxuanChuxian0.Enabled = false;
            chkLiangmachafenxuzuxuanChuxian1.Enabled = false;
            chkLiangmachafenxuzuxuanChuxian2.Enabled = false;
            chkLiangmachafenxuzuxuanChuxian3.Enabled = false;
        }

        private void chkLiangmachafenxuzuxuan1_1_Click(object sender, EventArgs e)
        {
            int count =
                  ((chkLiangmachafenxuzuxuan1_1.Checked || chkLiangmachafenxuzuxuan1_2.Checked || chkLiangmachafenxuzuxuan1_3.Checked || chkLiangmachafenxuzuxuan1_4.Checked || chkLiangmachafenxuzuxuan1_5.Checked || chkLiangmachafenxuzuxuan1_6.Checked || chkLiangmachafenxuzuxuan1_7.Checked || chkLiangmachafenxuzuxuan1_8.Checked || chkLiangmachafenxuzuxuan1_9.Checked || chkLiangmachafenxuzuxuan1_10.Checked) ? 1 : 0)
                + ((chkLiangmachafenxuzuxuan2_1.Checked || chkLiangmachafenxuzuxuan2_2.Checked || chkLiangmachafenxuzuxuan2_3.Checked || chkLiangmachafenxuzuxuan2_4.Checked || chkLiangmachafenxuzuxuan2_5.Checked || chkLiangmachafenxuzuxuan2_6.Checked || chkLiangmachafenxuzuxuan2_7.Checked || chkLiangmachafenxuzuxuan2_8.Checked || chkLiangmachafenxuzuxuan2_9.Checked || chkLiangmachafenxuzuxuan2_10.Checked) ? 1 : 0)
                + ((chkLiangmachafenxuzuxuan3_1.Checked || chkLiangmachafenxuzuxuan3_2.Checked || chkLiangmachafenxuzuxuan3_3.Checked || chkLiangmachafenxuzuxuan3_4.Checked || chkLiangmachafenxuzuxuan3_5.Checked || chkLiangmachafenxuzuxuan3_6.Checked || chkLiangmachafenxuzuxuan3_7.Checked || chkLiangmachafenxuzuxuan3_8.Checked || chkLiangmachafenxuzuxuan3_9.Checked || chkLiangmachafenxuzuxuan3_10.Checked) ? 1 : 0);

            SetCheckState(grpLiangmachafenxuzuxuan, count, "chkLiangmachafenxuzuxuanChuxian");
        }

        // TabControl 切换
        private void button22_Click(object sender, EventArgs e)
        {
            SetTabState(button22, true);
            SetTabState(button21, false);
            SetTabState(button20, false);
            SetTabState(button19, false);
            SetTabState(button44, false);
            tabControl4.SelectedIndex = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SetTabState(button22, false);
            SetTabState(button21, true);
            SetTabState(button20, false);
            SetTabState(button19, false);
            SetTabState(button44, false);
            tabControl4.SelectedIndex = 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SetTabState(button22, false);
            SetTabState(button21, false);
            SetTabState(button20, true);
            SetTabState(button19, false);
            SetTabState(button44, false);
            tabControl4.SelectedIndex = 2;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SetTabState(button22, false);
            SetTabState(button21, false);
            SetTabState(button20, false);
            SetTabState(button19, true);
            SetTabState(button44, false);
            tabControl4.SelectedIndex = 3;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            SetTabState(button22, false);
            SetTabState(button21, false);
            SetTabState(button20, false);
            SetTabState(button19, false);
            SetTabState(button44, true);
            tabControl4.SelectedIndex = 4;
        }

        // 11选3 tab control
        object CurrentSender11_3 = null;
        private void tabControl3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (tabControl3.SelectedIndex)
            {
                default:
                case 0: //选项条件

                    break;
                case 1: //走势图

                    if (CurrentSender11_3 == null)
                    {
                        if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + ".dll"))
                        {
                            viewErrorChart(Browser11_3);
                        }
                        else
                        {
                            //(CurrentSender11_3 as Button).PerformClick();
                            //Chart11_3Shift(sender, 1, "01");
                            button58_Click(button58, e);
                            SetTabState(button58, true);
                        }
                    }
                    else
                    {
                        (CurrentSender11_3 as Button).PerformClick();
                        SetTabState((CurrentSender11_3 as Button), true);
                    }
                    //this.MaximizeBox = true; 暂时取消
                    this.UpdateSystemButtonRect();
                    break;

            }
        }

        #region 11选3 走势图

        private void Chart11_3Shift(Object sender, int indexChart, string htmlName)
        {
            if (CurrentSender11_3 != null)
            {
                DeleteFile(currentHtml);
                Browser11_3.SaveDocument(System.Environment.CurrentDirectory + @"\chart\" + currentHtml);
            }
            /*
            //tcccc.SelectedIndex = 0;
            */
            CurrentSender11_3 = sender;
            btnIndex = 0;


            if (!File.Exists(System.Environment.CurrentDirectory + @"\data\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + ".dll"))
            {
                viewErrorChart(Browser11_3);
            }
            else
            {
                //if (clr0)
                //{
                //clr0 = false;
                List<string> days = new List<string>();

                List<Lottery11_3> lotterys = GetCPDllInfos11_3(USERID, currentLotteryTypeInfo11_3.Lottery_Type.ToString(), days);

                days.Reverse();
                lotterys.Reverse();

                string html = "";
                switch (indexChart)
                {
                    case 1:
                        html = CyyChart11_3.GetHtmlJiBenZouShi(lotterys, days);
                        break;
                    case 2:
                        html = CyyChart11_3.GetHtmlFenxuZouShi(lotterys, days);
                        break;
                    case 3:
                        html = CyyChart11_3.GetHtmlLtfwFbqjlZouShi(lotterys, days);
                        break;
                    case 4:
                        html = CyyChart11_3.GetHtmlZdlmkjBlhZouShi(lotterys, days);
                        break;
                    case 5:
                        html = CyyChart11_3.GetHtmlXtKd012(lotterys, days);
                        break;
                    case 6:
                        html = CyyChart11_3.GetHtmlHzhzZouShi(lotterys, days);
                        break;
                    case 7:
                        html = CyyChart11_3.GetHtmlLmhZouShi(lotterys, days);
                        break;
                    case 8:
                        html = CyyChart11_3.GetHtmlLmhFenxu(lotterys, days);
                        break;
                    case 9:
                        html = CyyChart11_3.GetHtmlLmcZouShi(lotterys, days);
                        break;
                    case 10:
                        html = CyyChart11_3.GetHtmlLmcFenxu(lotterys, days);
                        break;
                    case 11:
                        html = CyyChart11_3.GetHtmlQhgjHcch(lotterys, days);
                        break;
                    case 12:
                        html = CyyChart11_3.GetHtmlLmHCJianJu(lotterys, days);
                        break;
                }

                using (FileStream fs = File.Create(
                  System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + @"_" + htmlName + ".html"))
                {
                    StringBuilder sb = new StringBuilder();
                    byte[] info = new UTF8Encoding().GetBytes(html);
                    fs.Write(info, 0, info.Length);
                }

                //}
                Browser11_3.Navigate(System.Environment.CurrentDirectory + @"\chart\" + USERID + currentLotteryTypeInfo11_3.Lottery_Type.ToString() + @"_" + htmlName + ".html");
            }

            CurrentSender11_3 = sender;
            currentHtml = USERID + currentLotteryTypeInfo11_5.Lottery_Type.ToString() + @"_" + htmlName + ".html";
        }

        // 基本走势图
        private void button58_Click(object sender, EventArgs e)
        {
            SetTabState(button58, true);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 1, "01");
        }

        private void button57_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, true);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 2, "03");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, true);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 3, "03");
        }

        private void button56_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, true);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 4, "04");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, true);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 5, "05");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, true);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 6, "06");
        }

        private void button54_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, true);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 7, "07");
        }

        private void button53_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, true);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 8, "08");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, true);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 9, "09");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, true);
            SetTabState(button27, false);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 10, "10");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, true);
            SetTabState(button26, false);
            Chart11_3Shift(sender, 11, "11");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SetTabState(button58, false);
            SetTabState(button57, false);
            SetTabState(button32, false);
            SetTabState(button56, false);
            SetTabState(button31, false);
            SetTabState(button55, false);
            SetTabState(button54, false);
            SetTabState(button53, false);
            SetTabState(button30, false);
            SetTabState(button23, false);
            SetTabState(button27, false);
            SetTabState(button26, true);
            Chart11_3Shift(sender, 12, "12");
        }
        #endregion

        private void AutoGetCPDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cbbLotteryTypes.Enabled = !AutoGetCPDataCheckBox.Checked;
            //tmrAutoRefresh.Enabled = AutoGetCPDataCheckBox.Checked;
        }

        private void autoGetCP11x3DataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !autoGetCP11x3DataCheckBox.Checked;
            //tmrAutoRefresh.Enabled = autoGetCP11x3DataCheckBox.Checked;
        }

        private void qqButton1_Click(object sender, EventArgs e)
        {
            Suggestion su = new Suggestion();
            su.ShowDialog();
        }

    }
}
