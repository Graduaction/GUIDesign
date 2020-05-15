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
        readonly StudentManager tm = new StudentManager();
        public const string INPUTWARN = "输入提示";
        public const string INPUTNOEXIST = "工号或密码错误";
        public ChangePwdStu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tm.ChangeStuPwd(textBoxid.Text.Trim(), textBoxop.Text.Trim(), textBox12.Text.Trim()))
            {
                MessageBox.Show("修改密码成功");
            }
            else
            {
                MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
