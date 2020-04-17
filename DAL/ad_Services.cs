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
    public class ad_ServicesDAL
    {
        #region SelectStu查询学生数据
        /// <summary>
        /// 查询学生数据
        /// </summary>
        /// <returns>返回datatable</returns>
        public DataTable SelectStu()
        {
            string sql = "select StuNo as 学生学号,StuName as 学生姓名,StuNianji as 学生年级,Academy as 学生学院,Profession as 学生专业,StuClass as 学生班级,Grade as 学生综测,StuPwd as 初始密码 from Student";
            DataTable studentTable = SQLHelper.ExecuteQuery(sql);
            return studentTable;
        }
        #endregion

        #region SelectTea查询教师信息
        public DataTable SelectTea()
        {
            string sql = "select TeaNo as 教师工号,TeaName as 教师姓名,Academy as 所属学院,GroupNumber as 所带组数,TeaPwd as 初始密码 from Teacher";
            DataTable teaTable = SQLHelper.ExecuteQuery(sql);
            return teaTable;
        }
        #endregion

        #region SelectManage查询双选参数信息
        public int SelectManage(string adminno1)
        {
            int result = 0;
            string sql = @"select * from Manage where AdminNo1=@AdminNo1";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo1",SqlDbType.NVarChar)
            };
            sqlParameter[0].Value = adminno1;
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameter);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Keepinformation.AdminNo = reader[1].ToString();
                    Keepinformation.StartTime = Convert.ToDateTime(reader[2].ToString());
                    Keepinformation.EndTime = Convert.ToDateTime(reader[3].ToString());
                    Keepinformation.VolunteerFirstShare = reader[4].ToString();
                    Keepinformation.VolunteerSecondShare = reader[5].ToString();
                    Keepinformation.VolunteerThirdShare = reader[6].ToString();
                    Keepinformation.Grade = reader[7].ToString();
                    result = 1;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region InsertStu插入学生数据
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns>返回受影响行数</returns>
        public int InsertStu(StudentData studentData)
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

        #region InsertTea插入教师数据
        public int InsertTea(TeacherData teacherData)
        {
            string sql = @"insert into Teacher (TeaNo,TeaPwd,TeaName,Academy,GroupNumber) values(@TeaNo,@TeaPwd,@TeaName,@Academy,@GroupNumber)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaNo",SqlDbType.NVarChar),
                new SqlParameter("@TeaPwd",SqlDbType.NVarChar),
                new SqlParameter("@TeaName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@GroupNumber",SqlDbType.Int),
            };
            sqlParameter[0].Value = teacherData.TeaNo;
            sqlParameter[1].Value = teacherData.TeaPwd;
            sqlParameter[2].Value = teacherData.TeaName;
            sqlParameter[3].Value = teacherData.Academy;
            sqlParameter[4].Value = teacherData.GroupNumber;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region Manage表插入双选参数信息
        public int InsertManage(ManageData manageData)
        {
            string sql = @"insert into Manage (AdminNo1,StartTime,EndTime,VolunteerFirstShare,VolunteerSecondShare,VolunteerThirdShare,Grade) values(@AdminNo1,@StartTime,@EndTime,@VolunteerFirstShare,@VolunteerSencondShare,@VolunteerThirdShare,@Grade)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo1",SqlDbType.NVarChar),
                new SqlParameter("@StartTime",SqlDbType.DateTime),
                new SqlParameter("@EndTime",SqlDbType.DateTime),
                new SqlParameter("@VolunteerFirstShare",SqlDbType.Float),
                new SqlParameter("@VolunteerSencondShare",SqlDbType.Float),
                new SqlParameter("@VolunteerThirdShare",SqlDbType.Float),
                new SqlParameter("@Grade",SqlDbType.Float),
            };
            sqlParameter[0].Value = manageData.AdminNo1;
            sqlParameter[1].Value = manageData.StartTime;
            sqlParameter[2].Value = manageData.EndTime;
            sqlParameter[3].Value = manageData.VolunteerFirstShare;
            sqlParameter[4].Value = manageData.VolunteerSecondShare;
            sqlParameter[5].Value = manageData.VolunteerThirdShare;
            sqlParameter[6].Value = manageData.Grade;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数                       
            return result;
        }
        #endregion

        #region 根据DeleteBystuNo删除学生数据
        public bool DeleteBystuNo(string StuNo)
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

        #region 根据DaleteByteaNo删除教师数据
        public bool DaleteByteaNo(string TeaNo)
        {
            string strSql = "delete from Teacher where TeaNo=@TeaNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaNo",SqlDbType.VarChar)
            };
            sqlParameter[0].Value = TeaNo;
            return SQLHelper.ExecuteNonQuery(strSql, CommandType.Text, sqlParameter) > 0;
        }
        #endregion

        #region UpdateStudata修改学生数据
        public int UpdateStudata(StudentData studentData)
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

        #region UPdateTeadata修改教师数据
        public int UPdateTeadata(TeacherData teacherData)
        {
            string sql = @"update  Teacher set TeaPwd=@TeaPwd,TeaName=@TeaName,Academy=@Academy,GroupNumber=@GroupNumber where TeaNo=@TeaNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@TeaPwd",SqlDbType.NVarChar),
                new SqlParameter("@TeaName",SqlDbType.NVarChar),
                new SqlParameter("@Academy",SqlDbType.NVarChar),
                new SqlParameter("@GroupNumber",SqlDbType.Int),
                new SqlParameter("@TeaNo",SqlDbType.NVarChar),
            };
            sqlParameter[0].Value = teacherData.TeaPwd;
            sqlParameter[1].Value = teacherData.TeaName;
            sqlParameter[2].Value = teacherData.Academy;
            sqlParameter[3].Value = teacherData.GroupNumber;
            sqlParameter[4].Value = teacherData.TeaNo;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region UpdateAdmdata修改管理员数据
        /// <summary>
        /// UpdateAdmdata修改管理员数据
        /// </summary>
        /// <param name="adminData">传参：管理员对象</param>
        /// <returns></returns>
        public int UpdataAdmdata(AdminData adminData)
        {
            string sql = @"update  Admin set AdminPwd=@AdminPwd,AdminTitle=@AdminTitle,AdminEmail=@AdminEmail where AdminNo=@AdminNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminPwd",SqlDbType.NVarChar),
                new SqlParameter("@AdminName",SqlDbType.NVarChar),
                new SqlParameter("@AdminTitle",SqlDbType.NVarChar),
                new SqlParameter("@AdminEmail",SqlDbType.NVarChar),
                new SqlParameter("@AdminNo",SqlDbType.NVarChar),
            };
            sqlParameter[0].Value = adminData.AdminPwd;
            sqlParameter[1].Value = adminData.AdminName;
            sqlParameter[2].Value = adminData.AdminTitle;
            sqlParameter[3].Value = adminData.AdminEmail;
            sqlParameter[4].Value = adminData.AdminNo;
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
        }
        #endregion

        #region 导入excel文件功能
        /// <summary>
        /// 导入excel文件功能
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回datatable</returns>        
        public DataTable importFile(string sql, string filePath)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            using (SqlConnection conn = SQLHelper.createConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
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
        #endregion

        #region 将DataTable数据批量导入数据库
        /// <summary>
        /// 将DataTable数据批量导入数据库
        /// </summary>
        /// <param name="dt">传参：datatable</param>
        public void DataTableToStuSQLServer(DataTable dt)
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
                        MessageBox.Show("插入成功", "提示");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                    }
                }
            }
        }
        #endregion

        #region 将教师DataTable数据批量导入数据库
        /// <summary>
        /// 将教师DataTable数据批量导入数据库
        /// </summary>
        /// <param name="dt">传参：datatable</param>
        public void DataTableToTeaSQLServer(DataTable dt)
        {
            using (SqlConnection destinationConnection = SQLHelper.createConnection())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "Teacher";//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.ColumnMappings.Add("教师工号", "TeaNo");//映射字段名 DataTable列名 ,数据库 对应的列名 
                        bulkCopy.ColumnMappings.Add("教师密码", "TeaPwd");
                        bulkCopy.ColumnMappings.Add("教师姓名", "TeaName");
                        bulkCopy.ColumnMappings.Add("所属学院", "Academy");
                        bulkCopy.ColumnMappings.Add("所带组数", "GroupNumber");
                        bulkCopy.WriteToServer(dt);
                        MessageBox.Show("插入成功", "提示");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                    }
                }
            }
        }
        #endregion

        #region 个人中心页
        /// <summary>
        /// 查看管理员个人中心
        /// </summary>
        /// <returns>返回datatable</returns>
        //public DataTable SelectAdm()
        //{
        //    string sql = @"select AdminNo ,AdminName ,AdminTitle, AdminEmail from Student";

        //    DataTable admintable = SQLHelper.ExecuteReader(sql);

        //    return admintable;
        //}
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="adminData">admindata对象</param>
        /// <returns>result=0:登录失败，result=1：账号或密码不正确，result=2:登陆成功</returns>   
        public int Login(AdminData adminData)
        {
            int result = 0;
            string sql = @"select * from Admin where AdminNo=@AdminNo";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@AdminNo",SqlDbType.NVarChar)
            };
            sqlParameter[0].Value = adminData.AdminNo;
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text, sqlParameter);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader[1].ToString() == adminData.AdminPwd)
                    {
                        result = 2;
                        Keepinformation.AdminNo = adminData.AdminNo;
                        Keepinformation.AdminPwd = adminData.AdminPwd;
                        Keepinformation.AdminName = reader[2].ToString();
                        Keepinformation.AdminTitle = reader[3].ToString();
                        Keepinformation.AdminEmail = reader[4].ToString();
                    }
                    else result = 1;

                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        #endregion

        #region 双选匹配界面显示数据
        //学生列表
        public DataTable GetStuMatchtable()
        {
            DataTable table = new DataTable();
            string sql = @"select distinct(a.groupid) as 组号 ,a.membernum as 组内人数,a.leaderno as 组长学号,a.VolFirstId as 志愿一,a.VolSecondId as 志愿二,a.VolThirdId as 志愿三,a.Topic as 学生课题,
(select stuname from student where student.stuno=a.leaderno) as 组长姓名,
(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo) as 小组平均成绩
from grouptable a left join groupstu c
on a.GroupID = c.groupid ";

            table = SQLHelper.ExecuteQuery(sql);
            return table;
        }
        //教师列表
        public DataTable GetTeaMatchtable()
        {
            DataTable table = new DataTable();

            string sql = @"select distinct(b.teano) as 教师工号,b.teaname as 教师姓名,b.groupnumber as 所带组数,a.yixuan as 已选组数,a.Teavol1 as 志愿小组1,a.Teavol2 as 志愿小组2,a.Teavol3 as 志愿小组3,a.Teavol4 as 志愿小组4,a.Teavol5 as 志愿小组5 from addgrid b,Teavolheng a where a.teano=b.Teano";
            table = SQLHelper.ExecuteQuery(sql);
            return table;

        }
        #endregion

        #region 自动匹配功能，延迟接受思想，galeshapely算法
        //匹配算法
        public string Match()
        {
            //初始化对象数组
            sx_student[] sx_Students = new sx_student[50];//50个地址值
            sx_teacher[] sx_Teachers = new sx_teacher[20];//20个地址值
            MyLinkList<sx_student> myLinkList = new MyLinkList<sx_student>();

            DataTable stutable = GetStuMatchtable();
            int row_stucount = stutable.Rows.Count;
            DataTable teatable = GetTeaMatchtable();
            int row_teacount = teatable.Rows.Count;

            //将datatable中的值赋给sx_student对象数组
            for (int i = 0; i < row_stucount; i++)
            {
                sx_student student = new sx_student(10);
                //if(sx_Students[i]!=null)
                // {
                if (stutable.Rows[i][0] != DBNull.Value)
                {
                    student.Groupid = Convert.ToInt32(stutable.Rows[i][0]);
                }

                if (stutable.Rows[i][1] != DBNull.Value)
                {
                    student.Membernum = Convert.ToInt32(stutable.Rows[i][1]);
                }
                if (stutable.Rows[i][2] != DBNull.Value)
                {
                    student.Leaderno = stutable.Rows[i][2].ToString();
                }
                if (stutable.Rows[i][3] != DBNull.Value)
                {
                    student.LoveTeacher[0] = stutable.Rows[i][3].ToString();
                }
                if (stutable.Rows[i][4] != DBNull.Value)
                {
                    student.LoveTeacher[1] = stutable.Rows[i][4].ToString();
                }
                if (stutable.Rows[i][5] != DBNull.Value)
                {
                    student.LoveTeacher[2] = stutable.Rows[i][5].ToString();
                }
                if (stutable.Rows[i][6] != DBNull.Value)
                {
                    student.Topic = stutable.Rows[i][6].ToString();
                }
                if (stutable.Rows[i][7] != DBNull.Value)
                {
                    student.Stuname = stutable.Rows[i][7].ToString();
                }
                if (stutable.Rows[i][8] != DBNull.Value)
                {
                    student.Grade = Convert.ToDouble(stutable.Rows[i][8]);
                }
                student.Beixuan = 0;//初始化被选=0

                sx_Students[i] = student;
                //}
            }
            //将datatable中的值赋给sx_teacher对象数组
            for (int i = 0; i < row_teacount; i++)
            {
                sx_teacher teacher = new sx_teacher(20);//实例化对象
                teacher.Teano = teatable.Rows[i][0].ToString();
                teacher.Teaname = teatable.Rows[i][1].ToString();
                teacher.Groupnumber = Convert.ToInt32(teatable.Rows[i][2]);
                if (teatable.Rows[i][3] != DBNull.Value)
                {
                    teacher.Yixuan = Convert.ToInt32(teatable.Rows[i][3]);
                }
                if (teatable.Rows[i][4] != DBNull.Value)
                {
                    teacher.Groupid[0] = Convert.ToInt32(teatable.Rows[i][4]);
                }
                if (teatable.Rows[i][5] != DBNull.Value)
                {
                    teacher.Groupid[1] = Convert.ToInt32(teatable.Rows[i][5]);
                }
                if (teatable.Rows[i][6] != DBNull.Value)
                {
                    teacher.Groupid[2] = Convert.ToInt32(teatable.Rows[i][6]);
                }
                if (teatable.Rows[i][7] != DBNull.Value)
                {
                    teacher.Groupid[3] = Convert.ToInt32(teatable.Rows[i][7]);
                }
                if (teatable.Rows[i][8] != DBNull.Value)
                {
                    teacher.Groupid[4] = Convert.ToInt32(teatable.Rows[i][8]);
                }
                sx_Teachers[i] = teacher;
                sx_Teachers[i].LovestuList = new MyLinkList<sx_student>();
            }
            Console.WriteLine("表白游戏开始啦！！！");
            //学生有三个志愿,遍历三个志愿，找对应的teacher，看老师是否喜欢他
            for (int i = 0; i < row_stucount; i++)
            {
                for (int m = 0; m < 3; m++)
                {
                    string get_Lovetea = sx_Students[i].LoveTeacher[m];
                    for (int k = 0; k < row_teacount; k++)//遍历老师列表，查找当前学生的心仪老师
                    {
                        if (sx_Teachers[k].Teano == get_Lovetea)//找到这个老师
                        {
                            Console.WriteLine("学生" + sx_Students[i].Groupid + "向" + "第" + (m + 1) + "志愿老师" + sx_Teachers[k].Teaname + "表白了");

                            for (int a = 0; a < 5; a++)//5个志愿
                            {
                                if (sx_Teachers[k].Groupid[a].Equals(sx_Students[i].Groupid))//这个老师也喜欢他
                                {
                                    // Console.WriteLine(" 这个老师志愿组数 " + (a + 1) + " 的学生为 " + sx_Teachers[k].Groupid[a]);
                                    //判断他招的学生满了没有

                                    // Console.WriteLine("对象数组中的链表长度为=" + sx_Teachers[k].LovestuList.GetLength() + "新定义链表长度为" + myLinkList.GetLength());
                                    if (sx_Teachers[k].LovestuList.GetLength() < sx_Teachers[k].Groupnumber)//没满
                                    {
                                        int flag = 0;
                                        //判断这个老师列表里是不是已经有了该学生了
                                        for (int f = 1; f <= sx_Teachers[k].LovestuList.GetLength(); f++)
                                        {
                                            if (sx_Teachers[k].LovestuList.GetElem(f).Groupid == sx_Students[i].Groupid)//该老师列表已有这个学生
                                            {
                                                flag += 1;
                                                Console.WriteLine("学生重复，不加入链表");
                                                break;
                                            }
                                        }
                                        if (flag == 0 && sx_Students[i].Beixuan == 0)//这个老师列表里还没有这个学生且学生未被其他老师选
                                        {
                                            sx_Students[i].Beixuan = 1;
                                            sx_Teachers[k].LovestuList.Append(sx_Students[i]);
                                            Console.WriteLine("恭喜学生" + sx_Students[i].Groupid + "被" + sx_Teachers[k].Teaname + "老师录取了");

                                        }
                                        else if (flag == 0 && sx_Students[i].Beixuan == 1)//这个老师列表里还没有这个学生但已被其他老师选中                                                
                                        {
                                            break;//本来也就是志愿从高到底去找老师，这种情况无需考虑
                                        }
                                        else
                                        {
                                            break;
                                        }


                                    }
                                    else//满了
                                    {
                                        Console.WriteLine("啊哦，这个老师的可选人数已满了，让我们来看看可不可以抢位置");

                                        int length = sx_Teachers[k].LovestuList.GetLength();//获取已选学生列表长度
                                        for (int p = 1; p <= length; p++)//替换掉比当前学生成绩低的学生
                                        {
                                            if (sx_Teachers[k].LovestuList.GetElem(p).Grade < sx_Students[i].Grade)//有比该学生成绩还要低的
                                            {
                                                for (int g = 1; g <= row_stucount; g++)
                                                {
                                                    if (sx_Students[g].Groupid == sx_Teachers[k].LovestuList.GetElem(p).Groupid)
                                                    {
                                                        sx_Students[g].Beixuan = 0;
                                                        break;
                                                    }
                                                }

                                                Console.WriteLine("找到" + sx_Teachers[k].LovestuList.GetElem(p).Groupid + "比" + sx_Students[i].Groupid + "成绩还要低!抢他！！");
                                                Console.WriteLine("学生" + sx_Teachers[k].LovestuList.GetElem(p).Groupid + "失恋了，他的指导老师被学生" + sx_Students[i].Groupid + "抢了");
                                                sx_Teachers[k].LovestuList.Delete(p);//删除第p个节点
                                                sx_Students[i].Beixuan = 1;
                                                sx_Teachers[k].LovestuList.Append(sx_Students[i]);//插入第i个节点
                                                Console.WriteLine("恭喜学生" + sx_Students[i].Groupid + "被" + sx_Teachers[k].Teaname + "老师录取了");
                                                break;
                                            }
                                            else//没有比当前学生成绩还要低的了
                                            {
                                                Console.WriteLine("你的段位才" + sx_Students[i].Grade + ",打不过这个组" + sx_Teachers[k].LovestuList.GetElem(p).Groupid + "，他的段位" + sx_Teachers[k].LovestuList.GetElem(p).Grade);
                                                continue;
                                            }
                                        }
                                    }
                                }
                                else//这个老师不喜欢当前学生
                                {
                                    // Console.WriteLine("第"+(m+1)+"志愿老师"+sx_Teachers[k].Teano+"的志愿学生组"+(a+1)+"没选他，该学生继续表白下一个老师");
                                    continue;//跳出本次循环，即立刻去找下一个老师
                                }
                            }

                        }
                        else//没找到这个老师，不可能吧
                        {


                        }
                    }

                }
            }
            Random random = new Random();
            int j = random.Next(0, row_stucount);

            int[] vs = new int[40];
            int e = 0;
            string weipipei = "第一轮匹配失败组数[";
            foreach (sx_student sx in sx_Students)
            {
                if (sx != null && sx.Beixuan == 0)
                {
                    vs[e] = sx.Groupid;
                    e++;
                }
            }
            for (int h = 0; h < vs.Length; h++)
            {
                if (vs[h] != 0)
                {
                    weipipei += vs[h].ToString() + ",";
                }
            }
            weipipei += "]";
            Console.WriteLine(weipipei);
            Keepinformation.sx_Students = sx_Students;
            Keepinformation.sx_Teachers = sx_Teachers;
            //  return (sx_Students[j].Groupid + " 向 " + sx_Students[j].LoveTeacher[0] + ";" + sx_Students[j].LoveTeacher[1] + ";" + sx_Students[j].LoveTeacher[2] + "  表白了");
            return ("一轮匹配结束,点击确定查看匹配结果");
            // return sx_Students;
        }
        #endregion

        #region  删除整个表的数据，保留表结构
        public int Tuncast_TBrs(string sql)
        {
            return SQLHelper.ExecuteNonQuery(sql, CommandType.Text);
        }
        #endregion

        #region 查询result表数据
        public bool SearchRs(string sql)
        {
            SqlDataReader reader = SQLHelper.ExecuteReader(sql, CommandType.Text);
            if (reader.HasRows)
            {
                return reader.Read();
            }
            else
                return false;

        }

        #endregion

        #region 查找当前行的教师工号的可带人数
        public int GetGroupNum(string teano)
        {
            string sql = "select GroupNumber from Teacher where TeaNo=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            int re = (int)SQLHelper.ExecuteScalar(sql, CommandType.Text, paras);
            return re;

        }
        #endregion

        #region 查找当前行的教师工号的已选组数
        public int Yixuanzs(string teano)
        {
            string sql = "select yixuan from z_TeaVol where Teano=@teano";
            SqlParameter[] paras = { new SqlParameter("@teano", teano) };
            int re = (int)SQLHelper.ExecuteScalar(sql, CommandType.Text, paras);
            return re;


        }
        #endregion

        #region 将双选结果datatable导入数据库
        public void InsertToResult(DataTable dt)
        {
            //int result = 0;
            using (SqlConnection destinationConnection = SQLHelper.createConnection())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "Result";//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        bulkCopy.ColumnMappings.Add("教师工号", "TeacherNo");//映射字段名 DataTable列名 ,数据库 对应的列名 
                        bulkCopy.ColumnMappings.Add("学生组号", "GroupId");
                        bulkCopy.ColumnMappings.Add("论文课题", "Topic");
                        bulkCopy.WriteToServer(dt);
                        MessageBox.Show("插入成功", "提示");
                        //   result = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示");
                    }
                    finally
                    {
                    }
                }
            }
            //  return result;
        }
        #endregion



        #region 二轮双选匹配界面显示数据
        //学生列表
        public DataTable ST_GetStuMatchtable()
        {
            DataTable tableall = new DataTable();
            //
            string sql = @"select distinct(a.groupid) as 组号 ,a.membernum as 组内人数,a.leaderno as 组长学号,a.VolFirstId as 志愿一,a.VolSecondId as 志愿二,a.VolThirdId as 志愿三,a.Topic as 学生课题,
(select stuname from student where student.stuno=a.leaderno) as 组长姓名,
(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo) as 小组平均成绩
from grouptable a left join groupstu c
on a.GroupID = c.groupid ";
            tableall = SQLHelper.ExecuteQuery(sql);
            DataTable tableyixuan = new DataTable();
            string sql1 = "select teacherno as 教师工号,groupid as 学生组号,topic as 论文课题 from result";
            tableyixuan = SQLHelper.ExecuteQuery(sql1);

            for (int j = tableall.Rows.Count - 1; j >= 0; j--)
            {
                Console.WriteLine(tableall.Rows[j][0]);
                for (int i = 0; i < tableyixuan.Rows.Count; i++)
                {
                    if (tableall.Rows[j][0].ToString() == tableyixuan.Rows[i][1].ToString())
                    {
                        Console.WriteLine(tableall.Rows[j][0] + "tableyixuan:" + tableyixuan.Rows[i][1]);
                        tableall.Rows.RemoveAt(j);
                    }
                }
            }
            //倒序删除
            string str = "weipipeitable:[";
            for (int m = 0; m < tableall.Rows.Count; m++)
            {
                str += tableall.Rows[m][0] + ",";
            }
            str += "]";
            Console.WriteLine(str);
            return tableall;
        }
        //教师列表
        public DataTable ST_GetTeaMatchtable()
        {
            DataTable table = new DataTable();
            string sql = @"select distinct(b.teano) as 教师工号,b.teaname as 教师姓名,b.groupnumber as 所带组数,a.kexuan as 可选组数,a.Teavol1 as 志愿小组1,a.Teavol2 as 志愿小组2,a.Teavol3 as 志愿小组3,a.Teavol4 as 志愿小组4,a.Teavol5 as 志愿小组5,a.yixuan as 已选组数 from addgrid b,Teavolheng2 a where a.teano=b.Teano";
            table = SQLHelper.ExecuteQuery(sql);
            DataTable table1 = new DataTable();
            table1 = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i][3]) > 0)
                {
                    DataRow dr = table.Rows[i];
                    table1.Rows.Add(dr.ItemArray);
                }
            }
            return table;
        }
        #endregion


        #region 二轮选择实现
        public string MatchSecondtime()
        {
            sx_student[] sx_Students = new sx_student[50];
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            DataTable stutable = ST_GetStuMatchtable();
            int row_stucount = stutable.Rows.Count;
            DataTable teatable = ST_GetTeaMatchtable();
            int row_teacount = teatable.Rows.Count;
            //将datatable中的值赋给sx_student对象数组
            for (int i = 0; i < row_stucount; i++)
            {
                sx_student student = new sx_student(10);
                //if(sx_Students[i]!=null)
                // {
                if (stutable.Rows[i][0] != DBNull.Value)
                {
                    student.Groupid = Convert.ToInt32(stutable.Rows[i][0]);
                }

                if (stutable.Rows[i][1] != DBNull.Value)
                {
                    student.Membernum = Convert.ToInt32(stutable.Rows[i][1]);
                }
                if (stutable.Rows[i][2] != DBNull.Value)
                {
                    student.Leaderno = stutable.Rows[i][2].ToString();
                }
                if (stutable.Rows[i][3] != DBNull.Value)
                {
                    student.LoveTeacher[0] = stutable.Rows[i][3].ToString();
                }
                if (stutable.Rows[i][4] != DBNull.Value)
                {
                    student.LoveTeacher[1] = stutable.Rows[i][4].ToString();
                }
                if (stutable.Rows[i][5] != DBNull.Value)
                {
                    student.LoveTeacher[2] = stutable.Rows[i][5].ToString();
                }
                if (stutable.Rows[i][6] != DBNull.Value)
                {
                    student.Topic = stutable.Rows[i][6].ToString();
                }
                if (stutable.Rows[i][7] != DBNull.Value)
                {
                    student.Stuname = stutable.Rows[i][7].ToString();
                }
                if (stutable.Rows[i][8] != DBNull.Value)
                {
                    student.Grade = Convert.ToDouble(stutable.Rows[i][8]);
                }
                student.Beixuan = 0;//初始化被选=0

                sx_Students[i] = student;
                //}
            }
            //将datatable中的值赋给sx_teacher对象数组
            for (int i = 0; i < row_teacount; i++)
            {
                sx_teacher teacher = new sx_teacher(20);//实例化对象
                teacher.Teano = teatable.Rows[i][0].ToString();
                teacher.Teaname = teatable.Rows[i][1].ToString();
                teacher.Groupnumber = Convert.ToInt32(teatable.Rows[i][2]);
                if (teatable.Rows[i][3] != DBNull.Value)
                {
                    teacher.Kexuan = Convert.ToInt32(teatable.Rows[i][3]);
                }
                if (teatable.Rows[i][4] != DBNull.Value)
                {
                    teacher.Groupid[0] = Convert.ToInt32(teatable.Rows[i][4]);
                }
                if (teatable.Rows[i][5] != DBNull.Value)
                {
                    teacher.Groupid[1] = Convert.ToInt32(teatable.Rows[i][5]);
                }
                if (teatable.Rows[i][6] != DBNull.Value)
                {
                    teacher.Groupid[2] = Convert.ToInt32(teatable.Rows[i][6]);
                }
                if (teatable.Rows[i][7] != DBNull.Value)
                {
                    teacher.Groupid[3] = Convert.ToInt32(teatable.Rows[i][7]);
                }
                if (teatable.Rows[i][8] != DBNull.Value)
                {
                    teacher.Groupid[4] = Convert.ToInt32(teatable.Rows[i][8]);
                }
                if (teatable.Rows[i][9] != DBNull.Value)
                {
                    teacher.Yixuan = Convert.ToInt32(teatable.Rows[i][9]);
                }
                sx_Teachers[i] = teacher;
                sx_Teachers[i].LovestuList = new MyLinkList<sx_student>();
            }
            Console.WriteLine("第二轮表白游戏开始啦！！！");
            //教师有可选组数，遍历每个志愿学生，看学生是否喜欢他
            for (int i = 0; i < row_teacount; i++)//遍历每个教师，由教师追学生
            {
                if (sx_Teachers[i].Kexuan > sx_Teachers[i].LovestuList.GetLength())//该教师是否还有名额可以收徒
                {
                    for (int k = 0; k < sx_Teachers[i].Yixuan; k++)//遍历该教师的已选志愿
                    {
                        Console.WriteLine(sx_Teachers[i].Teaname + "老师向学生" + sx_Teachers[i].Groupid[k] + "表白啦");
                        for (int j = 0; j < row_stucount; j++)
                        {
                            if (sx_Students[j].Groupid == sx_Teachers[i].Groupid[k])//找到相应志愿的学生
                            {
                                for (int l = 0; l < 3; l++)
                                {
                                    if (sx_Students[j].LoveTeacher[l] == sx_Teachers[i].Teano && sx_Students[j].Beixuan == 0)
                                    {
                                        Console.WriteLine("该学生被" + sx_Teachers[i].Teaname + "老师录取啦");
                                        Console.WriteLine("该老师目前可选人数为" + sx_Teachers[i].Kexuan + "人\n");
                                        sx_Students[j].Beixuan = 1;
                                        sx_Teachers[i].LovestuList.Append(sx_Students[j]);
                                        sx_Teachers[i].Kexuan -= 1;

                                        break;
                                    }
                                    else if (sx_Students[j].LoveTeacher[l] == sx_Teachers[i].Teano && sx_Students[j].Beixuan == 1)
                                    {
                                        //找到该学生但却已经被录取了，那也没办法了
                                    }

                                }
                                break;
                            }
                            break;
                        }
                    }
                }

            }

            int[] vs = new int[40];
            int e = 0;
            string weipipei = "第二轮匹配失败组数[";
            foreach (sx_student sx in sx_Students)
            {
                if (sx != null && sx.Beixuan == 0)
                {
                    vs[e] = sx.Groupid;
                    e++;
                }
            }
            for (int h = 0; h < vs.Length; h++)
            {
                if (vs[h] != 0)
                {
                    weipipei += vs[h].ToString() + ",";
                }
            }
            weipipei += "]";
            Console.WriteLine(weipipei);
            Keepinformation.stsx_Students = sx_Students;
            Keepinformation.stsx_Teachers = sx_Teachers;
            Console.WriteLine("\n\n\n\n");
            Merge_First_Sec();
            return ("二轮匹配结束,点击确定查看匹配结果");
        }
        #endregion

        //将剩余的结果继续加到老师的链表中去并提交
        public void Merge_First_Sec()
        {
            sx_student[] sx_Students = Keepinformation.stsx_Students;
            sx_teacher[] sx_Teachers = Keepinformation.stsx_Teachers;

            for (int i = 0; i < sx_Students.Length; i++)
            {
                for (int j = 0; j < sx_Teachers.Length; j++)
                {
                    if (sx_Teachers[j] != null && sx_Teachers[j].Kexuan > 0 && sx_Students[i] != null && sx_Students[i].Beixuan == 0)
                    {
                        sx_Students[i].Beixuan = 1;
                        sx_Teachers[j].LovestuList.Append(sx_Students[i]);
                        Console.WriteLine("学生" + sx_Students[i].Groupid + "被老师" + sx_Teachers[j].Teaname + "录取啦");
                        sx_Teachers[j].Kexuan -= 1;
                        Console.WriteLine(sx_Teachers[j].Teaname + "的可选数为" + sx_Teachers[j].Kexuan);
                    }
                }
            }
            for (int k = 0; k < sx_Students.Length; k++)
            {
                if (sx_Students[k] != null && sx_Students[k].Beixuan == 0)
                {
                    Console.WriteLine("不好啦，学生" + sx_Students[k].Groupid + "被漏选啦");
                }
            }
            Keepinformation.stsx_Students = sx_Students;
            Keepinformation.sx_Teachers = sx_Teachers;
        }

        public void InsertSTtoResult()
        {

        }


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
    }
}


