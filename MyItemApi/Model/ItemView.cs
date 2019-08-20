using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class ItemView
    {
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsVirtual { get; set; }

        public int LogId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public List<ItemTextView> ItemTexts { get; set; }
        public List<ItemDataView> ItemDatas { get; set; }

    }
}
