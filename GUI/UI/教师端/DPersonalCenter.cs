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
    public partial class DPersonalCenter : Form
    {
        /// <summary>
        /// 常量定义
        /// </summary>
        readonly TeacherManager tm = new TeacherManager();
        public const string INPUTWARN = "输入提示";
        public const string INPUTNOEXIST = "修改失败";
        public string teaNo = LoginInterface.loginid;// 当前登录用户的账号  非常重要
        private static DPersonalCenter formInstance;
        public static DPersonalCenter GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DPersonalCenter();
                    return formInstance;
                }
            }
        }
        public DPersonalCenter()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            #region 页面载入时显示此时登入账号的个人信息
            try
            {
                DataTable dt = tm.Getperson(teaNo);//参数是登录时输入的那个账号  要吧那个账号固定成一个常量
                tbno.Text = dt.Rows[0]["TeaNo"].ToString();
                tbname.Text = dt.Rows[0]["TeaName"].ToString();
                tbtitle.Text = dt.Rows[0]["Title"].ToString();
                tbphone.Text = dt.Rows[0]["Contaction"].ToString();
                tbemail.Text = dt.Rows[0]["Email"].ToString();
                textBox1.Text = dt.Rows[0]["GroupNumber"].ToString();
                textBox7.Text = dt.Rows[0]["Profile"].ToString();
                
              
            }
            catch (Exception ex)
            {

                throw ex;
            } 
            #endregion
        }
        //提交按钮  提交textbox里的内容到对应的数据库字段里

        private void button2_Click(object sender, EventArgs e)
        {
            if (tm.UpdateTea(teaNo, tbname.Text.Trim(), tbtitle.Text.Trim(), tbphone.Text.Trim(), textBox7.Text.Trim(),tbemail.Text.Trim()))
            {
                MessageBox.Show("修改个人信息成功");
                tbname.ReadOnly = true;
                tbphone.ReadOnly = true;
                tbtitle.ReadOnly = true;
                textBox7.ReadOnly = true;
                tbemail.ReadOnly = true;

            }
            else
            {
                MessageBox.Show(INPUTNOEXIST, INPUTWARN, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //使用按钮点击事件进行跳转
        #region 跳转修改密码页面
        /// <summary>
        /// 跳转至修改密码页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Teacher f2 = new Teacher();
            //f2.ShowDialog();
            ChangePwd cp = new ChangePwd();
            cp.ShowDialog();
            this.Visible = true;
        } 
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //点击编辑按钮即可使各个textbox可以编辑
        private void button1_Click(object sender, EventArgs e)
        {
            tbname.ReadOnly = false;
            tbphone.ReadOnly = false;
            tbtitle.ReadOnly = false;
            textBox7.ReadOnly = false;
            tbemail.ReadOnly = false;


        }
    }
}
