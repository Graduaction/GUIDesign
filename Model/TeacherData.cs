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
        private int _chooseNo1 = 0;
        private int _chooseNo2 = 0;
        private int _chooseNo3 = 0;
        private int _chooseNo4 = 0;
        private int _chooseNo5 = 0;
        private int _chooseNo6 = 0;

        /// <summary>
        /// 工号
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
        /// 所选组号一
        /// </summary>
        public int ChooseNo1 { get => _chooseNo1; set => _chooseNo1 = value; }

        /// <summary>
        /// 所选组号二
        /// </summary>
        public int ChooseNo2 { get => _chooseNo2; set => _chooseNo2 = value; }

        /// <summary>
        /// 所选组号三
        /// </summary>
        public int ChooseNo3 { get => _chooseNo3; set => _chooseNo3 = value; }

        /// <summary>
        /// 所选组号四
        /// </summary>
        public int ChooseNo4 { get => _chooseNo4; set => _chooseNo4 = value; }

        /// <summary>
        /// 所选组号五
        /// </summary>
        public int ChooseNo5 { get => _chooseNo5; set => _chooseNo5 = value; }

        /// <summary>
        /// 所选组号六
        /// </summary>
        public int ChooseNo6 { get => _chooseNo6; set => _chooseNo6 = value; }
    }
}
