using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    public class DataReplicationJournal
    {
        public DataReplicationJournal(SystemPaths paths)
        {
            Paths = paths;
            Directory = new DirectoryInfo(Path.Combine(paths.Data.AppData, "ReplicationJournal"));
        }

        protected SystemPaths Paths { get; set; }

        public DirectoryInfo Directory { get; set; }

        public DataReplicationJournalEntry WriteEntry(DataReplicationJournalEntry journalEntry)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.FullName, journalEntry.Type.ToString().PadLeft(6, '0')));
            DirectoryInfo propertyDirectory = new DirectoryInfo(Path.Combine(directoryInfo.FullName, journalEntry.Property));
            FileInfo propertyFile = new FileInfo(Path.Combine(propertyDirectory.FullName, "seq".PadRight(9, '0')));
            propertyFile = new FileInfo(propertyFile.ToString().GetNextFileName());
            journalEntry.Value.SafeWriteToFile(propertyFile.FullName);
            Task.Run(() => propertyFile.ClearFileAccessLocks());
            return journalEntry;
        }
    }
}
