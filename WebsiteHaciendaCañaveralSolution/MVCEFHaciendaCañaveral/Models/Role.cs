using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        [Required]
        public String Descripcion { get; set; }
    }
}