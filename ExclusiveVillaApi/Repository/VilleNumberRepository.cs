using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository
{
    public class VilleNumberRepository : Repository<VilleNumber>, IVilleNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VilleNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<VilleNumber> UpdateAsync(VilleNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VilleNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
