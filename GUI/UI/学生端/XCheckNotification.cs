using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace GUI.UI
{
    public partial class XCheckNotification : Form
    {
        StudentManager sm = new StudentManager();
        public static string infono;
        public XCheckNotification()
        {
            InitializeComponent();
        }
        private static XCheckNotification formInstance;
        public static XCheckNotification GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new XCheckNotification();
                    return formInstance;
                }
            }
        }
        private void XCheckNotification_Load(object sender, EventArgs e)
        {
            DCheckNotification dCheckNotification = new DCheckNotification
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            this.Controls.Clear();
            this.Controls.Add(dCheckNotification);
            dCheckNotification.Show();

        }
    }
}
