using model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.config {
    class PersonConfiguration : EntityTypeConfiguration<Person> {

        public PersonConfiguration() {

            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasMany(x => x.Experiences).WithRequired(e => e.Person).WillCascadeOnDelete(true);
        }
    }
}
