using HangfireExample.Web.Services;

namespace HangfireExample.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void EmailSendJobToUserJob(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
        }

    }
}
