using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class MenuModel
    {
        [Key]
        public int IdMenu { get; set; }
        public LocalModel Local { get; set; }
    }
}
