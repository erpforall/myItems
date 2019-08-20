using MyNoteApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public int CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual User UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Item Item { get; set; }
        public virtual Hierarchy Hierarchy { get; set; }

        public virtual ItemAttribute ItemAttribute { get; set; }
        public virtual ItemText ItemText { get; set; }
        public virtual ItemData ItemData { get; set; }
    }
}
