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
    public partial class StudentForm : FormEX
    {
        private static StudentForm formInstance;
        public static StudentForm GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new StudentForm();
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
        public static XTeacherLise form2 = null;
        public static MyVolunteer form3 = null;
        public static XPersonalInformationPreview form4 = null;
        public static CheckMentor form5 = null;
        public static XCheckNotification form6 = null;
        public static XPersonalCenter form7 = null;
        public static MyTeam form8 = null;

        /// <summary>
        /// 当前显示窗体
        /// </summary>
        private System.Windows.Forms.Form currentForm;



        public StudentForm()
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
                this.button8.BackColor = Color.FromArgb(53, 66, 83);
                this.button9.BackColor = Color.FromArgb(53, 66, 83);
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
        private void Form17_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("../../img/横幅2.png");
            this.BackgroundImage = Image.FromFile("../../img/背景.jpg");
            this.IsMdiContainer = true;

            this.TitleText = "学生端";

            form1 = HomePage.GetIntance;
            form2 = XTeacherLise.GetIntance;
            form3 = MyVolunteer.GetIntance;
            form4 = XPersonalInformationPreview.GetIntance;
            form5 = CheckMentor.GetIntance;
            form6 = XCheckNotification.GetIntance;
            form7 = XPersonalCenter.GetIntance;
            form8 = MyTeam.GetIntance;


            //初始化按钮
            this.initButton();
            tabControl1.TabPages[0].Text = "使用步骤介绍";
            tabControl1.TabPages[1].Text = "通知";
            tabControl1.TabPages[2].Text = "动态";
            tabControl1.TabPages[3].Text = "注意事项";
        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {
            
        }

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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button8.BackColor = Color.FromArgb(95, 129, 174);
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

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form7);
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

        private void label10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Teacher f2 = new Teacher();
            //f2.ShowDialog();
            ChangePwd cp = new ChangePwd();
            cp.ShowDialog();
            this.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button9.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form8);
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
    }

 }


    

