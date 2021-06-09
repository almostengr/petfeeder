using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IWateringRepository : IRepositoryBase<Watering>
    {
        Task<List<Watering>> GetRecentWateringsAsync();
    }
}