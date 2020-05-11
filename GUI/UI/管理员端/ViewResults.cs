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
    public partial class ViewResults : Form
    {
        public ViewResults()
        {
            InitializeComponent();
        }
        private static ViewResults formInstance;
        public static ViewResults GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new ViewResults();
                    return formInstance;
                }
            }
        }
        //加载一轮匹配结果
        private void jiazaiyilun()
        {
            //加载一轮匹配结果
            sx_student[] sx_Students = new sx_student[100];
            sx_Students = Keepinformation.sx_Students;
            sx_teacher[] sx_Teachers = new sx_teacher[100];
            sx_Teachers = Keepinformation.sx_Teachers;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("教师工号", typeof(string));
            dataTable.Columns.Add("教师姓名", typeof(string));
            dataTable.Columns.Add("学生组号", typeof(int));
            dataTable.Columns.Add("组长姓名", typeof(string));
            dataTable.Columns.Add("组长学号", typeof(string));
            dataTable.Columns.Add("论文课题", typeof(string));
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];//声明了一个datacolumn的数组，该数组只有一个元素 
            PrimaryKeyColumns[0] = dataTable.Columns["学生组号"];//把主键列赋给数组元素 
            dataTable.PrimaryKey = PrimaryKeyColumns;//指定表的主键为PrimaryKeyColumns主键数组 
            if (sx_Teachers != null)
            {
                foreach (sx_teacher sx in sx_Teachers)
                {
                    if (sx != null)
                    {
                        
                            for (int i = 1; i <= sx.LovestuList.GetLength(); i++)
                            {
                            try
                            {
                                DataRow dataRow = dataTable.NewRow();
                                dataRow["教师工号"] = sx.Teano;
                                dataRow["教师姓名"] = sx.Teaname;
                                dataRow["学生组号"] = sx.LovestuList.GetElem(i).Groupid;
                                dataRow["组长姓名"] = sx.LovestuList.GetElem(i).Stuname;
                                dataRow["组长学号"] = sx.LovestuList.GetElem(i).Leaderno;
                                dataRow["论文课题"] = sx.LovestuList.GetElem(i).Topic;
                                dataTable.Rows.Add(dataRow);
                                Console.WriteLine(dataRow["教师姓名"].ToString());
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                            }
                        }
                            dataGridView1.DataSource = dataTable;
                        
                    }
                }
            }
        }

        //加载二轮匹配结果
        private void jiazaierlun()
        {
            //加载二轮匹配结果
            sx_student[] sx_Students = new sx_student[50];
            sx_Students = Keepinformation.stsx_Students;
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            sx_Teachers = Keepinformation.stsx_Teachers;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("教师工号", typeof(string));
            dataTable.Columns.Add("教师姓名", typeof(string));
            dataTable.Columns.Add("学生组号", typeof(int));
            dataTable.Columns.Add("组长姓名", typeof(string));
            dataTable.Columns.Add("组长学号", typeof(string));
            dataTable.Columns.Add("论文课题", typeof(string));
            if (sx_Teachers != null)
            {
                foreach (sx_teacher sx in sx_Teachers)
                {
                    if (sx != null)
                    {
                        for (int i = 1; i <= sx.LovestuList.GetLength(); i++)
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow["教师工号"] = sx.Teano;
                            dataRow["教师姓名"] = sx.Teaname;
                            dataRow["学生组号"] = sx.LovestuList.GetElem(i).Groupid;
                            dataRow["组长姓名"] = sx.LovestuList.GetElem(i).Stuname;
                            dataRow["组长学号"] = sx.LovestuList.GetElem(i).Leaderno;
                            dataRow["论文课题"] = sx.LovestuList.GetElem(i).Topic;
                            dataTable.Rows.Add(dataRow);
                            //Console.WriteLine(dataRow["教师姓名"].ToString());
                        }
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//导出
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//加载全部结果页面
        {
            dataGridView1.DataSource = null;
            //加载全部匹配结果
            ad_ServicesBLL servicesBLL = new ad_ServicesBLL();
            dataGridView2.DataSource=servicesBLL.SelectFromResuit();
        }

        private void button3_Click(object sender, EventArgs e)//提交结果
        {
            DataTable dataTable = new DataTable();
            dataTable = (DataTable)this.dataGridView1.DataSource;//获取datagridview的数据
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            bLL.InsertToResult(dataTable);
            button2_Click(sender, e);
            bLL.Tuncast_TBrs("truncate table teavolheng2");

        }

        private void button4_Click(object sender, EventArgs e)//重置结果
        {
            string deletesql = "truncate table result";
            string searchsql = "select * from result";
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if (bLL.SearchRs(searchsql))
            {
                int i = bLL.Tuncast_TBrs(deletesql);
                if (i == -1)
                {
                    button2_Click(sender, e);
                    MessageBox.Show("重置成功", "提示");
                }
                else
                    MessageBox.Show("重置失败", "提示");
            }
            else
            {
                button2_Click(sender, e);
                MessageBox.Show("请先提交数据", "提示");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)//加载二轮界面
        {
            jiazaierlun();
        }

        private void button6_Click(object sender, EventArgs e)//加载一轮界面
        {
            jiazaiyilun();
        }
    }
}
