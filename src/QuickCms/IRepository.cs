using System;
using System.Collections;

namespace QuickCms
{
    public interface IRepository : IDisposable
    {
        IEnumerable GetAll();
        object Get(object id);
    }
}