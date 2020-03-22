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
    public partial class PersonalInformationPreview : Form
    {
        public PersonalInformationPreview()
        {
            InitializeComponent();
        }
        private static PersonalInformationPreview formInstance;
        public static PersonalInformationPreview GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new PersonalInformationPreview();
                    return formInstance;
                }
            }
        }
        private void Form21_Load(object sender, EventArgs e)
        {

        }
    }
}
