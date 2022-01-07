using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetSchedulesAsync();
        Task<ScheduleDto> GetScheduleAsync(int id);
        Task<ScheduleDto> CreateScheduleAsync(ScheduleDto scheduleDto);
        Task<ScheduleDto> UpdateScheduleAsync(ScheduleDto schedule);
        Task<int> DeleteScheduleAsync(int id);
        Task<List<ScheduleDto>> GetSchedulesByTimeAsync(TimeSpan time);
    }
}