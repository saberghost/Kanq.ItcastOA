using Kanq.ItcastOA.WebApp.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace Kanq.ItcastOA.WebApp
{
    public class ExceptionConfig
    {
        /// <summary>
        /// 添加异常处理线程
        /// </summary>
        public static void CreateExceptionThread()
        {
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem(u => {
                while (true)
                {
                    if (MyExceptionAtttribute.ExceptionQueue.Count > 0)
                    {
                        Exception ex = MyExceptionAtttribute.ExceptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            //string fileFullName = filePath + fileName + ".txt";
                            //File.AppendAllText(fileFullName, ex.Message);
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());
                        }
                        else
                        {
                            Thread.Sleep(1000 * 5);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000 * 5);
                    }
                }
            }, filePath);
        }
    }
}