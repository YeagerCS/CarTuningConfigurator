using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Engine : TuningItem
    {
        public string Type { get; set; }
        public string Cylinder { get; set; }
        public int ImpactVelocity { get; set; }
        public int ImpactAcceleration { get; set; }
        public int ImpactHorsePower { get; set; }

        public Engine(string type, string cylinder, int impactVelocity, int impactAcceleration, int impactHorsePower)
        {
            Type = type;
            Cylinder = cylinder;
            ImpactVelocity = impactVelocity;
            ImpactAcceleration = impactAcceleration;
            ImpactHorsePower = impactHorsePower;
        }

        public Engine(int id, string name, string type, string cylinder, int level, double price, int impactVelocity, int impactAcceleration, int impactHorsePower)
        {
            Id = id;
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
