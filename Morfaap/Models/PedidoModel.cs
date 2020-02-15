using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class PedidoModel
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
