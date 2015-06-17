using System;
using System.Collections.Generic;

namespace QuickCms
{
    public class ItemModel
    {
        public dynamic Item { get; set; }

        public object Id { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public string FullTypeName { get; set; }

        public IEnumerable<ItemFieldModel> Fields { get; set; }
    }
}