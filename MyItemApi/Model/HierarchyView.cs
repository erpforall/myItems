using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class HierarchyView
    {
        public int HierarchyId { get; set; }

        public int? ParentItemId { get; set; }

        public int ItemId { get; set; }

        public int LogId { get; set; }
    }
}
