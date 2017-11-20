﻿/*
This file was generated and should not be modified directly
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Bam.Net;
using Bam.Net.Data;
using Bam.Net.Data.Repositories;
using Bam.Net.Services.Distributed.Data;

namespace Bam.Net.Services.Distributed.Data.Dao.Repository
{
	[Serializable]
	public class DistributedDataRepository: DatabaseRepository
	{
		public DistributedDataRepository()
		{
			SchemaName = "DistributedData";
			BaseNamespace = "Bam.Net.Services.Distributed.Data";			
﻿			
			AddType<Bam.Net.Services.Distributed.Data.CreateOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.DataPoint>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.DataProperty>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.DataRelationship>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.DeleteEvent>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.DeleteOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.QueryOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.ReplicationOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.RetrieveOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.SaveOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.UpdateOperation>();﻿			
			AddType<Bam.Net.Services.Distributed.Data.WriteEvent>();
			DaoAssembly = typeof(DistributedDataRepository).Assembly;
		}

		object _addLock = new object();
        public override void AddType(Type type)
        {
            lock (_addLock)
            {
                base.AddType(type);
                DaoAssembly = typeof(DistributedDataRepository).Assembly;
            }
        }

﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.CreateOperation GetOneCreateOperationWhere(WhereDelegate<CreateOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.CreateOperation>();
			return (Bam.Net.Services.Distributed.Data.CreateOperation)Bam.Net.Services.Distributed.Data.Dao.CreateOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single CreateOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CreateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CreateOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.CreateOperation OneCreateOperationWhere(WhereDelegate<CreateOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.CreateOperation>();
            return (Bam.Net.Services.Distributed.Data.CreateOperation)Bam.Net.Services.Distributed.Data.Dao.CreateOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.CreateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.CreateOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.CreateOperation> CreateOperationsWhere(WhereDelegate<CreateOperationColumns> where, OrderBy<CreateOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.CreateOperation>(Bam.Net.Services.Distributed.Data.Dao.CreateOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a CreateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CreateOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.CreateOperation> TopCreateOperationsWhere(int count, WhereDelegate<CreateOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.CreateOperation>(Bam.Net.Services.Distributed.Data.Dao.CreateOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of CreateOperations
		/// </summary>
		public long CountCreateOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.CreateOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CreateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CreateOperationColumns and other values
		/// </param>
        public long CountCreateOperationsWhere(WhereDelegate<CreateOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.CreateOperation.Count(where, Database);
        }
        
        public async Task BatchQueryCreateOperations(int batchSize, WhereDelegate<CreateOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.CreateOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.CreateOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.CreateOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllCreateOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.CreateOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.CreateOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.CreateOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.DataPoint GetOneDataPointWhere(WhereDelegate<DataPointColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataPoint>();
			return (Bam.Net.Services.Distributed.Data.DataPoint)Bam.Net.Services.Distributed.Data.Dao.DataPoint.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single DataPoint instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataPointColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPointColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.DataPoint OneDataPointWhere(WhereDelegate<DataPointColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataPoint>();
            return (Bam.Net.Services.Distributed.Data.DataPoint)Bam.Net.Services.Distributed.Data.Dao.DataPoint.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.DataPointColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.DataPointColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataPoint> DataPointsWhere(WhereDelegate<DataPointColumns> where, OrderBy<DataPointColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataPoint>(Bam.Net.Services.Distributed.Data.Dao.DataPoint.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a DataPointColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPointColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataPoint> TopDataPointsWhere(int count, WhereDelegate<DataPointColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataPoint>(Bam.Net.Services.Distributed.Data.Dao.DataPoint.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of DataPoints
		/// </summary>
		public long CountDataPoints()
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataPoint.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataPointColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPointColumns and other values
		/// </param>
        public long CountDataPointsWhere(WhereDelegate<DataPointColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataPoint.Count(where, Database);
        }
        
        public async Task BatchQueryDataPoints(int batchSize, WhereDelegate<DataPointColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataPoint>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataPoint.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataPoint>(batch));
            }, Database);
        }
		
        public async Task BatchAllDataPoints(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataPoint>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataPoint.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataPoint>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.DataProperty GetOneDataPropertyWhere(WhereDelegate<DataPropertyColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataProperty>();
			return (Bam.Net.Services.Distributed.Data.DataProperty)Bam.Net.Services.Distributed.Data.Dao.DataProperty.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single DataProperty instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataPropertyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPropertyColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.DataProperty OneDataPropertyWhere(WhereDelegate<DataPropertyColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataProperty>();
            return (Bam.Net.Services.Distributed.Data.DataProperty)Bam.Net.Services.Distributed.Data.Dao.DataProperty.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.DataPropertyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.DataPropertyColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataProperty> DataPropertiesWhere(WhereDelegate<DataPropertyColumns> where, OrderBy<DataPropertyColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataProperty>(Bam.Net.Services.Distributed.Data.Dao.DataProperty.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a DataPropertyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPropertyColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataProperty> TopDataPropertiesWhere(int count, WhereDelegate<DataPropertyColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataProperty>(Bam.Net.Services.Distributed.Data.Dao.DataProperty.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of DataProperties
		/// </summary>
		public long CountDataProperties()
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataProperty.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataPropertyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataPropertyColumns and other values
		/// </param>
        public long CountDataPropertiesWhere(WhereDelegate<DataPropertyColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataProperty.Count(where, Database);
        }
        
        public async Task BatchQueryDataProperties(int batchSize, WhereDelegate<DataPropertyColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataProperty>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataProperty.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataProperty>(batch));
            }, Database);
        }
		
        public async Task BatchAllDataProperties(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataProperty>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataProperty.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataProperty>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.DataRelationship GetOneDataRelationshipWhere(WhereDelegate<DataRelationshipColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataRelationship>();
			return (Bam.Net.Services.Distributed.Data.DataRelationship)Bam.Net.Services.Distributed.Data.Dao.DataRelationship.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single DataRelationship instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataRelationshipColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataRelationshipColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.DataRelationship OneDataRelationshipWhere(WhereDelegate<DataRelationshipColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DataRelationship>();
            return (Bam.Net.Services.Distributed.Data.DataRelationship)Bam.Net.Services.Distributed.Data.Dao.DataRelationship.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.DataRelationshipColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.DataRelationshipColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataRelationship> DataRelationshipsWhere(WhereDelegate<DataRelationshipColumns> where, OrderBy<DataRelationshipColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataRelationship>(Bam.Net.Services.Distributed.Data.Dao.DataRelationship.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a DataRelationshipColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataRelationshipColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DataRelationship> TopDataRelationshipsWhere(int count, WhereDelegate<DataRelationshipColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DataRelationship>(Bam.Net.Services.Distributed.Data.Dao.DataRelationship.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of DataRelationships
		/// </summary>
		public long CountDataRelationships()
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataRelationship.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DataRelationshipColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DataRelationshipColumns and other values
		/// </param>
        public long CountDataRelationshipsWhere(WhereDelegate<DataRelationshipColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.DataRelationship.Count(where, Database);
        }
        
        public async Task BatchQueryDataRelationships(int batchSize, WhereDelegate<DataRelationshipColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataRelationship>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataRelationship.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataRelationship>(batch));
            }, Database);
        }
		
        public async Task BatchAllDataRelationships(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DataRelationship>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DataRelationship.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DataRelationship>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.DeleteEvent GetOneDeleteEventWhere(WhereDelegate<DeleteEventColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DeleteEvent>();
			return (Bam.Net.Services.Distributed.Data.DeleteEvent)Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single DeleteEvent instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DeleteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteEventColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.DeleteEvent OneDeleteEventWhere(WhereDelegate<DeleteEventColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DeleteEvent>();
            return (Bam.Net.Services.Distributed.Data.DeleteEvent)Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.DeleteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.DeleteEventColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DeleteEvent> DeleteEventsWhere(WhereDelegate<DeleteEventColumns> where, OrderBy<DeleteEventColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DeleteEvent>(Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a DeleteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteEventColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DeleteEvent> TopDeleteEventsWhere(int count, WhereDelegate<DeleteEventColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DeleteEvent>(Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of DeleteEvents
		/// </summary>
		public long CountDeleteEvents()
        {
            return Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DeleteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteEventColumns and other values
		/// </param>
        public long CountDeleteEventsWhere(WhereDelegate<DeleteEventColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.Count(where, Database);
        }
        
        public async Task BatchQueryDeleteEvents(int batchSize, WhereDelegate<DeleteEventColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DeleteEvent>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DeleteEvent>(batch));
            }, Database);
        }
		
        public async Task BatchAllDeleteEvents(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DeleteEvent>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DeleteEvent.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DeleteEvent>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.DeleteOperation GetOneDeleteOperationWhere(WhereDelegate<DeleteOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DeleteOperation>();
			return (Bam.Net.Services.Distributed.Data.DeleteOperation)Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single DeleteOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DeleteOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.DeleteOperation OneDeleteOperationWhere(WhereDelegate<DeleteOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.DeleteOperation>();
            return (Bam.Net.Services.Distributed.Data.DeleteOperation)Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.DeleteOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.DeleteOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DeleteOperation> DeleteOperationsWhere(WhereDelegate<DeleteOperationColumns> where, OrderBy<DeleteOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DeleteOperation>(Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a DeleteOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.DeleteOperation> TopDeleteOperationsWhere(int count, WhereDelegate<DeleteOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.DeleteOperation>(Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of DeleteOperations
		/// </summary>
		public long CountDeleteOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a DeleteOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between DeleteOperationColumns and other values
		/// </param>
        public long CountDeleteOperationsWhere(WhereDelegate<DeleteOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.Count(where, Database);
        }
        
        public async Task BatchQueryDeleteOperations(int batchSize, WhereDelegate<DeleteOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DeleteOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DeleteOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllDeleteOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.DeleteOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.DeleteOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.DeleteOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.QueryOperation GetOneQueryOperationWhere(WhereDelegate<QueryOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.QueryOperation>();
			return (Bam.Net.Services.Distributed.Data.QueryOperation)Bam.Net.Services.Distributed.Data.Dao.QueryOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single QueryOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a QueryOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between QueryOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.QueryOperation OneQueryOperationWhere(WhereDelegate<QueryOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.QueryOperation>();
            return (Bam.Net.Services.Distributed.Data.QueryOperation)Bam.Net.Services.Distributed.Data.Dao.QueryOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.QueryOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.QueryOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.QueryOperation> QueryOperationsWhere(WhereDelegate<QueryOperationColumns> where, OrderBy<QueryOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.QueryOperation>(Bam.Net.Services.Distributed.Data.Dao.QueryOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a QueryOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between QueryOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.QueryOperation> TopQueryOperationsWhere(int count, WhereDelegate<QueryOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.QueryOperation>(Bam.Net.Services.Distributed.Data.Dao.QueryOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of QueryOperations
		/// </summary>
		public long CountQueryOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.QueryOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a QueryOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between QueryOperationColumns and other values
		/// </param>
        public long CountQueryOperationsWhere(WhereDelegate<QueryOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.QueryOperation.Count(where, Database);
        }
        
        public async Task BatchQueryQueryOperations(int batchSize, WhereDelegate<QueryOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.QueryOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.QueryOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.QueryOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllQueryOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.QueryOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.QueryOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.QueryOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.ReplicationOperation GetOneReplicationOperationWhere(WhereDelegate<ReplicationOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.ReplicationOperation>();
			return (Bam.Net.Services.Distributed.Data.ReplicationOperation)Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ReplicationOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ReplicationOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ReplicationOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.ReplicationOperation OneReplicationOperationWhere(WhereDelegate<ReplicationOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.ReplicationOperation>();
            return (Bam.Net.Services.Distributed.Data.ReplicationOperation)Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.ReplicationOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.ReplicationOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.ReplicationOperation> ReplicationOperationsWhere(WhereDelegate<ReplicationOperationColumns> where, OrderBy<ReplicationOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.ReplicationOperation>(Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a ReplicationOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ReplicationOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.ReplicationOperation> TopReplicationOperationsWhere(int count, WhereDelegate<ReplicationOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.ReplicationOperation>(Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of ReplicationOperations
		/// </summary>
		public long CountReplicationOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ReplicationOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ReplicationOperationColumns and other values
		/// </param>
        public long CountReplicationOperationsWhere(WhereDelegate<ReplicationOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.Count(where, Database);
        }
        
        public async Task BatchQueryReplicationOperations(int batchSize, WhereDelegate<ReplicationOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.ReplicationOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.ReplicationOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllReplicationOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.ReplicationOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.ReplicationOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.ReplicationOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.RetrieveOperation GetOneRetrieveOperationWhere(WhereDelegate<RetrieveOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.RetrieveOperation>();
			return (Bam.Net.Services.Distributed.Data.RetrieveOperation)Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single RetrieveOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RetrieveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RetrieveOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.RetrieveOperation OneRetrieveOperationWhere(WhereDelegate<RetrieveOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.RetrieveOperation>();
            return (Bam.Net.Services.Distributed.Data.RetrieveOperation)Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.RetrieveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.RetrieveOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.RetrieveOperation> RetrieveOperationsWhere(WhereDelegate<RetrieveOperationColumns> where, OrderBy<RetrieveOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.RetrieveOperation>(Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a RetrieveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RetrieveOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.RetrieveOperation> TopRetrieveOperationsWhere(int count, WhereDelegate<RetrieveOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.RetrieveOperation>(Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of RetrieveOperations
		/// </summary>
		public long CountRetrieveOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RetrieveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RetrieveOperationColumns and other values
		/// </param>
        public long CountRetrieveOperationsWhere(WhereDelegate<RetrieveOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.Count(where, Database);
        }
        
        public async Task BatchQueryRetrieveOperations(int batchSize, WhereDelegate<RetrieveOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.RetrieveOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.RetrieveOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllRetrieveOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.RetrieveOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.RetrieveOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.RetrieveOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.SaveOperation GetOneSaveOperationWhere(WhereDelegate<SaveOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.SaveOperation>();
			return (Bam.Net.Services.Distributed.Data.SaveOperation)Bam.Net.Services.Distributed.Data.Dao.SaveOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single SaveOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SaveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SaveOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.SaveOperation OneSaveOperationWhere(WhereDelegate<SaveOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.SaveOperation>();
            return (Bam.Net.Services.Distributed.Data.SaveOperation)Bam.Net.Services.Distributed.Data.Dao.SaveOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.SaveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.SaveOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.SaveOperation> SaveOperationsWhere(WhereDelegate<SaveOperationColumns> where, OrderBy<SaveOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.SaveOperation>(Bam.Net.Services.Distributed.Data.Dao.SaveOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a SaveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SaveOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.SaveOperation> TopSaveOperationsWhere(int count, WhereDelegate<SaveOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.SaveOperation>(Bam.Net.Services.Distributed.Data.Dao.SaveOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of SaveOperations
		/// </summary>
		public long CountSaveOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.SaveOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SaveOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SaveOperationColumns and other values
		/// </param>
        public long CountSaveOperationsWhere(WhereDelegate<SaveOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.SaveOperation.Count(where, Database);
        }
        
        public async Task BatchQuerySaveOperations(int batchSize, WhereDelegate<SaveOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.SaveOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.SaveOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.SaveOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllSaveOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.SaveOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.SaveOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.SaveOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.UpdateOperation GetOneUpdateOperationWhere(WhereDelegate<UpdateOperationColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.UpdateOperation>();
			return (Bam.Net.Services.Distributed.Data.UpdateOperation)Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single UpdateOperation instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UpdateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UpdateOperationColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.UpdateOperation OneUpdateOperationWhere(WhereDelegate<UpdateOperationColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.UpdateOperation>();
            return (Bam.Net.Services.Distributed.Data.UpdateOperation)Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.UpdateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.UpdateOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.UpdateOperation> UpdateOperationsWhere(WhereDelegate<UpdateOperationColumns> where, OrderBy<UpdateOperationColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.UpdateOperation>(Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a UpdateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UpdateOperationColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.UpdateOperation> TopUpdateOperationsWhere(int count, WhereDelegate<UpdateOperationColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.UpdateOperation>(Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of UpdateOperations
		/// </summary>
		public long CountUpdateOperations()
        {
            return Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UpdateOperationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UpdateOperationColumns and other values
		/// </param>
        public long CountUpdateOperationsWhere(WhereDelegate<UpdateOperationColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.Count(where, Database);
        }
        
        public async Task BatchQueryUpdateOperations(int batchSize, WhereDelegate<UpdateOperationColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.UpdateOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.UpdateOperation>(batch));
            }, Database);
        }
		
        public async Task BatchAllUpdateOperations(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.UpdateOperation>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.UpdateOperation.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.UpdateOperation>(batch));
            }, Database);
        }﻿		
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		public Bam.Net.Services.Distributed.Data.WriteEvent GetOneWriteEventWhere(WhereDelegate<WriteEventColumns> where)
		{
			Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.WriteEvent>();
			return (Bam.Net.Services.Distributed.Data.WriteEvent)Bam.Net.Services.Distributed.Data.Dao.WriteEvent.GetOneWhere(where, Database).CopyAs(wrapperType, this);
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single WriteEvent instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WriteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WriteEventColumns and other values
		/// </param>
		public Bam.Net.Services.Distributed.Data.WriteEvent OneWriteEventWhere(WhereDelegate<WriteEventColumns> where)
        {
            Type wrapperType = GetWrapperType<Bam.Net.Services.Distributed.Data.WriteEvent>();
            return (Bam.Net.Services.Distributed.Data.WriteEvent)Bam.Net.Services.Distributed.Data.Dao.WriteEvent.OneWhere(where, Database).CopyAs(wrapperType, this);
        }

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a Bam.Net.Services.Distributed.Data.WriteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between Bam.Net.Services.Distributed.Data.WriteEventColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.WriteEvent> WriteEventsWhere(WhereDelegate<WriteEventColumns> where, OrderBy<WriteEventColumns> orderBy = null)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.WriteEvent>(Bam.Net.Services.Distributed.Data.Dao.WriteEvent.Where(where, orderBy, Database));
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
		/// <param name="where">A WhereDelegate that recieves a WriteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WriteEventColumns and other values
		/// </param>
		public IEnumerable<Bam.Net.Services.Distributed.Data.WriteEvent> TopWriteEventsWhere(int count, WhereDelegate<WriteEventColumns> where)
        {
            return Wrap<Bam.Net.Services.Distributed.Data.WriteEvent>(Bam.Net.Services.Distributed.Data.Dao.WriteEvent.Top(count, where, Database));
        }

		/// <summary>
		/// Return the count of WriteEvents
		/// </summary>
		public long CountWriteEvents()
        {
            return Bam.Net.Services.Distributed.Data.Dao.WriteEvent.Count(Database);
        }

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WriteEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WriteEventColumns and other values
		/// </param>
        public long CountWriteEventsWhere(WhereDelegate<WriteEventColumns> where)
        {
            return Bam.Net.Services.Distributed.Data.Dao.WriteEvent.Count(where, Database);
        }
        
        public async Task BatchQueryWriteEvents(int batchSize, WhereDelegate<WriteEventColumns> where, Action<IEnumerable<Bam.Net.Services.Distributed.Data.WriteEvent>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.WriteEvent.BatchQuery(batchSize, where, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.WriteEvent>(batch));
            }, Database);
        }
		
        public async Task BatchAllWriteEvents(int batchSize, Action<IEnumerable<Bam.Net.Services.Distributed.Data.WriteEvent>> batchProcessor)
        {
            await Bam.Net.Services.Distributed.Data.Dao.WriteEvent.BatchAll(batchSize, (batch) =>
            {
				batchProcessor(Wrap<Bam.Net.Services.Distributed.Data.WriteEvent>(batch));
            }, Database);
        }
	}
}																								
