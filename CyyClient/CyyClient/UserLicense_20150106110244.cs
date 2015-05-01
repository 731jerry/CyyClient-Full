using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace CyyClient
{
    public partial class UserLicense : Form
    {
        private bool ok = false;
        public UserLicense()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //CyyDatabase.cyyDB.DeleteDateNow();
            ((Owner as CyyLogin).Owner as CyyMain).LoginState = false;

            CyyMain.cyyMainExit();
            //Close();
            //Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ok = true;

            if (((Owner as CyyLogin).Owner as CyyMain).back == 1)
            {
                ((Owner as CyyLogin).Owner as CyyMain).Visible = true;
            }
            Close();
        }

        private void UserLicense_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnOk;
            lblUserName.Text = (Owner as CyyLogin).userInfo["nickname"].ToString();
            string ip = (Owner as CyyLogin).userInfo["UserLogined_ip"].ToString();

            ((Owner as CyyLogin).Owner as CyyMain).lblUser.Text = lblUserName.Text;

            string lisDayString = "到期日期异常";
            if (!(Owner as CyyLogin).userInfo["UserLisDay"].ToString().Equals(""))
            {
                DateTime LisDay = DateTime.Parse((Owner as CyyLogin).userInfo["UserLisDay"].ToString());
                int DiffDays = (LisDay - DateTime.Now).Days;
                //lisDayString = "到期日期: " + LisDay.ToString("yyyy年M月d日") + "  还剩: " + DiffDays.ToString() + " 天到期";
                lisDayString = "使用期限: 剩余" + DiffDays.ToString() + "天";
            }
            ((Owner as CyyLogin).Owner as CyyMain).UserLienseLabel.Text = lisDayString;            

            webBrowser1.Navigate(System.Environment.CurrentDirectory + @"\config\lic.htm");

            //((Owner as CyyLogin).Owner as CyyMain).USERID = (Owner as CyyLogin).dtUserInfo.Rows[0]["UserNumber"].ToString();
            CyyMain.USERID = (Owner as CyyLogin).userInfo["user_name"].ToString();
            txtCurrentIP.Text = CyyMain.currentIP;
            txtCurrentAddress.Text = CyyMain.currentAddress;
        }

        private void UserLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ok)
            {
                //((Owner as CyyLogin).Owner as CyyMain).LoginState = false;
                btnExit.PerformClick();
            }
        }

    }
}
