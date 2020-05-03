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
    public partial class CheckMentor : Form
    {
        private readonly StudentManager sm = new StudentManager();
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
            //StuNo = "16209010016"
        };
        public string teaNo;
        public CheckMentor()
        {
            InitializeComponent();
        }
        private static CheckMentor formInstance;

        public static CheckMentor GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckMentor();
                    return formInstance;
                }
            }
        }
        private void CheckMentor_Load(object sender, EventArgs e)
        {
            DataTable dataTable1 = sm.MyMentor(student.StuNo);
            if (dataTable1.Rows.Count != 0)
            {
                teaNo = dataTable1.Rows[0]["TeacherNo"].ToString();
                DataTable dataTable = sm.CheckMentorByNo(teaNo);
                LbTeaName.Text = dataTable.Rows[0]["TeaName"].ToString();
                LbTeaTitle.Text = dataTable.Rows[0]["Title"].ToString();
                LbTeaProfile.Text = dataTable.Rows[0]["Profile"].ToString();
                LbTeaContaction.Text = dataTable.Rows[0]["Contaction"].ToString();
                LbTeaAcademy.Text = dataTable.Rows[0]["Academy"].ToString();
                LbTeaEmail.Text = dataTable.Rows[0]["Email"].ToString();
                string gender = dataTable.Rows[0]["Gender"].ToString();
                if (gender == "1")
                {
                    LbTeaGender.Text = "男";
                }
                else if (gender == "0")
                {
                    LbTeaGender.Text = "女";
                }
            }
            else
            {
                panel2.Visible = false;
                label3.Text = "你的心仪导师还未公布";
            }
        }
    }
}
