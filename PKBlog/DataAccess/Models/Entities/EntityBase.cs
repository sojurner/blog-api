using System;
using System.ComponentModel.DataAnnotations;

namespace PKBlog.DataAccess.Models
{
    public abstract class EntityBase: IEntity
    {
        protected EntityBase() { }

        [Key] public Guid Id { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
