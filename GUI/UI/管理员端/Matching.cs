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

        }

        private void btreset_Click(object sender, EventArgs e)//重置
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
