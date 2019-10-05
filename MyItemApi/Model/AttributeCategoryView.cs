using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class AttributeCategoryView
    {
        public int AttributeCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<AttributeNameView> AttributeNameViews { get; set; }
    }
}
