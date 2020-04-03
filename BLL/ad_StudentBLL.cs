using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ad_StudentBLL
    {
        private ad_StudentDAL sDAL = new ad_StudentDAL();
       
        public DataTable Select()
        {
            return sDAL.Select();
        }
        public bool Insert(StudentData studentData)
        {
            //sql语句，SQL语句类型，参数数组

            int result = sDAL.Insert(studentData);
            if (result != 0)
            {
                return true;//插入成功
            }
            else
            {
                return false;//插入失败
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="strcolum"></param>
        /// <param name="value"></param>
        /// <param name="strrow"></param>
        /// <returns></returns>
        public int Update(StudentData studentData)
        {
            ad_StudentDAL ad_StudentDAL = new ad_StudentDAL();
            return ad_StudentDAL.Update(studentData);
        }

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">学生id</param>
        /// <returns>返回true or false</returns>
        public bool Remove(string id)
        {

            return sDAL.DeleteById(id);
        }
        #endregion



        #region check
        public bool Check(string id)
        {
            return sDAL.CheckNo(id);
        }
        #endregion


        public DataTable importToExcel(string filePath)
        {
             //return sDAL.importFile(sql,filePath);
            Transferfile transferfile = new Transferfile();
            return transferfile.ExcelSheetImportToDataTable(filePath);
        }


        public void DataTableToSQLServer(DataTable dt)
        {
            sDAL.DataTableToSQLServer(dt);
        }
    }
}
