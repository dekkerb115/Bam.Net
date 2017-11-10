/*
	This file was generated and should not be modified directly
*/
// Model is Table
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Bam.Net;
using Bam.Net.Data;
using Bam.Net.Data.Qi;

namespace Bam.Net.Data.Tests
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Bam.Net.Data.Table("ListItem", "Shop")]
	public partial class ListItem: Bam.Net.Data.Dao
	{
		public ListItem():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ListItem(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ListItem(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ListItem(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		[Bam.Net.Exclude]
		public static implicit operator ListItem(DataRow data)
		{
			return new ListItem(data);
		}

		private void SetChildren()
		{
						
		}

	// property:Id, columnName:Id	
	[Bam.Net.Exclude]
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



	// start ListId -> ListId
	[Bam.Net.Data.ForeignKey(
        Table="ListItem",
		Name="ListId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="List",
		Suffix="1")]
	public long? ListId
	{
		get
		{
			return GetLongValue("ListId");
		}
		set
		{
			SetValue("ListId", value);
		}
	}

	List _listOfListId;
	public List ListOfListId
	{
		get
		{
			if(_listOfListId == null)
			{
				_listOfListId = Bam.Net.Data.Tests.List.OneWhere(c => c.KeyColumn == this.ListId, this.Database);
			}
			return _listOfListId;
		}
	}
	
	// start ItemId -> ItemId
	[Bam.Net.Data.ForeignKey(
        Table="ListItem",
		Name="ItemId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Item",
		Suffix="2")]
	public long? ItemId
	{
		get
		{
			return GetLongValue("ItemId");
		}
		set
		{
			SetValue("ItemId", value);
		}
	}

	Item _itemOfItemId;
	public Item ItemOfItemId
	{
		get
		{
			if(_itemOfItemId == null)
			{
				_itemOfItemId = Bam.Net.Data.Tests.Item.OneWhere(c => c.KeyColumn == this.ItemId, this.Database);
			}
			return _itemOfItemId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary>
		[Bam.Net.Exclude] 
		public override IQueryFilter GetUniqueFilter()
		{
			if(UniqueFilterProvider != null)
			{
				return UniqueFilterProvider();
			}
			else
			{
				var colFilter = new ListItemColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the ListItem table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ListItemCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ListItem>();
			Database db = database ?? Db.For<ListItem>();
			var results = new ListItemCollection(db, sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Process all records in batches of the specified size
		/// </summary>
		[Bam.Net.Exclude]
		public static async Task BatchAll(int batchSize, Action<IEnumerable<ListItem>> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				ListItemColumns columns = new ListItemColumns();
				var orderBy = Bam.Net.Data.Order.By<ListItemColumns>(c => c.KeyColumn, Bam.Net.Data.SortOrder.Ascending);
				var results = Top(batchSize, (c) => c.KeyColumn > 0, orderBy, database);
				while(results.Count > 0)
				{
					await Task.Run(()=>
					{
						batchProcessor(results);
					});
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (c) => c.KeyColumn > topId, orderBy, database);
				}
			});			
		}

		/// <summary>
		/// Process results of a query in batches of the specified size
		/// </summary>			 
		[Bam.Net.Exclude]
		public static async Task BatchQuery(int batchSize, QueryFilter filter, Action<IEnumerable<ListItem>> batchProcessor, Database database = null)
		{
			await BatchQuery(batchSize, (c) => filter, batchProcessor, database);			
		}

		/// <summary>
		/// Process results of a query in batches of the specified size
		/// </summary>	
		[Bam.Net.Exclude]
		public static async Task BatchQuery(int batchSize, WhereDelegate<ListItemColumns> where, Action<IEnumerable<ListItem>> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				ListItemColumns columns = new ListItemColumns();
				var orderBy = Bam.Net.Data.Order.By<ListItemColumns>(c => c.KeyColumn, Bam.Net.Data.SortOrder.Ascending);
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await Task.Run(()=>
					{ 
						batchProcessor(results);
					});
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (ListItemColumns)where(columns) && columns.KeyColumn > topId, orderBy, database);
				}
			});			
		}

		/// <summary>
		/// Process results of a query in batches of the specified size
		/// </summary>			 
		[Bam.Net.Exclude]
		public static async Task BatchQuery<ColType>(int batchSize, QueryFilter filter, Action<IEnumerable<ListItem>> batchProcessor, Bam.Net.Data.OrderBy<ListItemColumns> orderBy, Database database = null)
		{
			await BatchQuery<ColType>(batchSize, (c) => filter, batchProcessor, orderBy, database);			
		}

		/// <summary>
		/// Process results of a query in batches of the specified size
		/// </summary>	
		[Bam.Net.Exclude]
		public static async Task BatchQuery<ColType>(int batchSize, WhereDelegate<ListItemColumns> where, Action<IEnumerable<ListItem>> batchProcessor, Bam.Net.Data.OrderBy<ListItemColumns> orderBy, Database database = null)
		{
			await Task.Run(async ()=>
			{
				ListItemColumns columns = new ListItemColumns();
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await Task.Run(()=>
					{ 
						batchProcessor(results);
					});
					ColType top = results.Select(d => d.Property<ColType>(orderBy.Column.ToString())).ToArray().Largest();
					results = Top(batchSize, (ListItemColumns)where(columns) && orderBy.Column > top, orderBy, database);
				}
			});			
		}

		public static ListItem GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ListItem GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ListItem GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Uuid") == uuid, database);
		}

		public static ListItem GetByCuid(string cuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Cuid") == cuid, database);
		}

		[Bam.Net.Exclude]
		public static ListItemCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}

		[Bam.Net.Exclude]		
		public static ListItemCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ListItemColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ListItemColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		[Bam.Net.Exclude]
		public static ListItemCollection Where(Func<ListItemColumns, QueryFilter<ListItemColumns>> where, OrderBy<ListItemColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ListItem>();
			return new ListItemCollection(database.GetQuery<ListItemColumns, ListItem>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		[Bam.Net.Exclude]
		public static ListItemCollection Where(WhereDelegate<ListItemColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ListItem>();
			var results = new ListItemCollection(database, database.GetQuery<ListItemColumns, ListItem>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItemCollection Where(WhereDelegate<ListItemColumns> where, OrderBy<ListItemColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ListItem>();
			var results = new ListItemCollection(database, database.GetQuery<ListItemColumns, ListItem>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate&lt;ListItemColumns&gt;.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ListItemCollection Where(QiQuery where, Database database = null)
		{
			var results = new ListItemCollection(database, Select<ListItemColumns>.From<ListItem>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		[Bam.Net.Exclude]
		public static ListItem GetOneWhere(QueryFilter where, Database database = null)
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
		[Bam.Net.Exclude]
		public static ListItem OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ListItemColumns> whereDelegate = (c) => where;
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
		[Bam.Net.Exclude]
		public static ListItem GetOneWhere(WhereDelegate<ListItemColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ListItemColumns c = new ListItemColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ListItem instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItem OneWhere(WhereDelegate<ListItemColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ListItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ListItem OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItem FirstOneWhere(WhereDelegate<ListItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItem FirstOneWhere(WhereDelegate<ListItemColumns> where, OrderBy<ListItemColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItem FirstOneWhere(QueryFilter where, OrderBy<ListItemColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ListItemColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		[Bam.Net.Exclude]
		public static ListItemCollection Top(int count, WhereDelegate<ListItemColumns> where, Database database = null)
		{
			return Top(count, where, null, database);
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database">
		/// Which database to query or null to use the default
		/// </param>
		[Bam.Net.Exclude]
		public static ListItemCollection Top(int count, WhereDelegate<ListItemColumns> where, OrderBy<ListItemColumns> orderBy, Database database = null)
		{
			ListItemColumns c = new ListItemColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ListItem>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ListItem>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ListItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ListItemCollection>(0);
			results.Database = db;
			return results;
		}

		[Bam.Net.Exclude]
		public static ListItemCollection Top(int count, QueryFilter where, Database database)
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
		/// <param name="where">A QueryFilter used to filter the 
		/// results
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database">
		/// Which database to query or null to use the default
		/// </param>
		[Bam.Net.Exclude]
		public static ListItemCollection Top(int count, QueryFilter where, OrderBy<ListItemColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ListItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ListItem>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ListItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ListItemCollection>(0);
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
		/// <param name="database">
		/// Which database to query or null to use the default
		/// </param>
		public static ListItemCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ListItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ListItem>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ListItemCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Return the count of ListItems
		/// </summary>
		/// <param name="database">
		/// Which database to query or null to use the default
		/// </param>
		public static long Count(Database database = null)
        {
			Database db = database ?? Db.For<ListItem>();
            QuerySet query = GetQuerySet(db);
            query.Count<ListItem>();
            query.Execute(db);
            return (long)query.Results[0].DataRow[0];
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ListItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ListItemColumns and other values
		/// </param>
		/// <param name="database">
		/// Which database to query or null to use the default
		/// </param>
		[Bam.Net.Exclude]
		public static long Count(WhereDelegate<ListItemColumns> where, Database database = null)
		{
			ListItemColumns c = new ListItemColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ListItem>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ListItem>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}
		 
		public static long Count(QiQuery where, Database database = null)
		{
		    Database db = database ?? Db.For<ListItem>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ListItem>();
			query.Where(where);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		} 		

		private static ListItem CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ListItem>();			
			var dao = new ListItem();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ListItem OneOrThrow(ListItemCollection c)
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
