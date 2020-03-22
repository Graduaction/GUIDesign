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
    public partial class MyVolunteer : Form
    {
        public MyVolunteer()
        {
            InitializeComponent();
        }
        private static MyVolunteer formInstance;
        public static MyVolunteer GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyVolunteer();
                    return formInstance;
                }
            }
        }
        private void MyVolunteer_Load(object sender, EventArgs e)
        {

        }
    }
}
