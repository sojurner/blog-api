using System;
using System.ComponentModel.DataAnnotations;

namespace PKBlog.DataAccess.Models
{
    public class PageView : EntityBase
    {
        public PageView()
        {
        }

        [Required] public string Name { get; set; }

        [Required] public string Type { get; set; }

        [Required] public int Count { get; set; }
    }
}
