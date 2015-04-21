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
        private readonly EfDbContextScanner _dbContextScanner;

        private IList<Type> _typeDefinitions;

        public EfTypeDefinitionProvider(Type dbContextType, EfDbContextScanner dbContextScanner)
        {
            _dbContextType = dbContextType;
            _dbContextScanner = dbContextScanner;
        }

        public IEnumerable<Type> GetTypeDefinitions()
        {
            if (_typeDefinitions != null)
            {
                return _typeDefinitions;
            }

            _typeDefinitions = _dbContextScanner.GetDbSetProperties(_dbContextType)
                .Select(p => p.PropertyType.GetGenericArguments().First())
                .ToList();

            return _typeDefinitions;
        }
    }
}