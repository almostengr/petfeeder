using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Watering : ModelBase
    {
        public DateTime Timestamp { get; set; }
    }
}