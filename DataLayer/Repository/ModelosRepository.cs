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
    public class ModelosRepository : BaseRepository<Modelos>, IModelosRepository
    {
        public ModelosRepository(EntitiesModel context) : base(context)
        {
        }
    }
}
