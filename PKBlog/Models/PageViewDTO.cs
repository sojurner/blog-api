using System;
using PKBlog.DataAccess.Models;

namespace PKBlog.Models
{
    public class PageViewDTO
    {
        public PageViewDTO(PageView pageView)
        {
            Name = pageView.Name;
            Type = pageView.Type;
            Count = pageView.Count;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
    }
}
