﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net
{
    /// <summary>
    /// Used to specify the subdomain 
    /// a class should be served from when resolving
    /// hostname for a service
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ProxySubdomainAttribute: Attribute
    {
        public ProxySubdomainAttribute() { }
        public ProxySubdomainAttribute(string subdomain)
        {
            Subdomain = subdomain;
        }
        public string Subdomain { get; set; }
    }
}