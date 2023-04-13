using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class TuningItem
    {
        public int Id {  get; set; }
        public string? Name {  get; set; }
        public int Level {  get; set; }
        public double Price {  get; set; }

        public TuningItem(int id, string? name, int level, double price)
        {
            Id = id;
            Name = name;
            Level = level;
            Price = price;
        }

        public TuningItem() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
