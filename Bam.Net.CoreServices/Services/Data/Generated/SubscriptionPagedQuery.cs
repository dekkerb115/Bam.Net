/*
	This file was generated and should not be modified directly
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Bam.Net.Data;

namespace Bam.Net.CoreServices.Data.Daos
{
    public class SubscriptionPagedQuery: PagedQuery<SubscriptionColumns, Subscription>
    { 
		public SubscriptionPagedQuery(SubscriptionColumns orderByColumn, SubscriptionQuery query, Database db = null) : base(orderByColumn, query, db) { }
    }
}