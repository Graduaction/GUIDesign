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
    public partial class XPersonalCenter : Form
    {
        StudentManager sm = new StudentManager();
        StudentData student = new StudentData();
        public string stuNo = LoginInterface.loginid;

        public XPersonalCenter()
        {
            InitializeComponent();
        }

        private static XPersonalCenter formInstance;
        public static XPersonalCenter GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XPersonalCenter();
                    return formInstance;
                }
            }
        }
        private void XPersonalCenter_Load(object sender, EventArgs e)
        {
            DataTable dt = sm.GetStudentByNo(stuNo);
            TxtStuName.Text = dt.Rows[0]["StuName"].ToString();
            TxtStuNo.Text = dt.Rows[0]["StuNo"].ToString();
            TxtStuAcademy.Text = dt.Rows[0]["Academy"].ToString();
            TxtStuProfession.Text = dt.Rows[0]["Profession"].ToString();
            TxtStuGrade.Text = dt.Rows[0]["Grade"].ToString();
            TxtStuPhone.Text = dt.Rows[0]["StuPhone"].ToString();
            TxtStuQQ.Text = dt.Rows[0]["StuQQ"].ToString();
            TxtStuEmail.Text = dt.Rows[0]["StuEmail"].ToString();
            TxtStuNewPwd.Text = dt.Rows[0]["StuPwd"].ToString();
            TxtStuPerIntro.Text = dt.Rows[0]["StuPerIntro"].ToString();
            TxtStuHonors.Text = dt.Rows[0]["StuHonors"].ToString();
            string gender = dt.Rows[0]["Gender"].ToString();
            if(gender == "1")
            {
                TxtStuGender.Text = "男";
            }else if(gender =="0"){
                TxtStuGender.Text = "女";
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            student.StuPhone = TxtStuPhone.Text.Trim();
            student.StuQQ = TxtStuQQ.Text.Trim();
            student.StuEmail = TxtStuEmail.Text.Trim();
            student.StuPerIntro = TxtStuPerIntro.Text.Trim();
            student.StuHonors = TxtStuHonors.Text.Trim();
            student.StuNo = LoginInterface.loginid;
            if (sm.UpdateStu(student))
            {
                MessageBox.Show("修改个人信息成功");
            }
        }
    }
}
