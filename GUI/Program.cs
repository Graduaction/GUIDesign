using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          //  Application.Run(new CheckStudentsVolunteer());
            //  Application.Run(new StudentForm());//  LoginInterface  NoticeDetails  DCheckNotification
            Application.Run(new MainForm());

            //Application.Run(new CheckStudentsVolunteer());
            Application.Run(new CheckStudentsVolunteer());//  LoginInterface  NoticeDetails  DCheckNotification

        }
    }
}
