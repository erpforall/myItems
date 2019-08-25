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

        public string LoginId { get; set; }

        public string Password { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<Log> LogCreatedAt { get; set; }
        public virtual ICollection<Log> LogUpdatedAt { get; set; }
    }
}
