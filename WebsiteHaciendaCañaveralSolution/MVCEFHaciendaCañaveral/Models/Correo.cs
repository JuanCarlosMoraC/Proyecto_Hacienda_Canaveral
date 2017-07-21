using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Correo
    {
        [Key]
        public int IdCorreo { get; set; }
        [Required]
        public String Email { get; set; }
    }
}