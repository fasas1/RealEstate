using ExclusiveVillaApi.Models;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository.IRepository
{
    public interface IVilleRepository
    {
        Task<List<Ville>> GetAllAsync(Expression<Func<Ville, bool>> filter = null);
        Task <Ville> GetAsync(Expression<Func<Ville, bool>> filter = null, bool tracked=true);

        Task CreateAsync(Ville entity);
        Task UpdateAsync(Ville entity);
        Task RemoveAsync(Ville entity);
        Task SaveAsync();
    }
}
