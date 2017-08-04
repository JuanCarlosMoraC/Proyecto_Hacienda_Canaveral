using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCEFHaciendaCañaveral.Models
{
    public class Instruccion
    {
        [Key]
        public int IdInstruccion { get; set; }
        [Required]
        public String Descripcion { get; set; }
        [StringLength(255)]
        [Index("UQ_URLImagenInstruccion", IsUnique = true)]
        public String UrlImagen { get; set; }
        public int IdReceta { get; set; }
        [ForeignKey("IdReceta")]
        public Receta Receta { get; set; }
    }
}