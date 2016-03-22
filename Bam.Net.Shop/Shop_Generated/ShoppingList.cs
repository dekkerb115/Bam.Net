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

namespace Bam.Net.Shop
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Bam.Net.Data.Table("ShoppingList", "Shop")]
	public partial class ShoppingList: Dao
	{
		public ShoppingList():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingList(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingList(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingList(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShoppingList(DataRow data)
		{
			return new ShoppingList(data);
		}

		private void SetChildren()
		{

            this.ChildCollections.Add("ShoppingListShopItem_ShoppingListId", new ShoppingListShopItemCollection(Database.GetQuery<ShoppingListShopItemColumns, ShoppingListShopItem>((c) => c.ShoppingListId == GetLongValue("Id")), this, "ShoppingListId"));				
            this.ChildCollections.Add("ShoppingList_ShoppingListShopItem_ShopItem",  new XrefDaoCollection<ShoppingListShopItem, ShopItem>(this, false));
							
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

	// property:Name, columnName:Name	
	[Bam.Net.Data.Column(Name="Name", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Name
	{
		get
		{
			return GetStringValue("Name");
		}
		set
		{
			SetValue("Name", value);
		}
	}



				

	[Exclude]	
	public ShoppingListShopItemCollection ShoppingListShopItemsByShoppingListId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("ShoppingListShopItem_ShoppingListId"))
			{
				SetChildren();
			}

			var c = (ShoppingListShopItemCollection)this.ChildCollections["ShoppingListShopItem_ShoppingListId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

		// Xref       
        public XrefDaoCollection<ShoppingListShopItem, ShopItem> ShopItems
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("ShoppingList_ShoppingListShopItem_ShopItem"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<ShoppingListShopItem, ShopItem>)this.ChildCollections["ShoppingList_ShoppingListShopItem_ShopItem"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
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
				var colFilter = new ShoppingListColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the ShoppingList table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShoppingListCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShoppingList>();
			Database db = database ?? Db.For<ShoppingList>();
			var results = new ShoppingListCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static async Task BatchAll(int batchSize, Func<ShoppingListCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				ShoppingListColumns columns = new ShoppingListColumns();
				var orderBy = Order.By<ShoppingListColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, (c) => c.KeyColumn > 0, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (c) => c.KeyColumn > topId, orderBy, database);
				}
			});			
		}	 

		public static async Task BatchQuery(int batchSize, QueryFilter filter, Func<ShoppingListCollection, Task> batchProcessor, Database database = null)
		{
			await BatchQuery(batchSize, (c) => filter, batchProcessor, database);			
		}

		public static async Task BatchQuery(int batchSize, WhereDelegate<ShoppingListColumns> where, Func<ShoppingListCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				ShoppingListColumns columns = new ShoppingListColumns();
				var orderBy = Order.By<ShoppingListColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (ShoppingListColumns)where(columns) && columns.KeyColumn > topId, orderBy, database);
				}
			});			
		}

		public static ShoppingList GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShoppingList GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShoppingList GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Uuid") == uuid, database);
		}

		public static ShoppingList GetByCuid(string cuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Cuid") == cuid, database);
		}

		public static ShoppingListCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShoppingListCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShoppingListColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShoppingListColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingListCollection Where(Func<ShoppingListColumns, QueryFilter<ShoppingListColumns>> where, OrderBy<ShoppingListColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShoppingList>();
			return new ShoppingListCollection(database.GetQuery<ShoppingListColumns, ShoppingList>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingListCollection Where(WhereDelegate<ShoppingListColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShoppingList>();
			var results = new ShoppingListCollection(database, database.GetQuery<ShoppingListColumns, ShoppingList>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListCollection Where(WhereDelegate<ShoppingListColumns> where, OrderBy<ShoppingListColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShoppingList>();
			var results = new ShoppingListCollection(database, database.GetQuery<ShoppingListColumns, ShoppingList>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate&lt;ShoppingListColumns&gt;.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingListCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShoppingListCollection(database, Select<ShoppingListColumns>.From<ShoppingList>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShoppingList GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShoppingList OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShoppingListColumns> whereDelegate = (c) => where;
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
		public static ShoppingList GetOneWhere(WhereDelegate<ShoppingListColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShoppingListColumns c = new ShoppingListColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShoppingList instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingList OneWhere(WhereDelegate<ShoppingListColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingListColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingList OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingList FirstOneWhere(WhereDelegate<ShoppingListColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingList FirstOneWhere(WhereDelegate<ShoppingListColumns> where, OrderBy<ShoppingListColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingList FirstOneWhere(QueryFilter where, OrderBy<ShoppingListColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShoppingListColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListCollection Top(int count, WhereDelegate<ShoppingListColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListCollection Top(int count, WhereDelegate<ShoppingListColumns> where, OrderBy<ShoppingListColumns> orderBy, Database database = null)
		{
			ShoppingListColumns c = new ShoppingListColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShoppingList>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShoppingList>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingListColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingListCollection>(0);
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
		public static ShoppingListCollection Top(int count, QueryFilter where, OrderBy<ShoppingListColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingList>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingList>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingListColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingListCollection>(0);
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
		public static ShoppingListCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingList>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingList>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShoppingListCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShoppingListColumns> where, Database database = null)
		{
			ShoppingListColumns c = new ShoppingListColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShoppingList>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShoppingList>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShoppingList CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingList>();			
			var dao = new ShoppingList();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShoppingList OneOrThrow(ShoppingListCollection c)
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
