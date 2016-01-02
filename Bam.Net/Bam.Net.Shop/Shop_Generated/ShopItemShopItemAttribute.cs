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

namespace Bam.Net.Shop
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Bam.Net.Data.Table("ShopItemShopItemAttribute", "Shop")]
	public partial class ShopItemShopItemAttribute: Dao
	{
		public ShopItemShopItemAttribute():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopItemShopItemAttribute(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopItemShopItemAttribute(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopItemShopItemAttribute(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShopItemShopItemAttribute(DataRow data)
		{
			return new ShopItemShopItemAttribute(data);
		}

		private void SetChildren()
		{
						
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



﻿	// start ShopItemId -> ShopItemId
	[Bam.Net.Data.ForeignKey(
        Table="ShopItemShopItemAttribute",
		Name="ShopItemId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="ShopItem",
		Suffix="1")]
	public long? ShopItemId
	{
		get
		{
			return GetLongValue("ShopItemId");
		}
		set
		{
			SetValue("ShopItemId", value);
		}
	}

	ShopItem _shopItemOfShopItemId;
	public ShopItem ShopItemOfShopItemId
	{
		get
		{
			if(_shopItemOfShopItemId == null)
			{
				_shopItemOfShopItemId = Bam.Net.Shop.ShopItem.OneWhere(c => c.KeyColumn == this.ShopItemId, this.Database);
			}
			return _shopItemOfShopItemId;
		}
	}
	
﻿	// start ShopItemAttributeId -> ShopItemAttributeId
	[Bam.Net.Data.ForeignKey(
        Table="ShopItemShopItemAttribute",
		Name="ShopItemAttributeId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="ShopItemAttribute",
		Suffix="2")]
	public long? ShopItemAttributeId
	{
		get
		{
			return GetLongValue("ShopItemAttributeId");
		}
		set
		{
			SetValue("ShopItemAttributeId", value);
		}
	}

	ShopItemAttribute _shopItemAttributeOfShopItemAttributeId;
	public ShopItemAttribute ShopItemAttributeOfShopItemAttributeId
	{
		get
		{
			if(_shopItemAttributeOfShopItemAttributeId == null)
			{
				_shopItemAttributeOfShopItemAttributeId = Bam.Net.Shop.ShopItemAttribute.OneWhere(c => c.KeyColumn == this.ShopItemAttributeId, this.Database);
			}
			return _shopItemAttributeOfShopItemAttributeId;
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
				var colFilter = new ShopItemShopItemAttributeColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the ShopItemShopItemAttribute table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShopItemShopItemAttributeCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShopItemShopItemAttribute>();
			Database db = database ?? Db.For<ShopItemShopItemAttribute>();
			var results = new ShopItemShopItemAttributeCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShopItemShopItemAttribute GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShopItemShopItemAttribute GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShopItemShopItemAttribute GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => c.Uuid == uuid, database);
		}

		public static ShopItemShopItemAttributeCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShopItemShopItemAttributeCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShopItemShopItemAttributeColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemShopItemAttributeCollection Where(Func<ShopItemShopItemAttributeColumns, QueryFilter<ShopItemShopItemAttributeColumns>> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShopItemShopItemAttribute>();
			return new ShopItemShopItemAttributeCollection(database.GetQuery<ShopItemShopItemAttributeColumns, ShopItemShopItemAttribute>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemShopItemAttributeCollection Where(WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShopItemShopItemAttribute>();
			var results = new ShopItemShopItemAttributeCollection(database, database.GetQuery<ShopItemShopItemAttributeColumns, ShopItemShopItemAttribute>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttributeCollection Where(WhereDelegate<ShopItemShopItemAttributeColumns> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShopItemShopItemAttribute>();
			var results = new ShopItemShopItemAttributeCollection(database, database.GetQuery<ShopItemShopItemAttributeColumns, ShopItemShopItemAttribute>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemShopItemAttributeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttributeCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShopItemShopItemAttributeCollection(database, Select<ShopItemShopItemAttributeColumns>.From<ShopItemShopItemAttribute>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShopItemShopItemAttribute GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShopItemShopItemAttribute OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShopItemShopItemAttributeColumns> whereDelegate = (c) => where;
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
		public static ShopItemShopItemAttribute GetOneWhere(WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShopItemShopItemAttributeColumns c = new ShopItemShopItemAttributeColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShopItemShopItemAttribute instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttribute OneWhere(WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemShopItemAttributeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttribute OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttribute FirstOneWhere(WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttribute FirstOneWhere(WhereDelegate<ShopItemShopItemAttributeColumns> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttribute FirstOneWhere(QueryFilter where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShopItemShopItemAttributeColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttributeCollection Top(int count, WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemShopItemAttributeCollection Top(int count, WhereDelegate<ShopItemShopItemAttributeColumns> where, OrderBy<ShopItemShopItemAttributeColumns> orderBy, Database database = null)
		{
			ShopItemShopItemAttributeColumns c = new ShopItemShopItemAttributeColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShopItemShopItemAttribute>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShopItemShopItemAttribute>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemShopItemAttributeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemShopItemAttributeCollection>(0);
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
		public static ShopItemShopItemAttributeCollection Top(int count, QueryFilter where, OrderBy<ShopItemShopItemAttributeColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemShopItemAttribute>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemShopItemAttribute>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemShopItemAttributeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemShopItemAttributeCollection>(0);
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
		public static ShopItemShopItemAttributeCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemShopItemAttribute>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemShopItemAttribute>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShopItemShopItemAttributeCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemShopItemAttributeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemShopItemAttributeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShopItemShopItemAttributeColumns> where, Database database = null)
		{
			ShopItemShopItemAttributeColumns c = new ShopItemShopItemAttributeColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShopItemShopItemAttribute>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShopItemShopItemAttribute>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShopItemShopItemAttribute CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemShopItemAttribute>();			
			var dao = new ShopItemShopItemAttribute();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShopItemShopItemAttribute OneOrThrow(ShopItemShopItemAttributeCollection c)
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