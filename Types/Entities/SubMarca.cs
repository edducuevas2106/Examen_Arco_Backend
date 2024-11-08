using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Types.Entities
{
    public class SubMarca : BaseEntity
    {
        public int MarcaID { get; set; }  // Clave foránea a Marca
        public string Nombre { get; set; }
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;  // Fecha de creación con valor por defecto
        public bool IsActive { get; set; } = true;  // Estado activo por defecto

        // Relación con Marca
        public Marcas Marca { get; set; }  // Relación de muchos a uno

        // Relación con Modelo
        public ICollection<Modelos> Modelos { get; set; }
    }
}
