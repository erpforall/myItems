using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
