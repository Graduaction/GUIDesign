using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class GroupTableData
    {
        private int _groupID = 0;
        private string topic = string.Empty;
        private int _memberNum = 0;
        private string _leaderno = string.Empty;
        private string _volFirstId = string.Empty;
        private string _volSecondId = string.Empty;
        private string _volThirdId = string.Empty;
        /// <summary>
        /// 组别ID
        /// </summary>
        public int GroupID { get => _groupID; set => _groupID = value; }
        /// <summary>
        /// 课题
        /// </summary>
        public string Topic { get => topic; set => topic = value; }

        /// <summary>
        /// 该组总人数
        /// </summary>
        public int MemberNum { get => _memberNum; set => _memberNum = value; }

        /// <summary>
        /// 组长学号
        /// </summary>
        public string Leaderno { get => _leaderno; set => _leaderno = value; }

        /// <summary>
        /// 第一志愿老师id
        /// </summary>
        public string VolFirstId { get => _volFirstId; set => _volFirstId = value; }

        /// <summary>
        /// 第二志愿老师id
        /// </summary>
        public string VolSecondId { get => _volSecondId; set => _volSecondId = value; }

        /// <summary>
        /// 第三志愿老师id
        /// </summary>
        public string VolThirdId { get => _volThirdId; set => _volThirdId = value; }
    }
}
