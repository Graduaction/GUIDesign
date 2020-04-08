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
    public partial class MatchingFailure : Form
    {
        public MatchingFailure()
        {
            InitializeComponent();
        }
        private static MatchingFailure formInstance;
        public static MatchingFailure GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MatchingFailure();
                    return formInstance;
                }
            }
        }
        private void MatchingFailure_Load(object sender, EventArgs e)
        {

        }
    }
}
