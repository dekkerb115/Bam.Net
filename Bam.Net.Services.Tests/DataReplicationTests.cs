using Bam.Net.CoreServices;
using Bam.Net.Services.DataReplication;
using Bam.Net.Testing;
using Bam.Net.Testing.Unit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.Tests
{
    [Serializable]
    public class DataReplicationTests: CommandLineTestInterface
    {        
        [UnitTest("Data Replication: can get type map")]
        public void CanGetTypeMap()
        {
            DataReplicationTypeMap typeMap = GetTestObject<DataReplicationTypeMap>();
            Expect.IsNotNull(typeMap, "typeMap was null");
        }

        [UnitTest("Data Replication: can get journal")]
        public void CanGetJournal()
        {
            DataReplicationJournal journal = GetTestObject<DataReplicationJournal>();
            Expect.IsNotNull(journal, "journal was null");
        }

        [UnitTest("Data Replication: type map should not be null")]
        public void TypeMapShouldNotBeNull()
        {
            DataReplicationJournal journal = GetTestObject<DataReplicationJournal>();
            Expect.IsNotNull(journal.DataReplicationTypeMap);
        }

        [UnitTest("Data Replication: Can write entries")]
        public void CanWriteEntries()
        {
            DataReplicationJournal journal = GetTestObject<DataReplicationJournal>();
            
            GetDataInstance(out long? typeId, out DataReplicationTestClass value);
            IEnumerable<DataReplicationJournalEntry> entries = journal.WriteEntries(value);
            foreach (DataReplicationJournalEntry entry in entries)
            {
                if (typeId == null)
                {
                    typeId = entry.TypeId;
                }
                Expect.AreEqual(typeId, entry.TypeId);

                Console.WriteLine("TypeId={0}, PropertyId={1}, TypeName={2}, PropertyName={3}, Value={4}",
                    entry.TypeId, 
                    entry.PropertyId, 
                    journal.GetTypeName(entry.TypeId),
                    journal.GetPropertyName(entry.PropertyId),
                    entry.Value);
            }
            OutLineFormat("journal directory {0}", ConsoleColor.Cyan, journal.JournalDirectory.FullName);
        }

        [UnitTest("Data Replication: can save and load type map")]
        public void CanSaveAndLoadTypeMap()
        {
            DataReplicationTypeMap typeMap = GetTestObject<DataReplicationTypeMap>();
            typeMap.AddMapping(new DataReplicationTestClass());
            int typeCount = typeMap.TypeMappings.Count;
            int propCount = typeMap.PropertyMappings.Count;

            string filePath = typeMap.Save();
            Expect.IsTrue(File.Exists(filePath));

            DataReplicationTypeMap loaded = DataReplicationTypeMap.Load(filePath);
            Expect.AreEqual(loaded.TypeMappings.Count, typeCount);
            Expect.AreEqual(loaded.PropertyMappings.Count, propCount);
        }

        [UnitTest("Data Replication: can read entries")]
        public void CanRead()
        {
            throw new NotImplementedException();
        }

        private static void GetDataInstance(out long? typeId, out DataReplicationTestClass value)
        {
            int age = RandomNumber.Between(5, 100);
            typeId = null;
            value = new DataReplicationTestClass
            {
                FirstName = "FirstNameValue",
                LastName = "LastNameValue",
                Age = age,
                BirthDate = DateTime.Now.Subtract(TimeSpan.FromDays(365 * age))
            };
        }

        private T GetTestObject<T>()
        {
            ServiceRegistry registry = DataReplicationRegistryContainer.GetServiceRegistry();
            return registry.Get<T>();
        }
    }
}
