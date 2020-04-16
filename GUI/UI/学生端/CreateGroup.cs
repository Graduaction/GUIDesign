using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
namespace GUI.UI.学生端
{
    public partial class CreateGroup : Form
    {
        string stuNo = "16209010016";
        StudentManager sm = new StudentManager();
        GroupTableData groupTable = new GroupTableData();
        GroupStuData groupStu = new GroupStuData();
        public CreateGroup()
        {
            InitializeComponent();
        }

        private void CreateGroup_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sm.CheckStuList();
            if (sm.IsCreateGroup(stuNo))
            {
                MessageBox.Show("你已组队，不能重复组队");
                DataTable dtCheck = sm.CheckGroupList(stuNo);
                dataGridView2.DataSource = dtCheck;//查看我的队伍
                groupTable.GroupID = Convert.ToInt32(dtCheck.Rows[0]["组号"]);//获取我的组号（已组队后获取）
                label1.Text = groupTable.GroupID.ToString();
            }
            else
            {
                MessageBox.Show("组队成功");
                DataTable dt = sm.CreateGroup(stuNo);
                dataGridView3.DataSource = dt;//查看组号，队长学号
                dataGridView2.DataSource = sm.CheckGroupList(stuNo);//查看我的队伍
                groupTable.GroupID = Convert.ToInt32(dt.Rows[0]["GroupID"]);//获取我的组号（组队时获取）
                label1.Text = groupTable.GroupID.ToString();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupStu.StuNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();//获取当前行的学号
            label2.Text = groupStu.StuNo;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = sm.SelectGroupStu(groupTable.GroupID, groupStu.StuNo);//选择队员并查看我的队伍
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = stuNo;
            dataGridView2.DataSource = sm.CheckGroupList(stuNo);//查看我的队伍
        }
    }
}
