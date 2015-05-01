using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CyyClient
{
    public partial class UpdateNotification : Form
    {
        private bool isDetailClicked = false;
        private string urlString = "";

        public UpdateNotification()
        {
            InitializeComponent();
        }

        public UpdateNotification(string us, string ds, string url) {
            InitializeComponent();
            label1.Text = us;
            textBox1.Text = ds;
            urlString = url;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isDetailClicked)
            {
                textBox1.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + 70);
                isDetailClicked = true;
            }
            else {
                textBox1.Visible = false;
                this.Size = new Size(this.Size.Width, this.Size.Height - 70);
                isDetailClicked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            if (!urlString.Equals("")){
                update ud = new update(urlString);
                ud.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
