using Dapper;
using DataInterfaces.Repository;
using DataLayer.Communication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Types.Entities;
using Types.Models;

namespace DataLayer.Repository
{
    public class MarcasRepository : BaseRepository<Marcas>, IMarcasRepository
    {
        protected readonly AppSettingTool _appSettingTool;
        public MarcasRepository(EntitiesModel context) : base(context) 
        {
            _appSettingTool = new AppSettingTool(context._configuration);
        }


        /// <summary>
        /// Metodo para la consultaa la bd para extraer los registros en base tipo filtro, marca, subMarca
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task<IEnumerable<VehiculosDto>> GetVehiculos(int? filterType, string? nombre)
        {
            using (var connection = new SqlConnection(_appSettingTool.ConnectionString))
            {
                var query = @"
                SELECT
                    m.Nombre AS Marca,
                    s.Nombre AS Submarca,
                    mod.Año AS Año,
                    d.DescripcionTexto AS Descripcion
                FROM
                    Marca m
                JOIN
                    Submarca s ON m.id = s.MarcaID
                JOIN
                    Modelo mod ON s.id = mod.Id
                JOIN
                    Descripcion d ON mod.id = d.Id
                WHERE 
                    (
                        (@FilterType = 1 AND m.Nombre LIKE '%' + @Marca + '%')
                        OR
                        (@FilterType = 2 AND s.Nombre LIKE '%' + @Marca + '%')
                        OR
                        (@FilterType = 0 OR @FilterType IS NULL)
                    )
                ORDER BY
                    m.Nombre, s.Nombre, mod.Año, d.DescripcionTexto;";

                var parameters = new DynamicParameters();
                parameters.Add("@FilterType", filterType);
                parameters.Add("@Marca", nombre);

                return connection.Query<VehiculosDto>(query, parameters);
            }
        }
    }
}
