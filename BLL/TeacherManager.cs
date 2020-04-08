using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class TeacherManager
    {
        #region 常量变量定义
        TeacherService ts = new TeacherService();

        #endregion

        #region 执行教师登入检查
        /// <summary>
        /// 执行教师登入检查
        /// </summary>
        /// <param name="loginId">用户id</param>
        /// <param name="loginPwd">用户密码</param>
        /// <returns>true：登入成功  flase：反则</returns>
        public bool CheckTeacherLogin(string loginId, string loginPwd)
        {
            try
            {
                return ts.CheckTeacherLogin(loginId, loginPwd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 修改密码
        public bool ChangeTeaPwd(string loginId, string loginOPwd, string loginNPwd)
        {
            try
            {
                return ts.ChangeTeaPwd(loginId, loginOPwd, loginNPwd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 获取教师个人信息
        public DataTable Getperson(string teaNo)
        {
            try
            {
                return ts.Getperson(teaNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 修改教师个人信息
        public bool UpdateTea(string teaNo, string teaName, string teaTitle, string teaPhone, string teaProfile,string email)
        {
            try
            {
                return ts.UpdateTea(teaNo, teaName, teaTitle, teaPhone, teaProfile,email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 查询通知表 通知标题等
        public DataTable selectNote()
        {
            return ts.selectNote();
        }
        #endregion

        #region 显示通知详细内容
        public DataTable GetInfoDetail(string infono)
        {
            return ts.GetInfoDetail(infono);
        }
        #endregion

        #region 显示我的学生
        public DataTable selectMyStu(string teano)
        {
            return ts.selectMyStu(teano);
        }

        #endregion

        #region 从
        public string getstuno(string info)
        {
            return ts.getstuno(info);
        } 
        #endregion


    }
}
