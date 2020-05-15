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
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
        };
        private string stu_no;//学生列表当前行的学生学号
        StudentManager sm = new StudentManager();
        GroupTableData groupTable = new GroupTableData();
        GroupStuData groupStu = new GroupStuData();
        DataTable dt = new DataTable();
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
            dt = sm.CheckStuList();
            dataGridView2.DataSource = dt;
            if (sm.IsCreateGroup(student.StuNo))//判断学生是否组队
            {
                dataGridView1.DataSource = sm.CheckGroupList(student.StuNo); //查看我的队伍
                groupTable.GroupID = Convert.ToInt32(dataGridView1["组号", 0].Value);//获取组号
                groupTable.Leaderno = dataGridView1["学号", 0].Value.ToString();//获取队长学号
                //判断该学生是否组队，若true则显示队长姓名
                textBox1.Text = dataGridView1["姓名", 0].Value.ToString();//获取队长姓名
                if (!sm.IsLeader(student.StuNo))
                {
                    //判断是否为队长，是则可以选择/删除队员
                    button1.Enabled = false;
                    button3.Enabled = false;
                    label3.Visible = true;
                    label3.Text = "*你无法选择/删除队员，请联系队长操作";
                }
            }
            else
            {
                //若false队长姓名为空，你需要进行组队才能显示队伍信息
                textBox1.Text = " ";
                label2.Visible = true;
                label2.Text = "*你还未组队，请先组队";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //组队
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
            //队伍列表
            groupStu.StuNo = dataGridView1.CurrentRow.Cells[1].Value.ToString();//获取当前行的组员学号
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //学生列表
            stu_no = dataGridView2.CurrentRow.Cells[0].Value.ToString();//获取当前行的学生学号
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //选择队员
            if (sm.IsCreateGroup(student.StuNo))//判断自己是否组队
            {
                try
                {
                    if (!sm.IsCreateGroup(stu_no))//判断当前行的学生是否组队
                    {
                        dataGridView1.DataSource = sm.SelectGroupStu(groupTable.GroupID, stu_no);//选择队员并查看我的队伍
                    }
                    else
                    {
                        MessageBox.Show("该学生已组队，无法选择为组员","错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
                catch (Exception)
                {
                    MessageBox.Show("请在学生列表选择", "操作失误", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("你还未组队，请组队后再操作", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //删除队员
            if (sm.IsCreateGroup(student.StuNo))
            {
                try
                {
                    dataGridView1.DataSource = sm.DelGroupStu(groupTable.GroupID, groupStu.StuNo);//删除队员并查看我的队伍
                }
                catch (Exception)
                {
                    MessageBox.Show("请在队伍列表选择", "操作失误", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("你还未组队，请组队后再操作");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "请输入姓名")
            {
                dt.DefaultView.RowFilter = string.Format("姓名 LIKE '%{0}%'", textBox2.Text);//模糊查询
            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "请输入姓名")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Blue;
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "请输入姓名";
                textBox2.ForeColor = Color.Silver;
            }
        }
    }
}
