using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Tyres : TuningItem
    {
        [Column("tyres_id")]
        public int? TyresId { get; set; }
        public string? Type { get; set; }
        public int ImpactBreakingForce { get; set; }
        public int ImpactAcceleration { get; set; }

        public Tyres(string type, int impactBreakingForce, int impactAcceleration)
        {
            Type = type;
            ImpactBreakingForce = impactBreakingForce;
            ImpactAcceleration = impactAcceleration;
        }

        public Tyres() { }

        public Tyres(int id, string name, int level, double price, string type, int impactBreakingForce, int impactAcceleration) 
        {
            TyresId = id;
            Name = name;
            Level = level;
            Price = price;
            Type = type;
            ImpactBreakingForce = impactBreakingForce;
            ImpactAcceleration = impactAcceleration;
        }
    }
}
