using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorioPlato : IRepositorio<PlatoModel>
    {
        IList<PlatoModel> ObtenerPorNombre(string nombre);
        IList<PlatoModel> ObtenerPorCategoria(string categoria);
        IList<PlatoModel> ObtenerPorPrecio(decimal precio);
        int ModificarEstadoPlato(PlatoModel plato);
    }
}
