﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Break(int id, string name, int level, double price, int impactBreakingForce)
        {
            Id = id;
            Name = name;
            Level = level;
            Price = price;
            ImpactBreakingForce = impactBreakingForce;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
