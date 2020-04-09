using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace GUI.UI
{
    public partial class CheckStudentsVolunteer : Form
    {
        //变量定义
        TeacherManager tm = new TeacherManager();
        public static string restu = null;//存储点击单元格返回的单元格内的数据

        private static CheckStudentsVolunteer formInstance;
        public static CheckStudentsVolunteer GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckStudentsVolunteer();
                    return formInstance;
                }
            }
        }
        public CheckStudentsVolunteer()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            DataTable dt = tm.selectStuVol();
            dataGridView1.DataSource = dt;
            //以下是针对datagridview的显示设置
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns[0].HeaderText = "组号";
            dataGridView1.Columns[1].HeaderText = "论文选题";
            dataGridView1.Columns[2].HeaderText = "组内平均综测成绩";
            dataGridView1.Columns[3].HeaderText = "第一志愿";
            dataGridView1.Columns[4].HeaderText = "第二志愿";
            dataGridView1.Columns[5].HeaderText = "第三志愿";
            dataGridView1.Columns[6].HeaderText = "操作";
            dataGridView1.Columns[7].HeaderText = "操作状态";
            dataGridView1.Columns[8].HeaderText = "组员1";
            dataGridView1.Columns[9].HeaderText = "组员2";
            dataGridView1.Columns[10].HeaderText = "组员3";
            dataGridView1.Columns[11].HeaderText = "组员4";
            dataGridView1.Columns[12].HeaderText = "组员5";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int CIndex = e.ColumnIndex;
                if (CIndex >= 6 && CIndex <= 10)
                {
                    //re=点击datagridview里组员1-5单元格，获取单元格其中的内容
                    restu = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //获取单元格内容中的数字
                    restu = System.Text.RegularExpressions.Regex.Replace(restu, @"[^0-9]+", "");
                    //要用这个带参数的构造函数，把教师查看学生这边获取的学生id传到学生信息页面
                    XPersonalInformationPreview formChild = new XPersonalInformationPreview(restu);
                    formChild.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
