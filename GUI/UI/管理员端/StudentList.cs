using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateStudentInformation frm = new UpdateStudentInformation();
            if (frm.ShowDialog() == DialogResult.OK)//对话框返回值为ok时运行
            {
                button6_Click(sender, e); //这个是当前页面的重新加载的查询事件
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudentInformation frm = new AddStudentInformation();
            if (frm.ShowDialog() == DialogResult.OK)//对话框返回值为ok时运行
            {
                button5_Click(sender, e); //这个是当前页面的重新加载的查询事件
            }
        }
    }
}
