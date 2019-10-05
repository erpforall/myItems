using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class AttributeName
    {
        [Key]
        public int AttributeNameId { get; set; }

        public string Name { get; set; }

        [ForeignKey("AttributeCategory")]
        public int AttributeCategoryId { get; set; }

        public virtual AttributeCategory AttributeCategory { get; set; }

        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
