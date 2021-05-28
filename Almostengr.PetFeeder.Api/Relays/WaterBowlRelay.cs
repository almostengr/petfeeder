using System.Device.Gpio;
using Almostengr.PetFeeder.Api.Constants;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Relays
{
    public class WaterBowlRelay : RelayBase, IWaterBowlRelay
    {

        private readonly ILogger<WaterBowlRelay> _logger;
        private readonly GpioController _gpio;
        private const int WaterValveRelay = 25;

        public WaterBowlRelay(ILogger<WaterBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;
            
            OpenPin(gpio, PinMode.Output, WaterValveRelay);
        }

        public void OpenWaterValve()
        {
            _logger.LogInformation("Turning on water");
            _gpio.Write(WaterValveRelay, GpioPin.On);
        }

        public void CloseWaterValve()
        {
            _logger.LogInformation("Turning off water");
            _gpio.Write(WaterValveRelay, GpioPin.Off); // turn off water
        }

    }
}