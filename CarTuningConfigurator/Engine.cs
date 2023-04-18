using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Engine : TuningItem
    {
        [Column("engine_id")]
        public int? EngineId { get; set; }
        public string? Type { get; set; }
        public string? Cylinder { get; set; }
        public int ImpactVelocity { get; set; }
        public double ImpactAcceleration { get; set; }
        public int ImpactHorsePower { get; set; }

        public Engine(string type, string cylinder, int impactVelocity, double impactAcceleration, int impactHorsePower)
        {
            Type = type;
            Cylinder = cylinder;
            ImpactVelocity = impactVelocity;
            ImpactAcceleration = impactAcceleration;
            ImpactHorsePower = impactHorsePower;
        }

        public Engine() { }

        public Engine(int id, string name, string type, string cylinder, int level, double price, int impactVelocity, double impactAcceleration, int impactHorsePower)
        {
            EngineId = id;
            Name = name;
            Type = type;
            Cylinder = cylinder;
            Level = level;
            Price = price;
            ImpactVelocity = impactVelocity;
            ImpactAcceleration = impactAcceleration;
            ImpactHorsePower = impactHorsePower;
        }
    }
}
