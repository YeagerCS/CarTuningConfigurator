using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Car
    {
        public int Id { get; set; }
        public int TopSpeed { get; set; }
        public int BreakingForce { get; set; }
        public int Acceleration { get; set; }
        public int nitro { get; set; }
        public int Hp { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool TintedWindows { get; set; }
        public double Weight { get; set; }
        public Spoiler Spoiler { get; set; }
        public Rims Rims { get; set; }
        public Nitro Nitro { get; set; }
        public Engine Engine { get; set; }
        public Break Break { get; set; }
        public Exhaust Exhaust { get; set; }
        public Tyres Tyres { get; set; }
        public string Image { get; set; }

        public Car(int id, int topSpeed, int breakingForce, int acceleration, int nitro, int hp, string brand, string model, string color, bool tintedWindows, double weight, Spoiler spoiler, Rims rims, Nitro nitro, Engine engine, Break @break, Exhaust exhaust, Tyres tyres, string image)
        {
            Id = id;
            TopSpeed = topSpeed;
            BreakingForce = breakingForce;
            Acceleration = acceleration;
            Nitro = nitro;
            Hp = hp;
            Brand = brand;
            Model = model;
            Color = color;
            TintedWindows = tintedWindows;
            Weight = weight;
            Spoiler = spoiler;
            Rims = rims;
            Nitro = nitro;
            Engine = engine;
            Break = @break;
            Exhaust = exhaust;
            Tyres = tyres;
            Image = image;
        }
    }
}
