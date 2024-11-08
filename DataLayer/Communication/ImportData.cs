using DataInterfaces.Repository;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types.Entities;

namespace DataLayer.Communication
{
    public class ImportData: IImportData
    {
        protected readonly EntitiesModel _Context;
        protected readonly AppSettingTool _appSettingTool;

        public ImportData(EntitiesModel context)
        {
            _Context = context;
            _appSettingTool = new AppSettingTool(context._configuration);
        }

        public async Task Import()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var filePath = _appSettingTool.rutaExcel;

            using var package = new ExcelPackage(new FileInfo(filePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets["nuevo5"];

            if (worksheet == null) throw new Exception("No se encontró la hoja en el archivo Excel.");


            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var marcaNombre = worksheet.Cells[row, 1].Text;
                var submarcaNombre = worksheet.Cells[row, 2].Text;
                var modeloNombre = Convert.ToInt32(worksheet.Cells[row, 3].Text);
                var descripcionDetalle = worksheet.Cells[row, 4].Text;
                var descripcionId = Guid.Parse(worksheet.Cells[row, 5].Text);

                try
                {
                    // Inserta o busca la marca
                    var marca = await _Context.Marca.FirstOrDefaultAsync(m => m.Nombre == marcaNombre);
                    if (marca == null)
                    {
                        marca = new Marcas
                        {
                            Nombre = marcaNombre,
                            Fecha_Creacion = DateTime.Now,
                            IsActive = true
                        };
                        _Context.Marca.Add(marca);
                        await _Context.SaveChangesAsync();
                    }
                    var marcaId = marca.Id; // Aquí el ID de 'modelo' ya está asignado

                    // Inserta o busca la submarca
                    var submarca = await _Context.Submarca
                        .FirstOrDefaultAsync(s => s.Nombre == submarcaNombre && s.MarcaID == marcaId);
                    if (submarca == null)
                    {
                        submarca = new SubMarca
                        {
                            Nombre = submarcaNombre,
                            MarcaID = marcaId,
                            Fecha_Creacion = DateTime.Now,
                            IsActive = true
                        };
                        _Context.Submarca.Add(submarca);
                        await _Context.SaveChangesAsync();
                    }
                    var submarcaId = submarca.Id;

                    // Inserta o busca el modelo
                    var modelo = await _Context.Modelo
                        .FirstOrDefaultAsync(mo => mo.Año == modeloNombre && mo.SubmarcaID == submarcaId);
                    if (modelo == null)
                    {
                        modelo = new Modelos
                        {
                            Año = modeloNombre,
                            SubmarcaID = submarcaId,
                            Fecha_Creacion = DateTime.Now,
                            IsActive = true
                        };
                        _Context.Modelo.Add(modelo);
                        await _Context.SaveChangesAsync();
                    }
                    var modeloId = modelo.Id;


                    var lstDescripcion = new List<Descripcion>();
                    // Inserta la descripción
                    var descripcion = new Descripcion
                    {
                        DescripcionID = descripcionId,
                        DescripcionTexto = descripcionDetalle,
                        ModeloID = modeloId,
                        Fecha_Creacion = DateTime.Now,
                        IsActive = true
                    };
                    _Context.Descripcion.Add(descripcion);
                    await _Context.SaveChangesAsync();
                }
                catch (Exception ex) {
                    continue;
                }
            }

            
            Console.WriteLine("Datos importados con éxito.");
        }
    }
}
