using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int IdDatosOrganizacionales { get; set; }
        [ForeignKey("IdDatosOrganizacionales")]
        public DatosOrganizacionales DatosOrganizacionales { get; set; }
    }
}