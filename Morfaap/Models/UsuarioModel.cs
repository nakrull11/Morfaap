using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public DateTime FecNac { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Direccion { get; set; }
        public string NumCelular { get; set; }
        public string Password { get; set; }
    }
}
