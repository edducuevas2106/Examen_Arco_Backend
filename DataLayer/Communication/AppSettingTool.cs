using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Communication
{
    public class AppSettingTool
    {
        private readonly IConfiguration _configuration = null;
        public AppSettingTool(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString => _configuration.GetConnectionString("localDb");
        public string rutaExcel => _configuration.GetConnectionString("rutaExcel");
    }
}
