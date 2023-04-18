using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Rims : TuningItem
    {
        [Column("Rims_id")]
        public int? RimsId { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }

        public Rims(string Type, string Color)
        {
            this.Type = Type;
            this.Color = Color;
        }

        public Rims() { }
        public Rims(int id, string name, int level, double price, string type, string color) 
        {
            RimsId = id;
            Name = name;
            Level = level;
            Price = price;
            Type = type;
            Color = color;
        }


    }
}
