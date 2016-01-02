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
    public class LoadCounterQuery: Query<LoadCounterColumns, LoadCounter>
    { 
		public LoadCounterQuery(){}
		public LoadCounterQuery(WhereDelegate<LoadCounterColumns> where, OrderBy<LoadCounterColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }
		public LoadCounterQuery(Func<LoadCounterColumns, QueryFilter<LoadCounterColumns>> where, OrderBy<LoadCounterColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }		
		public LoadCounterQuery(Delegate where, Database db = null) : base(where, db) { }

		public LoadCounterCollection Execute()
		{
			return new LoadCounterCollection(this, true);
		}
    }
}