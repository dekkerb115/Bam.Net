﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.Data.Repositories;

namespace Bam.Net.Services.AssemblyManagement.Data
{
    [Serializable]
    public class AssemblyReferenceDescriptor: KeyHashRepoData
    {
        public virtual List<AssemblyDescriptor> AssemblyDescriptors { get; set; }
        [CompositeKey]
        public string ReferencerHash { get; set; }
        [CompositeKey]
        public string ReferencedHash { get; set; }        
    }
}