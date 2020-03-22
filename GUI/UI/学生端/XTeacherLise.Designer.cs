namespace GUI.UI
{
    partial class XTeacherLise
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.导师姓名 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.可带学生数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.第一志愿填报人数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.志愿序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(21, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 510);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看教师列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1157, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "1/10 上一页|下一页";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 19F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(560, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "教师列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.导师姓名,
            this.可带学生数,
            this.第一志愿填报人数,
            this.志愿序号,
            this.操作});
            this.dataGridView1.Location = new System.Drawing.Point(29, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1257, 378);
            this.dataGridView1.TabIndex = 4;
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
            // 可带学生数
            // 
            this.可带学生数.HeaderText = "可带学生数";
            this.可带学生数.MinimumWidth = 6;
            this.可带学生数.Name = "可带学生数";
            this.可带学生数.Width = 125;
            // 
            // 第一志愿填报人数
            // 
            this.第一志愿填报人数.HeaderText = "第一志愿填报人数";
            this.第一志愿填报人数.MinimumWidth = 6;
            this.第一志愿填报人数.Name = "第一志愿填报人数";
            this.第一志愿填报人数.Width = 125;
            // 
            // 志愿序号
            // 
            this.志愿序号.HeaderText = "志愿序号";
            this.志愿序号.MinimumWidth = 6;
            this.志愿序号.Name = "志愿序号";
            this.志愿序号.Width = 125;
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
            // XTeacherLise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 557);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XTeacherLise";
            this.Text = "Form18";
            this.Load += new System.EventHandler(this.XTeacherLise_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn 导师姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 可带学生数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 第一志愿填报人数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 志愿序号;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
    }
}