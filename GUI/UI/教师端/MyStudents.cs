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
    public partial class MyStudents : Form
    {
        private static MyStudents formInstance;
        public static MyStudents GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyStudents();
                    return formInstance;
                }
            }
        }
        public MyStudents()
        {
            InitializeComponent();
        }

        private void MyStudents_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
