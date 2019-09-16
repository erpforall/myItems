using MyItemApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class ItemText
    {
        [Key]
        public int ItemTextId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }

        public string Text { get; set; }

        [ForeignKey("Log")]
        public int LogId { get; set; }
        public virtual Log Log { get; set; }
    }
}
