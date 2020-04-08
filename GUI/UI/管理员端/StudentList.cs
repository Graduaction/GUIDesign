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
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.Util;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;

namespace GUI.UI
{
    public partial class StudentList : Form
    {
        private static StudentList formInstance;
        public static StudentList GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new StudentList();
                    return formInstance;
                }
            }
        }
        public StudentList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            DataTable studentTable = BLL.SelectStubll();
            dataGridView1.DataSource = studentTable;
            textBox5.Text = "2016";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//添加单个信息
        {
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            StudentData studentData = new StudentData();
            studentData.StuNo = textBox2.Text;
            studentData.StuPwd = textBox3.Text;
            studentData.StuName = textBox4.Text;
            studentData.StuNianji = textBox5.Text;
            studentData.Academy = textBox6.Text;
            studentData.Profession = textBox6.Text;
            studentData.StuClass = Convert.ToInt32(textBox8.Text);
            studentData.Grade = Convert.ToInt32(textBox9.Text);
            //if (BLL.Check(studentData.StuNo))//true代表数据库中已有该值
            //{
            //    MessageBox.Show("该学号已存在，不可重复录入", "警示", MessageBoxButtons.OK);
            //}
            //else
            //{
                if (BLL.InsertStubll(studentData))
                {
                    MessageBox.Show("导入成功", "提示", MessageBoxButtons.OK);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    DataTable table = BLL.SelectStubll();
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("导入失败", "提示", MessageBoxButtons.OKCancel);
                }
            //}

        }
       

        private void button8_Click(object sender, EventArgs e)//修改
        {
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)//确认修改
        {
            StudentData studentData = new StudentData();
            studentData.StuNo = textBox2.Text;
            studentData.StuPwd = textBox3.Text;
            studentData.StuName = textBox4.Text;
            studentData.StuNianji = textBox5.Text;
            studentData.Academy = textBox6.Text;
            studentData.Profession = textBox7.Text;
            studentData.StuClass = Convert.ToInt32(textBox8.Text);
            studentData.Grade = Convert.ToInt32(textBox9.Text);
            
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            if (BLL.UpdateStudatabll(studentData) > 0)
            {
                MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "2016";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                DataTable table = BLL.SelectStubll();
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("更新失败", "提示", MessageBoxButtons.OKCancel);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)//删除
        {
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if (bLL.RemoveStudata(id))
            {
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
                ad_ServicesBLL BLL = new ad_ServicesBLL();
                DataTable table = BLL.SelectStubll();
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)//导出到excel
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp =
                                new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            //写入标题             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < dataGridView1.Rows.Count; r++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁 
        }

        private void button1_Click(object sender, EventArgs e)//浏览
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "XLSX 工作表 (*.xlsx)|*.xlsx|Excel表（*.xls）|*.xls";            
            if(open.ShowDialog()==DialogResult.OK)
            {
                string fileName = open.FileName;
                textBox1.Text = fileName;
                ad_ServicesBLL bLL = new ad_ServicesBLL();
                //  string sql = "select * from Student";
                DataTable dataTable = bLL.importToExcel(fileName);
                bLL.DataTableToStuSQLServerbll(dataTable);
                dataGridView1.DataSource = bLL.importToExcel(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)//提交
        {
            //try
            //{
            //    sda.Update(dt);
            //    MessageBox.Show("提交成功");
            //    txtFilePath.Text = "";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
