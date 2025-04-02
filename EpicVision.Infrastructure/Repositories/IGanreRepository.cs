using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IGanreRepository
    {
        Task<IEnumerable<Ganre>> GetAllGanres();
        Task Add(Ganre ganre);
        void Update(Ganre ganre);
        void Delete(int id);
    }
}
