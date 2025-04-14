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
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor != null)
            {
                _context.Remove(actor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Actor>> GetAllActorsDirectory()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllActorsWithMovies()
        {
            return await _context.Actors.Include(a => a.Movies).ToListAsync();
        }


        public async Task<Actor> GetById(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                throw new KeyNotFoundException($"Актора з id {id} не знайдено.");
            }

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetByIds(IEnumerable<int> ids)
        {
            return await _context.Actors
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task Update(Actor actor)
        {
            var actorForUpdate = await _context.Actors.FindAsync(actor.Id);

            if (actorForUpdate == null)
            {
                throw new KeyNotFoundException($"Актора з id {actor.Id} не знайдено.");
            }

            actorForUpdate.FirstName = actor.FirstName;
            actorForUpdate.LastName = actor.LastName;

            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> GetInvalidIds(IEnumerable<int> ids)
        {
            var existingIds = await _context.Actors
                .Where(a => ids.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            return ids.Except(existingIds).ToList();
        }

    }
}

