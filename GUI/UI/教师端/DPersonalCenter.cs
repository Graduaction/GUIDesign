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
    public partial class DPersonalCenter : Form
    {
        

        private static DPersonalCenter formInstance;
        public static DPersonalCenter GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DPersonalCenter();
                    return formInstance;
                }
            }
        }
        public DPersonalCenter()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Teacher f2 = new Teacher();
            //f2.ShowDialog();
            ChangePwd cp = new ChangePwd();
            cp.ShowDialog();
            this.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
