using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QuickCms
{
    public class DefaultModelBuilder : IModelBuilder
    {
        public ItemModel GetModel(object item)
        {
            var typeName = item.GetType().Name;
            var id = GetPropertyValue(item, "Id") ?? item.GetHashCode();
            var name = Convert.ToString(GetPropertyValue(item, "Name")) ?? typeName + " " + id;

            return new ItemModel
            {
                Item = item,
                Id = id,
                Name = name,
                TypeName = typeName,
                Fields = GetFieldModels(item).ToList()
            };
        }

        private IEnumerable<ItemFieldModel> GetFieldModels(object item)
        {
            return item.GetType().GetProperties()
                .Select(prop => new ItemFieldModel
                {
                    Name = prop.Name,
                    Type = prop.PropertyType,
                    Value = prop.GetValue(item)
                });
        }

        private object GetPropertyValue(object item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName)?.GetValue(item);
        }
    }
}