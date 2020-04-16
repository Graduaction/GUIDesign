using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
 
    //双选匹配页的学生列表数据
    [Serializable]
   public class sx_student
    {
        private int groupid = 0;  //组号
        private int membernum = 0;  //成员数      
        private string leaderno = string.Empty; //组长学号
        //private string volFirstId = string.Empty; //志愿一
        //private string volSecondId = string.Empty;//志愿二
        //private string volThirdId = string.Empty;//志愿三
        private string[] loveTeacher ;
        private string stuname = string.Empty;//组长姓名
        private double grade = 0; //平均成绩
        private int beixuan = 0;//是否被选
        private string topic = string.Empty;//课题
        

        public sx_student(int length)
        {
            this.loveTeacher = new string[length];
        }

        public int Groupid { get => groupid; set => groupid = value; }
        public int Membernum { get => membernum; set => membernum = value; }
        public string Leaderno { get => leaderno; set => leaderno = value; }
        //public string VolFirstId { get => volFirstId; set => volFirstId = value; }
        //public string VolSecondId { get => volSecondId; set => volSecondId = value; }
        //public string VolThirdId { get => volThirdId; set => volThirdId = value; }
        public double Grade { get => grade; set => grade = value; }
        public string Stuname { get => stuname; set => stuname = value; }
        public string[] LoveTeacher { get => loveTeacher; set => loveTeacher = value; }
        public int Beixuan { get => beixuan; set => beixuan = value; }
        public string Topic { get => topic; set => topic = value; }
    }
}
