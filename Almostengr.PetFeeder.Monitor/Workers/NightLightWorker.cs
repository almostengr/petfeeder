using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Microsoft.Extensions.Logging;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public class NightLightWorker : BaseWorker
    {
        private readonly TimeSpan nightTimeOn = new TimeSpan(19, 00, 00);
        private readonly TimeSpan nightTimeOff = new TimeSpan(07, 00, 00);
        private readonly INightLightClient _nightLightClient;

        public NightLightWorker(ILogger<NightLightWorker> logger,
            INightLightClient nightLightClient) : base(logger)
        {
            _nightLightClient = nightLightClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                NightLight nightlight = new NightLight();

                if (currentTime >= nightTimeOn || currentTime <= nightTimeOff)
                {
                    nightlight.LightOn = true;
                    await _nightLightClient.CreateNightLightAsync(nightlight);
                }
                else
                {
                    nightlight.LightOn = false;
                    await _nightLightClient.CreateNightLightAsync(nightlight);
                }

                await Task.Delay(TimeSpan.FromMinutes(15));
            }
        }

    }
}