using MVCEFHaciendaCañaveral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Business
{
    public class RoleBusiness
    {
        public List<Role> GetAllRoles()
        {
            using (var db = new HaciendaCañaveralContext())
            {
                return db.Role.ToList();
            }
        }
    }
}