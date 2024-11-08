using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Models
{
    public class VehiculosDto
    {
        public string Marca { get; set; }
        public string Submarca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; } 

        public string DescripcionId { get; set; }
    }
}
