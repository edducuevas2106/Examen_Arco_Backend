using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types.Entities;
using Types.Models;

namespace DataInterfaces.Services
{
    public interface IVehiculosServices
    {
        Task<IEnumerable<VehiculosDto>> ObtenerVehiculos(int? filterType, string? nombre);
        Task IImportData();
    }
}
