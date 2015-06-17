using System;

namespace QuickCms
{
    public interface IRepositoryMetadata
    {
        Type GetEntityType();
    }
}