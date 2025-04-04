using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public class DurationUnitRepository: IDurationUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public DurationUnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(DurationUnit durationUnit)
        {
            await _context.AddAsync(durationUnit);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var durationUnit = await _context.DurationUnits.FindAsync(id);

            if (durationUnit != null)
            {
                _context.Remove(durationUnit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DurationUnit>> GetAllDurationUnitsDirectory()
        {
            return await _context.DurationUnits.ToListAsync();
        }


        public async Task<DurationUnit> GetById(int id)
        {
            var durationUnit = await _context.DurationUnits.FindAsync(id);

            if (durationUnit == null)
            {
                throw new KeyNotFoundException($"Одиницю виміру часу з id {id} не знайдено.");
            }

            return durationUnit;
        }

        public async Task Update(DurationUnit durationUnit)
        {
            var durationUnitForUpdate = await _context.DurationUnits.FindAsync(durationUnit.Id);

            if (durationUnitForUpdate == null)
            {
                throw new KeyNotFoundException($"Одиницю виміру часу з id {durationUnit.Id} не знайдено.");
            }

            durationUnitForUpdate.ShortName = durationUnit.ShortName;
            durationUnitForUpdate.FullName = durationUnit.FullName;

            await _context.SaveChangesAsync();
        }
    }
}
