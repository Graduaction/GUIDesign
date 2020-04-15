using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;


namespace GUI.UI
{
    public partial class MyTeam : Form
    {
        public MyTeam()
        {
            InitializeComponent();
        }
        private static MyTeam formInstance;
        public static MyTeam GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MyTeam();
                    return formInstance;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form33_Load(object sender, EventArgs e)
        {
            ad_ServicesBLL BLL = new ad_ServicesBLL();
            DataTable studentTable = BLL.SelectStubll();
            dataGridView1.DataSource = studentTable;
        }
        private Point Position = new Point(0, 0);

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static string[] a;
        
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                a = new string[dataGridView1.ColumnCount];
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    a[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }
                

            }
            catch { }
        }
        private void showGridView()
        {
            DataGridTextBoxColumn tb = new DataGridTextBoxColumn();
            dataGridView2.Rows.Add(tb);
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            dataGridView2.Rows[dataGridView2.RowCount - 2].Cells[i].Value = a[i];
            //根据AllowUserToAddRow属性选择最后一行，true时dataGridView1.RowCount-2,false时dataGridView1.RowCount-1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showGridView();
        }
    }
}
