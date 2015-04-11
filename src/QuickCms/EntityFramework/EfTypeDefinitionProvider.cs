using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using System.Reflection;

namespace QuickCms.EntityFramework
{
    public class EfTypeDefinitionProvider : ITypeDefinitionProvider
    {
        private readonly Type _dbContextType;
        private IList<Type> _typeDefinitions;

        public EfTypeDefinitionProvider(Type dbContextType)
        {
            _dbContextType = dbContextType;
        }

        public IEnumerable<Type> GetTypeDefinitions()
        {
            if (_typeDefinitions != null)
            {
                return _typeDefinitions;
            }

            _typeDefinitions = _dbContextType.GetProperties()
                .Where(p => p.PropertyType.IsConstructedGenericType &&  p.PropertyType.GetGenericTypeDefinition() == typeof (DbSet<>))
                .Select(p => p.PropertyType.GetGenericArguments().First())
                .ToList();

            return _typeDefinitions;
        }
    }
}