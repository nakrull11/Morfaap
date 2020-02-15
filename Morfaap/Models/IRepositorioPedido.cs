using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioPedido : IRepositorio<PedidoModel>
    {
        PedidoModel ObtenerPorUsuario(UsuarioModel usuario);

        int ModificarEstadoPedido(PedidoModel pedido);

    }
}
