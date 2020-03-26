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

        #region 检查学号是否存在
        /// <summary>
        /// 检查学号是否存在
        /// </summary>
        /// <param name="StuNo">学号</param>
        /// <returns>true:存在 false:不存在</returns>
        public bool CheckStudentIsExists(string StuNo) 
        {
            bool flag = false;//学号是否存在的标志，初始值为false，不存在
            //sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select COUNT(*)");
            sb.AppendLine("from Student");
            sb.AppendLine("where StuNo=@StuNo");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@StuNo",StuNo)
            };
            //连接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //执行工具（sql语句，连接对象）
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //添加参数
                cmd.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                //判断
                if (result > 0)
                {
                    flag = true;//学号存在
                }
            }
            catch(Exception ex)
            {

                throw ex;//发生异常时抛出
            } 
            finally
            {
                conn.Close();//最后关闭数据库
            }
            return flag;//学号不存在
        }
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
        /// 根据学号获取学生对象
        /// </summary>
        /// <param name="StuNo"></param>
        /// <returns></returns>
        public StudentData GetStudentByNo(string StuNo)
        {
            StudentData stu = null;
            //sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Student");
            sb.AppendLine("where StuNo = @StuNo");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@StuNo",StuNo)
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
                    stu = new StudentData
                    {
                        StuNo = Convert.ToString(reader["StuNo"]),
                        StuPwd = Convert.ToString(reader["StuPwd"]),
                        StuName = Convert.ToString(reader["StuName"]),
                        StuSex = Convert.ToString(reader["StuSex"]),
                        Academy = Convert.ToString(reader["Academy"]),
                        Profession = Convert.ToString(reader["Profession"]),
                        Grade = Convert.ToInt32(reader["Grade"]),
                        GroupID = Convert.ToInt32(reader["GroupID"]),
                        VoluntaryFirst = Convert.ToString(reader["VoluntaryFirst"]),
                        VoluntarySecond = Convert.ToString(reader["VoluntarySecond"]),
                        VoluntaryThird = Convert.ToString(reader["VoluntaryThird"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return stu;
        }
        #endregion

        #region !! 新增学生

        #endregion

        #region !! 更改学生信息

        #endregion

        #region !! 根据学号删除学生信息
        #endregion

        #region 获取学生全部信息
        /// <summary>
        /// 获取学生全部信息
        /// </summary>
        /// <returns>学生集合</returns>
        public List<StudentData> GetStudentDatas()
        {
            List<StudentData> students = new List<StudentData>();
            //sql语句
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Student");
            //连接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //打开连接
                conn.Open();
                //执行
                SqlDataReader reader = cmd.ExecuteReader();
                //判断
                while (reader.Read())
                {
                    StudentData student = new StudentData
                    {
                        StuNo = Convert.ToString(reader["StuNo"]),
                        StuPwd = Convert.ToString(reader["StuPwd"]),
                        StuName = Convert.ToString(reader["StuName"]),
                        StuSex = Convert.ToString(reader["StuSex"]),
                        Academy = Convert.ToString(reader["Academy"]),
                        Profession = Convert.ToString(reader["Profession"]),
                        Grade = Convert.ToInt32(reader["Grade"]),
                        GroupID = Convert.ToInt32(reader["GroupID"]),
                        VoluntaryFirst = Convert.ToString(reader["VoluntaryFirst"]),
                        VoluntarySecond = Convert.ToString(reader["VoluntarySecond"]),
                        VoluntaryThird = Convert.ToString(reader["VoluntaryThird"])
                    };
                    students.Add(student);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return students;
        }
        #endregion

        #region !! 根据姓名和年级条件查询学生信息
        #endregion

    }
}
