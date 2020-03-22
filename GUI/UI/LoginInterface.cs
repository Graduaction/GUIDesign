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
    public partial class LoginInterface : Form
    {
        public LoginInterface()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("../../img/背景.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = new Bitmap("../../img/横幅.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.Visible = false;
                StudentForm f1 = new StudentForm();
                f1.ShowDialog();
                this.Visible = true;
            }
            else if (radioButton2.Checked == true)
            {
                this.Visible = false;
                Teacher f2 = new Teacher();
                f2.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                MainForm f3 = new MainForm();
                f3.ShowDialog();
                this.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
