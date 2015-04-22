using System;
using System.Collections;
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

        public IEnumerable<dynamic> GetDbSet(DbContext dbContext, string propertyName)
        {
            var dbSetProperty = GetDbSetProperties(dbContext.GetType()).FirstOrDefault(p => p.Name == propertyName);

            if (dbSetProperty == null)
            {
                throw new ArgumentException();
            }

            return ((IEnumerable) dbSetProperty.GetValue(dbContext)).Cast<object>();
        }
    }
}