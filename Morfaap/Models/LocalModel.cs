using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class LocalModel
    {
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Direccion { get; set; }
        public string NumCelular { get; set; }
        public int idPropietario { get; set; }
        public UsuarioModel Propietario{ get; set; }
    }
}
