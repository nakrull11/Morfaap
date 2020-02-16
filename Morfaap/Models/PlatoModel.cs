using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class PlatoModel
    {
        [Key]
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int IdMenu { get; set; }
        public MenuModel Menu { get; set; }
    }
}
