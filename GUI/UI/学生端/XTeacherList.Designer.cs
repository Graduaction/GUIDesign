namespace GUI.UI
{
    partial class XTeacherList
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.工号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeaName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GroupNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolFirstNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolSort = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(21, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 478);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看教师列表";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(1011, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "提交志愿";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.工号,
            this.TeaName,
            this.GroupNumber,
            this.VolFirstNumber,
            this.VolSort,
            this.Topic,
            this.Control});
            this.dataGridView1.Location = new System.Drawing.Point(29, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1257, 378);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 518);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "备注：点击导师姓名可以查看导师详细介绍";
            // 
            // 工号
            // 
            this.工号.DataPropertyName = "TeaNo";
            this.工号.HeaderText = "工号";
            this.工号.MinimumWidth = 6;
            this.工号.Name = "工号";
            this.工号.Visible = false;
            this.工号.Width = 125;
            // 
            // TeaName
            // 
            this.TeaName.DataPropertyName = "TeaName";
            this.TeaName.HeaderText = "导师姓名";
            this.TeaName.MinimumWidth = 6;
            this.TeaName.Name = "TeaName";
            this.TeaName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TeaName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TeaName.Width = 125;
            // 
            // GroupNumber
            // 
            this.GroupNumber.DataPropertyName = "GroupNumber";
            this.GroupNumber.HeaderText = "可带组数";
            this.GroupNumber.MinimumWidth = 6;
            this.GroupNumber.Name = "GroupNumber";
            this.GroupNumber.Width = 125;
            // 
            // VolFirstNumber
            // 
            this.VolFirstNumber.HeaderText = "第一志愿填报人数";
            this.VolFirstNumber.MinimumWidth = 6;
            this.VolFirstNumber.Name = "VolFirstNumber";
            this.VolFirstNumber.Width = 125;
            // 
            // VolSort
            // 
            this.VolSort.HeaderText = "志愿序号";
            this.VolSort.Items.AddRange(new object[] {
            "第一志愿",
            "第二志愿",
            "第三志愿"});
            this.VolSort.MinimumWidth = 6;
            this.VolSort.Name = "VolSort";
            this.VolSort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VolSort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VolSort.Width = 125;
            // 
            // Topic
            // 
            this.Topic.DataPropertyName = "Topic";
            this.Topic.HeaderText = "预选题目";
            this.Topic.MinimumWidth = 6;
            this.Topic.Name = "Topic";
            this.Topic.Width = 125;
            // 
            // Control
            // 
            this.Control.HeaderText = "操作";
            this.Control.MinimumWidth = 6;
            this.Control.Name = "Control";
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Control.Text = "选择";
            this.Control.UseColumnTextForButtonValue = true;
            this.Control.Width = 125;
            // 
            // XTeacherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1388, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XTeacherList";
            this.Text = "Form18";
            this.Load += new System.EventHandler(this.XTeacherList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工号;
        private System.Windows.Forms.DataGridViewButtonColumn TeaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolFirstNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn VolSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topic;
        private System.Windows.Forms.DataGridViewButtonColumn Control;
    }
}