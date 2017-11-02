﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.Data.Repositories;

namespace Bam.Net.Services.Distributed.Data
{
    [Serializable]
    public class DataPoint: AuditRepoData
    {
        public DataPoint()
        {
            DataPropertyCollection = new DataPropertyCollection();
        }
        public string TypeNamespace { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string DataProperties
        {
            get
            {
                return DataPropertyCollection.ToBinaryBytes().ToBase64();
            }
            set
            {
                DataPropertyCollection = value.FromBase64().FromBinaryBytes<DataPropertyCollection>();
            }
        }
        protected internal DataPropertyCollection DataPropertyCollection { get; set; }

        public DataProperty Property(string name, object value = null)
        {
            DataPropertyCollection.Prop(name, value, out DataProperty prop);
            return prop;
        }

        public T Property<T>(string name)
        {
            return (T)Property(name, null).Value;
        }

        public static DataPoint FromInstance(object instance)
        {
            Type instanceType = instance.GetType();
            return new DataPoint { TypeNamespace = instanceType.Namespace, TypeName = instanceType.Name, Description = $"{instanceType.Namespace}.{instanceType.Name}", DataPropertyCollection = DataPropertyCollection.FromInstance(instance) };
        }

        public T ToInsance<T>() where T: class, new()
        {
            T result = new T();
            DataPropertyCollection.Each(dp => result.Property(dp.Name, dp.Value));            
            return result;
        }
    }
}
