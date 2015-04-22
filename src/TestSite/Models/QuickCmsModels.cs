using System;
using System.Collections.Generic;
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
}