using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioLocal : IRepositorio<LocalModel>
    {
        IList<LocalModel> BuscarPorNombre(string nombre);
        IList<LocalModel> ObtenerPorPuntuacion(int puntuacion);
    }
}
