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
           DialogResult dr= MessageBox.Show(Convert.ToString(bLL.match()),"提示",MessageBoxButtons.OKCancel);
            if(dr==DialogResult.OK)
            {
                //跳转页面

            }
            else
            {
                //
            }

            

        }

        private void btreset_Click(object sender, EventArgs e)//重置
        {
            
            MyLinkList<sx_student> myLinkLists = new MyLinkList<sx_student>();//它是一个链表类
            

           // LinkedList<sx_student> sx_Students = new LinkedList<sx_student>();
           // sx_student[] sx_Students = new sx_student[50];
            sx_student sx_Students1 = new sx_student(1);
            sx_Students1.Groupid = 5;
            sx_Students1.Leaderno = "16209010016";
            sx_Students1.Grade = 84;
            sx_Students1.Membernum = 6;
            sx_Students1.Stuname = "胡歌";            
            //sx_Students.AddLast(sx_Students1);
            myLinkLists.Append(sx_Students1);

            //sx_student sx_Students2 = new sx_student(1);
            //sx_Students[1].Groupid = 1;
            //sx_Students[1].Leaderno = "16209010001";
            //sx_Students[1].Grade = 82;
            //sx_Students[1].Membernum = 5;
            //sx_Students[1].Stuname = "小倩";          
          //  sx_Students.AddLast(sx_Students2);
            //myLinkLists.Append(sx_Students[1]);

            //sx_student sx_Student3 = new sx_student(1);
            //sx_Student3.Groupid = 3;
            //myLinkLists.Append(sx_Student3);
            Console.WriteLine(myLinkLists.GetLength());
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
