namespace CyyClient
{
    partial class Suggestion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.qqTextBox1 = new ControlExs.QQTextBox();
            this.qqButton1 = new ControlExs.QQButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.qqButton1);
            this.panel1.Controls.Add(this.qqTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panel1.Size = new System.Drawing.Size(468, 249);
            this.panel1.TabIndex = 0;
            // 
            // qqTextBox1
            // 
            this.qqTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qqTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.qqTextBox1.EmptyTextTip = null;
            this.qqTextBox1.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.qqTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.qqTextBox1.Location = new System.Drawing.Point(5, 5);
            this.qqTextBox1.Multiline = true;
            this.qqTextBox1.Name = "qqTextBox1";
            this.qqTextBox1.Size = new System.Drawing.Size(458, 193);
            this.qqTextBox1.TabIndex = 0;
            // 
            // qqButton1
            // 
            this.qqButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.qqButton1.Location = new System.Drawing.Point(329, 211);
            this.qqButton1.Name = "qqButton1";
            this.qqButton1.Size = new System.Drawing.Size(106, 23);
            this.qqButton1.TabIndex = 3;
            this.qqButton1.Text = "确认";
            this.qqButton1.UseVisualStyleBackColor = true;
            this.qqButton1.Click += new System.EventHandler(this.qqButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "我要建议",
            "我要投诉"});
            this.comboBox1.Location = new System.Drawing.Point(93, 212);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "请选择:";
            // 
            // Suggestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 249);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Suggestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "投诉建议";
            this.Load += new System.EventHandler(this.Suggestion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ControlExs.QQButton qqButton1;
        private ControlExs.QQTextBox qqTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}