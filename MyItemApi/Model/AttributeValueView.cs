using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class AttributeValueView
    {
        public int AttributeValueId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public int AttributeNameId { get; set; }

    }
}
