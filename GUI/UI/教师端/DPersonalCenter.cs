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
        TeacherManager tm = new TeacherManager();

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
           
            string teaNo = LoginInterface.loginid;// 当前登录用户的账号
            #region 页面载入时显示此时登入账号的个人信息
            try
            {
                DataTable dt = tm.Getperson(teaNo);//参数是登录时输入的那个账号  要吧那个账号固定成一个常量
                tbno.Text = dt.Rows[0]["TeaNo"].ToString();
                tbname.Text = dt.Rows[0]["TeaName"].ToString();
                tbtitle.Text = dt.Rows[0]["Title"].ToString();
                tbphone.Text = dt.Rows[0]["Contaction"].ToString();
                tbsex.Text = dt.Rows[0]["Gender"].ToString();
                textBox4.Text = dt.Rows[0]["Profile"].ToString();
                textBox12.Text = teaNo;//验证使用登录窗体的用户账号输入框的内容
            }
            catch (Exception ex)
            {

                throw ex;
            } 
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

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
            tbno.ReadOnly = false;
            tbphone.ReadOnly = false;
            tbqq.ReadOnly = false;
            tbsex.ReadOnly = false;
            tbtitle.ReadOnly = false;
            tbemail.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;

        }
    }
}
