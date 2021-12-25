using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Services.Interfaces
{
    public interface ISystemSettingService
    {
        Task<SystemSettingDto> GetSystemSettingAsync(string name);
        Task<SystemSettingDto> UpdateSystemSettingAsync(SystemSettingDto systemSetting);
        Task<SystemSettingDto> CreateSystemSettingAsync(SystemSettingDto systemSetting);
    }
}