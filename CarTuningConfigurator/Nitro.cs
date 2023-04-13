using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Nitro : TuningItem
    {
        public int ImpactNitro { get; set; }

        public Nitro(int impactNitro) 
        {
            ImpactNitro = impactNitro;
        }

        public Nitro(int id, string name, int level, double price, int impactNitro)
        {
            Id = id;
            Name = name;
            Level = level;
            Price = price;
            ImpactNitro = impactNitro;
        }
    }
}
