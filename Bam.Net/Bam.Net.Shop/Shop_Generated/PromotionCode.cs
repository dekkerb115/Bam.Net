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
	[Bam.Net.Data.Table("PromotionCode", "Shop")]
	public partial class PromotionCode: Dao
	{
		public PromotionCode():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PromotionCode(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PromotionCode(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PromotionCode(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PromotionCode(DataRow data)
		{
			return new PromotionCode(data);
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

﻿	// property:Value, columnName:Value	
	[Bam.Net.Data.Column(Name="Value", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Value
	{
		get
		{
			return GetStringValue("Value");
		}
		set
		{
			SetValue("Value", value);
		}
	}



﻿	// start PromotionId -> PromotionId
	[Bam.Net.Data.ForeignKey(
        Table="PromotionCode",
		Name="PromotionId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Promotion",
		Suffix="1")]
	public long? PromotionId
	{
		get
		{
			return GetLongValue("PromotionId");
		}
		set
		{
			SetValue("PromotionId", value);
		}
	}

	Promotion _promotionOfPromotionId;
	public Promotion PromotionOfPromotionId
	{
		get
		{
			if(_promotionOfPromotionId == null)
			{
				_promotionOfPromotionId = Bam.Net.Shop.Promotion.OneWhere(c => c.KeyColumn == this.PromotionId, this.Database);
			}
			return _promotionOfPromotionId;
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
				var colFilter = new PromotionCodeColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the PromotionCode table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PromotionCodeCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PromotionCode>();
			Database db = database ?? Db.For<PromotionCode>();
			var results = new PromotionCodeCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PromotionCode GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PromotionCode GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PromotionCode GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => c.Uuid == uuid, database);
		}

		public static PromotionCodeCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PromotionCodeCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PromotionCodeColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PromotionCodeColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionCodeCollection Where(Func<PromotionCodeColumns, QueryFilter<PromotionCodeColumns>> where, OrderBy<PromotionCodeColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PromotionCode>();
			return new PromotionCodeCollection(database.GetQuery<PromotionCodeColumns, PromotionCode>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionCodeCollection Where(WhereDelegate<PromotionCodeColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PromotionCode>();
			var results = new PromotionCodeCollection(database, database.GetQuery<PromotionCodeColumns, PromotionCode>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionCodeCollection Where(WhereDelegate<PromotionCodeColumns> where, OrderBy<PromotionCodeColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PromotionCode>();
			var results = new PromotionCodeCollection(database, database.GetQuery<PromotionCodeColumns, PromotionCode>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionCodeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PromotionCodeCollection Where(QiQuery where, Database database = null)
		{
			var results = new PromotionCodeCollection(database, Select<PromotionCodeColumns>.From<PromotionCode>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PromotionCode GetOneWhere(QueryFilter where, Database database = null)
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
		public static PromotionCode OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PromotionCodeColumns> whereDelegate = (c) => where;
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
		public static PromotionCode GetOneWhere(WhereDelegate<PromotionCodeColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PromotionCodeColumns c = new PromotionCodeColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PromotionCode instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCode OneWhere(WhereDelegate<PromotionCodeColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionCodeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PromotionCode OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCode FirstOneWhere(WhereDelegate<PromotionCodeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCode FirstOneWhere(WhereDelegate<PromotionCodeColumns> where, OrderBy<PromotionCodeColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCode FirstOneWhere(QueryFilter where, OrderBy<PromotionCodeColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PromotionCodeColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCodeCollection Top(int count, WhereDelegate<PromotionCodeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionCodeCollection Top(int count, WhereDelegate<PromotionCodeColumns> where, OrderBy<PromotionCodeColumns> orderBy, Database database = null)
		{
			PromotionCodeColumns c = new PromotionCodeColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PromotionCode>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PromotionCode>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PromotionCodeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionCodeCollection>(0);
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
		public static PromotionCodeCollection Top(int count, QueryFilter where, OrderBy<PromotionCodeColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCode>();
			QuerySet query = GetQuerySet(db);
			query.Top<PromotionCode>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PromotionCodeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionCodeCollection>(0);
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
		public static PromotionCodeCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCode>();
			QuerySet query = GetQuerySet(db);
			query.Top<PromotionCode>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PromotionCodeCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionCodeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionCodeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PromotionCodeColumns> where, Database database = null)
		{
			PromotionCodeColumns c = new PromotionCodeColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PromotionCode>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PromotionCode>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PromotionCode CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCode>();			
			var dao = new PromotionCode();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PromotionCode OneOrThrow(PromotionCodeCollection c)
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