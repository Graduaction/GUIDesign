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
    public partial class CheckStudentsVolunteer2 : Form
    {
        //变量定义
        TeacherManager tm = new TeacherManager();
        public string teaNo = LoginInterface.loginid;// 当前登录用户的账号  非常重要
       // public string teaNo = "10011";
        public static string restuno = null;//存储点击单元格返回的单元格内的数据
        public static string regroupid = null;//存储点击单元格返回的单元格内的数据
        public DataTable dtshu = new DataTable();//暂存教师志愿的datatable  纵向的暂时存储，然后在提交按钮的时候在转化成横向
        public DataTable dtheng = new DataTable();
        public DataTable dtStuvol2 = new DataTable();
        public CheckStudentsVolunteer2()
        {
            InitializeComponent();
        }

        private void Form35_Load(object sender, EventArgs e)
        {
            ///判断当前是一轮还是二轮  如果result表没有数据，说明没有一轮匹配，说明不能进入二轮
            dtStuvol2 = tm.selectlxStu();//页面载入时从数据库获取当前数据库中的所有学生志愿数据并显示在datagridview1中
            dataGridView1.DataSource = dtStuvol2;
            dtheng = tm.dtTeaVol2(teaNo);//页面载入时从数据库获取当前数据库中的当前教师工号的志愿数据
            if (dtheng.Rows.Count == 0)
            {
                dtshu.Columns.Add("Teano", typeof(string));
                dtshu.Columns.Add("Groupid", typeof(string));
                //设置dtshu的主键，控制不要同一个组插入多次竖向datatable
                dtshu.PrimaryKey = new DataColumn[2] { dtshu.Columns["Teano"], dtshu.Columns["Groupid"] };
                //设置dtheng的主键 
                dtheng.PrimaryKey = new DataColumn[1] { dtheng.Columns["teano"] };
                //以下是针对datagridview的显示设置
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//标题居中
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
            }
            if (dtheng.Rows.Count > 0)
            {
                MessageBox.Show("您已提交选择，您的二轮选择为" + dtheng.Rows[0][2] + "--" + dtheng.Rows[0][3] + "--" + dtheng.Rows[0][4] + "--" + dtheng.Rows[0][5] + "--" + dtheng.Rows[0][6] + "--");
                button1.Enabled = false;
                //dataGridView1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult mresult;
            mresult = MessageBox.Show("提交选择后二轮选择结束，不可更改，请慎重选择是否提交", "提示", MessageBoxButtons.YesNo);
            if (mresult == DialogResult.Yes)
            {
                int kexuan = tm.GetGroupNum(teaNo) - tm.GetyipipeiNum(teaNo);
                DataRow dr = dtheng.NewRow();
                dr[1] = teaNo;
                if (dtshu.Rows.Count == 0)
                {
                    DialogResult messresult;
                    messresult = MessageBox.Show("您二轮选择没有任何选择，请慎重提交,提交后2轮选择即结束", "提示", MessageBoxButtons.YesNo);
                    if (messresult == DialogResult.Yes) { dtheng.Rows.Add(dr); }
                }
                if (dtshu.Rows.Count == 1) { dr[2] = dtshu.Rows[0][1]; dr[7] =kexuan; dr[8] = dtshu.Rows.Count; dtheng.Rows.Add(dr); }
                if (dtshu.Rows.Count == 2) { dr[2] = dtshu.Rows[0][1]; dr[3] = dtshu.Rows[1][1]; dr[7] = kexuan; dr[8] = dtshu.Rows.Count; dtheng.Rows.Add(dr); }
                if (dtshu.Rows.Count == 3) { dr[2] = dtshu.Rows[0][1]; dr[3] = dtshu.Rows[1][1]; dr[4] = dtshu.Rows[2][1]; dr[7] = kexuan; dr[8] = dtshu.Rows.Count; dtheng.Rows.Add(dr); }
                if (dtshu.Rows.Count == 4) { dr[2] = dtshu.Rows[0][1]; dr[3] = dtshu.Rows[1][1]; dr[4] = dtshu.Rows[2][1]; dr[5] = dtshu.Rows[3][1]; dr[7] = kexuan; dr[8] = dtshu.Rows.Count; dtheng.Rows.Add(dr); }
                if (dtshu.Rows.Count == 5) { dr[2] = dtshu.Rows[0][1]; dr[3] = dtshu.Rows[1][1]; dr[4] = dtshu.Rows[2][1]; dr[5] = dtshu.Rows[3][1]; dr[6] = dtshu.Rows[4][1]; dr[7] = kexuan; dr[8] = dtshu.Rows.Count; dtheng.Rows.Add(dr); }
                int i = tm.updateTV2(dtheng);
                if (i > 0)//此方法为最终提交到数据库 并判断返回的数据即影响的行数是否大于0
                {
                    MessageBox.Show("提交选择成功");
                }
                button1.Enabled = false;
                //dataGridView1.Enabled = false;//整个datagridview变灰 无法触发点击事件
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int CIndex = e.ColumnIndex;
                if (CIndex >= 8 && CIndex <= 12)
                {
                    //re=点击datagridview里组员1-5单元格，获取单元格其中的内容
                    restuno = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //获取单元格内容中的数字
                    restuno = System.Text.RegularExpressions.Regex.Replace(restuno, @"[^0-9]+", "");
                    //要用这个带参数的构造函数，把教师查看学生这边获取的学生id传到学生信息页面
                    XPersonalInformationPreview formStu = new XPersonalInformationPreview(restuno);
                    formStu.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //单击任意单元格选中该行一整行
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            int CIndex = e.ColumnIndex;
            if (CIndex == 6)//点中的单元格第7个 --操作1 内容“选择”把该行数据插入teavol表（datatable暂存）
            {
                try
                {
                    //查询当前教师工号的二轮剩余可选组数
                    int teagrnum = tm.GetGroupNum(teaNo)-tm.GetyipipeiNum(teaNo);
                    //要查询当前dtshu中当前教师工号已经选了多少组
                    //[dtshu是每次进系统都重新建的 所以在一次启用程序里，里面全部都是同一个教师的
                    int i = dtshu.Rows.Count;
                    if (i < teagrnum)
                    {
                        //获取这条记录中的groupid  第0个单元格 查看通知  （获取通知id)  作为输入数据库的参数 参考教师查看修改个人信息  
                        //单击任意单元格，选中该行，获取该行中的序号列的内容
                        string re = this.dataGridView1.Rows[e.RowIndex].Cells["组号"].Value.ToString();
                        DataRow dr = dtshu.NewRow();
                        dr[0] = teaNo;
                        dr[1] = re;//groupid 从点击的行索引获取
                        dtshu.Rows.Add(dr);//到此为在datatable中保存新的数据
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;//点击后该行颜色改变
                        //i = i + 1;
                    }
                    else
                    {
                        MessageBox.Show("您二轮选择可带学生组数为:" + teagrnum + "组，如要选择该组，请先取消其他组");
                    }
                }
                catch //处理重复插入dtshu的异常
                {
                    MessageBox.Show("您已选择了该组，请不要重复选择");
                }

            }
            if (CIndex == 7)//取消选择  从datatable中删除数据
            {
                if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.Yellow)//该行颜色没改变说明没被选择
                {
                    MessageBox.Show("该组学生未被选择，不可取消选择");
                }
                else
                {
                    string re = this.dataGridView1.Rows[e.RowIndex].Cells["组号"].Value.ToString();
                    DataRow[] dr;
                    dr = dtshu.Select("Teano=" + teaNo + "and Groupid=" + re);
                    foreach (DataRow i in dr)
                    {
                        dtshu.Rows.Remove(i);
                    }//至此为在datatable dtteavol中删除特定行
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
