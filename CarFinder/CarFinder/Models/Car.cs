using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFinder.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Trim { get; set; }
        public string BodyType { get; set; }
        public string EnginePosition { get; set; }
        public string EngineCylinder { get; set; }
        public string EngineType { get; set; }
        public string EnginePowerRPM { get; set; }
        public string EngineTorqueRPM { get; set; }
        public string EngineFuel { get; set; }
        public string FuelCapacity { get; set; }
        public string TopSpeed { get; set; }
        public string Transmission { get; set; }
        public string Seats { get; set; }
        public string Doors { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
    }
}