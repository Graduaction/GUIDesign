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
    public partial class XTeacherLise : Form
    {
        public XTeacherLise()
        {
            InitializeComponent();
        }
        private static XTeacherLise formInstance;
        public static XTeacherLise GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XTeacherLise();
                    return formInstance;
                }
            }
        }
        private void XTeacherLise_Load(object sender, EventArgs e)
        {

        }
    }
}
