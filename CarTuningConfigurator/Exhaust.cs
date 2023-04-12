using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Exhaust : TuningItem
    {
        public int ImpactNitro { get; set; }

        public Exhaust(int impactNitro)
        {
            ImpactNitro = impactNitro;
        }
    }
}
