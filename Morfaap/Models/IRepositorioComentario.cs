using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioComentario : IRepositorio<ComentarioModel>
    {
        IList<ComentarioModel> ObtenerComentarioPorLocal(LocalModel local);

        IList<ComentarioModel> ObtenerComentarioPorPuntuacion(int puntuacion);

        IList<ComentarioModel> ObtenerComentarioPorUsuario(UsuarioModel usuario);

    }
}
