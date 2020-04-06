using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class StudentData
    {
        private int _stuID = 0;
        private int _stuClass = 1;
        private string _stuNianji = string.Empty;
        private string _stuNo = string.Empty;
        private string _stuPwd = string.Empty;
        private string _stuName = string.Empty;
        private int _gender ;
        private string academy = string.Empty;
        private string profession = string.Empty;
        private int grade = 0;
        private int _groupID = 0;
        private int _voluntaryFirst ;
        private int _voluntarySecond ;
        private int _voluntaryThird ;
        private string _stuPhone = string.Empty;
        private string _stuQQ = string.Empty;
        private string _stuEmail = string.Empty;
        private string _stuPerIntro = string.Empty;
        private string _stuHonors = string.Empty;

        /// <summary>
        /// 学号
        /// </summary>
        public string StuNo { get => _stuNo; set => _stuNo = value; }

        /// <summary>
        /// 密码
        /// </summary>
        public string StuPwd { get => _stuPwd; set => _stuPwd = value; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StuName { get => _stuName; set => _stuName = value; }

        /// <summary>
        /// 性别
        /// </summary>
        public int StuSex { get => _gender; set => _gender = value; }

        /// <summary>
        /// 学院
        /// </summary>
        public string Academy { get => academy; set => academy = value; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Profession { get => profession; set => profession = value; }

        /// <summary>
        /// 个人综测成绩
        /// </summary>
        public int Grade { get => grade; set => grade = value; }

        /// <summary>
        /// 组别ID
        /// </summary>
        public int GroupID { get => _groupID; set => _groupID = value; }

        /// <summary>
        /// 志愿一老师id
        /// </summary>
        public int VoluntaryFirst { get => _voluntaryFirst; set => _voluntaryFirst = value; }

        /// <summary>
        /// 志愿二老师id
        /// </summary>
        public int VoluntarySecond { get => _voluntarySecond; set => _voluntarySecond = value; }

        /// <summary>
        /// 志愿三老师id
        /// </summary>
        public int VoluntaryThird { get => _voluntaryThird; set => _voluntaryThird = value; }
        /// <summary>
        /// 学生年级
        /// </summary>
        public string StuNianji { get => _stuNianji; set => _stuNianji = value; }
        /// <summary>
        /// 学生班级
        /// </summary>
        public int StuClass { get => _stuClass; set => _stuClass = value; }
        /// <summary>
        /// 学生id
        /// </summary>
        public int StuID { get => _stuID; set => _stuID = value; }
        /// <summary>
        /// 手机
        /// </summary>
        public string StuPhone { get => _stuPhone; set => _stuPhone = value; }
        /// <summary>
        /// QQ
        /// </summary>
        public string StuQQ { get => _stuQQ; set => _stuQQ = value; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string StuEmail { get => _stuEmail; set => _stuEmail = value; }
        /// <summary>
        /// 个人简介
        /// </summary>
        public string StuPerIntro { get => _stuPerIntro; set => _stuPerIntro = value; }
        /// <summary>
        /// 在校期间获得的荣誉
        /// </summary>
        public string StuHonors { get => _stuHonors; set => _stuHonors = value; }
    }
}
