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
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.Util;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;
using System.Security.Permissions; //需加的
using NPOI.SS.Formula.Functions;

namespace GUI.UI
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]//需加的
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]//需加的 
    public partial class Notice : Form
    {
        
        public Notice()
        {
            InitializeComponent();
        }
        private static Notice formInstance;
        public static Notice GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Notice();
                    return formInstance;
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            InformationData InformationData = new InformationData();
            
            
            InformationData.InfoTitle = textBox1.Text;
            InformationData.InfoContent = textBox3.Text;
            if (BLL.ReleasingNotices(InformationData))
            {
                MessageBox.Show("发布成功", "提示", MessageBoxButtons.OK);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
                
            }
            else
            {
                MessageBox.Show("发布失败", "提示", MessageBoxButtons.OKCancel);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
