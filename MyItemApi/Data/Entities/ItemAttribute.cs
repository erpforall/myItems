using MyNoteApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class ItemAttribute
    {
        [Key]
        public int ItemAttributeId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [ForeignKey("AttributeValue")]
        public int AttributeValueId { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }

        [ForeignKey("Log")]
        public int LogId { get; set; }
        public virtual Log Log { get; set; }
    }
}
