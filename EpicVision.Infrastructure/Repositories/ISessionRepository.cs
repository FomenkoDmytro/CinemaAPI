using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllSessions();
        Task<IEnumerable<Session>> GetByIds(IEnumerable<int> ids);


        Task<List<int>> GetInvalidIds(IEnumerable<int> ids);


    }
}
