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
        private StudentManager sm = new StudentManager();
        public static string teaNo;
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
            DataTable dataTable = sm.StuCheckTeaList();
            dataGridView1.DataSource = dataTable;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[1].Name == "导师姓名")
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                teaNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                CheckMentor checkMentor = new CheckMentor
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
            };
                checkMentor.teaNo = teaNo;
                this.Controls.Clear();
                this.Controls.Add(checkMentor);
                checkMentor.Show();
            }
        }
    }
}
