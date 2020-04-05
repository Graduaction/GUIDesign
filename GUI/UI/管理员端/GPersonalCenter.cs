using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

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
            
            tbAdminNo.Text =Keepinformation.AdminNo;
            tbAdminName.Text = Keepinformation.AdminName;
            tbadmintitle.Text = Keepinformation.AdminTitle;
            tbminemail.Text = Keepinformation.AdminEmail;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//确认修改
        {
            AdminData adminData = new AdminData();
            adminData.AdminTitle = tbadmintitle.Text.Trim();
            adminData.AdminEmail = tbminemail.Text.Trim();
            adminData.AdminPwd = tbnewpwd.Text.Trim();
            adminData.AdminNo = Keepinformation.AdminNo;
            adminData.AdminName = Keepinformation.AdminName;
            ad_ServicesBLL bLL = new ad_ServicesBLL();          
            if(bLL.Updataadmbll(adminData)==1)
            {
                MessageBox.Show("修改成功","提示",MessageBoxButtons.OK);
                tbnewpwd.Text = "";
            }
            else
            {
                MessageBox.Show("修改失败","提示",MessageBoxButtons.OK);
            }
        }
    }
}
