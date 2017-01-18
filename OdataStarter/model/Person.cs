using model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    public class Person : IEntity {

        public Person() {
            Experiences = new List<Experience>();
            Friends = new List<Person>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public virtual List<Experience> Experiences { get; set; }

        public virtual Country CountryOfBirth { get; set; }

        public virtual List<Person> Friends { get; set; }
    }
}
