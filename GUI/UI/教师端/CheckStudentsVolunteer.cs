using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI.UI
{
    public partial class CheckStudentsVolunteer : Form
    {
        private static CheckStudentsVolunteer formInstance;
        public static CheckStudentsVolunteer GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new CheckStudentsVolunteer();
                    return formInstance;
                }
            }
        }
        public CheckStudentsVolunteer()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            QueryStu();
        }
        private void QueryStu()
        {
            String constr = "Data Source=134.175.170.29;Initial Catalog=导师双选系统;Persist Security Info=True;User ID=sa;Password=dssxXT2020,,,";
            SqlConnection conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                ///显示学生志愿，需要一个当前老师工号的参数，还没做
                string sql = "select distinct(b.groupid),PARSENAME(STUFF((select '.'+a.StuNo from GroupStu a where a.GroupID=b.GroupID for xml path('')),1,1,''),2) as 学生一,PARSENAME(STUFF((select '.'+a.StuNo from GroupStu a where a.GroupID=b.GroupID for xml path('')),1,1,''),1) as 学生2,(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo and d.groupid=b.groupid) as avg,c.vollevel from groupstu b,GroupVol c where b.groupid=c.groupid and c.TeaNo=1001 order by avg desc ";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
