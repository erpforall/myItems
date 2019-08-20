using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Model
{
    public class ItemTextView
    {
        public int ItemTextId { get; set; }

        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int LogId { get; set; }

    }
}
