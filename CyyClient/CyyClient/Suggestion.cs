using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CyyService;

namespace CyyClient
{
    public partial class Suggestion : Form
    {
        public Suggestion()
        {
            InitializeComponent();
        }

        private void qqButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BasicFeature.SendMail("[" + comboBox1.Text + "]" + "来自彩盈盈" + CyyMain.productKeyVersionNameString + "v" + CyyMain.proudctVersionString + "用户" + CyyMain.USERID, "", qqTextBox1.Text, false),"恭喜!");
            this.Close();
        }

        private void Suggestion_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
