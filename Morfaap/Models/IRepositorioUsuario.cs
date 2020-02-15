using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioUsuario : IRepositorio<UsuarioModel>
    {
        UsuarioModel ObtenerPorEmail(string email);
        UsuarioModel BuscarPorCelular(string celular);
    }
}
