using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class AttributeName
    {
        [Key]
        public int AttributeNameId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
