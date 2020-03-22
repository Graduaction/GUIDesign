using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class TeachersList : Form
    {
        public bool formSwitchFlag = false;
        public object lockObj = new object();
        public static AddTeacherInformation form1 = null;

        private static TeachersList formInstance;
        public static TeachersList GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new TeachersList();
                    return formInstance;
                }
            }
        }
        public TeachersList()
        {
            InitializeComponent();
            form1 = AddTeacherInformation.GetIntance;

        }
        //public void ShowForm(System.Windows.Forms.Panel panel, System.Windows.Forms.Form frm)
        //{
        //    lock (this)
        //    {
        //        try
        //        {
        //            if (this.currentForm != null && this.currentForm == frm)
        //            {
        //                return;
        //            }
        //            else if (this.currentForm != null)
        //            {
        //                if (this.ActiveMdiChild != null)
        //                {
        //                    this.ActiveMdiChild.Hide();
        //                }
        //            }
        //            this.currentForm = frm;
        //            frm.TopLevel = false;
        //            frm.MdiParent = this;
        //            panel.Controls.Clear();
        //            panel.Controls.Add(frm);
        //            frm.Show();
        //            frm.Dock = System.Windows.Forms.DockStyle.Fill;
        //            this.Refresh();
        //            foreach (Control item in frm.Controls)
        //            {
        //                item.Focus();
        //                break;
        //            }
        //        }
        //        catch (System.Exception ex)
        //        {
        //            //
        //        }
        //    }
        //}

        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
               
                
            //    Monitor.Enter(this.lockObj);
            //    if (!formSwitchFlag)
            //    {
            //        formSwitchFlag = true;
            //        this.ShowForm(pnlCenter, form1);
            //        formSwitchFlag = false;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    //
            //}
            //finally
            //{
            //    Monitor.Exit(this.lockObj);
            //}
        }
    }
}
