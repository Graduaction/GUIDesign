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
    public partial class CheckMentor : Form
    {
        public CheckMentor()
        {
            InitializeComponent();
        }
        private static CheckMentor formInstance;
        public static CheckMentor GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckMentor();
                    return formInstance;
                }
            }
        }
        private void CheckMentor_Load(object sender, EventArgs e)
        {

        }
    }
}
