using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Keepinformation
    {
        //个人信息页暂存信息
        public static string AdminNo = "";
        public static string AdminPwd = "";
        public static string AdminName = "";
        public static string AdminTitle = "";
        public static string AdminEmail = "";

        //设置双选参数页暂存信息
        public static string AdminNo1 = "";
        public static DateTime StartTime;
        public static DateTime EndTime;
        public static string VolunteerFirstShare = "";
        public static string VolunteerSecondShare = "";
        public static string VolunteerThirdShare = "";
        public static string Grade;

        //双选匹配页
        public static sx_teacher[] sx_Teachers;
        public static sx_student[] sx_Students;

        //第二轮双选
        public static sx_teacher[] stsx_Teachers;
        public static sx_student[] stsx_Students;
    }
}
