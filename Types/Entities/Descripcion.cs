using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Types.Entities
{
    public class Descripcion : BaseEntity
    {
        public Guid DescripcionID { get; set; }  // Clave primaria
        public int ModeloID { get; set; }  // Clave foránea a Modelo
        public string DescripcionTexto { get; set; }
        public DateTime Fecha_Creacion { get; set; } = DateTime.Now;  // Fecha de creación con valor por defecto
        public bool IsActive { get; set; } = true;  // Estado activo por defecto

        // Relación con Modelo
        public Modelos Modelo { get; set; }  // Relación de muchos a uno
    }
}
