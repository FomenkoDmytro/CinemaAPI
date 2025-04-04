using EpicVision.Application_BLL.DTO.DurationUnits;
using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.Services
{
    public class DurationUnitService : IDurationUnitService
    {
        private readonly IDurationUnitRepository _durationUnitRepository;

        public DurationUnitService(IDurationUnitRepository durationUnitRepository)
        {
            _durationUnitRepository = durationUnitRepository;
        }

        public async Task Add(AddDurationUnitDto durationUnitDto)
        {
            var durationUnit = new DurationUnit
            {
                ShortName = durationUnitDto.ShortName,
                FullName = durationUnitDto.FullName
            };
            await _durationUnitRepository.Add(durationUnit);
        }

        public async Task Delete(int id)
        {
            await _durationUnitRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllDurationUnitsDictionaryDto>> GetAllDurationUnitsDictionary()
        {
            var durationUnits = await _durationUnitRepository.GetAllDurationUnitsDirectory();
            return durationUnits
                .Select(d => new GetAllDurationUnitsDictionaryDto
                {
                    Id = d.Id,
                    ShortName = d.ShortName,
                    FullName = d.FullName
                }).ToList();

        }

        public async Task Update(int id, UpdateDurationUnitDto durationUnit)
        {
            var durationUnitForUpdate = await _durationUnitRepository.GetById(id);

            if (durationUnitForUpdate == null)
            {
                throw new KeyNotFoundException($"Одиницю виміру часу з id {id} не знайдено.");
            }

            durationUnitForUpdate.ShortName = durationUnit.ShortName;
            durationUnitForUpdate.FullName = durationUnit.FullName;


            await _durationUnitRepository.Update(durationUnitForUpdate);
        }
    }
}
