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
    public partial class DCheckNotification : Form
    {
        private static DCheckNotification formInstance;
        public static DCheckNotification GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DCheckNotification();
                    return formInstance;
                }
            }
        }
        public DCheckNotification()
        {
            InitializeComponent();
        }

        private void DCheckNotification_Load(object sender, EventArgs e)
        {

        }
    }
}
