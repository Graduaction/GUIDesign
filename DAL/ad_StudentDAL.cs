using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;


namespace DAL
{
    public class ad_StudentDAL
    {
        #region select查询数据
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns>返回datatable</returns>
        public DataTable Select()
        {
            string sql = "select StuNo as 学生学号,StuName as 学生姓名,StuNianji as 学生年级,Academy as 学生学院,Profession as 学生专业,StuClass as 学生班级,Grade as 学生综测 from Student";
            DataTable stendentTable = SQLHelper.ExecuteQuery(sql);
            return stendentTable;
        }
        #endregion

        #region insert插入数据
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public int Insert(StudentData studentData)
        {
            string sql = @"insert into Student (StuNo,StuPwd,StuName,Academy,Profession,Grade,StuNianji,StuClass) values(@StuNo,@StuPwd,@StuName,@Academy,@Profession,@Grade,@StuNianji,@StuClass)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.NVarChar),
                new SqlParameter("@StuPwd",SqlDbType.NVarChar),
                new SqlParameter("@StuName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@Profession",SqlDbType.NVarChar),
                new SqlParameter("@Grade",SqlDbType.Int),
                new SqlParameter("@StuNianji",SqlDbType.NVarChar),
                new SqlParameter("@StuClass",SqlDbType.Int)
            };
            sqlParameter[0].Value = studentData.StuNo;
            sqlParameter[1].Value = studentData.StuPwd;
            sqlParameter[2].Value = studentData.StuName;
            sqlParameter[3].Value = studentData.Academy;
            sqlParameter[4].Value = studentData.Profession;
            sqlParameter[5].Value = studentData.Grade;
            sqlParameter[6].Value = studentData.StuNianji;
            sqlParameter[7].Value = studentData.StuClass;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region 根据StuNo 删除数据
        public bool DeleteById(string StuNo)
        {
            string strSql = "delete from Student where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.VarChar)
            };
            sqlParameter[0].Value = StuNo;
            return SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, sqlParameter) > 0;
        }

        #endregion

        #region 修改数据
        public int Update(StudentData studentData)
        {
            string sql = @"update  Student set StuPwd=@StuPwd,StuName=@StuName,Academy=@Academy,Profession=@Profession,Grade=@Grade,StuNianji=@StuNianji,StuClass=@StuClass where StuNo=@StuNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@StuNo",SqlDbType.NVarChar),
                new SqlParameter("@StuPwd",SqlDbType.NVarChar),
                new SqlParameter("@StuName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@Profession",SqlDbType.NVarChar),
                new SqlParameter("@Grade",SqlDbType.Int),
                new SqlParameter("@StuNianji",SqlDbType.NVarChar),
                new SqlParameter("@StuClass",SqlDbType.Int)
            };
            sqlParameter[0].Value = studentData.StuNo;
            sqlParameter[1].Value = studentData.StuPwd;
            sqlParameter[2].Value = studentData.StuName;
            sqlParameter[3].Value = studentData.Academy;
            sqlParameter[4].Value = studentData.Profession;
            sqlParameter[5].Value = studentData.Grade;
            sqlParameter[6].Value = studentData.StuNianji;
            sqlParameter[7].Value = studentData.StuClass;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        //未完成：
        #region 判断表中是否有该学号的存在 ExecutScale
        /// <summary>
        /// 判断表中是否有该主键的存在
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>false:数据库中没有该值，true：数据库中有该值</returns>
        public bool CheckNo(string id)
        {
            bool res;
            string sql = @"select * from StuNo=@StuNo";
            SqlParameter sqlParameter = new SqlParameter("@StuNo", SqlDbType.NVarChar);
            sqlParameter.Value = id;
            SqlDataReader sqlDataReader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameter);
            if (sqlDataReader.HasRows)
            {
                res = true;
            }
            else
                res = false;
            return res;
        }
        #endregion

        //导入excel文件功能
        public DataTable importFile(string sql, string filePath)
        {
            
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();            
            using (SqlConnection conn=SQLHelper.createConnection())
            {                
                using (SqlCommand cmd =conn.CreateCommand())
                {                    
                    sqlDataAdapter.SelectCommand.CommandText = sql;
                    SqlCommandBuilder scb = new SqlCommandBuilder(sqlDataAdapter);
                    Transferfile transferfile = new Transferfile();
                    dataTable = transferfile.ExcelSheetImportToDataTable(filePath);
                    sqlDataAdapter.Fill(dataTable);
                    //sqlDataAdapter.Update(dataTable);
                    return dataTable;

                }

            }
            
            
        }

        //datatable数据批量导入数据库
        public void DataTableToSQLServer(DataTable dt)
        {            
            using (SqlConnection destinationConnection = SQLHelper.createConnection())
            {
               // destinationConnection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "Student";//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.ColumnMappings.Add("学生学号", "StuNo");//映射字段名 DataTable列名 ,数据库 对应的列名 
                        bulkCopy.ColumnMappings.Add("学生密码", "StuPwd");
                        bulkCopy.ColumnMappings.Add("学生姓名", "StuName");
                        bulkCopy.ColumnMappings.Add("学生年级", "StuNianji");
                        bulkCopy.ColumnMappings.Add("学生学院", "Academy");
                        bulkCopy.ColumnMappings.Add("学生专业", "Profession");
                        bulkCopy.ColumnMappings.Add("学生班级", "StuClass");
                        bulkCopy.ColumnMappings.Add("学生综测", "Grade");                                               
                        bulkCopy.WriteToServer(dt);
                        MessageBox.Show("插入成功","提示");
                    }
                    catch (Exception ex)
                    {                                             
                        MessageBox.Show(ex.Message,"提示");
                    }
                    finally
                    {


                    }
                }


            }
        }
    }
}

