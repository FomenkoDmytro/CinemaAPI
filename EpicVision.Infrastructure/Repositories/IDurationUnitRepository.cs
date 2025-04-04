using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IDurationUnitRepository
    {
        Task<IEnumerable<DurationUnit>> GetAllDurationUnitsDirectory();
        Task<DurationUnit> GetById(int id);
        Task Add(DurationUnit durationUnit);
        Task Update(DurationUnit durationUnit);
        Task Delete(int id);
    }
}
