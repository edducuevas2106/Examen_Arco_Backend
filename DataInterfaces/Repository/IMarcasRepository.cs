using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types.Entities;
using Types.Models;

namespace DataInterfaces.Repository
{
    public interface IMarcasRepository : IBaseRepository<Marcas>
    {
        Task<IEnumerable<VehiculosDto>> GetVehiculos(int? filterType, string? nombre);
    }
}
