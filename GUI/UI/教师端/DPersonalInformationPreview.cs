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
    public partial class DPersonalInformationPreview : Form
    {
        private static DPersonalInformationPreview formInstance;
        public static DPersonalInformationPreview GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new DPersonalInformationPreview();
                    return formInstance;
                }
            }
        }
        public DPersonalInformationPreview()
        {
            InitializeComponent();
        }

        private void XPersonalInformationPreview_Load(object sender, EventArgs e)
        {
           
        }
#pragma warning disable CS0169 // 从不使用字段“DPersonalInformationPreview.y”
        private int y;
#pragma warning restore CS0169 // 从不使用字段“DPersonalInformationPreview.y”
       
        private void XPersonalInformationPreview_Load(object sender, PaintEventArgs e)
        {
            
        }

        private void XPersonalInformationPreview_Load_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
    }

}
