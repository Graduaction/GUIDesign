using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace GUI.UI
{
    public partial class ChangePwdStu : Form
    {
        /// <summary>
        /// 常量定义
        /// </summary>
        readonly StudentManager sm = new StudentManager();
        public const string INPUTUSERNAME = "请输入学号";
        public const string INPUTWARN = "输入提示";
        public const string INPUTPWD = "请输入密码";
        public const string INPUTNOEXIST = "用户名或密码不存在";
        public ChangePwdStu()
        {
            InitializeComponent();
        }
        #region 输入验证
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns>true:通过 false:不通过</returns>
        public bool CheckInput()
        {
            if (this.textBoxid.Text == "")
            {
                MessageBox.Show(INPUTUSERNAME, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxid.Focus();
                return false;

            }
            if (this.textBoxop.Text == "")
            {
                MessageBox.Show(INPUTPWD, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxop.Focus();
                return false;
            }
            if (this.textBox12.Text == "")
            {
                MessageBox.Show(INPUTPWD, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox12.Focus();
                return false;
            }
            return true;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                {
                    return;
                }

                if (textBoxop.Text.Trim()== textBox12.Text.Trim())
                {
                    MessageBox.Show("新密码与旧密码一样", INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!sm.ChangeStuPwd(textBoxid.Text.Trim(), textBoxop.Text.Trim(), textBox12.Text.Trim()))
                    {
                        MessageBox.Show("修改密码成功");
                    }
                    else
                    {
                        MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePwdStu_Load(object sender, EventArgs e)
        {
            textBoxid.Text = LoginInterface.loginid;
        }
    }
}
