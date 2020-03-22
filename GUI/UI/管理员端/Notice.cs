using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions; //需加的

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
            //邮件标题
            string strtitle = "这是标题";
            Object[] objArray = new Object[1];
            objArray[0] = (Object)strtitle;
            webBrowser1.Document.InvokeScript("SetTitile", objArray);

            //邮件内容
            string name = @"<font color=""#FF0000""><h1>hello world</h1></font>!sendry lee.";
            objArray = new Object[1];
            objArray[0] = (Object)name;
            webBrowser1.Document.InvokeScript("SetContent", objArray);
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Application.StartupPath + "/HandyEditor-1.6.1/index.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strtitle = webBrowser1.Document.InvokeScript("GetTitile").ToString();
            string strfile = webBrowser1.Document.InvokeScript("GetFileUrl").ToString();
            string strcontent = webBrowser1.Document.InvokeScript("GetContent").ToString();
            MessageBox.Show("邮件的标题是：" + strtitle + "\n" + "附件：" + strfile + "\n" + "内容：" + strcontent);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
