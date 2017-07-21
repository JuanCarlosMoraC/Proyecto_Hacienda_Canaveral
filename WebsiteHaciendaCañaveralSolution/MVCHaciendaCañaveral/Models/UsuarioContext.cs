using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCHaciendaCañaveral.Models
{
    public class UsuarioContext: DbContext
    {

        public UsuarioContext():base("CAÑAVERAL")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}