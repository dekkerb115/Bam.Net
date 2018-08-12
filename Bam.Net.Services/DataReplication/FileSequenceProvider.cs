using Bam.Net.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    /// <summary>
    /// An implementation of ISequenceProvider that tracks the latest sequence value in a
    /// file.
    /// </summary>
    /// <seealso cref="Bam.Net.Services.DataReplication.ISequenceProvider" />
    public class FileSequenceProvider : ISequenceProvider
    {
        long _current;
        public FileSequenceProvider(SequenceFile sequenceFile, ILogger logger = null)
        {
            Logger = logger ?? Log.Default;
            if (sequenceFile.File.Exists)
            {
                string content = sequenceFile.File.ReadAllText();
                if (long.TryParse(content, out long result))
                {
                    _current = result;
                    Logger.AddEntry("Sequence value found in file: {0}", result.ToString());
                }
            }
            AppDomain.CurrentDomain.DomainUnload += (o, a) => _current.ToString().SafeWriteToFile(File.FullName, true);
        }

        public ILogger Logger { get; set; }
        public FileInfo File { get; set; }

        public long Next()
        {
            return ++_current;
        }
    }
}
