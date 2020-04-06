namespace GUI.UI
{
    partial class LoginInterface
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.RadioAdmin = new System.Windows.Forms.RadioButton();
            this.RadioTeacher = new System.Windows.Forms.RadioButton();
            this.RadioStudent = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-2, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(605, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // TxtPwd
            // 
            this.TxtPwd.Location = new System.Drawing.Point(234, 207);
            this.TxtPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.PasswordChar = '*';
            this.TxtPwd.Size = new System.Drawing.Size(162, 21);
            this.TxtPwd.TabIndex = 18;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(234, 160);
            this.TxtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(162, 21);
            this.TxtName.TabIndex = 17;
            this.TxtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("宋体", 12F);
            this.BtnExit.Location = new System.Drawing.Point(322, 290);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(74, 30);
            this.BtnExit.TabIndex = 16;
            this.BtnExit.Text = "退出";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Font = new System.Drawing.Font("宋体", 12F);
            this.BtnLogin.Location = new System.Drawing.Point(161, 290);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(71, 30);
            this.BtnLogin.TabIndex = 15;
            this.BtnLogin.Text = "登陆";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // RadioAdmin
            // 
            this.RadioAdmin.AutoSize = true;
            this.RadioAdmin.BackColor = System.Drawing.Color.Transparent;
            this.RadioAdmin.Font = new System.Drawing.Font("宋体", 12F);
            this.RadioAdmin.Location = new System.Drawing.Point(328, 242);
            this.RadioAdmin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioAdmin.Name = "RadioAdmin";
            this.RadioAdmin.Size = new System.Drawing.Size(74, 20);
            this.RadioAdmin.TabIndex = 14;
            this.RadioAdmin.TabStop = true;
            this.RadioAdmin.Text = "管理员";
            this.RadioAdmin.UseVisualStyleBackColor = false;
            // 
            // RadioTeacher
            // 
            this.RadioTeacher.AutoSize = true;
            this.RadioTeacher.BackColor = System.Drawing.Color.Transparent;
            this.RadioTeacher.Font = new System.Drawing.Font("宋体", 12F);
            this.RadioTeacher.Location = new System.Drawing.Point(250, 242);
            this.RadioTeacher.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioTeacher.Name = "RadioTeacher";
            this.RadioTeacher.Size = new System.Drawing.Size(58, 20);
            this.RadioTeacher.TabIndex = 13;
            this.RadioTeacher.TabStop = true;
            this.RadioTeacher.Text = "导师";
            this.RadioTeacher.UseVisualStyleBackColor = false;
            // 
            // RadioStudent
            // 
            this.RadioStudent.AutoSize = true;
            this.RadioStudent.BackColor = System.Drawing.Color.Transparent;
            this.RadioStudent.Font = new System.Drawing.Font("宋体", 12F);
            this.RadioStudent.Location = new System.Drawing.Point(161, 242);
            this.RadioStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RadioStudent.Name = "RadioStudent";
            this.RadioStudent.Size = new System.Drawing.Size(58, 20);
            this.RadioStudent.TabIndex = 12;
            this.RadioStudent.TabStop = true;
            this.RadioStudent.Text = "学生";
            this.RadioStudent.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(158, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(158, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "账号";
            // 
            // LoginInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.RadioAdmin);
            this.Controls.Add(this.RadioTeacher);
            this.Controls.Add(this.RadioStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆界面";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.RadioButton RadioAdmin;
        private System.Windows.Forms.RadioButton RadioTeacher;
        private System.Windows.Forms.RadioButton RadioStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}