/*
	Copyright © Bryan Apellanes 2015  
*/
// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Bam.Net;
using Bam.Net.Data;
using Bam.Net.Data.Qi;

namespace Bam.Net.Analytics
{
	// schema = Analytics
	// connection Name = Analytics
	[Serializable]
	[Bam.Net.Data.Table("Port", "Analytics")]
	public partial class Port: Dao
	{
		public Port():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Port(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Port(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Port(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Port(DataRow data)
		{
			return new Port(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("Url_PortId", new UrlCollection(Database.GetQuery<UrlColumns, Url>((c) => c.PortId == GetLongValue("Id")), this, "PortId"));							
		}

﻿	// property:Id, columnName:Id	
	[Exclude]
	[Bam.Net.Data.KeyColumn(Name="Id", DbDataType="BigInt", MaxLength="19")]
	public long? Id
	{
		get
		{
			return GetLongValue("Id");
		}
		set
		{
			SetValue("Id", value);
		}
	}

﻿	// property:Uuid, columnName:Uuid	
	[Bam.Net.Data.Column(Name="Uuid", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Uuid
	{
		get
		{
			return GetStringValue("Uuid");
		}
		set
		{
			SetValue("Uuid", value);
		}
	}

﻿	// property:Value, columnName:Value	
	[Bam.Net.Data.Column(Name="Value", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Value
	{
		get
		{
			return GetIntValue("Value");
		}
		set
		{
			SetValue("Value", value);
		}
	}



				
﻿
	[Exclude]	
	public UrlCollection UrlsByPortId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Url_PortId"))
			{
				SetChildren();
			}

			var c = (UrlCollection)this.ChildCollections["Url_PortId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			if(UniqueFilterProvider != null)
			{
				return UniqueFilterProvider();
			}
			else
			{
				var colFilter = new PortColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the Port table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PortCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Port>();
			Database db = database ?? Db.For<Port>();
			var results = new PortCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Port GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Port GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static Port GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Uuid") == uuid, database);
		}

		public static Port GetByCuid(string cuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Cuid") == cuid, database);
		}

		public static PortCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PortCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PortColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PortColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PortCollection Where(Func<PortColumns, QueryFilter<PortColumns>> where, OrderBy<PortColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Port>();
			return new PortCollection(database.GetQuery<PortColumns, Port>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PortCollection Where(WhereDelegate<PortColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Port>();
			var results = new PortCollection(database, database.GetQuery<PortColumns, Port>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PortCollection Where(WhereDelegate<PortColumns> where, OrderBy<PortColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Port>();
			var results = new PortCollection(database, database.GetQuery<PortColumns, Port>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PortColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PortCollection Where(QiQuery where, Database database = null)
		{
			var results = new PortCollection(database, Select<PortColumns>.From<Port>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Port GetOneWhere(QueryFilter where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				result = CreateFromFilter(where, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Port OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PortColumns> whereDelegate = (c) => where;
			var result = Top(1, whereDelegate, database);
			return OneOrThrow(result);
		}

		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Port GetOneWhere(WhereDelegate<PortColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PortColumns c = new PortColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Port instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Port OneWhere(WhereDelegate<PortColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PortColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Port OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Port FirstOneWhere(WhereDelegate<PortColumns> where, Database database = null)
		{
			var results = Top(1, where, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Port FirstOneWhere(WhereDelegate<PortColumns> where, OrderBy<PortColumns> orderBy, Database database = null)
		{
			var results = Top(1, where, orderBy, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Shortcut for Top(1, where, orderBy, database)
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Port FirstOneWhere(QueryFilter where, OrderBy<PortColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PortColumns> whereDelegate = (c) => where;
			var results = Top(1, whereDelegate, orderBy, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Execute a query and return the specified number
		/// of values. This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PortCollection Top(int count, WhereDelegate<PortColumns> where, Database database = null)
		{
			return Top(count, where, null, database);
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PortCollection Top(int count, WhereDelegate<PortColumns> where, OrderBy<PortColumns> orderBy, Database database = null)
		{
			PortColumns c = new PortColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Port>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Port>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PortColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PortCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A QueryFilter used to filter the 
		/// results
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="db"></param>
		public static PortCollection Top(int count, QueryFilter where, OrderBy<PortColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Port>();
			QuerySet query = GetQuerySet(db);
			query.Top<Port>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PortColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PortCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A QueryFilter used to filter the 
		/// results
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="db"></param>
		public static PortCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Port>();
			QuerySet query = GetQuerySet(db);
			query.Top<Port>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PortCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PortColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PortColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PortColumns> where, Database database = null)
		{
			PortColumns c = new PortColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Port>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Port>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Port CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Port>();			
			var dao = new Port();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Port OneOrThrow(PortCollection c)
		{
			if(c.Count == 1)
			{
				return c[0];
			}
			else if(c.Count > 1)
			{
				throw new MultipleEntriesFoundException();
			}

			return null;
		}

	}
}																								