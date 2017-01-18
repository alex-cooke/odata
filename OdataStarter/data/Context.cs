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
            Database.SetInitializer(new ContextInitializer());
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Experience> Experience { get; set; }

        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new ExperienceConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
