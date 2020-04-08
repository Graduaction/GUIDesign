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
    public partial class MainForm : FormEX
    {

        private static MainForm formInstance;
        public static MainForm GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MainForm();
                    return formInstance;
                }
            }
        }


        public object lockObj = new object();
        public bool formSwitchFlag = false;

        /// <summary>
        /// 子窗体界面单例元素
        /// </summary>
        public static TeachersList form1 = null;
        public static StudentList form2 = null;
        public static AddTeacherInformation form3 = null;
        public static AddStudentInformation form4 = null;
        public static HomePage form5 = null;
        public static Notice form6 = null;
        public static CheckNotification form7 = null;
        public static ViewResults form9 = null;
        public static Setting form8 = null;
        public static PersonalCenter form10 = null;
        public static Matching form11 = null;
        /// <summary>
        /// 当前显示窗体
        /// </summary>
        private System.Windows.Forms.Form currentForm;


        /// <summary>
        /// 构造方法
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //主窗体容器打开
            this.IsMdiContainer = true;

            this.TitleText = "管理员";

            //实例化子窗体界面
            form1 = TeachersList.GetIntance;
            form2 = StudentList.GetIntance;
            form3 = AddTeacherInformation.GetIntance;
            form4 = AddStudentInformation.GetIntance;
            form5 = HomePage.GetIntance;
            form6 = Notice.GetIntance;
            form7 = CheckNotification.GetIntance;
            form9 = ViewResults.GetIntance;
            form8 = Setting.GetIntance;
            form10 = PersonalCenter.GetIntance;
            form11 = Matching.GetIntance;

            //初始化按钮
            this.initButton();

        }


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

        private bool initButton()
        {
            try
            {
                this.button1.BackColor = Color.FromArgb(53, 66, 83);
                
                this.button4.BackColor = Color.FromArgb(53, 66, 83);
                this.button5.BackColor = Color.FromArgb(53, 66, 83);
                this.button6.BackColor = Color.FromArgb(53, 66, 83);
                this.button7.BackColor = Color.FromArgb(53, 66, 83);
                this.button8.BackColor = Color.FromArgb(53, 66, 83);
                this.button9.BackColor = Color.FromArgb(53, 66, 83);
                this.button10.BackColor = Color.FromArgb(53, 66, 83);
                this.button11.BackColor = Color.FromArgb(53, 66, 83);
                this.button12.BackColor = Color.FromArgb(53, 66, 83);
                this.button13.BackColor = Color.FromArgb(53, 66, 83);
                this.button14.BackColor = Color.FromArgb(53, 66, 83);
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="frm"></param>
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
                    this.ShowForm(pnlCenter,form5);
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("../../img/横幅2.png");
            this.BackgroundImage = Image.FromFile("../../img/背景.jpg");

            tabControl1.TabPages[0].Text = "使用步骤介绍";
            tabControl1.TabPages[1].Text = "通知";
            tabControl1.TabPages[2].Text = "动态";
            tabControl1.TabPages[3].Text = "注意事项";


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button4.BackColor = Color.FromArgb(95, 129, 174);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
               
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button5.BackColor = Color.FromArgb(95, 129, 174);
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

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button13.BackColor = Color.FromArgb(95, 129, 174);
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
                    this.ShowForm(pnlCenter, form9);
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

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button14.BackColor = Color.FromArgb(95, 129, 174);
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

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form10);
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

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button12.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form11);
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
