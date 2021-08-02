using System;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Enums;
using Almostengr.PetFeeder.Web.Models;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Web.Constants;

namespace Almostengr.PetFeeder.Web.Relays
{
    public class FoodBowlRelay : RelayBase, IFoodBowlRelay
    {
        private readonly ILogger<FoodBowlRelay> _logger;
        private readonly GpioController _gpio;
        
        public FoodBowlRelay(ILogger<FoodBowlRelay> logger, GpioController gpio) : base()
        {
            _logger = logger;
            _gpio = gpio;

            OpenPins(gpio, PinMode.Output, new Int32[] { GpioPin.FoodForwardRelay, GpioPin.FoodBackwardRelay });
        }

        public async Task<Feeding> PerformFeeding(Feeding feeding)
        {
            // run the motor to dispense food
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feeding.Amount);
            await RunMotor(MotorDirection.Backward, 0.5);

            feeding.Created = DateTime.Now;

            return feeding;
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
        {
            switch (direction)
            {
                case MotorDirection.Forward:
                    _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.On);
                    _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
                    break;

                case MotorDirection.Backward:
                    _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
                    _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.On);
                    break;

                default:
                    break;
            }

            await Task.Delay(TimeSpan.FromSeconds(onTime));

            _gpio.Write(GpioPin.FoodForwardRelay, GpioOutput.Off);
            _gpio.Write(GpioPin.FoodBackwardRelay, GpioOutput.Off);
        }
    }
}