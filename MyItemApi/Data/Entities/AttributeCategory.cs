using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class AttributeCategory
    {
        [Key]
        public int AttributeCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AttributeName> AttributeNames { get; set; }
    }
}
