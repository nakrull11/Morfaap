using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class ComentarioModel
    {
        public int IdUsuario { get; set; }
        public int IdLocal { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
    }
}
