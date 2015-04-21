using System;
using System.Collections.Generic;

namespace TestSite.Models
{
    public class AdminIndexViewModel
    {
        public IList<Type> FoundTypes { get; set; }
    }

    public class EntityIndexViewModel
    {
        public string EntityName { get; set; }
        public IList<object> Entities { get; set; }
    }
}