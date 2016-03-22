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

namespace Bam.Net.DaoRef
{
	// schema = DaoRef
	// connection Name = DaoRef
	[Serializable]
	[Bam.Net.Data.Table("Right", "DaoRef")]
	public partial class Right: Dao
	{
		public Right():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Right(DataRow data)
			: base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Right(Database db)
			: base(db)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Right(Database db, DataRow data)
			: base(db, data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Right(DataRow data)
		{
			return new Right(data);
		}

		private void SetChildren()
		{

            this.ChildCollections.Add("LeftRight_RightId", new LeftRightCollection(Database.GetQuery<LeftRightColumns, LeftRight>((c) => c.RightId == GetLongValue("Id")), this, "RightId"));							
            this.ChildCollections.Add("Right_LeftRight_Left",  new XrefDaoCollection<LeftRight, Left>(this, false));
				
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
	public LeftRightCollection LeftRightsByRightId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("LeftRight_RightId"))
			{
				SetChildren();
			}

			var c = (LeftRightCollection)this.ChildCollections["LeftRight_RightId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			


		// Xref       
        public XrefDaoCollection<LeftRight, Left> Lefts
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Right_LeftRight_Left"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<LeftRight, Left>)this.ChildCollections["Right_LeftRight_Left"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }		/// <summary>
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
				var colFilter = new RightColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the Right table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static RightCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Right>();
			Database db = database ?? Db.For<Right>();
			var results = new RightCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static async Task BatchAll(int batchSize, Func<RightCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				RightColumns columns = new RightColumns();
				var orderBy = Order.By<RightColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, (c) => c.KeyColumn > 0, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (c) => c.KeyColumn > topId, orderBy, database);
				}
			});			
		}	 

		public static async Task BatchQuery(int batchSize, QueryFilter filter, Func<RightCollection, Task> batchProcessor, Database database = null)
		{
			await BatchQuery(batchSize, (c) => filter, batchProcessor, database);			
		}

		public static async Task BatchQuery(int batchSize, WhereDelegate<RightColumns> where, Func<RightCollection, Task> batchProcessor, Database database = null)
		{
			await Task.Run(async ()=>
			{
				RightColumns columns = new RightColumns();
				var orderBy = Order.By<RightColumns>(c => c.KeyColumn, SortOrder.Ascending);
				var results = Top(batchSize, where, orderBy, database);
				while(results.Count > 0)
				{
					await batchProcessor(results);
					long topId = results.Select(d => d.Property<long>(columns.KeyColumn.ToString())).ToArray().Largest();
					results = Top(batchSize, (RightColumns)where(columns) && columns.KeyColumn > topId, orderBy, database);
				}
			});			
		}

		public static Right GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Right GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static Right GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Uuid") == uuid, database);
		}

		public static Right GetByCuid(string cuid, Database database = null)
		{
			return OneWhere(c => Bam.Net.Data.Query.Where("Cuid") == cuid, database);
		}

		public static RightCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static RightCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<RightColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a RightColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RightCollection Where(Func<RightColumns, QueryFilter<RightColumns>> where, OrderBy<RightColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Right>();
			return new RightCollection(database.GetQuery<RightColumns, Right>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RightCollection Where(WhereDelegate<RightColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Right>();
			var results = new RightCollection(database, database.GetQuery<RightColumns, Right>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RightCollection Where(WhereDelegate<RightColumns> where, OrderBy<RightColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Right>();
			var results = new RightCollection(database, database.GetQuery<RightColumns, Right>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate&lt;RightColumns&gt;.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RightCollection Where(QiQuery where, Database database = null)
		{
			var results = new RightCollection(database, Select<RightColumns>.From<Right>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Right GetOneWhere(QueryFilter where, Database database = null)
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
		public static Right OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<RightColumns> whereDelegate = (c) => where;
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
		public static Right GetOneWhere(WhereDelegate<RightColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				RightColumns c = new RightColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Right instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Right OneWhere(WhereDelegate<RightColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RightColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Right OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Right FirstOneWhere(WhereDelegate<RightColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Right FirstOneWhere(WhereDelegate<RightColumns> where, OrderBy<RightColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Right FirstOneWhere(QueryFilter where, OrderBy<RightColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<RightColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RightCollection Top(int count, WhereDelegate<RightColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RightCollection Top(int count, WhereDelegate<RightColumns> where, OrderBy<RightColumns> orderBy, Database database = null)
		{
			RightColumns c = new RightColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Right>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Right>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<RightColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RightCollection>(0);
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
		public static RightCollection Top(int count, QueryFilter where, OrderBy<RightColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Right>();
			QuerySet query = GetQuerySet(db);
			query.Top<Right>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<RightColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RightCollection>(0);
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
		public static RightCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Right>();
			QuerySet query = GetQuerySet(db);
			query.Top<Right>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<RightCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RightColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RightColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<RightColumns> where, Database database = null)
		{
			RightColumns c = new RightColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Right>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Right>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Right CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Right>();			
			var dao = new Right();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Right OneOrThrow(RightCollection c)
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
