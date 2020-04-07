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
    public partial class DCheckNotification : Form
    {
        //变量定义
        public static string infono = null;//某行的通知序号标志
        private static DCheckNotification formInstance;
        public static DCheckNotification GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DCheckNotification();
                    return formInstance;
                }
            }
        }
        public DCheckNotification()
        {
            InitializeComponent();
        }

        private void DCheckNotification_Load(object sender, EventArgs e)
        {

            #region 通知页面显示通知表 通知标题等
            TeacherManager tm = new TeacherManager();
            DataTable notetable = tm.selectNote();
            dataGridView1.DataSource = notetable;
            //以下是针对datagridview的显示设置
            dataGridView1.Columns[1].Width = 400;//通知标题宽度加大
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            #endregion

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击任意单元格，选中该行一整行
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //单击任意单元格，选中该行，获取该行中的序号列的内容
           infono = this.dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            //MessageBox.Show(infono);//测试有没有获取到这个值

            #region 跳转到通知详细页面  可能双击事件更好
            this.Visible = false;
            NoticeDetails nd = new NoticeDetails();
            nd.ShowDialog();
            this.Visible = true; 
            #endregion
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 跳转到通知详细页面  
            this.Visible = false;
            NoticeDetails nd = new NoticeDetails();
            nd.ShowDialog();
            this.Visible = true;
            #endregion
        }
    }
}
