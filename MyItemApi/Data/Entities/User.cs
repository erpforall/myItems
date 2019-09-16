using MyItemApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(20)]
        public string LoginId { get; set; }

        [MaxLength(32)]
        public string Password { get; set; }

        [MaxLength(32)]
        public string Salt { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<Log> LogCreatedAt { get; set; }
        public virtual ICollection<Log> LogUpdatedAt { get; set; }
    }
}
