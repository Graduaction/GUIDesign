﻿namespace GUI.UI
{
    partial class MyStudents
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.组别号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.组内成员 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.组长 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.组长联系电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(739, 303);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看我的学生";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 19F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(400, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "学生列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.组别号,
            this.组内成员,
            this.组长,
            this.组长联系电话});
            this.dataGridView1.Location = new System.Drawing.Point(18, 43);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(938, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // 组别号
            // 
            this.组别号.HeaderText = "组别号";
            this.组别号.MinimumWidth = 6;
            this.组别号.Name = "组别号";
            this.组别号.Width = 125;
            // 
            // 组内成员
            // 
            this.组内成员.HeaderText = "组内成员";
            this.组内成员.MinimumWidth = 6;
            this.组内成员.Name = "组内成员";
            this.组内成员.Width = 125;
            // 
            // 组长
            // 
            this.组长.HeaderText = "组长";
            this.组长.MinimumWidth = 6;
            this.组长.Name = "组长";
            this.组长.Width = 125;
            // 
            // 组长联系电话
            // 
            this.组长联系电话.HeaderText = "组长联系电话";
            this.组长联系电话.MinimumWidth = 6;
            this.组长联系电话.Name = "组长联系电话";
            this.组长联系电话.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "备注：点击组员姓名可以查看组员详细介绍";
            // 
            // MyStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(797, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyStudents";
            this.Text = "Form31";
            this.Load += new System.EventHandler(this.MyStudents_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.DataGridViewTextBoxColumn 组别号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组内成员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组长;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组长联系电话;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}