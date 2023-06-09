﻿using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository
{
    public class VilleRepository : Repository<Ville>, IVilleRepository
    {
        private readonly ApplicationDbContext _db;
        public VilleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<Ville> UpdateAsync(Ville entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
