using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class ItemDataView
    {
        public int ItemDateId { get; set; }

        public int ItemId { get; set; }

        public string Title { get; set; }

        public byte Type { get; set; }

        public byte[] Data { get; set; }

        [MaxLength(256)]
        public string Path { get; set; }
 
        public int LogId { get; set; }

    }
}
