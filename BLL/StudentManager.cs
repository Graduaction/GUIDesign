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

        #region 个人中心更新学生信息
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

        #region 学生查看教师列表
        /// <summary>
        /// 学生查看教师列表
        /// </summary>
        /// <returns>教师表</returns>
        public DataTable StuCheckTeaList()
        {
            return ss.StuCheckTeaList();
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
            return ss.CheckMentorByNo(teaNo);
        }
        #endregion

        #region 学生查看通知
        /// <summary>
        /// 学生查看查看通知
        /// </summary>
        /// <returns>通知表</returns>
        public DataTable CheckNotification()
        {
            return ss.CheckNotification();
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
            return ss.IsCreateGroup(stuno);
        }
        #endregion

        #region 学生创建队伍
        /// <summary>
        /// 学生创建队伍
        /// </summary>
        /// <returns>组队表</returns>
        public DataTable CreateGroup(string stuNo)
        {
            return ss.CreateGroup(stuNo);
        }
        #endregion

        #region 学生查看学生列表
        /// <summary>
        /// 学生查看学生列表
        /// </summary>
        /// <returns>学生列表</returns>
        public DataTable CheckStuList()
        {
            return ss.CheckStuList();
        }
        #endregion

        #region 学生查看队伍列表
        /// <summary>
        /// 学生查看队伍列表
        /// </summary>
        /// <returns>队伍列表</returns>
        public DataTable CheckGroupList(string stuno)
        {
            return ss.CheckGroupList(stuno);
        }
        #endregion

        #region 选择组员
        /// <summary>
        /// 选择组员
        /// </summary>
        /// <returns>组员表</returns>
        public DataTable SelectGroupStu(int groupid, string stuno)
        {
            return ss.SelectGroupStu(groupid,stuno);
        }
        #endregion
    }
}
