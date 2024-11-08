using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Entities
{
    public class Modelos : BaseEntity
    {
        public int SubmarcaID { get; set; }  // Clave foránea a Submarca
        public int Año { get; set; }  // Año del modelo
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;  // Fecha de creación con valor por defecto
        public bool IsActive { get; set; } = true;  // Estado activo por defecto

        // Relación con Submarca
        public SubMarca Submarca { get; set; }  // Relación de muchos a uno

        // Relación con Descripcion
        public ICollection<Descripcion> Descripciones { get; set; }
    }
}
