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
    public partial class Matching : Form
    {
        public Matching()
        {
            InitializeComponent();
        }
        private static Matching formInstance;
        public static Matching GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Matching();
                    return formInstance;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Matching_Load(object sender, EventArgs e)
        {

        }
    }
}
