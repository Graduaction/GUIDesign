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
    public partial class HomePage : Form
    {
        private static HomePage formInstance;
        public static HomePage GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new HomePage();
                    return formInstance;
                }
            }
        }
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = "综合";
            tabControl1.TabPages[1].Text = "通知";
            tabControl1.TabPages[2].Text = "动态";
            tabControl1.TabPages[3].Text = "注意事项";

        }
    }
}
