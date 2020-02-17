using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class LocalModel
    {
        [Key]
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Direccion { get; set; }
        public string NumCelular { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public UsuarioModel Propietario{ get; set; }
    }
}
