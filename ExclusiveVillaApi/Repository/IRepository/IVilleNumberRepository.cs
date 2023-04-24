using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Repository.IRepository;
using System.Linq.Expressions;

namespace ExclusiveVillaApi.Repository.IRepository
{
    public interface IVilleNumberRepository : IRepository<VilleNumber>
    {

        Task<VilleNumber> UpdateAsync(VilleNumber entity);


    }
}


