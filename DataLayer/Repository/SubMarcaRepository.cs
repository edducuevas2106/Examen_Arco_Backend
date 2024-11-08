using DataInterfaces.Repository;
using DataLayer.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types.Entities;

namespace DataLayer.Repository
{
    public class SubMarcaRepository : BaseRepository<SubMarca>, ISubMarcaRepository
    {
        public SubMarcaRepository(EntitiesModel context) : base(context)
        {
        }
    }
}
