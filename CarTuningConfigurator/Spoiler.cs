using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Spoiler : TuningItem
    {
        public string Type { get; set; }
        public int ImpactVelocity { get; set; }

        public Spoiler(string type, int impactVelocity)
        {
            Type = type;
            ImpactVelocity = impactVelocity;
        }

        public Spoiler(int id, string type, string name, int level, double price, int impactVelocity) 
        {
            Id = id;
            Type = type;
            Name = name;
            Level = level;
            Price = price;
            ImpactVelocity = impactVelocity;
        }
    }
}
