using System.Diagnostics;

namespace HangfireExample.Web.BackgroundJobs
{
    public class ContinuationsJob
    {

        public static void WritewaterMarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{fileName} : resime watermark eklenmiştir."));

        }
    }
}
