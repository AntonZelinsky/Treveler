using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class BaseEntity : IEntityId
    {
        [Required]
        [Key]

        public int Id { get; set; }
    }

    public interface IEntityId
    {
        int Id { get; }
    }
}