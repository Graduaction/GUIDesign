using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{   
    /// <summary>
    /// 学生信息
    /// </summary>
    public class StudentService
    {
        #region 数据库连接字符串
        public static string connStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="StuNo">学号</param>
        /// <param name="StuPwd">密码</param>
        /// <returns>true:登录成功 false:登录失败</returns>
        public bool CheckStudentLogin(string StuNo ,string StuPwd)
        {
            bool flag = false;
            //sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Student");
            sb.AppendLine("where StuNo = @StuNo and StuPwd = @StuPwd");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@StuNo",StuNo),
                new SqlParameter("@StuPwd",StuPwd),
            };
            //连接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //添加参数
                cmd.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                SqlDataReader reader = cmd.ExecuteReader();
                //判断
                if (reader.Read())
                {
                    flag = true;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        #endregion

        #region 根据学号获取学生对象
        /// <summary>
        /// 根据学号获取学生信息
        /// </summary>
        /// <param name="StuNo">学号</param>
        /// <returns>返回学生表</returns>
        public DataTable GetStudentByNo(string stuNo)
        {
            try
            {
                string sql = @"select * from Student where StuNo = @StuNo";
                SqlParameter[] paras =
                {
                new SqlParameter("@StuNo",stuNo)
                };
                DataTable dataTable = SQLHelper.ExecuteQuery(sql, paras);
                return dataTable;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 个人中心更新学生信息
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdateStu(StudentData studentData)
        {
            string sql = @"update  Student set  StuPhone=@StuPhone,StuQQ=@StuQQ,StuEmail=@StuEmail,StuPerIntro=@StuPerIntro,StuHonors=@StuHonors,StuPwd=@StuPwd where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuPhone",SqlDbType.NVarChar),
                new SqlParameter("@StuQQ",SqlDbType.NVarChar),
                new SqlParameter("@StuEmail",SqlDbType.NVarChar),
                new SqlParameter("@StuPerIntro",SqlDbType.NVarChar),
                new SqlParameter("@StuHonors",SqlDbType.NVarChar),
                new SqlParameter("@StuPwd",SqlDbType.NVarChar),
                new SqlParameter("@StuNo",studentData.StuNo)
            };
            sqlParameter[0].Value = studentData.StuPhone;
            sqlParameter[1].Value = studentData.StuQQ;
            sqlParameter[2].Value = studentData.StuEmail;
            sqlParameter[3].Value = studentData.StuPerIntro;
            sqlParameter[4].Value = studentData.StuHonors;
            sqlParameter[5].Value = studentData.StuPwd;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region 学生查看导师列表
        /// <summary>
        /// 学生查看导师列表
        /// </summary>
        /// <returns>导师表</returns>
        public DataTable StuCheckTeaList()
        {
            string sql = @"select * from Teacher";
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql,CommandType.Text);
            return dataTable;
        }
        #endregion

        #region 学生查看导师简介
        /// <summary>
        /// 学生查看导师简介
        /// </summary>
        /// <param name="teaNo">工号</param>
        /// <returns>导师表</returns>
        public DataTable CheckMentorByNo(string teaNo)
        {
            string sql = @"select * from Teacher where TeaNo=@TeaNo";
            SqlParameter[] sqlParameter =
            {
                new SqlParameter("@TeaNo", teaNo)
            };
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameter);
            return dataTable;
        }
        #endregion

        #region 学生查看通知
        /// <summary>
        /// 学生查看查看通知
        /// </summary>
        /// <returns>通知表</returns>
        public DataTable CheckNotification()
        {
            string sql = @"select * from Information";
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text);
            return dataTable;
        }
        #endregion

        #region 判断学生是否创建过队伍
        /// <summary>
        /// 判断学生是否创建过队伍
        /// </summary>
        /// <param name="stuno">入参：当前学生学号</param>
        /// <returns>true:已组过队，false:未组过队</returns>
        public bool IsCreateGroup(string stuno)
        {
            string sql = @"select GroupID ,StuNo  from GroupStu where StuNo = @StuNo";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@StuNo",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = stuno;
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameters);
            bool flag;
            if (reader.Read())
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 学生创建队伍
        /// <summary>
        /// 学生创建队伍
        /// </summary>
        /// <returns>组队表</returns>
        public DataTable CreateGroup(string leaderno)
        {
            string sql = @"insert into GroupTable (leaderno) values (@leaderno) select GroupID,leaderno from GroupTable where leaderno=@leaderno";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@leaderno",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = leaderno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql,CommandType.Text,sqlParameters);
            return dataTable;
        }
        #endregion

        #region 学生查看学生列表
        /// <summary>
        /// 学生查看学生列表
        /// </summary>
        /// <returns>学生列表</returns>
        public DataTable CheckStuList()
        {
            string sql = @"select StuNo as 学号,StuName as 姓名 from Student";
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text);
            return dataTable;
        }
        #endregion

        #region 学生查看队伍列表
        /// <summary>
        /// 学生查看队伍列表
        /// </summary>
        /// <returns>队伍列表</returns>
        public DataTable CheckGroupList(string stuno)
        {
            string sql = @"select GroupID as 组号, StuNo as 学号,StuName as 姓名 from Student where GroupID =(select GroupID from GroupStu where StuNo = @StuNo)";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
           };
            sqlParameters[0].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 选择组员
        /// <summary>
        /// 选择组员
        /// </summary>
        /// <returns>组员表</returns>
        public DataTable SelectGroupStu(int groupid,string stuno)
        {
            string sql = @"insert into GroupStu (GroupID,StuNo) values (@GroupID,@StuNo) select GroupID as 组号,StuNo as 学号,StuName as 姓名 from Student where GroupID=@GroupID";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@GroupID",SqlDbType.Int),
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = groupid;
            sqlParameters[1].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text,sqlParameters);
            return dataTable;
        }
        #endregion
    }
}
