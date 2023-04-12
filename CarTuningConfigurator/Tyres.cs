﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Tyres : TuningItem
    {
        public string Type { get; set; }
        public int ImpactBreakingForce { get; set; }
        public int ImpactAcceleration { get; set; }

        public Tyres(string type, int impactBreakingForce, int impactAcceleration)
        {
            Type = type;
            ImpactBreakingForce = impactBreakingForce;
            ImpactAcceleration = impactAcceleration;
        }
    }
}