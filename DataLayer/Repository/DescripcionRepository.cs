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
    public class DescripcionRepository : BaseRepository<Descripcion>, IDescripcionRepository
    {
        public DescripcionRepository(EntitiesModel context) : base(context)
        {
        }
    }
}
