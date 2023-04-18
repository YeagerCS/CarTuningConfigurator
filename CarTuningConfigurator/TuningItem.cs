using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class TuningItem
    {
        public string? Name {  get; set; }
        public int? Level {  get; set; }
        public double Price {  get; set; }

        public TuningItem(string? name, int level, double price)
        {
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
