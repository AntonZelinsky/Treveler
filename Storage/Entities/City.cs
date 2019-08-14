using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class City : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}