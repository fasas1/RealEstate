using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository
{
    public class VilleRepository : IVilleRepository
    {
        private readonly ApplicationDbContext _db;
     
        public VilleRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task CreateAsync(Ville entity)
        {
            await _db.Villes.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Ville> GetAsync(Expression<Func<Ville, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Ville> query = _db.Villes;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Ville>> GetAllAsync(Expression<Func<Ville, bool>> filter = null)
        {
            IQueryable<Ville> query = _db.Villes;

            if(filter != null)
            {
                query = query.Where(filter);
            }
             return await query.ToListAsync();
        }

        public async Task RemoveAsync(Ville entity)
        {
             _db.Villes.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ville entity)
        {
            _db.Villes.Update(entity);
            await SaveAsync();
        }
    }
}
