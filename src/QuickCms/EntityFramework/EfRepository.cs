using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Entity;

namespace QuickCms.EntityFramework
{
    public class EfRepository : IRepository
    {
        private readonly DbContext _dbContext;
        private readonly string _dbSetName;
        private readonly EfDbContextScanner _dbContextScanner;

        public EfRepository(DbContext dbContext, string dbSetName, EfDbContextScanner dbContextScanner)
        {
            _dbContext = dbContext;
            _dbSetName = dbSetName;
            _dbContextScanner = dbContextScanner;
        }

        public IEnumerable<object> GetAll()
        {
            return GetDbSet();
        }

        public object Get(object id)
        {
            return GetDbSet().FirstOrDefault(x => x.Id.ToString() == id.ToString());
        }

        public void Save(object entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            var entityType = GetEntityType();
            var entity = Activator.CreateInstance(entityType);
            var idProperty = entityType.GetProperty("Id");
            idProperty.SetValue(entity, Convert.ChangeType(id, idProperty.PropertyType));

            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private IEnumerable<dynamic> GetDbSet()
        {
            return _dbContextScanner.GetDbSet(_dbContext, _dbSetName);
        }

        private Type GetEntityType()
        {
            return GetDbSet().GetType().GetGenericArguments().First();
        }
    }
}