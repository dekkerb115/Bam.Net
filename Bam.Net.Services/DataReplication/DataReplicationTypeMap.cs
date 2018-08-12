using Bam.Net.Data;
using Bam.Net.Data.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Services.DataReplication
{
    /// <summary>
    /// A class that provides a mapping between a numeric (long) values and Types.
    /// </summary>
    public class DataReplicationTypeMap
    {
        public DataReplicationTypeMap(SystemPaths paths) : this()
        {
            if(paths != null)
            {
                Directory = new DirectoryInfo(Path.Combine(paths.Data.AppData, nameof(DataReplicationJournal)));
            }
        }
        
        protected DataReplicationTypeMap()
        {
            TypeMappings = new ConcurrentDictionary<long, string>();
            PropertyMappings = new ConcurrentDictionary<long, string>();
        }

        protected internal DirectoryInfo Directory { get; set; }
        
        public string Save()
        {
            string path = Path.Combine(Directory.FullName, nameof(DataReplicationTypeMap));
            this.ToJsonFile(path);
            return path;
        }

        public static DataReplicationTypeMap Load(string path)
        {
            DataReplicationTypeMap typeMap = path.FromJsonFile<DataReplicationTypeMap>();
            typeMap.Directory = new FileInfo(path).Directory;
            return typeMap;
        }

        public ConcurrentDictionary<long, string> TypeMappings { get; set; }
        public ConcurrentDictionary<long, string> PropertyMappings { get; set; }

        public string GetTypeName(long typeId)
        {
            return TypeMappings[typeId];
        }

        public string GetPropertyName(long propertyId)
        {
            return PropertyMappings[propertyId];
        }

        public void AddMapping(KeyHashAuditRepoData instance)
        {
            long typeId = GetTypeId(instance, out object dynamicInstance, out Type dynamicType);
            AddTypeMapping(dynamicType);
            foreach (PropertyInfo property in dynamicType.GetProperties())
            {
                AddPropertyMapping(property);
            }
        }
        
        protected long AddPropertyMapping(PropertyInfo property)
        {
            long key = GetPropertyId(property, out string name);
            PropertyMappings.TryAdd(key, name);
            return key;
        }

        protected long AddTypeMapping(Type type)
        {
            long key = GetTypeId(type, out string name);
            TypeMappings.TryAdd(key, name);
            return key;
        }

        public static long GetTypeId(KeyHashAuditRepoData instance, out object dynamicInstance, out Type dynamicType)
        {
            dynamicInstance = instance.ToDynamic(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string), out dynamicType);
            return GetTypeId(dynamicType, out string ignore);
        }

        public static long GetTypeId(Type type, out string name)
        {
            name = NormalizeName(type);
            return name.ToSha256Long();
        }

        public static long GetPropertyId(PropertyInfo prop, out string name)
        {
            name = NormalizeName(prop);
            return name.ToSha256Long();
        }

        private static string NormalizeName(Type type)
        {
            return $"{type.Namespace}.{type.Name}";
        }

        private static string NormalizeName(PropertyInfo prop)
        {
            return $"{prop.DeclaringType.Namespace}.{prop.DeclaringType.Name}.{prop.Name}::{prop.PropertyType.Name}";
        }
    }
}
