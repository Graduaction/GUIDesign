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
        private string _memberFirstId = string.Empty;
        private string _memberSecondId = string.Empty;
        private string _memberThirdId = string.Empty;
        private string _memberForthId = string.Empty;
        private string _memberFifthId = string.Empty;
        private string _memberSixthId = string.Empty;
        private string _volFirstId = string.Empty;
        private string _volSecondId = string.Empty;
        private string _volThirdId = string.Empty;
        private string topic = string.Empty;
        private int _memberNum = 0;


        /// <summary>
        /// 组别ID
        /// </summary>
        public int GroupID { get => _groupID; set => _groupID = value; }

        /// <summary>
        /// 组员1
        /// </summary>
        public string MemberFirstId { get => _memberFirstId; set => _memberFirstId = value; }

        /// <summary>
        /// 组员2
        /// </summary>
        public string MemberSecondId { get => _memberSecondId; set => _memberSecondId = value; }

        /// <summary>
        /// 组员3
        /// </summary>
        public string MemberThirdId { get => _memberThirdId; set => _memberThirdId = value; }

        /// <summary>
        /// 组员4
        /// </summary>
        public string MemberForthId { get => _memberForthId; set => _memberForthId = value; }

        /// <summary>
        /// 组员5
        /// </summary>
        public string MemberFifthId { get => _memberFifthId; set => _memberFifthId = value; }

        /// <summary>
        /// 组员6
        /// </summary>
        public string MemberSixthId { get => _memberSixthId; set => _memberSixthId = value; }

        /// <summary>
        /// 志愿一老师id
        /// </summary>
        public string VolFirstId { get => _volFirstId; set => _volFirstId = value; }

        /// <summary>
        /// 志愿二老师id
        /// </summary>
        public string VolSecondId { get => _volSecondId; set => _volSecondId = value; }

        /// <summary>
        /// 志愿三老师id
        /// </summary>
        public string VolThirdId { get => _volThirdId; set => _volThirdId = value; }

        /// <summary>
        /// 课题
        /// </summary>
        public string Topic { get => topic; set => topic = value; }

        /// <summary>
        /// 该组总人数
        /// </summary>
        public int MemberNum { get => _memberNum; set => _memberNum = value; }
    }
}
