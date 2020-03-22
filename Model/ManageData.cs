using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class ManageData
    {
        private int _manageId = 0;
        private string _adminNo = string.Empty;
        private DateTime _startTime;
        private DateTime _endTime;
        private double grade;
        private double _volunteerFirstShare;
        private double _volunteerSecondShare;
        private double _volunteerThirdShare;


        /// <summary>
        /// ID
        /// </summary>
        public int ManageId { get => _manageId; set => _manageId = value; }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public string AdminNo { get => _adminNo; set => _adminNo = value; }

        /// <summary>
        /// 开放时间
        /// </summary>
        public DateTime StartTime { get => _startTime; set => _startTime = value; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime EndTime { get => _endTime; set => _endTime = value; }

        /// <summary>
        /// 组员平均综测成绩
        /// </summary>
        public double Grade { get => grade; set => grade = value; }

        /// <summary>
        /// 志愿等级一
        /// </summary>
        public double VolunteerFirstShare { get => _volunteerFirstShare; set => _volunteerFirstShare = value; }

        /// <summary>
        /// 志愿等级二
        /// </summary>
        public double VolunteerSecondShare { get => _volunteerSecondShare; set => _volunteerSecondShare = value; }

        /// <summary>
        /// 志愿等级三
        /// </summary>
        public double VolunteerThirdShare { get => _volunteerThirdShare; set => _volunteerThirdShare = value; }
    }
}
