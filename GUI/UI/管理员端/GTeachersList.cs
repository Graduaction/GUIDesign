using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace GUI.UI
{
    public partial class TeachersList : Form
    {
        public bool formSwitchFlag = false;
        public object lockObj = new object();
        public static AddTeacherInformation form1 = null;

        private static TeachersList formInstance;
        public static TeachersList GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new TeachersList();
                    return formInstance;
                }
            }
        }
        public TeachersList()
        {
            InitializeComponent();
            form1 = AddTeacherInformation.GetIntance;

        }
        //public void ShowForm(System.Windows.Forms.Panel panel, System.Windows.Forms.Form frm)
        //{
        //    lock (this)
        //    {
        //        try
        //        {
        //            if (this.currentForm != null && this.currentForm == frm)
        //            {
        //                return;
        //            }
        //            else if (this.currentForm != null)
        //            {
        //                if (this.ActiveMdiChild != null)
        //                {
        //                    this.ActiveMdiChild.Hide();
        //                }
        //            }
        //            this.currentForm = frm;
        //            frm.TopLevel = false;
        //            frm.MdiParent = this;
        //            panel.Controls.Clear();
        //            panel.Controls.Add(frm);
        //            frm.Show();
        //            frm.Dock = System.Windows.Forms.DockStyle.Fill;
        //            this.Refresh();
        //            foreach (Control item in frm.Controls)
        //            {
        //                item.Focus();
        //                break;
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            //
        //        }
        //    }
        //}

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

        private void Form1_Load(object sender, EventArgs e)
        {
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            Teagridview.DataSource = bLL.SelectTeabll();
        }

        private void button5_Click(object sender, EventArgs e)//删除
        {
            string teano = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[0].Value.ToString();
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if (bLL.RemoveTeadata(teano))
            {
                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
                ad_ServicesBLL BLL = new ad_ServicesBLL();
                DataTable table = BLL.SelectTeabll();
                Teagridview.DataSource = table;
            }
            else
            {
                MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)//导出
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
            for (int i = 0; i < Teagridview.ColumnCount; i++)
            { worksheet.Cells[1, i + 1] = Teagridview.Columns[i].HeaderText; }
            //写入数值
            for (int r = 0; r < Teagridview.Rows.Count; r++)
            {
                for (int i = 0; i < Teagridview.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = Teagridview.Rows[r].Cells[i].Value;
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

        private void button7_Click_1(object sender, EventArgs e)//修改
        {
            tbteano.Text = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[0].Value.ToString();
           tbteapwd.Text = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[4].Value.ToString();
            tbteaname.Text = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[1].Value.ToString();
            tbacademy.Text = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[2].Value.ToString();
            tbgroupnumber.Text = Teagridview.Rows[Teagridview.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void button8_Click_1(object sender, EventArgs e)//确认修改
        {
            TeacherData teacherData = new TeacherData();
            teacherData.TeaNo = tbteano.Text.Trim();
            teacherData.TeaPwd = tbteapwd.Text.Trim();
            teacherData.TeaName = tbteaname.Text.Trim();
            teacherData.Academy = tbacademy.Text.Trim();
            teacherData.GroupNumber = Convert.ToInt32(tbgroupnumber.Text.Trim());
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            if (BLL.UpdateTeadatabll(teacherData) > 0)
            {
                MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK);
                tbteano.Text = "";
                tbteapwd.Text = "";
                tbteaname.Text = "";
                tbacademy.Text = "";
                tbgroupnumber.Text = "";
                DataTable table = BLL.SelectTeabll();
                Teagridview.DataSource = table;
            }
            else
            {
                MessageBox.Show("更新失败", "提示", MessageBoxButtons.OKCancel);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)//确认添加
        {
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            TeacherData teacherData = new TeacherData();
            teacherData.TeaNo = tbteano.Text.Trim();
            teacherData.TeaPwd = tbteapwd.Text.Trim();
            teacherData.TeaName = tbteaname.Text.Trim();
            teacherData.Academy = tbacademy.Text.Trim();
            teacherData.GroupNumber = Convert.ToInt32(tbgroupnumber.Text.Trim());
            if (BLL.InsertTeabll(teacherData))
            {
                MessageBox.Show("导入成功", "提示", MessageBoxButtons.OK);
                tbteano.Text = "";
                tbteapwd.Text = "";
                tbteaname.Text = "";
                tbacademy.Text = "";
                tbgroupnumber.Text = "";
                DataTable table = BLL.SelectTeabll();
                Teagridview.DataSource = table;
            }
            else
            {
                MessageBox.Show("导入失败", "提示", MessageBoxButtons.OKCancel);
            }
        }

        private void button1_Click(object sender, EventArgs e)//导入
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "XLSX 工作表 (*.xlsx)|*.xlsx|Excel表（*.xls）|*.xls";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                textBox1.Text = fileName;
                ad_ServicesBLL bLL = new ad_ServicesBLL();
                DataTable dataTable = bLL.importToExcel(fileName);
                bLL.DataTableToTeaSQLServerbll(dataTable);
                Teagridview.DataSource = dataTable;
            }
        }
    }
}
