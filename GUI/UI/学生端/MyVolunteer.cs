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
        StudentManager sm = new StudentManager();
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
        };
        TeacherData teacher = new TeacherData();
        GroupTableData groupTable = new GroupTableData();
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
            if (sm.IsCreateGroup(student.StuNo))//判断学生是否组队
            {
                dataGridView1.DataSource = sm.CheckMyVol(student.StuNo);
                if (dataGridView1.Rows.Count<= 0)
                {
                    MessageBox.Show("你所在的小组还未提交志愿");
                }
                else
                {
                    GetVolSort();
                    GetVolStatus();
                }
            }
            else
            {
                MessageBox.Show("你还未组队");
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            teacher.TeaNo = dataGridView1["工号", 0].Value.ToString();
            if (e.ColumnIndex == dataGridView1.Columns["TeaName"].Index)
            {
                DPersonalInformationPreview dPersonalInformation = new DPersonalInformationPreview(teacher.TeaNo)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                //dPersonalInformation.teaNo = teacher.TeaNo;
                this.Controls.Clear();
                this.Controls.Add(dPersonalInformation);
                dPersonalInformation.Show();
            }
            /*else if (e.ColumnIndex == dataGridView1.Columns["Control"].Index)
            {
                MessageBox.Show("test");
            }*/
        }
        public void GetVolSort()
        {
            //志愿序号
            dataGridView1.Columns["VolFirstId"].Visible = false;
            dataGridView1.Columns["VolSecondId"].Visible = false;
            dataGridView1.Columns["VolThirdId"].Visible = false;
            groupTable.VolFirstId = dataGridView1["VolFirstId", 0].Value.ToString();
            groupTable.VolSecondId = dataGridView1["VolSecondId", 0].Value.ToString();
            groupTable.VolThirdId = dataGridView1["VolThirdId", 0].Value.ToString();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                teacher.TeaNo = dataGridView1["工号", i].Value.ToString();
                if (teacher.TeaNo == groupTable.VolFirstId)
                {
                    dataGridView1.Rows[i].Cells[7].Value = "第一志愿";
                }
                else if (teacher.TeaNo == groupTable.VolSecondId)
                {
                    dataGridView1.Rows[i].Cells[7].Value = "第二志愿";
                }
                else if (teacher.TeaNo == groupTable.VolThirdId)
                {
                    dataGridView1.Rows[i].Cells[7].Value = "第三志愿";
                }
            }
        }
        public void GetVolStatus()
        {
            //志愿状态
            DataTable dataTable1 = sm.MyMentor(student.StuNo);
            //MessageBox.Show(dataTable1.Rows.Count.ToString());
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                teacher.TeaNo = dataGridView1["工号", i].Value.ToString();//获取志愿列表里的导师工号
                if (dataTable1.Rows.Count != 0)
                {
                    string ReteaNo = dataTable1.Rows[0]["TeacherNo"].ToString();//获取结果表里的导师工号 
                    if (teacher.TeaNo == ReteaNo)
                    {
                        dataGridView1.Rows[i].Cells[8].Value = "已被录取";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[8].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[i].Cells[8].Value = "录取失败";
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells[8].Style.ForeColor = Color.YellowGreen;
                    dataGridView1.Rows[i].Cells[8].Value = "等待录取";
                }
            }
        }
    }
}
