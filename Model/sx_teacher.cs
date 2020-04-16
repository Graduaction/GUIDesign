using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class sx_teacher
    {
        private string teano = string.Empty;//教师工号
        private string teaname=string.Empty;//教师姓名
        private int groupnumber=0;//所带组数
        private int yixuan = 0;//已选组数
        //private int groupid1=0;//志愿一
        //private int groupid2=0;//志愿二
        //private int groupid3=0;//志愿三
        //private int groupid4=0;//志愿四
        //private int groupid5=0;//志愿五
        private int[] groupid;
       // private doubleLinkedList doubleLinkedList;//调用另一个表声明的双向链表
        private MyLinkList<sx_student> lovestuList;//单链表

        

        public sx_teacher(int length)
        {
            this.groupid = new int[length];
        }
        
        

        public string Teano { get => teano; set => teano = value; }
        public string Teaname { get => teaname; set => teaname = value; }
        public int Groupnumber { get => groupnumber; set => groupnumber = value; }
        public int Yixuan { get => yixuan; set => yixuan = value; }
        //public int Groupid1 { get => groupid1; set => groupid1 = value; }
        //public int Groupid2 { get => groupid2; set => groupid2 = value; }
        //public int Groupid3 { get => groupid3; set => groupid3 = value; }
        //public int Groupid4 { get => groupid4; set => groupid4 = value; }
        //public int Groupid5 { get => groupid5; set => groupid5 = value; }
        public int[] Groupid { get => groupid; set => groupid = value; }
        public MyLinkList<sx_student> LovestuList { get => lovestuList; set => lovestuList = value; }













    }
}
