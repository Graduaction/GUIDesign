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
    public partial class XTeacherList : Form
    {
        //string stuNo = "16209040087";
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
        };
        StudentManager sm = new StudentManager();
        public static string teaNo;
        GroupTableData groupTableData = new GroupTableData
        {
            GroupID = 28
        };
        public XTeacherList()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }
        private static XTeacherList formInstance;
        public static XTeacherList GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XTeacherList();
                    return formInstance;
                }
            }
        }
        private void XTeacherList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sm.StuCheckTeaList();
            DataTable dataTable = sm.CheckGroupList(student.StuNo);
            //groupTableData.GroupID =  
            //button1.Text = dataTable.Rows[0][0].ToString();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            teaNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (e.ColumnIndex == dataGridView1.Columns["TeaName"].Index)
            {
                string i = dataGridView1["TeaName", e.RowIndex].Value.ToString();
                MessageBox.Show(i);
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
                string j = dataGridView1["VolSort", e.RowIndex].Value.ToString();
                if (j == "第一志愿")
                {
                    groupTableData.VolFirstId = teaNo;
                }
                else if (j == "第二志愿")
                {
                    groupTableData.VolSecondeId = teaNo;
                }
                else if (j == "第三志愿")
                {
                    groupTableData.VolThirdId = teaNo;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Topic"].Index)
            {
                groupTableData.Topic = dataGridView1["Topic", e.RowIndex].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sm.SelectVol(groupTableData) > 0)
            {
                MessageBox.Show("提交志愿成功");
            }
        }
    }
}
