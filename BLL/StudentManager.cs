using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

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
                return ss.GetStudentByNo(stuNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 个人中心插入学生信息
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public bool UpdateStu(StudentData studentData)
        {
            int result = ss.UpdateStu(studentData);
            if (result != 0)
            {
                return true;//插入成功
            }
            else
            {
                return false;//插入失败
            }
        }
        #endregion
    }
}
