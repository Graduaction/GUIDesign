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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        private static Setting formInstance;
        public static Setting GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Setting();
                    return formInstance;
                }
            }
        }
        private void Setting_Load(object sender, EventArgs e)
        {

        }
    }
}
