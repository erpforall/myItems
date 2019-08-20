using MyItemApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class ItemData
    {
        [Key]
        public int ItemDataId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string Title { get; set; }

        public byte Type { get; set; }

        public byte[] Data { get; set; }

        [MaxLength(256)]
        public string Path { get; set; }

        [ForeignKey("Log")]
        public int LogId { get; set; }
        public virtual Log Log { get; set; }
    }
}
