using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Spoiler : TuningItem
    {
        [Column("spoiler_id")]
        public int SpoilerId { get; set; }
        public string Type { get; set; }
        public int ImpactVelocity { get; set; }

        public Spoiler(string type, int impactVelocity)
        {
            Type = type;
            ImpactVelocity = impactVelocity;
        }

        public Spoiler(int id, string type, string name, int level, double price, int impactVelocity) 
        {
            SpoilerId = id;
            Type = type;
            Name = name;
            Level = level;
            Price = price;
            ImpactVelocity = impactVelocity;
        }
    }
}
