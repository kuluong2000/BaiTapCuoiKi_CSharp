using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    public class Common
    {
        //sPage: tên trang cần log, sFunction: tên hàm cần log, sMessage:Nội dung cần log
        //public static void WriteLog(string sPage, string sFunction, string sMessage)
        //{
        //    try
        //    {
        //        string LogPath = HttpContext.Current.Server.MapPath("~/LogInfo");
        //        if (!System.IO.Directory.Exists(LogPath))
        //        {
        //            System.IO.Directory.CreateDirectory(LogPath);
        //        }
        //        CLogger TestLogger = new CLogger();
        //        TestLogger.Initialize(LogPath, "Web.log", 2);
        //        TestLogger.LogInformation(sPage, sFunction, sMessage);
        //        TestLogger.Terminate();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //   }
        }
}