using DataInterfaces.Repository;
using DataInterfaces.Services;
using Logs;
using Types.Models;

namespace BussinesLayer.Services
{
    public class VehiculosServices : IVehiculosServices
    {
        protected readonly IMarcasRepository _marcasRepository;
        protected readonly ILogger _logger;
        protected readonly IImportData _importData;

        public VehiculosServices(IMarcasRepository marcasRepository,ILogger logger, IImportData importData)
        {
            this._marcasRepository = marcasRepository;
            _logger = logger;
            _importData = importData;
        }

        public Task IImportData()
        {
            return _importData.Import();
        }

        public async Task<IEnumerable<VehiculosDto>> ObtenerVehiculos(int? filterType, string? nombre)
        {
            try
            {
                // Obtener datos desde el repositorio
                var marcas = await _marcasRepository.GetVehiculos(filterType, nombre);
                return marcas;
            }
            catch (Exception ex) 
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return new List<VehiculosDto>();
            }
        }
    }
}
