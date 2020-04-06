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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        private static Setting formInstance;
        public static Setting GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Setting();
                    return formInstance;
                }
            }
        }
        private void Setting_Load(object sender, EventArgs e)
        {
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if(bLL.SelectManagebll(Keepinformation.AdminNo)==1)
            {
                change_enable(false);
                dtptimestart.Value = Keepinformation.StartTime;
                dtptimeend.Value = Keepinformation.EndTime;
                tbvolunteer1.Text = Keepinformation.VolunteerFirstShare;
                tbvolunteer2.Text = Keepinformation.VolunteerSecondShare;
                tbvolunteer3.Text = Keepinformation.VolunteerThirdShare;
                tbscore.Text = Keepinformation.Grade;
            }
            else
            {
                change_enable(true);
                
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btcommit_Click(object sender, EventArgs e)//确认提交
        {

            ManageData manageData = new ManageData();
            manageData.AdminNo1 = Keepinformation.AdminNo;
            manageData.StartTime =Convert.ToDateTime(dtptimestart.Text);
            manageData.EndTime =Convert.ToDateTime(dtptimeend.Text);
            manageData.VolunteerFirstShare =Convert.ToDouble(tbvolunteer1.Text.Trim());
            manageData.VolunteerSecondShare = Convert.ToDouble(tbvolunteer2.Text.Trim());
            manageData.VolunteerThirdShare = Convert.ToDouble(tbvolunteer3.Text.Trim());
            manageData.Grade = Convert.ToDouble(tbscore.Text.Trim());
            //Console.WriteLine(manageData.StartTime);            
            //OUTPUT:2020/4/6 00:00  默认时间是00:00
            ad_ServicesBLL bLL = new ad_ServicesBLL();
            if (bLL.Setparambll(manageData) == 1)
            {
                MessageBox.Show("设置成功", "提示", MessageBoxButtons.OK);
                change_enable(false);
            }
            else
                MessageBox.Show("设置失败","提示",MessageBoxButtons.OK);
        }

        public void change_enable(bool tem)
        {
            dtptimestart.Enabled = tem;
            dtptimeend.Enabled = tem;
            tbvolunteer1.Enabled = tem;
            tbvolunteer2.Enabled = tem;
            tbvolunteer3.Enabled = tem;
            tbscore.Enabled = tem;
        }
    }
}
