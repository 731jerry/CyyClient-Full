namespace CyyClient
{
    partial class CyyLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CyyLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Psw = new System.Windows.Forms.TextBox();
            this.RemPsw = new System.Windows.Forms.CheckBox();
            this.AgreeCyy = new System.Windows.Forms.CheckBox();
            this.weblink = new System.Windows.Forms.LinkLabel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadCyy = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Acc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // Psw
            // 
            this.Psw.Location = new System.Drawing.Point(142, 193);
            this.Psw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Psw.MaxLength = 12;
            this.Psw.Name = "Psw";
            this.Psw.PasswordChar = '*';
            this.Psw.Size = new System.Drawing.Size(116, 23);
            this.Psw.TabIndex = 3;
            this.Psw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Psw_KeyPress);
            // 
            // RemPsw
            // 
            this.RemPsw.AutoSize = true;
            this.RemPsw.Checked = true;
            this.RemPsw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemPsw.Location = new System.Drawing.Point(107, 224);
            this.RemPsw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemPsw.Name = "RemPsw";
            this.RemPsw.Size = new System.Drawing.Size(75, 21);
            this.RemPsw.TabIndex = 5;
            this.RemPsw.Text = "记住密码";
            this.RemPsw.UseVisualStyleBackColor = true;
            this.RemPsw.CheckedChanged += new System.EventHandler(this.RemPsw_CheckedChanged);
            // 
            // AgreeCyy
            // 
            this.AgreeCyy.AutoSize = true;
            this.AgreeCyy.Enabled = false;
            this.AgreeCyy.Location = new System.Drawing.Point(205, 224);
            this.AgreeCyy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AgreeCyy.Name = "AgreeCyy";
            this.AgreeCyy.Size = new System.Drawing.Size(75, 21);
            this.AgreeCyy.TabIndex = 7;
            this.AgreeCyy.Text = "自动登录";
            this.AgreeCyy.UseVisualStyleBackColor = true;
            this.AgreeCyy.CheckedChanged += new System.EventHandler(this.AgreeCyy_CheckedChanged);
            // 
            // weblink
            // 
            this.weblink.AutoSize = true;
            this.weblink.Location = new System.Drawing.Point(269, 198);
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(56, 17);
            this.weblink.TabIndex = 8;
            this.weblink.TabStop = true;
            this.weblink.Text = "找回密码";
            this.weblink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblink_LinkClicked);
            // 
            // btnSetting
            // 
            this.btnSetting.Enabled = false;
            this.btnSetting.Image = global::CyyClient.Properties.Resources.wrench;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(45, 262);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(105, 30);
            this.btnSetting.TabIndex = 10;
            this.btnSetting.Text = "   设  置";
            this.btnSetting.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CyyClient.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 147);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LoadCyy
            // 
            this.LoadCyy.Image = global::CyyClient.Properties.Resources._lock;
            this.LoadCyy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadCyy.Location = new System.Drawing.Point(220, 262);
            this.LoadCyy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoadCyy.Name = "LoadCyy";
            this.LoadCyy.Size = new System.Drawing.Size(105, 30);
            this.LoadCyy.TabIndex = 6;
            this.LoadCyy.Text = "  登   录";
            this.LoadCyy.UseVisualStyleBackColor = true;
            this.LoadCyy.Click += new System.EventHandler(this.LoadCyy_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CyyClient.Properties.Resources.man;
            this.pictureBox2.Location = new System.Drawing.Point(10, 156);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 82);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(269, 165);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 17);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "注册帐号";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Acc
            // 
            this.Acc.FormattingEnabled = true;
            this.Acc.Location = new System.Drawing.Point(143, 162);
            this.Acc.Name = "Acc";
            this.Acc.Size = new System.Drawing.Size(115, 25);
            this.Acc.TabIndex = 13;
            this.Acc.SelectedIndexChanged += new System.EventHandler(this.Acc_SelectedIndexChanged);
            // 
            // CyyLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 305);
            this.Controls.Add(this.Acc);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.weblink);
            this.Controls.Add(this.AgreeCyy);
            this.Controls.Add(this.LoadCyy);
            this.Controls.Add(this.RemPsw);
            this.Controls.Add(this.Psw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CyyLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "彩盈盈";
            this.Load += new System.EventHandler(this.CyyLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Psw;
        private System.Windows.Forms.CheckBox RemPsw;
        private System.Windows.Forms.CheckBox AgreeCyy;
        private System.Windows.Forms.LinkLabel weblink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox Acc;
        internal System.Windows.Forms.Button LoadCyy;
    }
}