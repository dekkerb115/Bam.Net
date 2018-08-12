using Bam.Net.Data.Repositories;
using Bam.Net.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    public class DataReplicationJournal
    {
        Queue<DataReplicationJournalEntry> _dataReplicationJournalEntries;
        bool _keepFlushing;

        public DataReplicationJournal(SystemPaths paths, DataReplicationTypeMap typeMap, ISequenceProvider sequenceProvider, ILogger logger = null)
        {
            _dataReplicationJournalEntries = new Queue<DataReplicationJournalEntry>();
            _keepFlushing = true;
            SequenceProvider = sequenceProvider;
            Paths = paths;
            DataReplicationTypeMap = typeMap;
            JournalDirectory = new DirectoryInfo(Path.Combine(paths.Data.AppData, nameof(DataReplicationJournal), nameof(DataReplicationJournalEntry).Pluralize()));
            Logger = logger;
            AppDomain.CurrentDomain.DomainUnload += (o, a) => _keepFlushing = false;
            FlushQueue();
        }

        protected internal SystemPaths Paths { get; set; }
        protected internal DataReplicationTypeMap DataReplicationTypeMap { get; set; }
        protected internal ISequenceProvider SequenceProvider { get; set; }

        public DirectoryInfo JournalDirectory { get; set; }
        public ILogger Logger { get; set; }

        public string GetTypeName(long typeId)
        {
            return DataReplicationTypeMap.GetTypeName(typeId);
        }

        public string GetPropertyName(long propId)
        {
            return DataReplicationTypeMap.GetPropertyName(propId);
        }

        /// <summary>
        /// Gets or sets the exception the number of exceptions to tolerate while flushing the queue before stopping the flush thread.
        /// </summary>
        /// <value>
        /// The exception threshold.
        /// </value>
        public int ExceptionThreshold { get; set; }

        public IEnumerable<DataReplicationJournalEntry> WriteEntries(KeyHashAuditRepoData data)
        {
            Task.Run(() => DataReplicationTypeMap.AddMapping(data));
            foreach(DataReplicationJournalEntry entry in DataReplicationJournalEntry.FromInstance(data))
            {
                yield return WriteEntry(entry);
            }
        }

        protected internal DataReplicationJournalEntry WriteEntry(DataReplicationJournalEntry journalEntry)
        {
            journalEntry.Seq = SequenceProvider.Next();
            _dataReplicationJournalEntries.Enqueue(journalEntry);
            return journalEntry;
        }

        int _exceptionCount;
        private void FlushQueue()
        {
            Task.Run(() =>
            {
                while (_keepFlushing )
                {
                    try
                    {
                        if (_dataReplicationJournalEntries.Count > 0)
                        {
                            DataReplicationJournalEntry journalEntry = _dataReplicationJournalEntries.Dequeue();
                            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(JournalDirectory.FullName, journalEntry.TypeId.ToString().PadLeft(6, '0')));
                            DirectoryInfo propertyDirectory = new DirectoryInfo(Path.Combine(directoryInfo.FullName, journalEntry.PropertyId.ToString()));
                            FileInfo propertyFile = new FileInfo(Path.Combine(propertyDirectory.FullName, journalEntry.Seq.ToString().PadRight(9, '0')));
                            journalEntry.Value.SafeWriteToFile(propertyFile.FullName, true);
                        }
                        else
                        {
                            Thread.Sleep(300);
                        }
                    }
                    catch (Exception ex)
                    {
                        _exceptionCount++;
                        Logger.AddEntry("Exception in {0}.{1}: Count {2}", ex, nameof(DataReplicationJournal), nameof(FlushQueue), _exceptionCount.ToString());
                        if (_exceptionCount >= ExceptionThreshold)
                        {
                            _keepFlushing = false;
                            Logger.AddEntry("ExceptionThreshold reached ({0}), stopping flushing thread.", ExceptionThreshold.ToString());
                        }
                    }
                }
            });
        }
    }
}
