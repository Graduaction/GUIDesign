using BenNHControl;
using static BenNHControl.FormEX;
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
    public partial class Teacher : FormEX
    {
        private static Teacher formInstance;
        public static Teacher GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new Teacher();
                    return formInstance;
                }
            }
        }

        public object lockObj = new object();
        public bool formSwitchFlag = false;

        /// <summary>
        /// 子窗体界面单例元素
        /// </summary>
        public static HomePage form1 = null;
        public static DPersonalInformationPreview form2 = null;
        public static CheckStudentsVolunteer form3 = null;
        public static MyStudents form4 = null;
        public static DCheckNotification form5 = null;
        public static DPersonalCenter form6 = null;
        public Teacher()
        {
            InitializeComponent();
        }
        private bool initButton()
        {
            try
            {
                this.button1.BackColor = Color.FromArgb(53, 66, 83);
                this.button2.BackColor = Color.FromArgb(53, 66, 83);
                this.button3.BackColor = Color.FromArgb(53, 66, 83);
                this.button4.BackColor = Color.FromArgb(53, 66, 83);
                this.button5.BackColor = Color.FromArgb(53, 66, 83);
                this.button6.BackColor = Color.FromArgb(53, 66, 83);
                this.button7.BackColor = Color.FromArgb(53, 66, 83);
                

                this.button10.BackColor = Color.FromArgb(53, 66, 83);
                this.button11.BackColor = Color.FromArgb(53, 66, 83);

            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return false;
            }
            return true;
        }
        private void Student_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("../../img/横幅2.png");
            this.BackgroundImage = Image.FromFile("../../img/背景.jpg");
            this.IsMdiContainer = true;

            this.TitleText = "教师端";

            form1 = HomePage.GetIntance;
            form2 = DPersonalInformationPreview.GetIntance;
            form3 = CheckStudentsVolunteer.GetIntance;
            form4 = MyStudents.GetIntance;
            form5 = DCheckNotification.GetIntance;
            form6 = DPersonalCenter.GetIntance;

            tabControl1.TabPages[0].Text = "使用步骤介绍";
            tabControl1.TabPages[1].Text = "通知";
            tabControl1.TabPages[2].Text = "动态";
            tabControl1.TabPages[3].Text = "注意事项";
            this.initButton();
        }
        private System.Windows.Forms.Form currentForm;
        public void ShowForm(System.Windows.Forms.Panel panel, System.Windows.Forms.Form frm)
        {
            lock (this)
            {
                try
                {
                    if (this.currentForm != null && this.currentForm == frm)
                    {
                        return;
                    }
                    else if (this.currentForm != null)
                    {
                        if (this.ActiveMdiChild != null)
                        {
                            this.ActiveMdiChild.Hide();
                        }
                    }
                    this.currentForm = frm;
                    frm.TopLevel = false;
                    frm.MdiParent = this;
                    panel.Controls.Clear();
                    panel.Controls.Add(frm);
                    frm.Show();
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.Refresh();
                    foreach (Control item in frm.Controls)
                    {
                        item.Focus();
                        break;
                    }
                }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
                catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
                {
                    //
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            try
            {
                this.initButton();
                this.button1.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form1);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
            try
            {
                this.initButton();
                this.button2.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form2);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                this.initButton();
                this.button3.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form3);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                this.initButton();
                this.button4.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form4);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            try
            {
               
                this.initButton();
                this.button5.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form5);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form6);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (System.Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //Teacher f2 = new Teacher();
            //f2.ShowDialog();
            ChangePwd cp = new ChangePwd();
            cp.ShowDialog();
            this.Visible = true;
        }
    }
}
