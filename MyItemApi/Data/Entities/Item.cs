using MyItemApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(100)]
        public bool IsVirtual { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Log")]
        public int LogId { get; set; }
        public virtual Log Log { get; set; }

        public ICollection<ItemText> ItemTexts { get; set; }
        public ICollection<ItemData> ItemDatas { get; set; }
        public ICollection<Hierarchy> HierarchyItems { get; set; }
        public ICollection<Hierarchy> HierarchyParentItems { get; set; }
        public ICollection<ItemAttribute> ItemAttributes { get; set; }



    }
}
