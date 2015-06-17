using System;
using System.Collections.Generic;
using System.Dynamic;
using QuickCms;

namespace TestSite.Models
{
    public class AdminIndexViewModel
    {
        public IList<Type> FoundTypes { get; set; }
    }

    public class EntityIndexViewModel
    {
        public string EntityName { get; set; }
        public IList<ItemModel> Entities { get; set; }
    }

    public class EntityEditPostViewModel
    {
        public ExpandoObject Item { get; set; }
        public string TypeName { get; set; }
        public string FullTypeName { get; set; }
    }
}