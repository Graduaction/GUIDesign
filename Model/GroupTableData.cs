﻿using System;
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
    }
}
