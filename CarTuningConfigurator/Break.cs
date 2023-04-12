using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Break : TuningItem
    {
        public int ImpactBreakingForce { get; set; }

        public Break(int impactBreakingForce)
        {
            ImpactBreakingForce = impactBreakingForce;
        }
    }
}
