using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class ComentarioModel
    {   [Key]
        [Column(Order=1)]
        public int IdUsuario { get; set; }
        [Key]
        [Column(Order = 2)]
        public int IdLocal { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
    }
}
