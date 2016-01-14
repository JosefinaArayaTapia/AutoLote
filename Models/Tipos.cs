using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoLote.Models
{
    public class Tipos
    {
        [Key]
        public int TipoId{ get; set; }
        [Required]
        public String Descripcion{ get; set; }
        public String Comentario{ get; set; }

    }
}