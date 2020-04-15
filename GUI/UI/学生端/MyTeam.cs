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
    public partial class MyTeam : Form
    {
        //string stuNo = "16209040087";
        StudentData student =new StudentData() {
            StuNo = LoginInterface.loginid
        };
        StudentManager sm = new StudentManager();
        GroupTableData groupTable = new GroupTableData();
        GroupStuData groupStu = new GroupStuData();
        public MyTeam()
        {
            InitializeComponent();
        }
        private static MyTeam formInstance;
        public static MyTeam GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyTeam();
                    return formInstance;
                }
            }
        }

        private void Form33_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = sm.CheckStuList();
            dataGridView1.DataSource = sm.CheckGroupList(student.StuNo); //查看我的队伍
            if (sm.IsCreateGroup(student.StuNo))
            {
                textBox1.Text = dataGridView1["姓名", 0].Value.ToString();//获取队长姓名
                groupTable.GroupID = Convert.ToInt32(dataGridView1["组号", 0].Value);//获取组号
            }
            else
            {
                textBox1.Text = " ";
            }
        }
       /* private void showGridView()
        {
            DataGridTextBoxColumn tb = new DataGridTextBoxColumn();
            dataGridView2.Rows.Add(tb);
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            dataGridView2.Rows[dataGridView2.RowCount - 2].Cells[i].Value = a[i];
            //根据AllowUserToAddRow属性选择最后一行，true时dataGridView1.RowCount-2,false时dataGridView1.RowCount-1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showGridView();
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            if (sm.IsCreateGroup(student.StuNo))
            {
                MessageBox.Show("你已组队，不能重复组队");
            }
            else
            {
                MessageBox.Show("组队成功");
                sm.CreateGroup(student.StuNo);
                dataGridView1.DataSource = sm.CheckGroupList(student.StuNo); //查看我的队伍
                textBox1.Text = dataGridView1["姓名", 0].Value.ToString();//获取队长姓名
                groupTable.GroupID = Convert.ToInt32(dataGridView1["组号", 0].Value);//获取组号
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupStu.StuNo = dataGridView1.CurrentRow.Cells[1].Value.ToString();//获取当前行的学号
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupStu.StuNo = dataGridView2.CurrentRow.Cells[0].Value.ToString();//获取当前行的学号
            button1.Text = groupStu.StuNo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (sm.IsCreateGroup(student.StuNo))
            {
                dataGridView1.DataSource = sm.SelectGroupStu(groupTable.GroupID, groupStu.StuNo);//选择队员并查看我的队伍
            }
            else
            {
                MessageBox.Show("你还未组队，请组队后再操作");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sm.IsCreateGroup(student.StuNo))
            {
                //groupStu.StuNo = dataGridView1["学号", 0].Value.ToString();
               // MessageBox.Show(groupStu.StuNo);
                dataGridView1.DataSource = sm.DelGroupStu(groupTable.GroupID, groupStu.StuNo);//删除队员并查看我的队伍
            }
            else
            {
                MessageBox.Show("你还未组队，请组队后再操作");
            }
        }

    }
}
