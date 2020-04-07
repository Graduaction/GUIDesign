namespace GUI.UI
{
    partial class PersonalCenter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbadmintitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbnewpwd = new System.Windows.Forms.TextBox();
            this.tbminemail = new System.Windows.Forms.TextBox();
            this.tbAdminNo = new System.Windows.Forms.TextBox();
            this.tbAdminName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbadmintitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbnewpwd);
            this.groupBox1.Controls.Add(this.tbminemail);
            this.groupBox1.Controls.Add(this.tbAdminNo);
            this.groupBox1.Controls.Add(this.tbAdminName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1325, 494);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人中心";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbadmintitle
            // 
            this.tbadmintitle.Location = new System.Drawing.Point(657, 210);
            this.tbadmintitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbadmintitle.Name = "tbadmintitle";
            this.tbadmintitle.Size = new System.Drawing.Size(153, 25);
            this.tbadmintitle.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(517, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "职称：";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(606, 363);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 38);
            this.button1.TabIndex = 14;
            this.button1.Text = "确认修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbnewpwd
            // 
            this.tbnewpwd.Location = new System.Drawing.Point(657, 307);
            this.tbnewpwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbnewpwd.Name = "tbnewpwd";
            this.tbnewpwd.PasswordChar = '*';
            this.tbnewpwd.Size = new System.Drawing.Size(153, 25);
            this.tbnewpwd.TabIndex = 13;
            this.tbnewpwd.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // tbminemail
            // 
            this.tbminemail.Location = new System.Drawing.Point(657, 259);
            this.tbminemail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbminemail.Name = "tbminemail";
            this.tbminemail.Size = new System.Drawing.Size(153, 25);
            this.tbminemail.TabIndex = 12;
            // 
            // tbAdminNo
            // 
            this.tbAdminNo.Location = new System.Drawing.Point(657, 103);
            this.tbAdminNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAdminNo.Name = "tbAdminNo";
            this.tbAdminNo.ReadOnly = true;
            this.tbAdminNo.Size = new System.Drawing.Size(153, 25);
            this.tbAdminNo.TabIndex = 9;
            // 
            // tbAdminName
            // 
            this.tbAdminName.Location = new System.Drawing.Point(657, 159);
            this.tbAdminName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAdminName.Name = "tbAdminName";
            this.tbAdminName.ReadOnly = true;
            this.tbAdminName.Size = new System.Drawing.Size(153, 25);
            this.tbAdminName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(493, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "新密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(517, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "邮箱：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(517, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "工号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(517, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 19F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(582, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "个人中心";
            // 
            // PersonalCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1349, 518);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PersonalCenter";
            this.Text = "Form15";
            this.Load += new System.EventHandler(this.PersonalCenter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbminemail;
        private System.Windows.Forms.TextBox tbAdminNo;
        private System.Windows.Forms.TextBox tbAdminName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbadmintitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbnewpwd;
        private System.Windows.Forms.Label label7;
    }
}