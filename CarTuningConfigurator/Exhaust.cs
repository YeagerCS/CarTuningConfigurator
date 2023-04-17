using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Exhaust : TuningItem
    {
        [Column("exhaust_id")]
        public int ExhaustId { get; set; }
        public int ImpactNitro { get; set; }

        public Exhaust(int impactNitro)
        {
            ImpactNitro = impactNitro;
        }

        public Exhaust(int id, string name, int level, double price, int impactNitro) 
        { 
            ExhaustId = id; 
            Name = name; 
            Level = level; 
            Price = price;
            ImpactNitro = impactNitro;
        }
    }
}
