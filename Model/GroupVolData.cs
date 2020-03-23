using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupVolData
    {
        private int _groupID = 0;
        private int _volLevel = 0;
        private string _teaNo = string.Empty;
        /// <summary>
        /// 组别ID 更改
        /// </summary>
        public int GroupID { get => _groupID; set => _groupID = value; }
        /// <summary>
        /// 志愿等级
        /// </summary>
        public int VolLevel { get => _volLevel; set => _volLevel = value; }
        /// <summary>
        /// 教师工号
        /// </summary>
        public string TeaNo { get => _teaNo; set => _teaNo = value; }
        
    }
}
