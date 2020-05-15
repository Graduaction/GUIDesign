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

        #region 1.登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="StuNo">学号</param>
        /// <param name="StuPwd">密码</param>
        /// <returns>true:登录成功 false:登录失败</returns>
        public bool CheckStudentLogin(string StuNo, string StuPwd)
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
            catch (Exception ex)
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

        #region 执行学生修改密码
        /// <summary>
        /// 执行学生修改密码
        /// </summary>
        /// <param name="loginId">修改密码的学号</param>
        /// <param name="loginOPwd">学生的旧密码</param>
        /// <param name="loginNPwd">学生的新密码</param>
        /// <returns></returns>

        public bool ChangeStuPwd(string loginId, string loginOPwd, string loginNPwd)
        {
            bool flag;
            string sql = @"update Student set StuPwd=@loginNPwd where StuNo=@loginId and StuPwd=@loginOPwd";
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@loginOPwd",loginOPwd),
                new SqlParameter("@loginNPwd",loginNPwd)
            };
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text, paras);
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

        #region 2.1根据学号获取学生对象
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

        #region 2.2个人中心更新学生信息
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public int UpdateStu(StudentData studentData)
        {
            string sql = @"update  Student set  StuPhone=@StuPhone,StuQQ=@StuQQ,StuEmail=@StuEmail,StuPerIntro=@StuPerIntro,StuHonors=@StuHonors where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuPhone",SqlDbType.NVarChar),
                new SqlParameter("@StuQQ",SqlDbType.NVarChar),
                new SqlParameter("@StuEmail",SqlDbType.NVarChar),
                new SqlParameter("@StuPerIntro",SqlDbType.NVarChar),
                new SqlParameter("@StuHonors",SqlDbType.NVarChar),
                new SqlParameter("@StuNo",studentData.StuNo)
            };
            sqlParameter[0].Value = studentData.StuPhone;
            sqlParameter[1].Value = studentData.StuQQ;
            sqlParameter[2].Value = studentData.StuEmail;
            sqlParameter[3].Value = studentData.StuPerIntro;
            sqlParameter[4].Value = studentData.StuHonors;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region 3.1学生查看导师列表
        /// <summary>
        /// 学生查看导师列表
        /// </summary>
        /// <returns>导师表</returns>
        public DataTable StuCheckTeaList()
        {
            //string sql = @"select TeaNo as 工号,TeaName as 导师姓名,Title as 职称,GroupNumber as 可选组数,'选择' 操作1,'取消' 操作2 from Teacher";
            string sql = @"select TeaNo as 工号,TeaName as 导师姓名,Title as 职称,GroupNumber as 可选组数,(select count (*) from GroupTable where VolFirstId = Teacher.TeaNo) as 第一志愿已选人数 from Teacher";
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text);
            return dataTable;
        }
        #endregion

        #region 3.2学生查看导师简介
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

        #region 4.1学生查看通知
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

        #region 5.1判断学生是否创建过队伍
        /// <summary>
        /// 判断学生是否创建过队伍
        /// </summary>
        /// <param name="stuno">入参：当前学生学号</param>
        /// <returns>true:已组过队，false:未组过队</returns>
        public bool IsCreateGroup(string stuno)
        {
            string sql = @"select GroupID ,StuNo  from GroupStu where StuNo =@StuNo";
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

        #region 5.2学生创建队伍
        /// <summary>
        /// 学生创建队伍
        /// </summary>
        /// <returns>组队表</returns>
        public DataTable CreateGroup(string leaderno)
        {
            string sql = @"insert into GroupTable (leaderno) values (@leaderno) select GroupID,leaderno from GroupTable where leaderno=@leaderno";
            //string sql = @"insert into GroupTable (GroupID,leaderno) values (@GroupID,@leaderno) select GroupID,leaderno from GroupTable where leaderno=@leaderno";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@leaderno",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = leaderno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 5.3学生查看学生列表
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

        #region 5.4学生查看队伍列表
        /// <summary>
        /// 学生查看队伍列表
        /// </summary>
        /// <returns>队伍列表</returns>
        public DataTable CheckGroupList(string stuno)
        {
            string sql = @"select b.GroupID as 组号,b.StuNo as 学号,b.StuName as 姓名 from GroupStu a right join Student b on a.GroupID = b.GroupID where a.StuNo=@StuNo";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
           };
            sqlParameters[0].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 5.5判断学生是否是队长
        /// <summary>
        /// 判断学生是否是队长
        /// </summary>
        /// <param name="stuno">入参：当前学生学号</param>
        /// <returns>true:是队长，false:不是队长</returns>
        public bool IsLeader(string stuno)
        {
            string sql = @"select GroupID ,leaderno  from GroupTable where leaderno =@StuNo 
";
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

        #region 5.6选择组员
        /// <summary>
        /// 选择组员
        /// </summary>
        /// <returns>组员表</returns>
        public DataTable SelectGroupStu(int groupid, string stuno)
        {
            string sql = @"insert into GroupStu (GroupID,StuNo) values (@GroupID,@StuNo) select GroupID as 组号,StuNo as 学号,StuName as 姓名 from Student where GroupID=@GroupID";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@GroupID",SqlDbType.Int),
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = groupid;
            sqlParameters[1].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 5.7删除组员
        /// <summary>
        /// 删除组员
        /// </summary>
        /// <returns>组员表</returns>
        public DataTable DelGroupStu(int groupid, string stuno)
        {
            string sql = @"delete from GroupStu where GroupID =@GroupID and StuNo = @StuNo select a.GroupID as 组号, a.StuNo as 学号 ,b.StuName as 姓名 from  GroupStu a  inner join Student b on a.GroupID=@GroupID and a.StuNo=b.StuNo ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@GroupID",SqlDbType.Int),
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = groupid;
            sqlParameters[1].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 6.1选择志愿
        /// <summary>
        /// 选择志愿
        /// </summary>
        /// <returns>小组志愿列表更新所影响的行数</returns>
        public int SelectVol(GroupTableData groupTableData)
        {
            string sql = @"update GroupTable set VolFirstId=@VolFirstId,VolSecondId=@VolSecondId,VolThirdId=@VolThirdId,Topic=@Topic where leaderno = @leaderno";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@VolFirstId",SqlDbType.NVarChar),
                new SqlParameter("@VolSecondId",SqlDbType.NVarChar),
                new SqlParameter("@VolThirdId",SqlDbType.NVarChar),
                new SqlParameter("@Topic",SqlDbType.NVarChar),
                new SqlParameter("@leaderno",SqlDbType.NVarChar),
           };
            sqlParameters[0].Value = groupTableData.VolFirstId;
            sqlParameters[1].Value = groupTableData.VolSecondId;
            sqlParameters[2].Value = groupTableData.VolThirdId;
            sqlParameters[3].Value = groupTableData.Topic;
            sqlParameters[4].Value = groupTableData.Leaderno;
            int res = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
            return res;
        }
        #endregion

        #region 6.2学生查看志愿列表
        /// <summary>
        /// 学生查看志愿列表
        /// </summary>
        /// <returns>志愿  列表</returns>
        public DataTable CheckMyVol(string stuno)
        {
            string sql = @"select a.TeaNo, a.TeaName,a.Contaction,a.Email,b.VolFirstId,b.VolSecondId ,b.VolThirdId ,' ' 志愿序号,' '  志愿状态 from Teacher a left join GroupTable b on a.TeaNo=b.VolFirstId or a.TeaNo=b.VolSecondId or a.TeaNo=b.VolThirdId where b.GroupID =(select GroupID from GroupStu where StuNo = @StuNo)";
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@StuNo",SqlDbType.NVarChar)
           };
            sqlParameters[0].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 7.1查看双选结果的导师
        /// <summary>
        /// 查看双选结果的导师
        /// </summary>
        /// <param name="stuno">入参：当前学生学号</param>
        public DataTable MyMentor(string stuno)
        {
            string sql = @"select a.TeacherNo from Result a left join GroupTable b on a.GroupID=b.GroupID left join GroupStu c on c.GroupID=b.GroupID where c.StuNo=@StuNo";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@StuNo",SqlDbType.NVarChar)
            };
            sqlParameters[0].Value = stuno;
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text, sqlParameters);
            return dataTable;
        }
        #endregion

        #region 8.1获取系统开放时间
        /// <summary>
        /// 获取系统开放时间
        /// </summary>
        public DataTable GetOpenTime()
        {
            string sql = @"select StartTime,EndTime from Manage";
            DataTable dataTable = SQLHelper.ExecuteDataTable(sql, CommandType.Text);
            return dataTable;
        }
        #endregion
    }
}
