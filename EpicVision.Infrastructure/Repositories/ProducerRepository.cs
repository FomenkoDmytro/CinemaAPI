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
    public class ProducerRepository: IProducerRepository
    {
        private readonly ApplicationDbContext _context;

        public ProducerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var producer = await _context.Producers.FindAsync(id);

            if (producer != null)
            {
                _context.Producers.Remove(producer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Producer>> GetAllProducersDirectory()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllProducersWithMovies()
        {
            return await _context.Producers.Include(a => a.Movies).ToListAsync();
        }


        public async Task<Producer> GetById(int id)
        {
            var producer = await _context.Producers.FindAsync(id);

            if (producer == null)
            {
                throw new KeyNotFoundException($"Продюсера з id {id} не знайдено.");
            }

            return producer;
        }

        public async Task Update(Producer producer)
        {
            var producerForUpdate = await _context.Producers.FindAsync(producer.Id);

            if (producerForUpdate == null)
            {
                throw new KeyNotFoundException($"Продюсера з id {producer.Id} не знайдено.");
            }

            producerForUpdate.FirstName = producer.FirstName;
            producerForUpdate.LastName = producer.LastName;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistById(int id)
        {
            return await _context.Producers.AnyAsync(d => d.Id == id);
        }
    }
}
