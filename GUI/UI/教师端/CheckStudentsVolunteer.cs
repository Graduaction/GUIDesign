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
    public partial class CheckStudentsVolunteer : Form
    {
        private static CheckStudentsVolunteer formInstance;
        public static CheckStudentsVolunteer GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckStudentsVolunteer();
                    return formInstance;
                }
            }
        }
        public CheckStudentsVolunteer()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {

        }
    }
}
