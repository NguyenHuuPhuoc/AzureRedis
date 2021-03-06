﻿using System.Collections.Generic;

namespace AzureRedis.Models
{
    public class PaginationSet<T>
    {
        public int PageIndex { set; get; }
        public int PageSize { get; set; }
        public long TotalRows { set; get; }
        public IEnumerable<T> Items { set; get; }
    }
}
