using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class XPersonalInformationPreview : Form
    {
        private StudentManager sm = new StudentManager();
        private StudentData student = new StudentData();
        public string stuNo = LoginInterface.loginid;
        public XPersonalInformationPreview()
        {
            InitializeComponent();
        }
        public XPersonalInformationPreview(string re)
        {
            InitializeComponent();
            stuNo = re;
        }
        private static XPersonalInformationPreview formInstance;
        public static XPersonalInformationPreview GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XPersonalInformationPreview();
                    return formInstance;
                }
            }
        }
        private void Form21_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = sm.GetStudentByNo(stuNo);
                LbStuName.Text = dt.Rows[0]["StuName"].ToString();
                LbStuProfession.Text = dt.Rows[0]["Profession"].ToString();
                LbStuPhone.Text = dt.Rows[0]["StuPhone"].ToString();
                LbStuQQ.Text = dt.Rows[0]["StuQQ"].ToString();
                LbStuEmail.Text = dt.Rows[0]["StuEmail"].ToString();
                TxtStuPerIntro.Text = dt.Rows[0]["StuPerIntro"].ToString();
                TxtStuHonors.Text = dt.Rows[0]["StuHonors"].ToString();
                string gender = dt.Rows[0]["Gender"].ToString();
                if (gender == "1")
                {
                    LbStuGender.Text = "男";
                }
                else if (gender == "0")
                {
                    LbStuGender.Text = "女";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
