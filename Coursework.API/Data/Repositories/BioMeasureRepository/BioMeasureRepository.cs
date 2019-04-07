using Core.Entities.Origin;
using Data.Repositories.Generic;

namespace Data.Repositories.BioMeasureRepository
{
    public class BioMeasureRepository : GenericRepository<BioMeasure>, IBioMeasureRepository
    {
        public BioMeasureRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
