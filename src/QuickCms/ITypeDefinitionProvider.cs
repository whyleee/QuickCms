using System;
using System.Collections.Generic;

namespace QuickCms
{
    public interface ITypeDefinitionProvider
    {
        IEnumerable<Type> GetTypeDefinitions();
    }
}