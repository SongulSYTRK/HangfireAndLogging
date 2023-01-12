using Hangfire;
using System.Diagnostics;

namespace HangfireExample.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1",()=>EmailReport(),Cron.Minutely);

            //cron :zaman olarak temsilleri var 
        }
        //çağırılan method public olmak zorunda 
        public static void EmailReport()
        {
            Debug.WriteLine("Rapor email oalrak gönderildi");
        }
    }
}
