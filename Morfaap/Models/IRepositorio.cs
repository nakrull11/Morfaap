using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public interface IRepositorio<T>
    {
        int Alta(T ob);
        int Baja(int id);
        int Modificacion(T ob);
        IList<T> ObtenerTodos();
        T ObtenerPorId(int id);
    }
}
