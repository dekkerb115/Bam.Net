/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Bam.Net.Data;

namespace Bam.Net.Analytics
{
    public class PortPagedQuery: PagedQuery<PortColumns, Port>
    { 
		public PortPagedQuery(PortColumns orderByColumn, PortQuery query, Database db = null) : base(orderByColumn, query, db) { }
    }
}