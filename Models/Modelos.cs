using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoLote.Models
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }
        [Required(ErrorMessage = "Ingrese Descripcion")]
        public String Descripcion { get; set; }
        public String MarcaId { get; set; }
        public Marcas Marcas;
    }
}