using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class HaciendaCañaveralContext:DbContext
    {
        public HaciendaCañaveralContext() : base("HaciendaCañaVeral")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Telefono> Telefono { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasRequired(x => x.Role); //Permite realizar el foreing key
            base.OnModelCreating(modelBuilder);
        }

    }
}