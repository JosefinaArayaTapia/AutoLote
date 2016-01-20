using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoLote.Models
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }
        [Required(ErrorMessage = "Ingrese Descripcion")]
        [Display(Name = "Modelo")]
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }
        public Marcas Marcas { get; set; }

        
        
    }
}