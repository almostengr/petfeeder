using System.Device.Gpio;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.BackEnd.Constants;

namespace Almostengr.PetFeeder.BackEnd.Relays
{
    public class WaterBowlRelay : RelayBase, IWaterBowlRelay
    {
        private readonly ILogger<WaterBowlRelay> _logger;
        private readonly GpioController _gpio;

        public WaterBowlRelay(ILogger<WaterBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;
            
            OpenPin(gpio, PinMode.Output, GpioPin.WaterValveRelay);
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }
    }
}