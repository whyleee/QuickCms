using System;

namespace QuickCms
{
    public interface IRepositoryFactory
    {
        IRepository CreateRepository(string name);
    }
}