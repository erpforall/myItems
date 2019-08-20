using MyItemApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class Hierarchy
    {
        [Key]
        public int HierarchyId { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public int? ParentItemId { get; set; }
        [ForeignKey("ParentItemId")]
        public virtual Item ParentItem { get; set; }

        [ForeignKey("Log")]
        public int LogId { get; set; }

        public virtual Log Log { get; set; }

    }
}
