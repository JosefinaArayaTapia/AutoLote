using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoLote.Models
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Ingrese Descripcion")]
        public String Descripcion { get; set; }
        public String UrlImagen{ get; set; }
        public virtual ICollection<Modelos> ListaModelos { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper ImagenSubida{ get; set; }
    }
}