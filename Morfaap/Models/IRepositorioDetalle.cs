using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioDetalle : IRepositorio<DetalleModel>
    {
        DetalleModel ObtenerDetallePorPedido(PedidoModel pedido);
    }
}
