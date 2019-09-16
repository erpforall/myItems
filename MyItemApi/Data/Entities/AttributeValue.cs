using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Data.Entities
{
    public class AttributeValue
    {
        [Key]
        public int AttributeValueId { get; set; }

        [MaxLength(20)]
        public string Value { get; set; }

        [ForeignKey("AttributeName")]
        public int AttributeNameId { get; set; }
        public virtual AttributeName AttributeName { get; set; }

        public ICollection<ItemAttribute> ItemAttributes { get; set; }
    }
}
