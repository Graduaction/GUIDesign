using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLL
{
    public class ad_ServicesBLL
    {
        private ad_ServicesDAL sDAL = new ad_ServicesDAL();

        #region 查询学生信息
        public DataTable SelectStubll()
        {
            return sDAL.SelectStu();
        }
        #endregion

        #region 查询教师信息
        public DataTable SelectTeabll()
        {
            return sDAL.SelectTea();
        }
        #endregion

        #region 学生表插入数据
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="studentData">传参：学生对象</param>
        /// <returns>成功：返回true，失败：返回false</returns>
        public bool InsertStubll(StudentData studentData)
        {
            int result = sDAL.InsertStu(studentData);
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

        #region 教师表插入数据
        /// <summary>
        /// 教师表插入数据
        /// </summary>
        /// <param name="teacherData">传参：教师对象</param>
        /// <returns>成功：返回true，失败：返回false</returns>
        public bool InsertTeabll(TeacherData teacherData)
        {
            int result = sDAL.InsertTea(teacherData);
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

        #region 学生表更新
        /// <summary>
        /// 学生表更新
        /// </summary>
        /// <param name="studentData">传参：学生对象</param>
        /// <returns></returns>
        public int UpdateStudatabll(StudentData studentData)
        {
            ad_ServicesDAL ad_StudentDAL = new ad_ServicesDAL();
            return ad_StudentDAL.UpdateStudata(studentData);
        }
        #endregion

        #region 教师表更新
        /// <summary>
        /// 教师表更新
        /// </summary>
        /// <param name="teacherData">传参：教师对象</param>
        /// <returns></returns>
        public int UpdateTeadatabll(TeacherData teacherData)
        {
            ad_ServicesDAL ad_StudentDAL = new ad_ServicesDAL();
            return ad_StudentDAL.UPdateTeadata(teacherData);
        }
        #endregion

        #region 删除学生数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns>返回true or false</returns>
        public bool RemoveStudata(string StuNo)
        {

            return sDAL.DeleteBystuNo(StuNo);
        }
        #endregion
        #region 删除教师数据
        public bool RemoveTeadata(string TeaNo)
        {
            return sDAL.DaleteByteaNo(TeaNo);
        }
        #endregion
        #region check
        public bool Check(string id)
        {
            return sDAL.CheckNo(id);
        }
        #endregion

        #region 从Excel导入到datatable
        /// <summary>
        /// 从Excel导入到datatable
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回datatable</returns>
        public DataTable importToExcel(string filePath)
        {
            //return sDAL.importFile(sql,filePath);
            Transferfile transferfile = new Transferfile();
            return transferfile.ExcelSheetImportToDataTable(filePath);
        }
        #endregion

        #region 将学生DataTable数据导入到数据库
        /// <summary>
        /// 将DataTable数据导入到数据库
        /// </summary>
        /// <param name="dt">参数：datatable</param>
        public void DataTableToStuSQLServerbll(DataTable dt)
        {
            sDAL.DataTableToStuSQLServer(dt);
        }
        #endregion

        #region 将教师DataTable数据导入到数据库
        /// <summary>
        /// 将DataTable数据导入到数据库
        /// </summary>
        /// <param name="dt">参数：datatable</param>
        public void DataTableToTeaSQLServerbll(DataTable dt)
        {
            sDAL.DataTableToTeaSQLServer(dt);
        }

        #endregion


        #region 登录
        
        public int CheckAdminLogin(AdminData adminData)
        {
            return sDAL.Login(adminData);
        }
        #endregion

        #region 个人信息页
        public int Updataadmbll(AdminData adminData)
        {
            if(sDAL.UpdataAdmdata(adminData)==1)
            {
                Keepinformation.AdminEmail = adminData.AdminEmail;
                Keepinformation.AdminTitle = adminData.AdminTitle;
                Keepinformation.AdminPwd = adminData.AdminPwd;
            }
            return sDAL.UpdataAdmdata(adminData);
        }
        #endregion

        #region 设置双选参数
        public int Setparambll(ManageData manageData)
        {
            int result =sDAL.InsertManage(manageData);
            return result;
        }
        #endregion

        #region 查询双选参数信息
        public int SelectManagebll(string adminno1)
        {
            return sDAL.SelectManage(adminno1);
        }
        #endregion
    }
}
