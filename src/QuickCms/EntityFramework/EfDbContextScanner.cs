using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Entity;

namespace QuickCms.EntityFramework
{
    public class EfDbContextScanner
    {
        public IEnumerable<PropertyInfo> GetDbSetProperties(Type dbContextType)
        {
            return dbContextType.GetProperties()
                .Where(p => p.PropertyType.IsConstructedGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
        }

        public PropertyInfo GetDbSetProperty(Type dbContextType, string propertyName)
        {
            return GetDbSetProperties(dbContextType).FirstOrDefault(p => p.Name == propertyName);
        }
    }
}