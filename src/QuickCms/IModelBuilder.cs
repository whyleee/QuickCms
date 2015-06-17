using System;

namespace QuickCms
{
    public interface IModelBuilder
    {
        ItemModel GetModel(object item);
    }
}