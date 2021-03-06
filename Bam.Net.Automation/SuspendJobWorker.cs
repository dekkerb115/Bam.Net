/*
	Copyright © Bryan Apellanes 2015  
*/
using Bam.Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Automation
{
    public class SuspendJobWorker: Worker
    {
        public SuspendJobWorker() : base() { }
        public SuspendJobWorker(string name) : base(name) { }

        protected override WorkState Do(WorkState currentWorkState)
        {
            SuspendedJob suspended = JobConductorService.SuspendJob(Job); ;
            WorkState<SuspendedJob> result = new WorkState<SuspendedJob>(this, suspended)
            {
                Status = Status.Suspended
            };
            return result;
        }

        public override string[] RequiredProperties
        {
            get { return new string[] { }; } // no required properties to suspend the job
        }
    }
}
