using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class DetalleModel
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public PedidoModel Pedido { get; set; }
        public int IdPlato { get; set; }
        public PlatoModel Plato { get; set; }
    }
}
