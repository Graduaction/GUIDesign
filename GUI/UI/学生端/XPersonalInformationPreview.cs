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
    public partial class PersonalInformationPreview : Form
    {
        StudentManager sm = new StudentManager();
        StudentData student = new StudentData();
        public string stuNo = LoginInterface.loginid;
        public PersonalInformationPreview()
        {
            InitializeComponent();
        }
        private static PersonalInformationPreview formInstance;
        public static PersonalInformationPreview GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new PersonalInformationPreview();
                    return formInstance;
                }
            }
        }
        private void Form21_Load(object sender, EventArgs e)
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
    }
}
