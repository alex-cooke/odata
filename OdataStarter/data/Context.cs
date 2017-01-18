using data.config;
using model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data {
    public class Context : DbContext {

        public Context(string connectionStringName) : base(connectionStringName) {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
