using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Receta
    {
        [Key]
        public int IdReceta { get; set; }
        [Required]
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public List<Instruccion> Instrucciones { get; set; }
    }
}