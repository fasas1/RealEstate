using ExclusiveVillaApi.Models;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository.IRepository
{
    public interface IVilleRepository
    {
        Task<List<Ville>> GetAll(Expression<Func<Ville, bool>> filter = null);
        Task <Ville> Get(Expression<Func<Ville, bool>> filter = null, bool tracked=true);

        Task Create(Ville entity);
        Task Remove(Ville entity);
        Task Save();
    }
}
