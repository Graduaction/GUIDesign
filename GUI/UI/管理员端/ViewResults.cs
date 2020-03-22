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
    public partial class ViewResults : Form
    {
        public ViewResults()
        {
            InitializeComponent();
        }
        private static ViewResults formInstance;
        public static ViewResults GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new ViewResults();
                    return formInstance;
                }
            }
        }
        private void Form14_Load(object sender, EventArgs e)
        {

        }
    }
}
