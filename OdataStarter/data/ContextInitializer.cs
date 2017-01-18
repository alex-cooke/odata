using model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data {
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context> {

        public override void InitializeDatabase(Context context) {

            context.Person.Add(new Person {
                FirstName = "Peter",
                LastName = "Cooke",
                DateOfBirth = DateTimeOffset.Parse("1951-12-23")
            });

            context.Person.Add(new Person {
                FirstName = "Jo",
                LastName = "Cooke",
                DateOfBirth = DateTimeOffset.Parse("1955-05-07"),
                Experiences = {
                    new model.Experience() {
                        Name = "travelled to Europe"
                    }
                }
            });

            context.Country.Add(new Country {
                Name = "Australia"
            });


            base.InitializeDatabase(context);
        }
    }
}
