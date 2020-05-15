using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace GUI.UI
{
    public partial class LoginInterface : Form
    {
        #region 常量,变量的定义
        public const string INPUTUSERNAME = "请输入用户名";
        public const string INPUTWARN = "输入提示";
        public const string INPUTPWD = "请输入密码";
        public const string LOGINFAILED = "登录失败";
        public const string INPUTNOEXIST = "用户名或密码不存在";
        readonly StudentManager sm = new StudentManager();//实例化对象
        readonly TeacherManager tm = new TeacherManager();

        readonly ad_ServicesBLL ad_ServicesBLL = new ad_ServicesBLL();
        //public static string loginid = "16209010016";//登入账号
        public static string loginid;//登入账号

        #endregion

        // 构造函数
        public LoginInterface()
        {
            InitializeComponent();

        }

        // 窗体加载事件
        private void Form9_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("../../img/背景.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = new Bitmap("../../img/横幅.png");
        }

        #region 输入验证
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns>true:通过 false:不通过</returns>
        public bool CheckInput()
        {
            if (this.TxtName.Text == "")
            {
                MessageBox.Show(INPUTUSERNAME, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TxtName.Focus();
                return false;

            }
            if (this.TxtPwd.Text == "")
            {
                MessageBox.Show(INPUTPWD, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TxtPwd.Focus();
                return false;
            }
            return true;
        }
        #endregion

        // 单击登录事件
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                {
                    return;
                }
                // 判断用户类型
                if (RadioStudent.Checked == true)
                {
                    StudentData student = new StudentData();
                    student.StuNo = TxtName.Text.Trim();
                    student.StuPwd = TxtPwd.Text.Trim();
                    if (sm.CheckStudentLogin(TxtName.Text.Trim(), TxtPwd.Text.Trim()))
                    {
                        this.Visible = false;
                        StudentForm f1 = new StudentForm();
                        f1.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (RadioTeacher.Checked == true)
                {
                    if (tm.CheckTeacherLogin(TxtName.Text.Trim(), TxtPwd.Text.Trim()))
                    {
                        this.Visible = false;
                        Teacher f2 = new Teacher();
                        f2.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    AdminData adminData = new AdminData();
                    adminData.AdminNo = TxtName.Text.Trim();

                    adminData.AdminPwd = TxtPwd.Text.Trim();
                    if (ad_ServicesBLL.CheckAdminLogin(adminData) == 2)
                    {
                        this.Visible = false;
                        MainForm f3 = new MainForm();
                        f3.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, LOGINFAILED, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 退出登录
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            loginid = this.TxtName.Text.Trim();
        }
    }
}
