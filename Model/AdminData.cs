using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class AdminData
    {
        ///
        /// <summary>
        /// Admin表
        /// </summary>
        private string _adminNo = string.Empty;
        private string _adminPwd = string.Empty;
        private string _adminName = string.Empty;
        private string _adminTitle = string.Empty;

        /// <summary>
        /// 管理员ID
        /// </summary>
        public string AdminNo { get => _adminNo; set => _adminNo = value; }

        /// <summary>
        /// 密码
        /// </summary>
        public string AdminPwd { get => _adminPwd; set => _adminPwd = value; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string AdminName { get => _adminName; set => _adminName = value; }

        /// <summary>
        /// 职称
        /// </summary>
        public string AdminTitle { get => _adminTitle; set => _adminTitle = value; }
    }
}
