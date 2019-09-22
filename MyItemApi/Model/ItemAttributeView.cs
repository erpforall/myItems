using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class ItemAttributeView
    {
        public int ItemAttributeId { get; set; }

        public int ItemId { get; set; }

        public int AttributeNameId { get; set; }
        public string AttributeName { get; set; }

        public int AttributeValueId { get; set; }
        public string AttributeValue { get; set; }

        public int LogId { get; set; }
    }
}
