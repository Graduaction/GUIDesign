﻿using System;
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

    }
}