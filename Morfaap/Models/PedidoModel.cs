using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class PedidoModel
    {
        [Key]
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public UsuarioModel Usuario { get; set; }
    }
}
