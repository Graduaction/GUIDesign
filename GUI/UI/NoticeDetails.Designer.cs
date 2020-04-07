namespace GUI.UI
{
    partial class NoticeDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbtitle = new System.Windows.Forms.TextBox();
            this.tbc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbtime);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(958, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通知详情";
            // 
            // lbtime
            // 
            this.lbtime.AutoSize = true;
            this.lbtime.BackColor = System.Drawing.Color.Transparent;
            this.lbtime.Font = new System.Drawing.Font("宋体", 12F);
            this.lbtime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbtime.Location = new System.Drawing.Point(100, 99);
            this.lbtime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(40, 16);
            this.lbtime.TabIndex = 1;
            this.lbtime.Text = "日期";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.tbc);
            this.panel3.Location = new System.Drawing.Point(103, 118);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 230);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Location = new System.Drawing.Point(103, 347);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 62);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.tbtitle);
            this.panel1.Location = new System.Drawing.Point(103, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 62);
            this.panel1.TabIndex = 0;
            // 
            // tbtitle
            // 
            this.tbtitle.Location = new System.Drawing.Point(3, 3);
            this.tbtitle.Multiline = true;
            this.tbtitle.Name = "tbtitle";
            this.tbtitle.ReadOnly = true;
            this.tbtitle.Size = new System.Drawing.Size(713, 45);
            this.tbtitle.TabIndex = 1;
            // 
            // tbc
            // 
            this.tbc.Location = new System.Drawing.Point(14, 3);
            this.tbc.Multiline = true;
            this.tbc.Name = "tbc";
            this.tbc.ReadOnly = true;
            this.tbc.Size = new System.Drawing.Size(682, 209);
            this.tbc.TabIndex = 2;
            // 
            // NoticeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 439);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NoticeDetails";
            this.Text = "Form24";
            this.Load += new System.EventHandler(this.NoticeDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbc;
        private System.Windows.Forms.TextBox tbtitle;
    }
}