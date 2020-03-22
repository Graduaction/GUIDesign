namespace GUI.UI
{
    partial class CheckStudentsVolunteer
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
            this.组内成员 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.志愿序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.综测平均分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.操作状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1310, 458);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看学生志愿";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 19F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(473, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "学生列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.组别号,
            this.组内成员,
            this.志愿序号,
            this.综测平均分,
            this.操作,
            this.操作状态});
            this.dataGridView1.Location = new System.Drawing.Point(31, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1243, 369);
            this.dataGridView1.TabIndex = 5;
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
            this.组内成员.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.组内成员.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.组内成员.Width = 125;
            // 
            // 志愿序号
            // 
            this.志愿序号.HeaderText = "志愿序号";
            this.志愿序号.MinimumWidth = 6;
            this.志愿序号.Name = "志愿序号";
            this.志愿序号.Width = 125;
            // 
            // 综测平均分
            // 
            this.综测平均分.HeaderText = "综测平均分";
            this.综测平均分.MinimumWidth = 6;
            this.综测平均分.Name = "综测平均分";
            this.综测平均分.Width = 125;
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
            // 操作状态
            // 
            this.操作状态.HeaderText = "操作状态";
            this.操作状态.MinimumWidth = 6;
            this.操作状态.Name = "操作状态";
            this.操作状态.Width = 125;
            // 
            // CheckStudentsVolunteer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 498);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckStudentsVolunteer";
            this.Text = "Form29";
            this.Load += new System.EventHandler(this.Form29_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组别号;
        private System.Windows.Forms.DataGridViewButtonColumn 组内成员;
        private System.Windows.Forms.DataGridViewTextBoxColumn 志愿序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 综测平均分;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作状态;
    }
}