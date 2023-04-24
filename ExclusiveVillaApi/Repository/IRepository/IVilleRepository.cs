using ExclusiveVillaApi.Models;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository.IRepository
{
    public interface IVilleRepository : IRepository<Ville>
    {

        Task<Ville> UpdateAsync(Ville entity);

    }
}
