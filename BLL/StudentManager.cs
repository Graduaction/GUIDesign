using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class StudentManager
    {

        #region 变量, 常量的定义
        readonly StudentService ss = new StudentService();
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="StuNo">学号</param>
        /// <param name="StuPwd">密码</param>
        /// <returns>true:登录成功 false:登录失败</returns>
        public bool CheckStudentLogin(string StuNo, string StuPwd)
        {
            try
            {
                return ss.CheckStudentLogin(StuNo, StuPwd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
