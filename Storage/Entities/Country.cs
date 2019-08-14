using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Entities
{
    public class Country : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<City> Cities { get; set; }
    }
}