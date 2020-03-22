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
    public partial class PersonalCenter : Form
    {
        private static PersonalCenter formInstance;
        public static PersonalCenter GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new PersonalCenter();
                    return formInstance;
                }
            }
        }
        public PersonalCenter()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void PersonalCenter_Load(object sender, EventArgs e)
        {

        }
    }
}
