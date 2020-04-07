namespace GUI.UI
{
    partial class MyVolunteer
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.导师姓名 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.导师电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导师邮箱 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.志愿序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.志愿状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 19F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(561, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "志愿列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1323, 505);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "我的志愿";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.导师姓名,
            this.导师电话,
            this.导师邮箱,
            this.志愿序号,
            this.志愿状态,
            this.操作});
            this.dataGridView1.Location = new System.Drawing.Point(44, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1257, 406);
            this.dataGridView1.TabIndex = 3;
            // 
            // 导师姓名
            // 
            this.导师姓名.HeaderText = "导师姓名";
            this.导师姓名.MinimumWidth = 6;
            this.导师姓名.Name = "导师姓名";
            this.导师姓名.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.导师姓名.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.导师姓名.Width = 125;
            // 
            // 导师电话
            // 
            this.导师电话.HeaderText = "导师电话";
            this.导师电话.MinimumWidth = 6;
            this.导师电话.Name = "导师电话";
            this.导师电话.Width = 125;
            // 
            // 导师邮箱
            // 
            this.导师邮箱.HeaderText = "导师邮箱";
            this.导师邮箱.MinimumWidth = 6;
            this.导师邮箱.Name = "导师邮箱";
            this.导师邮箱.Width = 125;
            // 
            // 志愿序号
            // 
            this.志愿序号.HeaderText = "志愿序号";
            this.志愿序号.MinimumWidth = 6;
            this.志愿序号.Name = "志愿序号";
            this.志愿序号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.志愿序号.Width = 125;
            // 
            // 志愿状态
            // 
            this.志愿状态.HeaderText = "志愿状态";
            this.志愿状态.MinimumWidth = 6;
            this.志愿状态.Name = "志愿状态";
            this.志愿状态.Width = 125;
            // 
            // 操作
            // 
            this.操作.HeaderText = "操作";
            this.操作.MinimumWidth = 6;
            this.操作.Name = "操作";
            this.操作.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.操作.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.操作.Width = 125;
            // 
            // MyVolunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1363, 535);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyVolunteer";
            this.Text = "Form19";
            this.Load += new System.EventHandler(this.MyVolunteer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn 导师姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导师电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导师邮箱;
        private System.Windows.Forms.DataGridViewTextBoxColumn 志愿序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 志愿状态;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
    }
}