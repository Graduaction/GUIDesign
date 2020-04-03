using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace DAL
{
    public partial class SQLHelper
    {
        //数据库连接字符串
        public static string connStr = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
        //新建DataSet
        //  public static DataSet DataSet = new DataSet();
        //创建DataTable对象的实例，指定名称为studentTable，并将其添加到DataSet的Tables集合中
        //   public static DataTable studentTable = DataSet.Tables.Add("studentTable");
        //   DataColumn dataColumn = studentTable.Columns.Add("StuID",typeof(int));       

        //新建SqlDataAdapter对象的实例


        public static SqlConnection createConnection()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
        #region 执行查询:select返回多行多列
        //执行查询:select返回多行多列
        public static DataTable ExecuteQuery(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(table);
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    table.Load(reader);
                //}
            }
            return table;//返回加载的表

        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = createConnection())
            {
                return ExecuteQuery(conn, sql, parameters);
            }
        }

        #endregion

        #region 执行insert/update/delete，返回受影响的行数
        /// <summary>
        /// 执行insert/update/delete，返回受影响的行数
        /// </summary>
        /// <param name="sql">带参数的sql语句</param>
        /// <param name="cmdType">SqlCommand执行类型，CommandType.Text为SQL语句执行类型，CommandType.StoredProcedure为调用存储过程</param>
        /// <param name="pms">可变的Sql的参数数组</param>
        /// <returns>返回受影响行数,对create table 和drop table语句返回值为0，其他类型语句，返回值为-1</returns>
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection conn = createConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //设置当前执行的是单参数的sql语句还是存储过程
                    cmd.CommandType = cmdType;
                    cmd.CommandText = sql;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }

                    int res = cmd.ExecuteNonQuery();
                    //返回受影响行数
                    return res;
                }
            }
        }
        #endregion

        #region 若执行查询语句则返回结果集首行首列（单个值）的方法，若不是，返回未实例化对象
        /// <summary>
        /// 若执行查询语句返回结果集首行首列（单个值）的方法，否则返回一个未实例化的对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    object obj = cmd.ExecuteScalar();
                    con.Close();
                    con.Dispose();
                    return obj;
                }
            }
        }
        #endregion

        #region 返回SqlDataReader
        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(connStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }

        }
        #endregion

        #region 返回DataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region 批量导入datatable
        /// <summary>
        /// 批量导入datatable
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="TabelName">数据表名</param>
        /// <param name="dtColum">列集合</param>
        public static int InsertTable(DataTable dt, string TabelName, DataColumnCollection dtColum)
        {
            //打开数据库
            SqlConnection conn = createConnection();
            try
            {
                //声明SqlBulkCopy ,using释放非托管资源
                using (SqlBulkCopy sqlBC = new SqlBulkCopy(createConnection()))
                {
                    //一次批量的插入的数据量
                    //sqlBC.BatchSize = 1000;
                    //超时之前操作完成所允许的秒数，如果超时则事务不会提交 ，数据将回滚，所有已复制的行都会从目标表中移除
                    //sqlBC.BulkCopyTimeout = 60;

                    //設定 NotifyAfter 属性，以便在每插入10000 条数据时，呼叫相应事件。 
                    //sqlBC.NotifyAfter = 10000;
                    // sqlBC.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                    //设置要批量写入的表
                    sqlBC.DestinationTableName = TabelName;

                    //自定义的datatable和数据库的字段进行对应

                    for (int i = 0; i < dtColum.Count; i++)
                    {
                        sqlBC.ColumnMappings.Add(dtColum[i].ColumnName.ToString(), dtColum[i].ColumnName.ToString());
                    }
                    //批量写入
                    sqlBC.WriteToServer(dt);
                }
                //导入成功，返回1
                return 1;
            }
            catch
            {
                //导入失败返回-1
                return -1;

            }
            finally
            {
                //关闭数据库
                conn.Close();
            }
        }
        #endregion

        #region  md5加密
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public static string GetMD5(string strPwd)
        {
            string pwd = "";
            //实例化一个md5对象
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(strPwd));
            //翻转生成的MD5码  
            s.Reverse();
            //通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            //只取MD5码的一部分，这样恶意访问者无法知道取的是哪几位
            for (int i = 3; i < s.Length - 1; i++)
            {
                //将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                //进一步对生成的MD5码做一些改造
                pwd = pwd + (s[i] < 198 ? s[i] + 28 : s[i]).ToString("X");
            }
            return pwd;
        }
        #endregion




    }
}
