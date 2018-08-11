using Bam.Net.CoreServices;
using Bam.Net.Services.DataReplication;
using Bam.Net.Testing;
using Bam.Net.Testing.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.Tests
{
    [Serializable]
    public class DataReplicationTests: CommandLineTestInterface
    {
        [UnitTest]
        public void CanWriteJournalEntry()
        {
            DataReplicationJournal journal = GetTestObject<DataReplicationJournal>();
            //journal.WriteEntry(DataReplicationJournalEntry)
        }

        private T GetTestObject<T>()
        {
            ServiceRegistry registry = DataReplicationRegistryContainer.GetServiceRegistry();
            return registry.Get<T>();
        }
    }
}
