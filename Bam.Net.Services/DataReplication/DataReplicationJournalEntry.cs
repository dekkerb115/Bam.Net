using Bam.Net.Data;
using Bam.Net.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    public class DataReplicationJournalEntry
    {
        /// <summary>
        /// Gets or sets the type int determined by DataReplicationtypeMap.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public long TypeId { get; set; }

        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public long Seq { get; set; }
        public long PropertyId { get; set; }
        public string Value { get; set; }

        public static IEnumerable<DataReplicationJournalEntry> FromInstance(KeyHashAuditRepoData instance)
        {
            Args.ThrowIfNull(instance, "instance");
            long typeId = DataReplicationTypeMap.GetTypeId(instance, out object dynamicInstance, out Type dynamicType);
            foreach (PropertyInfo prop in dynamicType.GetProperties())
            {
                yield return new DataReplicationJournalEntry { TypeId = typeId, Id = instance.GetLongKeyHash(), PropertyId = DataReplicationTypeMap.GetPropertyId(prop, out string ignore), Value = prop.GetValue(dynamicInstance)?.ToString() };
            }
        }

    }
}
