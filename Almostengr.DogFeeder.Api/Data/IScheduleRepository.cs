using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Models;
using Almostengr.DogFeeder.Models;

namespace Almostengr.DogFeeder.Api.Data
{
    public interface IScheduleRepository
    {
        Task CreateSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
        Task<List<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleAsync(int id);
        Task SaveChangesAsync();
        Task<List<Schedule>> GetAllActiveSchedulesAsync();
        Task<List<Schedule>>  GetAllInactiveSchedulesAsync();
    }
}