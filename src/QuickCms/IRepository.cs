using System;
using System.Collections.Generic;

namespace QuickCms
{
    public interface IRepository : IDisposable
    {
        IEnumerable<object> GetAll();
        object Get(object id);
    }
}