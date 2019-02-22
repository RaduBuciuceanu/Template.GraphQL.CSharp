using System.Collections.Generic;

namespace Template.Business.Models
{
    public class Pagination<TItem>
    {
        public IEnumerable<TItem> Items { get; set; } = new List<TItem>();

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
