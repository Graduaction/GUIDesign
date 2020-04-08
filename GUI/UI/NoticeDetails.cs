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
    public partial class NoticeDetails : Form
    {
        //变量定义
        readonly TeacherManager tm = new TeacherManager();
        public string infono = DCheckNotification.infono;//通知表页面点击的行的通知序号，通过这个序号查找详细内容
        public NoticeDetails()
        {
            InitializeComponent();
        }

        private void NoticeDetails_Load(object sender, EventArgs e)
        {
            #region 页面载入时显示这个序号的通知详细内容
           // MessageBox.Show(infono);//测试可以获取通知表页面的通知序号
            DataTable dt = tm.GetInfoDetail(infono);
            //tbno.Text = dt.Rows[0]["TeaNo"].ToString();
            tbtitle.Text = dt.Rows[0]["InfoTitle"].ToString();
            lbtime.Text = dt.Rows[0]["InfoTime"].ToString();
            tbc.Text = dt.Rows[0]["InfoContent"].ToString();
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DCheckNotification cform = new DCheckNotification();//实例化一个子窗口
            //设置子窗口不显示为顶级窗口
            cform.TopLevel = false;
            //设置子窗口的样式，没有上面的标题栏
            cform.FormBorderStyle = FormBorderStyle.None;
            //填充
            cform.Dock = DockStyle.Fill;
            //清空控件
            this.Controls.Clear();
            //加入控件
            this.Controls.Add(cform);
            //让窗体显示
            cform.Show();
        }
    }
}
