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
    public partial class DPersonalInformationPreview : Form
    {
        //常用定义
        public string teaNo = LoginInterface.loginid;// 当前登录用户的账号
        readonly TeacherManager tm = new TeacherManager();

        private static DPersonalInformationPreview formInstance;
        public static DPersonalInformationPreview GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DPersonalInformationPreview();
                    return formInstance;
                }
            }
        }
        public DPersonalInformationPreview()
        {
            InitializeComponent();
        }

        private void XPersonalInformationPreview_Load(object sender, EventArgs e)
        {
            //页面载入时显示当前账号的个人信息
            try
            {
                DataTable dt = tm.Getperson(teaNo);//参数是登录时输入的那个账号  要吧那个账号固定成一个常量
                lbname.Text = dt.Rows[0]["TeaName"].ToString();
                lbtitle.Text = dt.Rows[0]["Title"].ToString();
                lbgnum.Text = dt.Rows[0]["GroupNumber"].ToString();
                lbphone.Text = dt.Rows[0]["Contaction"].ToString();
                lbemail.Text = dt.Rows[0]["Email"].ToString();
                textBox1.Text = dt.Rows[0]["Profile"].ToString();
                string sex = dt.Rows[0]["Gender"].ToString();
                if (sex == "1")
                {
                    lbsex.Text = "男";
                }
                else if (sex == "0")
                {
                    lbsex.Text = "女";
                }
                else { lbsex.Text = ""; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
#pragma warning disable CS0169 // 从不使用字段“DPersonalInformationPreview.y”
        private int y;
#pragma warning restore CS0169 // 从不使用字段“DPersonalInformationPreview.y”
       
        private void XPersonalInformationPreview_Load(object sender, PaintEventArgs e)
        {
            

        }

        private void XPersonalInformationPreview_Load_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
