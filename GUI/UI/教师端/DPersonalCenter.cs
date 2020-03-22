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
    }
}
