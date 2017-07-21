using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Business
{
    public class UsuarioBusiness
    {
        public List<Usuario> GetAllUsers()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Usuario.ToList();
            }
        }
    }
}