using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class DatosOrganizacionales
    {
        [Key]
        public int IdDatosOrganizacionales { get; set; }
        [Required]
        [StringLength(255)]
        public String Nombre { get; set; }
        [Required]
        public String Descripcion { get; set; }
        public String Mision { get; set; }
        public String Vision { get; set; }
        [Required]
        public String Ubicacion { get; set; }
        public List<Correo> Correos { get; set; }
        public List<Telefono> Telefonos { get; set; }
    }
}