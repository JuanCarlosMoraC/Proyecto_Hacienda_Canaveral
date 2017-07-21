using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Telefono
    {
        [Key]
        public int IdTelefono { get; set; }
        [Required]
        [StringLength(20)]
        public String NumeroTelefono{ get; set; }

    }
}