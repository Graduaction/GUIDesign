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
    public partial class XPersonalCenter : Form
    {
        public XPersonalCenter()
        {
            InitializeComponent();
        }

        private static XPersonalCenter formInstance;
        public static XPersonalCenter GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XPersonalCenter();
                    return formInstance;
                }
            }
        }
        private void XPersonalCenter_Load(object sender, EventArgs e)
        {

        }
    }
}
