namespace GUI.UI
{
    partial class Matching
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btreset = new System.Windows.Forms.Button();
            this.btmatch = new System.Windows.Forms.Button();
            this.teadataGridView = new System.Windows.Forms.DataGridView();
            this.studataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1108, 423);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "双选匹配";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btreset);
            this.panel1.Controls.Add(this.btmatch);
            this.panel1.Controls.Add(this.teadataGridView);
            this.panel1.Controls.Add(this.studataGridView);
            this.panel1.Location = new System.Drawing.Point(4, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 360);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(714, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "导师列表";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(147, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "学生列表";
            // 
            // btreset
            // 
            this.btreset.Font = new System.Drawing.Font("宋体", 12F);
            this.btreset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btreset.Location = new System.Drawing.Point(450, 205);
            this.btreset.Margin = new System.Windows.Forms.Padding(2);
            this.btreset.Name = "btreset";
            this.btreset.Size = new System.Drawing.Size(90, 38);
            this.btreset.TabIndex = 15;
            this.btreset.Text = "重置结果";
            this.btreset.UseVisualStyleBackColor = true;
            this.btreset.Click += new System.EventHandler(this.btreset_Click);
            // 
            // btmatch
            // 
            this.btmatch.Font = new System.Drawing.Font("宋体", 12F);
            this.btmatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btmatch.Location = new System.Drawing.Point(450, 119);
            this.btmatch.Margin = new System.Windows.Forms.Padding(2);
            this.btmatch.Name = "btmatch";
            this.btmatch.Size = new System.Drawing.Size(90, 38);
            this.btmatch.TabIndex = 14;
            this.btmatch.Text = "一键匹配";
            this.btmatch.UseVisualStyleBackColor = true;
            this.btmatch.Click += new System.EventHandler(this.btmatch_Click);
            // 
            // teadataGridView
            // 
            this.teadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teadataGridView.Location = new System.Drawing.Point(565, 54);
            this.teadataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.teadataGridView.Name = "teadataGridView";
            this.teadataGridView.RowHeadersWidth = 51;
            this.teadataGridView.RowTemplate.Height = 27;
            this.teadataGridView.Size = new System.Drawing.Size(479, 299);
            this.teadataGridView.TabIndex = 13;
            // 
            // studataGridView
            // 
            this.studataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studataGridView.Location = new System.Drawing.Point(8, 54);
            this.studataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.studataGridView.Name = "studataGridView";
            this.studataGridView.RowHeadersWidth = 51;
            this.studataGridView.RowTemplate.Height = 27;
            this.studataGridView.Size = new System.Drawing.Size(420, 299);
            this.studataGridView.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 19F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(458, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "双选匹配";
            // 
            // Matching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1184, 443);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Matching";
            this.Text = "Form25";
            this.Load += new System.EventHandler(this.Matching_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btreset;
        private System.Windows.Forms.Button btmatch;
        private System.Windows.Forms.DataGridView teadataGridView;
        private System.Windows.Forms.DataGridView studataGridView;
    }
}