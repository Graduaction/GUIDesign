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
using System.Threading;

namespace GUI.UI
{
    public partial class MyStudents : Form
    {
        //变量定义
        TeacherManager tm = new TeacherManager();
        public string teaNo = LoginInterface.loginid;// 当前登录用户的账号  非常重要
       public static  string restu = null;//存储点击单元格返回的单元格内的数据
        private static MyStudents formInstance;
        public static MyStudents GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyStudents();
                    return formInstance;
                }
            }
        }
        public MyStudents()
        {
            InitializeComponent();
        }

        private void MyStudents_Load(object sender, EventArgs e)
        {
            #region 页面载入时显示当前登录账号的所带学生
            DataTable dt = tm.selectMyStu(teaNo);
            dataGridView1.DataSource = dt;
            //以下是针对datagridview的显示设置
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns[0].HeaderText = "组号";
            dataGridView1.Columns[1].HeaderText = "组员一";
            dataGridView1.Columns[2].HeaderText = "组员二";
            dataGridView1.Columns[3].HeaderText = "组员三";
            dataGridView1.Columns[4].HeaderText = "组员四";
            dataGridView1.Columns[5].HeaderText = "组员五";
            dataGridView1.Columns[6].HeaderText = "组长联系方式";
            dataGridView1.Columns[7].HeaderText = "论文预选题目";
            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////re=点击datagridview里任意单元格，获取单元格其中的内容
            //restu=dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            ////获取单元格内容中的数字
            //restu = System.Text.RegularExpressions.Regex.Replace(restu, @"[^0-9]+", "");
            ////MessageBox.Show(restu);
            ////要用这个带参数的构造函数，把教师查看学生这边获取的学生id传到学生信息页面
            //    PersonalInformationPreview formChild = new PersonalInformationPreview(restu);
            //    formChild.ShowDialog();
        }
        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int CIndex = e.ColumnIndex;
                if (CIndex >= 1 && CIndex <= 5)
                {
                    //re=点击datagridview里组员1-5单元格，获取单元格其中的内容
                    restu = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //获取单元格内容中的数字
                    restu = System.Text.RegularExpressions.Regex.Replace(restu, @"[^0-9]+", "");
                    //要用这个带参数的构造函数，把教师查看学生这边获取的学生id传到学生信息页面
                    XPersonalInformationPreview cform = new XPersonalInformationPreview();//实例化一个子窗口
                                                                                          //设置子窗口不显示为顶级窗口
                    cform.TopLevel = false;
                    //设置子窗口的样式，没有上面的标题栏
                    cform.FormBorderStyle = FormBorderStyle.None;
                    //填充
                    cform.Dock = DockStyle.Fill;
                    //清空控件
                    this.Controls.Clear();
                    //加入控件
                    this.Controls.Add(cform);
                    cform.Show();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
