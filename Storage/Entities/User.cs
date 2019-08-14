using System.Collections.Generic;

namespace Storage.Entities
{
    public class User : BaseEntity
    {

        public long ExternalUserId { get; set; }

        public virtual IEnumerable<City> Cities { get; set; }
    }
}