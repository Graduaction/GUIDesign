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
    public partial class MatchingFailure : Form
    {
        public MatchingFailure()
        {
            InitializeComponent();
        }
        private static MatchingFailure formInstance;
        public static MatchingFailure GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MatchingFailure();
                    return formInstance;
                }
            }
        }
        private void MatchingFailure_Load(object sender, EventArgs e)
        {
            button1_Click(sender,e);
            button2_Click(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)//加载学生列表
        {
            //获取学生对象数组
            sx_student[] sx_Students = new sx_student[50];
            sx_Students = Keepinformation.sx_Students;
            //获取教师对象数组
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            sx_Teachers = Keepinformation.sx_Teachers;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("学生组号", typeof(string));
            dataTable.Columns.Add("组长姓名", typeof(string));
            dataTable.Columns.Add("论文课题", typeof(string));
            dataTable.Columns.Add("组内人数", typeof(int));
            dataTable.Columns.Add("志愿一", typeof(string));
            dataTable.Columns.Add("志愿二", typeof(string));
            dataTable.Columns.Add("志愿三", typeof(string));
            dataTable.Columns.Add("综测均分", typeof(double));
            //dataTable.Columns.Add("是否被选", typeof(string));
            if (sx_Students != null)
            {
                for (int i = 0; i < sx_Students.Length; i++)
                {
                    if (sx_Students[i] != null && sx_Students[i].Beixuan > 0)
                    {
                        continue;
                    }
                    // Console.WriteLine(sx_Students[i].Beixuan);

                    DataRow dataRow = dataTable.NewRow();
                    if (sx_Students[i] != null && sx_Students[i].Groupid != 0)
                    {
                        dataRow["学生组号"] = sx_Students[i].Groupid;
                    }
                    if (sx_Students[i] != null && sx_Students[i].Stuname != null)
                    {
                        dataRow["组长姓名"] = sx_Students[i].Stuname;
                    }
                    if (sx_Students[i] != null && sx_Students[i].Topic != null)
                    {
                        dataRow["论文课题"] = sx_Students[i].Topic;
                    }
                    if (sx_Students[i] != null && sx_Students[i].Membernum != 0)
                    {
                        dataRow["组内人数"] = sx_Students[i].Membernum;
                    }
                    if (sx_Students[i] != null && sx_Students[i].LoveTeacher[0] != null)
                    {
                        dataRow["志愿一"] = sx_Students[i].LoveTeacher[0];
                    }
                    if (sx_Students[i] != null && sx_Students[i].LoveTeacher[1] != null)
                    {
                        dataRow["志愿二"] = sx_Students[i].LoveTeacher[1];
                    }
                    if (sx_Students[i] != null && sx_Students[i].LoveTeacher[2] != null)
                    {
                        dataRow["志愿三"] = sx_Students[i].LoveTeacher[2];
                    }
                    if (sx_Students[i] != null && sx_Students[i].Grade != 0)
                    {
                        dataRow["综测均分"] = sx_Students[i].Grade;
                    }
                    dataTable.Rows.Add(dataRow);


                    //dataRow["是否被选"] = sx_Students[i].Beixuan > 0 ? "是" : "不是";

                }
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)//加载教师列表
        {
            //获取学生对象数组
            sx_student[] sx_Students = new sx_student[50];
            sx_Students = Keepinformation.sx_Students;
            //获取教师对象数组
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            sx_Teachers = Keepinformation.sx_Teachers;

            DataTable dataTable = new DataTable();            
            dataTable.Columns.Add("教师姓名", typeof(string));
            dataTable.Columns.Add("应带组数", typeof(int));
            dataTable.Columns.Add("已匹配组数", typeof(int));
            dataTable.Columns.Add("匹配组数一", typeof(string));
            dataTable.Columns.Add("匹配组数二", typeof(string));
            dataTable.Columns.Add("匹配组数三", typeof(string));
            dataTable.Columns.Add("匹配组数四", typeof(double));
            dataTable.Columns.Add("匹配组数五", typeof(double));
            //dataTable.Columns.Add("是否被选", typeof(string));
            if (sx_Teachers != null)
            {
                for (int i = 0; i < sx_Teachers.Length; i++)
                {
                    if (sx_Teachers[i] == null)
                    {
                        continue;
                    }                   
                    if(sx_Teachers[i].Groupnumber>sx_Teachers[i].LovestuList.GetLength())
                    {
                        DataRow dataRow = dataTable.NewRow();
                        if (sx_Teachers[i] != null && sx_Teachers[i].Teaname != null)
                        {
                            dataRow["教师姓名"] = sx_Teachers[i].Teaname;
                        }
                        if (sx_Teachers[i] != null && sx_Teachers[i].Groupnumber != 0)
                        {
                            dataRow["应带组数"] = sx_Teachers[i].Groupnumber;
                        }
                        if (sx_Teachers[i] != null && sx_Teachers[i].LovestuList.GetLength() != 0)
                        {
                            dataRow["已匹配组数"] = sx_Teachers[i].LovestuList.GetLength();
                        }
                        for (int j = 1; j <= sx_Teachers[i].LovestuList.GetLength(); j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    dataRow["匹配组数一"] = sx_Teachers[i].LovestuList.GetElem(j).Groupid;
                                    break;
                                case 2:
                                    dataRow["匹配组数二"] = sx_Teachers[i].LovestuList.GetElem(j).Groupid;
                                    break;
                                case 3:
                                    dataRow["匹配组数三"] = sx_Teachers[i].LovestuList.GetElem(j).Groupid;
                                    break;
                                case 4:
                                    dataRow["匹配组数四"] = sx_Teachers[i].LovestuList.GetElem(j).Groupid;
                                    break;
                                case 5:
                                    dataRow["匹配组数五"] = sx_Teachers[i].LovestuList.GetElem(j).Groupid;
                                    break;
                            }

                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    


                    //dataRow["是否被选"] = sx_Students[i].Beixuan > 0 ? "是" : "不是";

                }
                dataGridView2.DataSource = dataTable;
            }
        }
    }

}
    

