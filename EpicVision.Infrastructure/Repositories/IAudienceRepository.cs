using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IAudienceRepository
    {
        Task<IEnumerable<Audience>> GetAllAudiences();
        Task<Audience> GetById(int id);
        Task Add(Audience audience);
        Task Update(Audience audience);
        Task Delete(int id);
    }
}
