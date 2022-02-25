using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.BackgroundJobs
{
    public class DelayedJobs
    {

        public static string DebugOutput()
        {
            return Hangfire.BackgroundJob.Schedule(() => OutputWrite(), TimeSpan.FromSeconds(10));
        }

        public static void OutputWrite()
        {
            Debug.WriteLine("This method was written for testing Hangfire.");
        }


    }
}
