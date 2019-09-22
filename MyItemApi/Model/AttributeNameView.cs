using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyItemApi.Model
{
    public class AttributeNameView
    {
        public int AttributeNameId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<AttributeValueView> AttributeValueViews { get; set; }

    }
}
