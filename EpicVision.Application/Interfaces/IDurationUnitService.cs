using EpicVision.Application_BLL.DTO.DurationUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IDurationUnitService
    {
        Task<IEnumerable<GetAllDurationUnitsDictionaryDto>> GetAllDurationUnitsDictionary();
        Task Add(AddDurationUnitDto durationUnitDto);
        Task Update(int id, UpdateDurationUnitDto durationUnit);
        Task Delete(int id);
    }
}
