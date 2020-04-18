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
    public partial class DHomePage : Form
    {
        public DHomePage()
        {
            InitializeComponent();
        }

        private void DHomePage_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = "使用步骤介绍";
            tabControl1.TabPages[1].Text = "通知";
            tabControl1.TabPages[2].Text = "动态";
            tabControl1.TabPages[3].Text = "注意事项";
        }
    }
}
