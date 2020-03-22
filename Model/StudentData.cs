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
        private string _stuNo = string.Empty;
        private string _stuPwd = string.Empty;
        private string _stuName = string.Empty;
        private string _stuSex = string.Empty;
        private string academy = string.Empty;
        private string profession = string.Empty;
        private int grade = 0;
        private int _groupID = 0;
        private string _voluntaryFirst = string.Empty;
        private string _voluntarySecond = string.Empty;
        private string _voluntaryThird = string.Empty;

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
        public string StuSex { get => _stuSex; set => _stuSex = value; }

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
        public string VoluntaryFirst { get => _voluntaryFirst; set => _voluntaryFirst = value; }

        /// <summary>
        /// 志愿二老师id
        /// </summary>
        public string VoluntarySecond { get => _voluntarySecond; set => _voluntarySecond = value; }

        /// <summary>
        /// 志愿三老师id
        /// </summary>
        public string VoluntaryThird { get => _voluntaryThird; set => _voluntaryThird = value; }
    }
}
