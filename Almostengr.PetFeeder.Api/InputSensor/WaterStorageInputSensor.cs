using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.InputSensor
{
    public class WaterStorageInputSensor : InputSensorBase, IWaterStorageInputSensor
    {
        private const int WaterStorageVcc = 4;
        private const int WaterStorageGnd = 5;

        private readonly ILogger<WaterStorageInputSensor> _logger;
        private readonly GpioController _gpio;

        public WaterStorageInputSensor(ILogger<WaterStorageInputSensor> logger,
            GpioController gpio) : base(logger, gpio)
        {
            _logger = logger;
            _gpio = gpio;
        }

        public bool IsWaterStorageLow()
        {
            return IsWaterLevelLow(WaterStorageVcc, WaterStorageGnd);
        }
    }
}