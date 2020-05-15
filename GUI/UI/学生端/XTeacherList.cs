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
        StudentManager sm = new StudentManager();
        StudentData student = new StudentData()
        {
            StuNo = LoginInterface.loginid
        };
        GroupTableData groupTableData = new GroupTableData();
        TeacherData teacher = new TeacherData();
        public XTeacherList()
        {
            InitializeComponent();
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
            dataGridView1.DataSource = sm.StuCheckTeaList();
            if (!sm.IsCreateGroup(student.StuNo))
            {
                groupBox2.Enabled = false;
                label11.Text = "*请先组队后再进行志愿填报";
            }
            else if (!sm.IsLeader(student.StuNo))
            {
                groupBox2.Enabled = false; 
                label11.Text = "*请联系队长填报志愿";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任意单元格选中该行一整行
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacher.TeaNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();//获取当前行的导师工号
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["导师姓名"].Index)
            {
                //点击导师姓名查看导师信息
                DPersonalInformationPreview dPersonalInformation = new DPersonalInformationPreview(teacher.TeaNo)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                //dPersonalInformation.teaNo = teacher.TeaNo;
                this.Controls.Clear();
                this.Controls.Add(dPersonalInformation);
                dPersonalInformation.Show();
            }
        }

        private void BtnVolFirst_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请在教师表选择一行", "操作失误", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                TxtVolFirst.Text = teacher.TeaNo;
            }
        }

        private void BtnVolSecond_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请在教师表选择一行", "操作失误", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                TxtVolSecond.Text = teacher.TeaNo;
            }
        }

        private void BtnVolThird_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请在教师表选择一行", "操作失误", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                TxtVolThird.Text = teacher.TeaNo;
            }
        }
        public bool InputEmpty()
        {
            if (this.TxtVolFirst.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整", "非空验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TxtVolFirst.Focus();
                return false;
            }
            if (this.TxtVolSecond.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整", "非空验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TxtVolSecond.Focus();
                return false;
            }
            if (this.TxtVolThird.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整", "非空验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TxtVolThird.Focus();
                return false;
            }
            if (this.TxtTopic.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整", "非空验证", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TxtTopic.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                groupTableData.VolFirstId = this.TxtVolFirst.Text.Trim();
                groupTableData.VolSecondId = this.TxtVolSecond.Text.Trim();
                groupTableData.VolThirdId = this.TxtVolThird.Text.Trim();
                groupTableData.Topic = this.TxtTopic.Text.Trim();
                groupTableData.Leaderno = student.StuNo;
                if (InputEmpty())
                {
                    if (sm.SelectVol(groupTableData) > 0)
                    {
                        MessageBox.Show("提交志愿成功");
                    }
                    else
                    {
                        MessageBox.Show("提交志愿失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
