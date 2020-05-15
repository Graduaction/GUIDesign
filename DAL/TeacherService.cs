using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TeacherService
    {
        #region 数据库连接字符串
        public static string connStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
        #endregion

        #region 执行教师登入检查--检查输入的账号密码有没有在数据库对应
        /// <summary>
        /// 执行教师登入检查
        /// </summary>
        /// <param name="loginId">用户id</param>
        /// <param name="loginPwd">用户密码</param>
        /// <returns>true：登入成功  flase：反则</returns>
        public bool CheckTeacherLogin(string loginId, string loginPwd)
        {
            bool flag = false;
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Teacher");
            sb.AppendLine("where TeaNo=@loginId and TeaPwd=@loginPwd");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@loginPwd",loginPwd)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //创建执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //设置执行工具的参数
                cmd.Parameters.AddRange(paras);
                //打开链接
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
            //flag=true 代表登入成功>>reader找得到则flag=true
        }
        #endregion
        
        #region 执行教师修改密码
        /// <summary>
        /// 执行教师修改密码
        /// </summary>
        /// <param name="loginId">修改密码的教师工号</param>
        /// <param name="loginOPwd">教师的旧密码</param>
        /// <param name="loginNPwd">教师的新密码</param>
        /// <returns></returns>
        
        public bool ChangeTeaPwd(string loginId, string loginOPwd,string loginNPwd)
        {
            bool flag = false;
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update Teacher set TeaPwd=@loginNPwd");
            sb.AppendLine("where TeaNo=@loginId and TeaPwd=@loginOPwd");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@loginOPwd",loginOPwd),
                new SqlParameter("@loginNPwd",loginNPwd)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //创建执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //设置执行工具的参数
                cmd.Parameters.AddRange(paras);
                //打开链接
                conn.Open();
                //执行
                ///SqlDataReader reader = cmd.ExecuteReader();
                int syxhs = cmd.ExecuteNonQuery();///executenonquery 函数返回受影响的行数
                //判断
                if (syxhs>0)
                {
                    flag = true;
                }
                //reader.Close();

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
            //flag=true 代表受影响行数大于1，表示有一个或一个以上的记录更改
        }

        #endregion

        #region 显示教师的个人信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teaNo">教师工号 由登入时输入text的账号所得</param>
        /// <returns></returns>
       public DataTable Getperson(string teaNo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select TeaNo,TeaName,Title,Contaction,Gender,Profile ,groupnumber ,email from Teacher");
            sb.AppendLine("where TeaNo =@teaNo");
            SqlParameter[] paras ={ new SqlParameter("@teaNo",teaNo) };
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(),conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        #endregion

        #region 执行教师修改个人信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teaNo"></param>
        /// <param name="teaName"></param>
        /// <param name="teaTitle"></param>
        /// <param name="teaPhone"></param>
        /// <param name="teaProfile"></param>
        /// <returns>返回flag=true说明re受影响的行数=1，说明更新一条记录</returns>
        public bool UpdateTea(string teaNo,string teaName,string teaTitle,string teaPhone,string teaProfile,string email)
        {
            bool flag = false;
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update Teacher set TeaName=@teaname,Title=@teatitle,Contaction=@phone,Profile=@jxuk,Email=@teaemail");
            sb.AppendLine("where TeaNo=@loginId");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",teaNo),
                new SqlParameter("@teaname",teaName),
                new SqlParameter("@teatitle",teaTitle),
                new SqlParameter("@phone",teaPhone),
                new SqlParameter("@jxuk",teaProfile),
                new SqlParameter("@teaemail",email)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                //创建执行工具
                SqlCommand cmdd = new SqlCommand(sb.ToString(), conn);
                //设置执行工具的参数
                cmdd.Parameters.AddRange(paras);
                //打开链接
                conn.Open();
                //执行
                int syxhss = cmdd.ExecuteNonQuery();///executenonquery 函数返回受影响的行数
                //判断
                if (syxhss > 0)
                {
                    flag = true;
                }

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

        #region 查询显示通知表 通知标题等 
        public DataTable selectNote()
        {
            string sql = "select infono as 序号,infotitle as 标题,(select Adminname from Admin b where  a.Adminno =b.AdminNo)as 发布人,infotime as 发布时间 from information a";
            DataTable notetable = SQLHelper.ExecuteQuery(sql);
            return notetable;
        }
        #endregion

       
        #region 获取通知详情
        public DataTable GetInfoDetail(string infono)
        {
            string sql = "select InfoTitle,InfoContent,InfoTime from Information where InfoNo=@infono";
            SqlParameter[] paras = { new SqlParameter("@infono", infono) };
            DataTable infode = SQLHelper.ExecuteQuery(sql, paras);
            return infode;
        }
        #endregion

        #region 从“小红1234”获取到1234
        public string getstuno(string info)
        {
            string sno = null;
            string sql = @"select dbo.f_GetNum(@info)";
            SqlParameter[] paras = { new SqlParameter("@info", SqlDbType.NVarChar) };
            paras[0].Value = info;
            sno = (string)SQLHelper.ExecuteScalar(sql, CommandType.Text, paras);
            return sno;
        }
        #endregion


        #region 显示当前教师账号的所带组员列表(我的学生

        public DataTable selectMyStu(string teano)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("exec getmystu_procedure @teano");
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        public static DataSet dsvol = new DataSet();
        /*DataTable dtStuVol = dsvol.Tables.Add("StuVol");*///拉取数据库中的内容 放在这个datatable  显示在datagridview 中
        //DataTable dtTeaVol = dsvol.Tables.Add("TeaVol");//把教师选择的志愿信息 放在这个datatable 中，连接到数据库，一次性提交到数据库
       
        #region 查询显示所有学生组的志愿和组员姓名
        public DataTable selectStuVol1()
        {
            string sql = "select d.groupid as 组号,d.topic as 论文选题,c.avg_grade as 平均综测,(select teaname from teacher where teano = d.volfirstid) as 第一志愿,(select teaname from teacher where teano = d.volsecondid)as 第二志愿,(select teaname from teacher where teano = d.volthirdid)as 第三志愿,'选择' 操作1,'取消'  操作2,(select stuname from  student a where a.StuNo = b.stuno1)+b.stuno1  as 组员1 ,(select stuname from student a where a.StuNo = b.stuno2)+b.stuno2  as 组员2 ,(select stuname from student a where a.StuNo = b.stuno3)+b.stuno3  as 组员3 ,(select stuname from student a where a.StuNo = b.stuno4)+b.stuno4  as 组员4 ,(select stuname from student a where a.StuNo = b.stuno5)+b.stuno5 as 组员5 from grouptable d left join getgroupstuno b on b.groupid = d.GroupId left join avg_groupgrade c on d.groupid = c.groupid order by d.groupid asc";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtStuVol1 = new DataTable();
                sda.Fill(dtStuVol1);
                return dtStuVol1;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //DataTable dt = SQLHelper.ExecuteQuery(sql);
            //return dt;
        }
        #endregion


        #region 获取teavolheng表 一轮志愿教师表 存入一个datatable
        public DataTable dtTeaVol(string teano)
        {

            DataTable dtTeaVol = new DataTable();
            string sql = "select * from TeaVolheng where teano=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano",teano) };
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.AddRange(paras);
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtTeaVol);
                return dtTeaVol;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 向数据库提交datatable的更新一轮志愿的表teavolheng
        public int updateTV(DataTable dt)
        {
            string sql = "select * from teavolheng";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sda);
            //sda.Update(dt);
            return sda.Update(dt);
        }
        #endregion

        #region 查找当前登录的教师工号的可带人数
        public int GetGroupNum(string teano)
        {
            string sql = "select GroupNumber from Teacher where TeaNo=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            int re = (int)SQLHelper.ExecuteScalar(sql, CommandType.Text, paras);
            return re;

        }
        #endregion

        #region 查找当前时间双选结果表内记录数
        public int GetResultNum()
        {
            string sql = "select count(*) from result";
            int re = (int)SQLHelper.ExecuteScalar(sql, CommandType.Text);
            return re;

        }
        #endregion

        #region 查看一轮匹配后当前登录的教师工号的已匹配组数
        public int GetyipipeiNum(string teano)
        {
            string sql = "select count(*) from result  where TeacherNo=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            int re = (int)SQLHelper.ExecuteScalar(sql, CommandType.Text, paras);
            return re;
        }
        #endregion

        #region 查询显示所有漏选学生的志愿和组员姓名  
        public DataTable selectlxStu()
        {
            string sql = "select d.groupid as 组号,d.topic as 论文选题,c.avg_grade as 平均综测,(select teaname from teacher where teano = d.volfirstid) as 第一志愿,(select teaname from teacher where teano = d.volsecondid)as 第二志愿,(select teaname from teacher where teano = d.volthirdid)as 第三志愿,'选择' 操作1,'取消'  操作2,(select stuname from  student a where a.StuNo = b.stuno1)+b.stuno1  as 组员1 ,(select stuname from student a where a.StuNo = b.stuno2)+b.stuno2  as 组员2 ,(select stuname from student a where a.StuNo = b.stuno3)+b.stuno3  as 组员3 ,(select stuname from student a where a.StuNo = b.stuno4)+b.stuno4  as 组员4 ,(select stuname from student a where a.StuNo = b.stuno5)+b.stuno5 as 组员5 from GroupNoinResult d left join getgroupstuno b on b.groupid = d.GroupId left join avg_groupgrade c on d.groupid = c.groupid order by c.avg_grade desc";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtStuVol2 = new DataTable();
                sda.Fill(dtStuVol2);
                return dtStuVol2;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //DataTable dt = SQLHelper.ExecuteQuery(sql);
            //return dt;
        }
        #endregion
        
        #region 获取teavolheng2表 二轮志愿教师表 存入一个datatable
        public DataTable dtTeaVol2(string teano)
        {

            DataTable dtTeaVol = new DataTable();
            string sql = "select * from TeaVolheng2 where teano=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(paras);
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtTeaVol);
                return dtTeaVol;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 向数据库提交datatable的更新二轮志愿的表teavolheng2
        public int updateTV2(DataTable dt)
        {
            string sql = "select * from teavolheng2";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sda);
            //sda.Update(dt);
            return sda.Update(dt);
        }
        #endregion
    }
}
