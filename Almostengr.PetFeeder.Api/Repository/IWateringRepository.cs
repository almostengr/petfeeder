using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Repository
{
    public interface IWateringRepository : IBaseRepository
    {
        Task CreateWateringAsync(Watering watering);
        Task<List<Watering>> GetAllWateringsAsync();
        Task<Watering> GetWateringByIdAsync(int? id);
        void DeleteWatering(Watering watering);
        void DeleteWaterings(List<Watering> waterings);
        Task<List<Watering>> GetRecentWateringsAsync();
        void UpdateWatering(Watering watering);
    }
}