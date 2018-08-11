using Bam.Net.Data;
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
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public int Seq { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }

        public static IEnumerable<DataReplicationJournalEntry> FromInstance(object instance)
        {
            object dto = DataExtensions.ToJsonSafe(instance);
            PropertyInfo[] properties = dto.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {

            }

            throw new NotImplementedException();
        }
    }
}
