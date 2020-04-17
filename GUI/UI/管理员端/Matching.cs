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
    public partial class Matching : Form
    {
        public Matching()
        {
            InitializeComponent();
        }
        private static Matching formInstance;
        public static Matching GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Matching();
                    return formInstance;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Matching_Load(object sender, EventArgs e)//加载
        {
            ad_ServicesBLL servicesBLL = new ad_ServicesBLL();           
            studataGridView.DataSource = servicesBLL.stuGetmatchdata();
            teadataGridView.DataSource = servicesBLL.teaGetmatchdata();

        }

        private void btmatch_Click(object sender, EventArgs e)//一键匹配
        {
            ad_ServicesBLL bLL = new ad_ServicesBLL();           
           DialogResult dr= MessageBox.Show(bLL.match(),"提示",MessageBoxButtons.OKCancel);
            if(dr==DialogResult.OK)
            {
                //跳转页面

            }
            else
            {
                //
            }
            //获取学生的对象数组           
            sx_student[] sx_Students = new sx_student[50];
            sx_Students = Keepinformation.sx_Students;
            //获取教师的对象数组 
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            sx_Teachers = Keepinformation.sx_Teachers;

            //Random random = new Random();
            //int i = random.Next(0, sx_Students.Length);
            //Console.WriteLine(sx_Students[i].Groupid + sx_Students[i].Leaderno);

        }

        private void btreset_Click(object sender, EventArgs e)//重置
        {
            string deletesql = "truncate table result";
            string searchsql = "select * from result";
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if(bLL.SearchRs(searchsql))
            {
                int i = bLL.Tuncast_TBrs(deletesql);                
                if (i==-1)
                {                  
                    MessageBox.Show("重置成功", "提示");
                }
                else
                    MessageBox.Show("重置失败", "提示");
            }
            else
            {
                MessageBox.Show("请先提交数据", "提示");
            }           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
