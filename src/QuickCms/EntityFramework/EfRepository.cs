using System;
using System.Collections;
using System.Reflection;
using Microsoft.Data.Entity;

namespace QuickCms.EntityFramework
{
    public class EfRepository : IRepository
    {
        private readonly DbContext _db;
        private readonly string _dbSetName;
        private readonly EfDbContextScanner _dbContextScanner;

        public EfRepository(DbContext db, string dbSetName, EfDbContextScanner dbContextScanner)
        {
            _db = db;
            _dbSetName = dbSetName;
            _dbContextScanner = dbContextScanner;
        }

        public IEnumerable GetAll()
        {
            var dbSetProperty = _dbContextScanner.GetDbSetProperty(_db.GetType(), _dbSetName);

            if (dbSetProperty == null)
            {
                throw new ArgumentException();
            }

            return (IEnumerable) dbSetProperty.GetValue(_db);
        }

        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}