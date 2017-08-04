using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }
        [Required]
        public String Nombre { get; set; }
        [StringLength(255)]
        [Index("UQ_URLImagenIngrediente", IsUnique = true)]
        public String UrlImagen { get; set; }
        public int IdReceta { get; set; }
        [ForeignKey("IdReceta")]
        public Receta Receta { get; set; }
    }
}