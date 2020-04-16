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
    public partial class MyVolunteer : Form
    {
        //string stuNo = "16209040087";
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
        };
        public static string teaNo;
        StudentManager sm = new StudentManager();
        public MyVolunteer()
        {
            InitializeComponent();
        }
        private static MyVolunteer formInstance;
        public static MyVolunteer GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyVolunteer();
                    return formInstance;
                }
            }
        }
        private void MyVolunteer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sm.CheckMyVol(student.StuNo);
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            teaNo = dataGridView1["工号", 0].Value.ToString();
            if (e.ColumnIndex == dataGridView1.Columns["TeaName"].Index)
            {
                DPersonalInformationPreview dPersonalInformation = new DPersonalInformationPreview()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                dPersonalInformation.teaNo = teaNo;
                this.Controls.Clear();
                this.Controls.Add(dPersonalInformation);
                dPersonalInformation.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Control"].Index)
            {
                MessageBox.Show("test");
            }
        }
    }
}
