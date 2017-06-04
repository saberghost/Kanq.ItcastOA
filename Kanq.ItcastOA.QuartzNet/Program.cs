﻿using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Quartz.MisfireInstruction;

namespace Kanq.ItcastOA.QuartzNet
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler sched;
            ISchedulerFactory sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();
            JobDetailImpl job = new JobDetailImpl("job1", "group1", typeof(IndexJob));//IndexJob为实现了IJob接口的类
            //DateTime ts = TriggerUtils.GetNextGivenSecondDate(null, 5);//5秒后开始第一次运行
            TimeSpan interval = TimeSpan.FromSeconds(5);//每隔1小时执行一次
            SimpleTriggerImpl trigger = new SimpleTriggerImpl("trigger1", "group1", "job1", "group1", DateTime.Now.AddSeconds(5), null,
                                                    SimpleTriggerImpl.RepeatIndefinitely, interval);//每若干小时运行一次，小时间隔由appsettings中的IndexIntervalHour参数指定

            //sched.AddJob(job, true);
            sched.ScheduleJob(job,trigger);
            sched.Start();
            Console.ReadKey();
        }
    }
}
