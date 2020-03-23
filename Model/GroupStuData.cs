using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupStuData
    {
        private int _groupID = 0;
        private string _stuNo = string.Empty;
        /// <summary>
        /// 组号
        /// </summary>

        public int GroupID { get => _groupID; set => _groupID = value; }
        /// <summary>
        /// 该组的组员学号
        /// </summary>
        public string StuNo { get => _stuNo; set => _stuNo = value; }
    }
}
