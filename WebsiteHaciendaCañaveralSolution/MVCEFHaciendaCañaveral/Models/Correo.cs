using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Correo
    {
        [Key]
        public int IdCorreo { get; set; }
        [Required]
        [StringLength(255)]
        [Index("UQ_EMAILCorreo", IsUnique = true)]
        public String Email { get; set; }
        public int IdDatosOrganizacionales { get; set; }
        [ForeignKey("IdDatosOrganizacionales")]
        public DatosOrganizacionales DatosOrganizacionales { get; set; }
    }
}