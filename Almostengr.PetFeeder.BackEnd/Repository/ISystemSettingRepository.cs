using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Repository
{
    public interface ISystemSettingRepository : IBaseRepository
    {
        Task<SystemSettingDto> GetSystemSettingAsync(string name);
        Task<List<SystemSettingDto>> GetSystemSettingsAsync();
        Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSetting systemSetting);
        Task<SystemSetting> GetSystemSettingEntity(string name);
    }
}