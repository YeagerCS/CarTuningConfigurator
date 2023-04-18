using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Nitro : TuningItem
    {
        [Column("nitro_id")]
        public int? NitroId { get; set; }
        public int ImpactNitro { get; set; }

        public Nitro(int impactNitro) 
        {
            ImpactNitro = impactNitro;
        }

        public Nitro() { }
        public Nitro(int id, string name, int level, double price, int impactNitro)
        {
            NitroId = id;
            Name = name;
            Level = level;
            Price = price;
            ImpactNitro = impactNitro;
        }
    }
}
