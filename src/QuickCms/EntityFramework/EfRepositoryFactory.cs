using System;
using Microsoft.Data.Entity;

namespace QuickCms.EntityFramework
{
    public class EfRepositoryFactory : IRepositoryFactory
    {
        private readonly Type _dbContextType;
        private readonly EfDbContextScanner _efDbContextScanner;

        public EfRepositoryFactory(Type dbContextType, EfDbContextScanner efDbContextScanner)
        {
            _dbContextType = dbContextType;
            _efDbContextScanner = efDbContextScanner;
        }

        public IRepository CreateRepository(string name)
        {
            var db = (DbContext) Activator.CreateInstance(_dbContextType);
            return new EfRepository(db, name + "s", _efDbContextScanner);
        }
    }
}