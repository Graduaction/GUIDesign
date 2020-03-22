using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class InformationData
    {
        private int _infoNo = 0;
        private string _adminNo = string.Empty;
        private string _infoTitle = string.Empty;
        private string _infoContent = string.Empty;
        private DateTime _infoTime;

        /// <summary>
        /// 通知Id
        /// </summary>
        public int InfoNo { get => _infoNo; set => _infoNo = value; }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public string AdminNo { get => _adminNo; set => _adminNo = value; }

        /// <summary>
        /// 通知标题
        /// </summary>
        public string InfoTitle { get => _infoTitle; set => _infoTitle = value; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string InfoContent { get => _infoContent; set => _infoContent = value; }

        /// <summary>
        /// 通知时间
        /// </summary>
        public DateTime InfoTime { get => _infoTime; set => _infoTime = value; }
    }
}
