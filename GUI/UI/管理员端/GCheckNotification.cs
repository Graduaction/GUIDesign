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
    public partial class CheckNotification : Form
    {
        public CheckNotification()
        {
            InitializeComponent();
        }
        private static CheckNotification formInstance;
        public static CheckNotification GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckNotification();
                    return formInstance;
                }
            }
        }
        private void CheckNotification_Load(object sender, EventArgs e)
        {

        }
    }
}
