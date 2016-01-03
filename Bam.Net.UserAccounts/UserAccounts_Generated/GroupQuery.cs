/*
	Copyright © Bryan Apellanes 2015  
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Bam.Net.Data;

namespace Bam.Net.UserAccounts.Data
{
    public class GroupQuery: Query<GroupColumns, Group>
    { 
		public GroupQuery(){}
		public GroupQuery(WhereDelegate<GroupColumns> where, OrderBy<GroupColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }
		public GroupQuery(Func<GroupColumns, QueryFilter<GroupColumns>> where, OrderBy<GroupColumns> orderBy = null, Database db = null) : base(where, orderBy, db) { }		
		public GroupQuery(Delegate where, Database db = null) : base(where, db) { }

		public GroupCollection Execute()
		{
			return new GroupCollection(this, true);
		}
    }
}