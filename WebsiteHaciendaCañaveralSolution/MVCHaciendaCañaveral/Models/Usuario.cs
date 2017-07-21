using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHaciendaCañaveral.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public  String nombre { get; set; }
        public String apellidos{ get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean enable { get; set; }
        public Role role { get; set; }
    }
}