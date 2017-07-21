using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public String Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public String Apellidos { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        public Boolean Enable { get; set; }
        public virtual Role Role { get; set; }
    }
}