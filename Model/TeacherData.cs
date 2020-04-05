using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TeacherData
    {
        private string _teaNo = string.Empty;
        private string _teaPwd = string.Empty;
        private string _teaName = string.Empty;
        private string title = string.Empty;
        private string _teaSex = string.Empty;
        private string profile = string.Empty;
        private int _groupNumber = 0;
        private string contaction = string.Empty;
        private string _academy = string.Empty;



        /// <summary>
        /// 工号 更改
        /// </summary>
        public string TeaNo { get => _teaNo; set => _teaNo = value; }

        /// <summary>
        /// 密码
        /// </summary>
        public string TeaPwd { get => _teaPwd; set => _teaPwd = value; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string TeaName { get => _teaName; set => _teaName = value; }

        /// <summary>
        /// 职称
        /// </summary>
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// 性别
        /// </summary>
        public string TeaSex { get => _teaSex; set => _teaSex = value; }

        /// <summary>
        /// 个人简介
        /// </summary>
        public string Profile { get => profile; set => profile = value; }

        /// <summary>
        /// 所带组数
        /// </summary>
        public int GroupNumber { get => _groupNumber; set => _groupNumber = value; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contaction { get => contaction; set => contaction = value; }
        /// <summary>
        /// 所属学院
        /// </summary>
        public string Academy { get => _academy; set => _academy = value; }
    }
}
