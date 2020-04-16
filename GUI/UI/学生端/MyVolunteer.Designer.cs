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
            this.工号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeaName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Contaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.工号,
            this.TeaName,
            this.Contaction,
            this.Email,
            this.VolSort,
            this.VolStatus,
            this.Control});
            this.dataGridView1.Location = new System.Drawing.Point(29, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1257, 406);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // 工号
            // 
            this.工号.DataPropertyName = "TeaNo";
            this.工号.HeaderText = "工号";
            this.工号.MinimumWidth = 6;
            this.工号.Name = "工号";
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
            // Contaction
            // 
            this.Contaction.DataPropertyName = "Contaction";
            this.Contaction.HeaderText = "导师电话";
            this.Contaction.MinimumWidth = 6;
            this.Contaction.Name = "Contaction";
            this.Contaction.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "导师邮箱";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // VolSort
            // 
            this.VolSort.DataPropertyName = "VolSort";
            this.VolSort.HeaderText = "志愿序号";
            this.VolSort.MinimumWidth = 6;
            this.VolSort.Name = "VolSort";
            this.VolSort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VolSort.Width = 125;
            // 
            // VolStatus
            // 
            this.VolStatus.DataPropertyName = "VolStatus";
            this.VolStatus.HeaderText = "志愿状态";
            this.VolStatus.MinimumWidth = 6;
            this.VolStatus.Name = "VolStatus";
            this.VolStatus.Width = 125;
            // 
            // Control
            // 
            this.Control.DataPropertyName = "Control";
            this.Control.HeaderText = "操作";
            this.Control.MinimumWidth = 6;
            this.Control.Name = "Control";
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Control.Width = 125;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 工号;
        private System.Windows.Forms.DataGridViewButtonColumn TeaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolStatus;
        private System.Windows.Forms.DataGridViewButtonColumn Control;
    }
}