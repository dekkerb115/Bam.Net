using Bam.Net.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    public class DataReplicationTypeMap
    {
        public DataReplicationTypeMap()
        {
            TypeMappings = new ConcurrentDictionary<int, string>();
            PropertyMappings = new ConcurrentDictionary<int, string>();
        }

        public ConcurrentDictionary<int, string> TypeMappings { get; set; }
        public ConcurrentDictionary<int, string> PropertyMappings { get; set; }

        public void AddMapping(object instance)
        {
            Type actualType = instance.GetType();
            object jsonSafe = DataExtensions.ToJsonSafe(instance);
            Type type = jsonSafe.GetType();
            AddTypeMapping(actualType.Namespace, actualType.Name);
            string typeNameString = $"{actualType.Namespace}.{actualType.Name}";
            foreach (PropertyInfo property in type.GetProperties())
            {
                AddPropertyMapping(typeNameString, property.PropertyType.Name, property.Name);
            }
        }

        public int AddPropertyMapping(string typeNamestring, string propertyType, string propertyName)
        {
            string name = $"{typeNamestring}.{propertyName}.{propertyType}";
            int key = name.ToSha256Int();
            PropertyMappings.TryAdd(key, name);
            return key;
        }

        public int AddTypeMapping(string nameSpace, string type)
        {
            string name = $"{nameSpace}.{type}";
            int key = name.ToSha256Int();
            TypeMappings.TryAdd(key, name);
            return key;
        }
    }
}
