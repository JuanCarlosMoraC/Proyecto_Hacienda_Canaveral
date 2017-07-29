using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(255)]
        [Index("UQ_EMAIL",IsUnique =true)]
        public String Email { get; set; }
        [Required]
        [StringLength(255)]
        public String Password { get; set; }
        public Boolean Enable { get; set; }
        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public Role Role { get; set; }
    }
}