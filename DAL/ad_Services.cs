using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;


namespace DAL
{
    public class ad_ServicesDAL
    {
        #region SelectStu查询学生数据
        /// <summary>
        /// 查询学生数据
        /// </summary>
        /// <returns>返回datatable</returns>
        public DataTable SelectStu()
        {
            string sql = "select StuNo as 学生学号,StuName as 学生姓名,StuNianji as 学生年级,Academy as 学生学院,Profession as 学生专业,StuClass as 学生班级,Grade as 学生综测,StuPwd as 初始密码 from Student";
            DataTable studentTable = SQLHelper.ExecuteQuery(sql);
            return studentTable;
        }
        #endregion

        #region SelectTea查询教师信息
        public DataTable SelectTea()
        {
            string sql = "select TeaNo as 教师工号,TeaName as 教师姓名,Academy as 所属学院,GroupNumber as 所带组数,TeaPwd as 初始密码 from Teacher";
            DataTable teaTable = SQLHelper.ExecuteQuery(sql);
            return teaTable;
        }
        #endregion

        #region SelectManage查询双选参数信息
        public int SelectManage(string adminno1)
        {
            int result = 0;
            string sql = @"select * from Manage where AdminNo1=@AdminNo1";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo1",SqlDbType.NVarChar)
            };
            sqlParameter[0].Value = adminno1;
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameter);
            if (reader.HasRows)
            {
                while (reader.Read())
                {                    
                    Keepinformation.AdminNo =reader[1].ToString();
                    Keepinformation.StartTime =Convert.ToDateTime(reader[2].ToString());
                    Keepinformation.EndTime = Convert.ToDateTime(reader[3].ToString());
                    Keepinformation.VolunteerFirstShare =reader[4].ToString();
                    Keepinformation.VolunteerSecondShare = reader[5].ToString();
                    Keepinformation.VolunteerThirdShare = reader[6].ToString();
                    Keepinformation.Grade = reader[7].ToString();
                    result = 1;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region InsertStu插入学生数据
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public int InsertStu(StudentData studentData)
        {
            string sql = @"insert into Student (StuNo,StuPwd,StuName,Academy,Profession,Grade,StuNianji,StuClass) values(@StuNo,@StuPwd,@StuName,@Academy,@Profession,@Grade,@StuNianji,@StuClass)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.NVarChar),
                new SqlParameter("@StuPwd",SqlDbType.NVarChar),
                new SqlParameter("@StuName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@Profession",SqlDbType.NVarChar),
                new SqlParameter("@Grade",SqlDbType.Int),
                new SqlParameter("@StuNianji",SqlDbType.NVarChar),
                new SqlParameter("@StuClass",SqlDbType.Int)
            };
            sqlParameter[0].Value = studentData.StuNo;
            sqlParameter[1].Value = studentData.StuPwd;
            sqlParameter[2].Value = studentData.StuName;
            sqlParameter[3].Value = studentData.Academy;
            sqlParameter[4].Value = studentData.Profession;
            sqlParameter[5].Value = studentData.Grade;
            sqlParameter[6].Value = studentData.StuNianji;
            sqlParameter[7].Value = studentData.StuClass;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region InsertTea插入教师数据
        public int InsertTea(TeacherData teacherData)
        {
            string sql = @"insert into Teacher (TeaNo,TeaPwd,TeaName,Academy,GroupNumber) values(@TeaNo,@TeaPwd,@TeaName,@Academy,@GroupNumber)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaNo",SqlDbType.NVarChar),
                new SqlParameter("@TeaPwd",SqlDbType.NVarChar),
                new SqlParameter("@TeaName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@GroupNumber",SqlDbType.Int),
            };
            sqlParameter[0].Value = teacherData.TeaNo;
            sqlParameter[1].Value = teacherData.TeaPwd;
            sqlParameter[2].Value = teacherData.TeaName;
            sqlParameter[3].Value = teacherData.Academy;
            sqlParameter[4].Value = teacherData.GroupNumber;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region Manage表插入双选参数信息
        public int InsertManage(ManageData manageData)
        {
            string sql = @"insert into Manage (AdminNo1,StartTime,EndTime,VolunteerFirstShare,VolunteerSecondShare,VolunteerThirdShare,Grade) values(@AdminNo1,@StartTime,@EndTime,@VolunteerFirstShare,@VolunteerSencondShare,@VolunteerThirdShare,@Grade)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo1",SqlDbType.NVarChar),
                new SqlParameter("@StartTime",SqlDbType.DateTime),
                new SqlParameter("@EndTime",SqlDbType.DateTime),
                new SqlParameter("@VolunteerFirstShare",SqlDbType.Float),
                new SqlParameter("@VolunteerSencondShare",SqlDbType.Float),
                new SqlParameter("@VolunteerThirdShare",SqlDbType.Float),
                new SqlParameter("@Grade",SqlDbType.Float),
            };
            sqlParameter[0].Value = manageData.AdminNo1;
            sqlParameter[1].Value = manageData.StartTime;
            sqlParameter[2].Value = manageData.EndTime;
            sqlParameter[3].Value = manageData.VolunteerFirstShare;
            sqlParameter[4].Value = manageData.VolunteerSecondShare;
            sqlParameter[5].Value = manageData.VolunteerThirdShare;
            sqlParameter[6].Value = manageData.Grade;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数                       
            return result;
        }
        #endregion

        #region 根据DeleteBystuNo删除学生数据
        public bool DeleteBystuNo(string StuNo)
        {
            string strSql = "delete from Student where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.VarChar)
            };
            sqlParameter[0].Value = StuNo;
            return SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, sqlParameter) > 0;
        }
        #endregion

        #region 根据DaleteByteaNo删除教师数据
        public bool DaleteByteaNo(string TeaNo)
        {
            string strSql = "delete from Teacher where TeaNo=@TeaNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaNo",SqlDbType.VarChar)
            };
            sqlParameter[0].Value = TeaNo;
            return SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, sqlParameter) > 0;
        }
        #endregion

        #region UpdateStudata修改学生数据
        public int UpdateStudata(StudentData studentData)
        {
            string sql = @"update  Student set StuPwd=@StuPwd,StuName=@StuName,Academy=@Academy,Profession=@Profession,Grade=@Grade,StuNianji=@StuNianji,StuClass=@StuClass where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.NVarChar),
                new SqlParameter("@StuPwd",SqlDbType.NVarChar),
                new SqlParameter("@StuName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@Profession",SqlDbType.NVarChar),
                new SqlParameter("@Grade",SqlDbType.Int),
                new SqlParameter("@StuNianji",SqlDbType.NVarChar),
                new SqlParameter("@StuClass",SqlDbType.Int)
            };
            sqlParameter[0].Value = studentData.StuNo;
            sqlParameter[1].Value = studentData.StuPwd;
            sqlParameter[2].Value = studentData.StuName;
            sqlParameter[3].Value = studentData.Academy;
            sqlParameter[4].Value = studentData.Profession;
            sqlParameter[5].Value = studentData.Grade;
            sqlParameter[6].Value = studentData.StuNianji;
            sqlParameter[7].Value = studentData.StuClass;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region UPdateTeadata修改教师数据
        public int UPdateTeadata(TeacherData teacherData)
        {
            string sql = @"update  Teacher set TeaPwd=@TeaPwd,TeaName=@TeaName,Academy=@Academy,GroupNumber=@GroupNumber where TeaNo=@TeaNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaPwd",SqlDbType.NVarChar),
                new SqlParameter("@TeaName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@GroupNumber",SqlDbType.Int),
                new SqlParameter("@TeaNo",SqlDbType.NVarChar),
            };
            sqlParameter[0].Value = teacherData.TeaPwd;
            sqlParameter[1].Value = teacherData.TeaName;
            sqlParameter[2].Value = teacherData.Academy;
            sqlParameter[3].Value = teacherData.GroupNumber;
            sqlParameter[4].Value = teacherData.TeaNo;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region UpdateAdmdata修改管理员数据
        /// <summary>
        /// UpdateAdmdata修改管理员数据
        /// </summary>
        /// <param name="adminData">传参：管理员对象</param>
        /// <returns></returns>
        public int UpdataAdmdata(AdminData adminData)
        {         
            string sql = @"update  Admin set AdminPwd=@AdminPwd,AdminTitle=@AdminTitle,AdminEmail=@AdminEmail where AdminNo=@AdminNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminPwd",SqlDbType.NVarChar),               
                new SqlParameter("@AdminName",SqlDbType.NVarChar),
                new SqlParameter("@AdminTitle",SqlDbType.NVarChar),
                new SqlParameter("@AdminEmail",SqlDbType.NVarChar),
                new SqlParameter("@AdminNo",SqlDbType.NVarChar),
            };
            sqlParameter[0].Value = adminData.AdminPwd;
            sqlParameter[1].Value = adminData.AdminName;
            sqlParameter[2].Value = adminData.AdminTitle;
            sqlParameter[3].Value = adminData.AdminEmail;
            sqlParameter[4].Value = adminData.AdminNo;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region 导入excel文件功能
        /// <summary>
        /// 导入excel文件功能
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回datatable</returns>        
        public DataTable importFile(string sql, string filePath)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            using (SqlConnection conn = SQLHelper.createConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    sqlDataAdapter.SelectCommand.CommandText = sql;
                    SqlCommandBuilder scb = new SqlCommandBuilder(sqlDataAdapter);
                    Transferfile transferfile = new Transferfile();
                    dataTable = transferfile.ExcelSheetImportToDataTable(filePath);
                    sqlDataAdapter.Fill(dataTable);
                    //sqlDataAdapter.Update(dataTable);
                    return dataTable;

                }

            }
        }
        #endregion

        #region 将DataTable数据批量导入数据库
        /// <summary>
        /// 将DataTable数据批量导入数据库
        /// </summary>
        /// <param name="dt">传参：datatable</param>
        public void DataTableToStuSQLServer(DataTable dt)
        {
            using (SqlConnection destinationConnection = SQLHelper.createConnection())
            {
                // destinationConnection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "Student";//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.ColumnMappings.Add("学生学号", "StuNo");//映射字段名 DataTable列名 ,数据库 对应的列名 
                        bulkCopy.ColumnMappings.Add("学生密码", "StuPwd");
                        bulkCopy.ColumnMappings.Add("学生姓名", "StuName");
                        bulkCopy.ColumnMappings.Add("学生年级", "StuNianji");
                        bulkCopy.ColumnMappings.Add("学生学院", "Academy");
                        bulkCopy.ColumnMappings.Add("学生专业", "Profession");
                        bulkCopy.ColumnMappings.Add("学生班级", "StuClass");
                        bulkCopy.ColumnMappings.Add("学生综测", "Grade");
                        bulkCopy.WriteToServer(dt);
                        MessageBox.Show("插入成功", "提示");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                    }
                }
            }
        }
        #endregion

        #region 将教师DataTable数据批量导入数据库
        /// <summary>
        /// 将教师DataTable数据批量导入数据库
        /// </summary>
        /// <param name="dt">传参：datatable</param>
        public void DataTableToTeaSQLServer(DataTable dt)
        {
            using (SqlConnection destinationConnection = SQLHelper.createConnection())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "Teacher";//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.ColumnMappings.Add("教师工号", "TeaNo");//映射字段名 DataTable列名 ,数据库 对应的列名 
                        bulkCopy.ColumnMappings.Add("教师密码", "TeaPwd");
                        bulkCopy.ColumnMappings.Add("教师姓名", "TeaName");
                        bulkCopy.ColumnMappings.Add("所属学院", "Academy");
                        bulkCopy.ColumnMappings.Add("所带组数", "GroupNumber");
                        bulkCopy.WriteToServer(dt);
                        MessageBox.Show("插入成功", "提示");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                    }
                }
            }
        }
        #endregion

        #region 个人中心页
        /// <summary>
        /// 查看管理员个人中心
        /// </summary>
        /// <returns>返回datatable</returns>
        //public DataTable SelectAdm()
        //{
        //    string sql = @"select AdminNo ,AdminName ,AdminTitle, AdminEmail from Student";

        //    DataTable admintable = SQLHelper.ExecuteReader(sql);

        //    return admintable;
        //}
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="adminData">admindata对象</param>
        /// <returns>result=0:登录失败，result=1：账号或密码不正确，result=2:登陆成功</returns>   
        public int Login(AdminData adminData)
        {
            int result = 0;
            string sql = @"select * from Admin where AdminNo=@AdminNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo",SqlDbType.NVarChar)
            };
            sqlParameter[0].Value = adminData.AdminNo;
            SqlDataReader reader = SQLHelper.ExecuteReader(sql,CommandType.Text,sqlParameter);
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    if (reader[1].ToString() == adminData.AdminPwd)
                    {
                        result = 2;
                        Keepinformation.AdminNo = adminData.AdminNo;
                        Keepinformation.AdminPwd = adminData.AdminPwd;
                        Keepinformation.AdminName= reader[2].ToString();
                        Keepinformation.AdminTitle = reader[3].ToString();
                        Keepinformation.AdminEmail = reader[4].ToString();
                    }
                    else result = 1;
                    
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        //未完成：
        #region 判断表中是否有该学号的存在 ExecutScale
        /// <summary>
        /// 判断表中是否有该主键的存在
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>false:数据库中没有该值，true：数据库中有该值</returns>
        public bool CheckNo(string id)
        {
            bool res;
            string sql = @"select * from StuNo=@StuNo";
            SqlParameter sqlParameter = new SqlParameter("@StuNo", SqlDbType.NVarChar);
            sqlParameter.Value = id;
            SqlDataReader sqlDataReader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameter);
            if (sqlDataReader.HasRows)
            {
                res = true;
            }
            else
                res = false;
            return res;
        }
        #endregion


        #region 双选匹配界面显示数据
        //学生列表
        public DataTable GetStuMatchtable()
        {
            DataTable table=new DataTable();
            string sql = @"select distinct(a.groupid) as 组号 ,a.membernum as 组内人数,a.leaderno as 组长学号,a.VolFirstId as 志愿一,a.VolSecondId as 志愿二,a.VolThirdId as 志愿三,
(select stuname from student where student.stuno=a.leaderno) as 组长姓名,
(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo) as 小组平均成绩
from grouptable a left join groupstu c
on a.GroupID = c.groupid ";

           table= SQLHelper.ExecuteQuery(sql);
            return table;
        }
        //教师列表
        public DataTable GetTeaMatchtable()
        {
            DataTable table = new DataTable();
            string sql = @"select distinct(b.teano) as 教师工号,b.teaname as 教师姓名,b.groupnumber as 所带组数, b.yppsm as 已匹配组数,
PARSENAME(stuff((select '.' + cast(a.groupid as char) from addgrid a  where a.teano = b.teano for xml path ('')),1,1,''),5) as 志愿小组一,
PARSENAME(stuff((select '.' + cast(a.groupid as char) from addgrid a  where a.teano = b.teano for xml path ('')),1,1,''),4) as 志愿小组二,
PARSENAME(stuff((select '.' + cast(a.groupid as char) from addgrid a  where a.teano = b.teano for xml path ('')),1,1,''),3) as 志愿小组三,
PARSENAME(stuff((select '.' + cast(a.groupid as char) from addgrid a  where a.teano = b.teano for xml path ('')),1,1,''),2) as 志愿小组四,
PARSENAME(stuff((select '.' + cast(a.groupid as char) from addgrid a  where a.teano = b.teano for xml path ('')),1,1,''),1) as 志愿小组五
from addgrid b ";
            table = SQLHelper.ExecuteQuery(sql);
            return table;

        }
        #endregion


    }
}

