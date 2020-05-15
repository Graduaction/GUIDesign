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
        //从数据库中获取要显示在学生列表的数据
        public DataTable GetStuMatchtable()
        {
            DataTable table = new DataTable();
            string sql = @"select distinct(a.groupid) as 学生组号,
(select stuname from student where student.stuno=a.leaderno) as 组长姓名,
a.Topic as 学生课题,
a.VolFirstId as 志愿一,a.VolSecondId as 志愿二,a.VolThirdId as 志愿三,
(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo) as 小组平均成绩,
a.membernum as 组内人数,a.leaderno as 组长学号 from grouptable a left join groupstu c
on a.GroupID = c.groupid ";

            table = SQLHelper.ExecuteQuery(sql);
            return table;
        }
        //教师列表
        public DataTable GetTeaMatchtable()
        {
            DataTable table = new DataTable();

            string sql = @"select distinct(b.teano) as 教师工号,
b.teaname as 教师姓名,
b.groupnumber as 应带组数,
a.yixuan as 已选组数,
a.Teavol1 as 志愿小组1,a.Teavol2 as 志愿小组2,a.Teavol3 as 志愿小组3,a.Teavol4 as 志愿小组4,a.Teavol5 as 志愿小组5 from addgrid b,Teavolheng a where a.teano=b.Teano";
            table = SQLHelper.ExecuteQuery(sql);
            return table;

        }
        #endregion

        #region 第一轮自动匹配功能，延迟接受思想，galeshapely算法
        //匹配算法
        public string Match()
        {
            //初始化对象数组
            sx_student[] sx_Students = new sx_student[50];//50个地址值
            sx_teacher[] sx_Teachers = new sx_teacher[20];//20个地址值
            MyLinkList<sx_student> myLinkList = new MyLinkList<sx_student>();//声明对象链表

            DataTable stutable = GetStuMatchtable();//获取学生列表
            int row_stucount = stutable.Rows.Count;
            DataTable teatable = GetTeaMatchtable();//获取教师列表
            int row_teacount = teatable.Rows.Count;

            //将datatable中的值赋给sx_student对象数组
            for (int i = 0; i < row_stucount; i++)
            {
                sx_student student = new sx_student(10);
                //if(sx_Students[i]!=null)
                // {
                if (stutable.Rows[i][0] != DBNull.Value)//组号
                {
                    student.Groupid = Convert.ToInt32(stutable.Rows[i][0]);
                }

                if (stutable.Rows[i][1] != DBNull.Value)//组长姓名
                {
                    student.Stuname =stutable.Rows[i][1].ToString();
                }
                if (stutable.Rows[i][2] != DBNull.Value)//学生课题
                {
                    student.Topic = stutable.Rows[i][2].ToString();
                }
                if (stutable.Rows[i][3] != DBNull.Value)//志愿一
                {
                    student.LoveTeacher[0] = stutable.Rows[i][3].ToString();
                }
                if (stutable.Rows[i][4] != DBNull.Value)//志愿二
                {
                    student.LoveTeacher[1] = stutable.Rows[i][4].ToString();
                }
                if (stutable.Rows[i][5] != DBNull.Value)//志愿三
                {
                    student.LoveTeacher[2] = stutable.Rows[i][5].ToString();
                }
                if (stutable.Rows[i][6] != DBNull.Value)//小组平均成绩
                {
                    student.Grade = Convert.ToDouble(stutable.Rows[i][6]);
                }
                if (stutable.Rows[i][7] != DBNull.Value)//组内人数
                {
                    student.Membernum = Convert.ToInt16(stutable.Rows[i][7]);
                }
                if (stutable.Rows[i][8] != DBNull.Value)//组长学号
                {
                    student.Leaderno = stutable.Rows[i][8].ToString();
                }
                student.Beixuan = 0;//初始化被选=0

                sx_Students[i] = student;
                //}
            }
            //将datatable中的值赋给sx_teacher对象数组
            for (int i = 0; i < row_teacount; i++)
            {
                sx_teacher teacher = new sx_teacher(20);//实例化对象
                teacher.Teano = teatable.Rows[i][0].ToString();//工号
                teacher.Teaname = teatable.Rows[i][1].ToString();//姓名
                teacher.Groupnumber = Convert.ToInt32(teatable.Rows[i][2]);//应带组数
                if (teatable.Rows[i][3] != DBNull.Value)//已选组数
                {
                    teacher.Yixuan = Convert.ToInt32(teatable.Rows[i][3]);
                }
                if (teatable.Rows[i][4] != DBNull.Value)//志愿一
                {
                    teacher.Groupid[0] = Convert.ToInt32(teatable.Rows[i][4]);
                }
                if (teatable.Rows[i][5] != DBNull.Value)//志愿二
                {
                    teacher.Groupid[1] = Convert.ToInt32(teatable.Rows[i][5]);
                }
                if (teatable.Rows[i][6] != DBNull.Value)//志愿三
                {
                    teacher.Groupid[2] = Convert.ToInt32(teatable.Rows[i][6]);
                }
                if (teatable.Rows[i][7] != DBNull.Value)//志愿四
                {
                    teacher.Groupid[3] = Convert.ToInt32(teatable.Rows[i][7]);
                }
                if (teatable.Rows[i][8] != DBNull.Value)//志愿五
                {
                    teacher.Groupid[4] = Convert.ToInt32(teatable.Rows[i][8]);
                }
                sx_Teachers[i] = teacher;
                sx_Teachers[i].LovestuList = new MyLinkList<sx_student>();//初始化一个链表，用于选择学生
            }

            Console.WriteLine("表白游戏开始啦！！！");
            //学生有三个志愿,遍历三个志愿，找对应的teacher，看老师是否喜欢他
            for (int i = 0; i < row_stucount; i++)
            {
                Console.WriteLine("\n\n学生" + sx_Students[i].Groupid + "进来啦");
                if (sx_Students[i].Beixuan!=0)//若已经被选了就直接轮到下一个学生
                {
                    continue;
                }
                for (int m = 0; m < 3; m++)//三个志愿老师
                {
                    string get_Lovetea = sx_Students[i].LoveTeacher[m];
                    for (int k = 0; k < row_teacount; k++)//遍历老师列表，查找当前学生的心仪老师
                    {
                        if (sx_Teachers[k].Teano == get_Lovetea)//找到这个老师
                        {
                            Console.WriteLine("学生" + sx_Students[i].Groupid + "向" + "第" + (m + 1) + "志愿老师" + sx_Teachers[k].Teaname + "表白了");

                            for (int a = 0; a < 5; a++)//教师的志愿个数，最多循环5个志愿
                            {
                                if (sx_Teachers[k].Groupid[a].Equals(sx_Students[i].Groupid)&&sx_Students[i].Beixuan==0)//这个老师也喜欢他
                                {
                                    Console.WriteLine("老师也喜欢他");
                                    //判断他招的学生满了没有                         
                                    if (sx_Teachers[k].LovestuList.GetLength() < sx_Teachers[k].Groupnumber && sx_Students[i].Beixuan == 0)//没满
                                    {
                                        int flag = 0;
                                     //   判断这个老师列表里是不是已经有了该学生了
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
                                            sx_student item = sx_Students[i];
                                            item.Beixuan = 1;
                                            sx_Teachers[k].LovestuList.Append(item);
                                            Console.WriteLine("恭喜学生" + item.Groupid + "被" + sx_Teachers[k].Teaname + "老师录取了");

                                            string str = "此时教师" + sx_Teachers[k].Teaname + "的心仪学生有：[";
                                            for(int t=1;t<=sx_Teachers[k].LovestuList.GetLength();t++)
                                            {
                                                str += sx_Teachers[k].LovestuList.GetElem(t).Groupid + ",";
                                            }
                                            str += "]";
                                            Console.WriteLine(str);
                                            //break;
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
                                                    if (sx_Students[g].Groupid == sx_Teachers[k].LovestuList.GetElem(p).Groupid)//根据教师列表中的groupid定位到学生对象数组中对应学生
                                                    {
                                                        sx_Students[g].Beixuan = 0;                                                
                                                    }
                                                }
                                                Console.WriteLine("找到" + sx_Teachers[k].LovestuList.GetElem(p).Groupid + "比" + sx_Students[i].Groupid + "成绩还要低!抢他！！");
                                                Console.WriteLine("学生" + sx_Teachers[k].LovestuList.GetElem(p).Groupid + "失恋了，他的指导老师被学生" + sx_Students[i].Groupid + "抢了");
                                                sx_Teachers[k].LovestuList.Delete(p);//删除第p个节点
                                                sx_Students[i].Beixuan = 1;
                                                sx_Teachers[k].LovestuList.Append(sx_Students[i]);//插入第i个节点
                                                Console.WriteLine("恭喜学生" + sx_Students[i].Groupid + "被" + sx_Teachers[k].Teaname + "老师录取了");
                                                string str = "此时教师" + sx_Teachers[k].Teaname + "的心仪学生有：[";
                                                for (int t = 1; t <= sx_Teachers[k].LovestuList.GetLength(); t++)
                                                {
                                                    str += sx_Teachers[k].LovestuList.GetElem(t).Groupid + ",";
                                                }
                                                str += "]";
                                                Console.WriteLine(str);
                                                //break;

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
                                   //若有空位则暂时接受该学生
                                   if(sx_Teachers[k].LovestuList.GetLength()<sx_Teachers[k].Groupnumber&&sx_Students[i].Beixuan==0)
                                    {
                                        sx_Students[i].Beixuan = 1;
                                        sx_Teachers[k].LovestuList.Append(sx_Students[i]);//
                                        Console.WriteLine("该老师不喜欢这个学生，不过可以暂时接受他");
                                        Console.WriteLine("恭喜学生"+sx_Students[i].Groupid+"被老师"+sx_Teachers[k].Teaname+"录取啦！");
                                        string str = "此时教师" + sx_Teachers[k].Teaname + "的心仪学生有：[";
                                        for (int t = 1; t <= sx_Teachers[k].LovestuList.GetLength(); t++)
                                        {
                                            str += sx_Teachers[k].LovestuList.GetElem(t).Groupid + ",";
                                        }
                                        str += "]";
                                        Console.WriteLine(str);
                                        //break;
                                    }
                                    //break;
                                }
                            }

                        }
                        else//没找到这个老师，不可能吧
                        {
                            //Console.WriteLine("没找到"+ sx_Teachers[k].Teano  + "老师不可能呀"+ "，我要找的是："+ get_Lovetea);
                            if(sx_Students[i].Beixuan==1)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                }
            }


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



            for (int h = 0; h < sx_Teachers.Length; h++)  //检测教师心仪的学生链表里的值
            {
                MyLinkList<sx_student> myLinkList1 = new MyLinkList<sx_student>();
                if(sx_Teachers[h]!=null&& sx_Teachers[h].LovestuList.GetLength()>0)
                {
                    myLinkList1 = sx_Teachers[h].LovestuList;
                    string str = "教师" +sx_Teachers[h].Teano+"   ___"+ sx_Teachers[h].Teaname + "选的学生是[";
                    for(int i=1;i<=sx_Teachers[h].LovestuList.GetLength();i++)
                    {
                       str+= myLinkList1.GetElem(i).Groupid+",";
                    }
                    str += "]";
                    Console.WriteLine(str);
                }
            }


            Keepinformation.sx_Students = sx_Students; //没办法同时返回两个对象数组，只能通过第三方存储了？？？
            Keepinformation.sx_Teachers = sx_Teachers;




            return ("一轮匹配结束,点击确定查看匹配结果");
         
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
            string sql = @"select distinct(a.groupid) as 学生组号,
(select stuname from student where student.stuno=a.leaderno) as 组长姓名,
a.Topic as 学生课题,
a.VolFirstId as 志愿一,a.VolSecondId as 志愿二,a.VolThirdId as 志愿三,
(select avg(grade) as avg_grade from Student e,GroupStu d where e.StuNo=d.StuNo) as 小组平均成绩,
a.membernum as 组内人数,a.leaderno as 组长学号 from grouptable a left join groupstu c
on a.GroupID = c.groupid ";
            tableall = SQLHelper.ExecuteQuery(sql);//所有学生列表
            DataTable tableyixuan = new DataTable();
            string sql1 = "select teacherno as 教师工号,groupid as 学生组号,topic as 论文课题 from result";
          
            tableyixuan = SQLHelper.ExecuteQuery(sql1);//存放已完成匹配的学生
            Console.WriteLine( tableall.Rows.Count);
            for (int j = tableall.Rows.Count-1; j >= 0; j--)//倒序删除
            {
                Console.WriteLine("j="+j);
                for (int i = 0; i < tableyixuan.Rows.Count; i++)
                {
                    
                    if(tableall.Rows[j].RowState!=DataRowState.Deleted)
                    {
                        if (tableall.Rows[j][0].ToString() == tableyixuan.Rows[i][1].ToString())
                        {
                            tableall.Rows[j].Delete();
                        }
                    }
                }
                tableall.AcceptChanges();
            }
           
            return tableall;//通过删除已完成匹配的学生的方法将剩余的未完成匹配的学生数据返回
        }
        //教师列表
        public DataTable ST_GetTeaMatchtable()
        {
            DataTable table = new DataTable();
            string sql = @"select distinct(b.teano) as 教师工号,b.teaname as 教师姓名,b.groupnumber as 应带组数,a.kexuan as 可选组数,a.yixuan as 已选组数,a.Teavol1 as 志愿小组1,a.Teavol2 as 志愿小组2,a.Teavol3 as 志愿小组3,a.Teavol4 as 志愿小组4,a.Teavol5 as 志愿小组5 from addgrid b,Teavolheng2 a where a.teano=b.Teano";
            table = SQLHelper.ExecuteQuery(sql);
            DataTable table1 = new DataTable();
            table1 = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //if (Convert.ToInt32(table.Rows[i][3]) > 0)//若可选组数>0则显示
                //{
                    DataRow dr = table.Rows[i];
                    table1.Rows.Add(dr.ItemArray);
             //   Console.WriteLine("ST_GeyTeaMatchtable");
                //}
            }
            return table;
        }
        #endregion


        #region 二轮匹配实现
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
                if (stutable.Rows[i][0] != DBNull.Value)//组号
                {
                    student.Groupid = Convert.ToInt32(stutable.Rows[i][0]);
                }

                if (stutable.Rows[i][1] != DBNull.Value)//组长姓名
                {
                    student.Stuname = stutable.Rows[i][1].ToString();
                }
                if (stutable.Rows[i][2] != DBNull.Value)//学生课题
                {
                    student.Topic = stutable.Rows[i][2].ToString();
                }
                if (stutable.Rows[i][3] != DBNull.Value)//志愿一
                {
                    student.LoveTeacher[0] = stutable.Rows[i][3].ToString();
                }
                if (stutable.Rows[i][4] != DBNull.Value)//志愿二
                {
                    student.LoveTeacher[1] = stutable.Rows[i][4].ToString();
                }
                if (stutable.Rows[i][5] != DBNull.Value)//志愿三
                {
                    student.LoveTeacher[2] = stutable.Rows[i][5].ToString();
                }
                if (stutable.Rows[i][6] != DBNull.Value)//小组平均成绩
                {
                    student.Grade = Convert.ToDouble(stutable.Rows[i][6]);
                }
                if (stutable.Rows[i][7] != DBNull.Value)//组内人数
                {
                    student.Membernum = Convert.ToInt16(stutable.Rows[i][7]);
                }
                if (stutable.Rows[i][8] != DBNull.Value)//组长学号
                {
                    student.Leaderno = stutable.Rows[i][8].ToString();
                }
                student.Beixuan = 0;//初始化被选=0

                sx_Students[i] = student;
              
            }

            //将datatable中的值赋给sx_teacher对象数组
            for (int i = 0; i < row_teacount; i++)
            {
                sx_teacher teacher = new sx_teacher(20);//实例化对象
                teacher.Teano = teatable.Rows[i][0].ToString();//工号
                teacher.Teaname = teatable.Rows[i][1].ToString();//姓名
                teacher.Groupnumber = Convert.ToInt32(teatable.Rows[i][2]);//应带组数
                if (teatable.Rows[i][3] != DBNull.Value)//可选组数
                {
                    teacher.Kexuan = Convert.ToInt32(teatable.Rows[i][3]);
                }

                if (teatable.Rows[i][4] != DBNull.Value)//已选组数
                {
                    teacher.Yixuan = Convert.ToInt32(teatable.Rows[i][4]);
                }
                if (teatable.Rows[i][5] != DBNull.Value)//志愿一
                {
                    teacher.Groupid[0] = Convert.ToInt32(teatable.Rows[i][5]);
                }
                if (teatable.Rows[i][6] != DBNull.Value)//志愿二
                {
                    teacher.Groupid[1] = Convert.ToInt32(teatable.Rows[i][6]);
                }
                if (teatable.Rows[i][7] != DBNull.Value)//志愿三
                {
                    teacher.Groupid[2] = Convert.ToInt32(teatable.Rows[i][7]);
                }
                if (teatable.Rows[i][8] != DBNull.Value)//志愿四
                {
                    teacher.Groupid[3] = Convert.ToInt32(teatable.Rows[i][8]);
                }
                if (teatable.Rows[i][9] != DBNull.Value)//志愿五
                {
                    teacher.Groupid[4] = Convert.ToInt32(teatable.Rows[i][9]);
                }
                sx_Teachers[i] = teacher;
                sx_Teachers[i].LovestuList = new MyLinkList<sx_student>();//初始化一个链表，用于选择学生
            }
            Console.WriteLine("第二轮表白游戏开始啦！！！");
            //教师有可选组数，遍历每个志愿学生，看学生是否喜欢他
            for (int i = 0; i < row_teacount; i++)//遍历每个教师，由教师追学生
            {
                if (sx_Teachers[i].Kexuan >0)//该教师是否还有名额可以收徒
                {
                    for (int k = 0; k < sx_Teachers[i].Yixuan; k++)//遍历该教师的已选志愿
                    {
                        Console.WriteLine(sx_Teachers[i].Teaname + "老师向学生" + sx_Teachers[i].Groupid[k] + "表白啦");
                        for (int j = 0; j < row_stucount;j++)
                        {
                            if (sx_Students[j].Groupid == sx_Teachers[i].Groupid[k])//找到相应志愿的学生
                            {
                                for (int l = 0; l < 3; l++)//看学生的三个志愿老师里面有没有他
                                {
                                    if (sx_Students[j].LoveTeacher[l] == sx_Teachers[i].Teano && sx_Students[j].Beixuan == 0)
                                    {
                                        sx_Students[j].Beixuan = 1;
                                        sx_Teachers[i].LovestuList.Append(sx_Students[j]);
                                        Console.WriteLine("该学生被" + sx_Teachers[i].Teaname + "老师录取啦");
                                        sx_Teachers[i].Kexuan -= 1;
                                        Console.WriteLine("该老师目前可选人数为" + sx_Teachers[i].Kexuan + "人\n");
                                        
                                        

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
            Keepinformation.sx_Students = sx_Students;
            Keepinformation.sx_Teachers = sx_Teachers;
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
            sx_student[] sx_Students = new sx_student[50];
            sx_teacher[] sx_Teachers = new sx_teacher[20];
            sx_Students = Keepinformation.stsx_Students;
            sx_Teachers = Keepinformation.stsx_Teachers;

            ////将datatable中的值赋给sx_teacher对象数组
            //for (int i = 0; i < sx_Teachers.Length; i++)
            //{
            //    sx_teacher teacher = new sx_teacher(20);//实例化对象                
            //    sx_Teachers[i] = teacher;
            //    sx_Teachers[i].LovestuList = new MyLinkList<sx_student>();//初始化一个链表，用于选择学生
            //}

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
           //    Keepinformation.sx_Teachers = sx_Teachers;
            Keepinformation.stsx_Teachers = sx_Teachers;
        }

        public DataTable SelectFromResuit()
        {
            string sql = @"select distinct(a.groupid) as 学生组号,(select stuname from student d where d.stuno=(select leaderno from grouptable c where c.groupid=a.groupid)) as 组长姓名,b.teaname as 教师姓名,a.topic as 论文课题 from result a,teacher b,student c where a.teacherno=b.teano and a.groupid=c.groupid";
            DataTable dataTable = SQLHelper.ExecuteQuery(sql);
            return dataTable;
        }
        public int ReleasingNotices(InformationData InformationData)
        {
            string sql = @"insert into Information (InfoTitle,InfoContent) values(@InfoTitle,@InfoContent)";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                
                
                new SqlParameter("@InfoTitle",SqlDbType.NVarChar),
                new SqlParameter("@InfoContent",SqlDbType.NVarChar),
               
                
            };
            
            
            sqlParameter[0].Value = InformationData.InfoTitle;
            sqlParameter[1].Value = InformationData.InfoContent;
            
            int result = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameter);//执行insert/update/delete，返回受影响的行数
            return result;
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


