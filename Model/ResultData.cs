using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ResultData
    {
        private int _resultId = 0;
        private string _teaNo = string.Empty;
        private int _groupId = 0;
        private string topic = string.Empty;

        /// <summary>
        /// ID
        /// </summary>
        public int ResultId { get => _resultId; set => _resultId = value; }

        /// <summary>
        /// 老师id
        /// </summary>
        public string TeaNo { get => _teaNo; set => _teaNo = value; }

        /// <summary>
        /// 组别id
        /// </summary>
        public int GroupId { get => _groupId; set => _groupId = value; }

        /// <summary>
        /// 课题
        /// </summary>
        public string Topic { get => topic; set => topic = value; }
    }
}
