using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Entities
{
    public class Marcas : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;  // Fecha de creación con valor por defecto
        public bool IsActive { get; set; } = true;  // Estado activo por defecto

        // Relación con Submarca
        public ICollection<SubMarca> Submarcas { get; set; }
    }
}
