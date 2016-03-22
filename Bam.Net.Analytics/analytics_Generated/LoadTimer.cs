/*
	This file was generated and should not be modified directly
*/
// Model is Table
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Bam.Net;
using Bam.Net.Data;
using Bam.Net.Data.Qi;

namespace Bam.Net.Analytics
{
	// schema = Analytics
	// connection Name = Analytics
	[Serializable]
	[Bam.Net.Data.Table("LoadTimer", "Analytics")]
	public partial class LoadTimer: Dao
	{
		public LoadTimer():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public LoadTimer(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public LoadTimer(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public LoadTimer(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator LoadTimer(DataRow data)
		{
			return new LoadTimer(data);
		}

		private void SetChildren()
		{
						
		}

	// property:Id, columnName:Id	
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

	// property:Uuid, columnName:Uuid	
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

	// property:UrlId, columnName:UrlId	
	[Bam.Net.Data.Column(Name="UrlId", DbDataType="Int", MaxLength="10", AllowNull=true)]
	public int? UrlId
	{
		get
		{
			return GetIntValue("UrlId");
		}
		set
		{
			SetValue("UrlId", value);
		}
	}



	// start TimerId -> TimerId
	[Bam.Net.Data.ForeignKey(
        Table="LoadTimer",
		Name="TimerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Timer",
		Suffix="1")]
	public long? TimerId
	{
		get
		{
			return GetLongValue("TimerId");
		}
		set
		{
			SetValue("TimerId", value);
		}
	}

	Timer _timerOfTimerId;
	public Timer TimerOfTimerId
	{
		get
		{
			if(_timerOfTimerId == null)
			{
				_timerOfTimerId = Bam.Net.Analytics.Timer.OneWhere(c => c.KeyColumn == this.TimerId, this.Database);
			}
			return _timerOfTimerId;
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
				var colFilter = new LoadTimerColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the LoadTimer table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static LoadTimerCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<LoadTimer>();
			Database db = database ?? Db.For<LoadTimer>();
			var results = new LoadTimerCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static async Task BatchAll(int batchSize, Func<LoadTimerCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				LoadTimerColumns columns = new LoadTimerColumns();
				var orderBy = Order.By<LoadTimerColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, (c) => c.KeyColumn > 0, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (c) => c.KeyColumn > topId, orderBy, database);
				}
			});			
		}	 

		public static async Task BatchQuery(int batchSize, QueryFilter filter, Func<LoadTimerCollection, Task> batchProcessor, Database database = null)
		{
			await BatchQuery(batchSize, (c) => filter, batchProcessor, database);			
		}

		public static async Task BatchQuery(int batchSize, WhereDelegate<LoadTimerColumns> where, Func<LoadTimerCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				LoadTimerColumns columns = new LoadTimerColumns();
				var orderBy = Order.By<LoadTimerColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (LoadTimerColumns)where(columns) && columns.KeyColumn > topId, orderBy, database);
				}
			});			
		}

		public static LoadTimer GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static LoadTimer GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static LoadTimer GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Uuid") == uuid, database);
		}

		public static LoadTimer GetByCuid(string cuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Cuid") == cuid, database);
		}

		public static LoadTimerCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static LoadTimerCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<LoadTimerColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a LoadTimerColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LoadTimerCollection Where(Func<LoadTimerColumns, QueryFilter<LoadTimerColumns>> where, OrderBy<LoadTimerColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<LoadTimer>();
			return new LoadTimerCollection(database.GetQuery<LoadTimerColumns, LoadTimer>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LoadTimerCollection Where(WhereDelegate<LoadTimerColumns> where, Database database = null)
		{		
			database = database ?? Db.For<LoadTimer>();
			var results = new LoadTimerCollection(database, database.GetQuery<LoadTimerColumns, LoadTimer>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LoadTimerCollection Where(WhereDelegate<LoadTimerColumns> where, OrderBy<LoadTimerColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<LoadTimer>();
			var results = new LoadTimerCollection(database, database.GetQuery<LoadTimerColumns, LoadTimer>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate&lt;LoadTimerColumns&gt;.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LoadTimerCollection Where(QiQuery where, Database database = null)
		{
			var results = new LoadTimerCollection(database, Select<LoadTimerColumns>.From<LoadTimer>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static LoadTimer GetOneWhere(QueryFilter where, Database database = null)
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
		public static LoadTimer OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<LoadTimerColumns> whereDelegate = (c) => where;
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
		public static LoadTimer GetOneWhere(WhereDelegate<LoadTimerColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				LoadTimerColumns c = new LoadTimerColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single LoadTimer instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadTimer OneWhere(WhereDelegate<LoadTimerColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<LoadTimerColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LoadTimer OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadTimer FirstOneWhere(WhereDelegate<LoadTimerColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadTimer FirstOneWhere(WhereDelegate<LoadTimerColumns> where, OrderBy<LoadTimerColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadTimer FirstOneWhere(QueryFilter where, OrderBy<LoadTimerColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<LoadTimerColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadTimerCollection Top(int count, WhereDelegate<LoadTimerColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LoadTimerCollection Top(int count, WhereDelegate<LoadTimerColumns> where, OrderBy<LoadTimerColumns> orderBy, Database database = null)
		{
			LoadTimerColumns c = new LoadTimerColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<LoadTimer>();
			QuerySet query = GetQuerySet(db); 
			query.Top<LoadTimer>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<LoadTimerColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LoadTimerCollection>(0);
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
		public static LoadTimerCollection Top(int count, QueryFilter where, OrderBy<LoadTimerColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<LoadTimer>();
			QuerySet query = GetQuerySet(db);
			query.Top<LoadTimer>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<LoadTimerColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LoadTimerCollection>(0);
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
		public static LoadTimerCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<LoadTimer>();
			QuerySet query = GetQuerySet(db);
			query.Top<LoadTimer>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<LoadTimerCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<LoadTimerColumns> where, Database database = null)
		{
			LoadTimerColumns c = new LoadTimerColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<LoadTimer>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<LoadTimer>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static LoadTimer CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<LoadTimer>();			
			var dao = new LoadTimer();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static LoadTimer OneOrThrow(LoadTimerCollection c)
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
