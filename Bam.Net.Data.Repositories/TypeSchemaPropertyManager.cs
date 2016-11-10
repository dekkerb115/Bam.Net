﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Data.Repositories
{
    public class TypeSchemaPropertyManager
    {
        public TypeSchemaPropertyManager(TypeSchema typeSchema)
        {
            TypeSchema = typeSchema;
        }
        public TypeSchema TypeSchema { get; set; }
        public void SaveCollections(object parent, Action<object> childWriter)
        {
            ForEachChildCollection(parent, (coll) =>
            {
                foreach(object child in coll)
                {
                    Meta.SetUuid(child);
                    SetParentProperties(parent, child);
                    childWriter(child);
                }
            });
        }
        public void ForEachChildCollection(object parent, Action<IEnumerable> forEachCollection)
        {
            Type parentType = parent.GetType();
            List<TypeFk> fkDescriptors = TypeSchema.ForeignKeys.Where(tfk => tfk.PrimaryKeyType == parentType).ToList();
            foreach (TypeFk fk in fkDescriptors)
            {
                IEnumerable collection = (IEnumerable)fk.CollectionProperty.GetValue(parent);
                if (collection != null)
                {
                    forEachCollection(collection);
                }
            }
        }
        public void SetParentProperties(object parent, object child)
        {
            Type parentType = parent.GetType();
            Type childType = child.GetType();
            long parentId = Meta.GetId(parent);
            foreach (TypeFk typeFk in TypeSchema.ForeignKeys.Where(fk => fk.ForeignKeyType == childType && fk.PrimaryKeyType == parentType))
            {
                typeFk.ForeignKeyProperty.SetValue(child, parentId);
                PropertyInfo parentInstanceProperty = childType.GetProperty(typeFk.PrimaryKeyType.Name);
                if (parentInstanceProperty != null)
                {
                    parentInstanceProperty.SetValue(child, parent);
                }
            }
        }
    }
}
