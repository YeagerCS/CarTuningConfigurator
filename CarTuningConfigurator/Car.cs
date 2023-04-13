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
        public int nitroPower { get; set; }
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
        public double Price { get; set; }
        public string Image { get; set; }

        public Car(int id, int topSpeed, int breakingForce, int acceleration, int nitroPower, int hp, string brand, string model, string color, bool tintedWindows, double weight, Spoiler spoiler, Rims rims, Nitro Nitro, Engine engine, Break @break, Exhaust exhaust, Tyres tyres, string image)
        {
            Id = id;
            TopSpeed = topSpeed;
            BreakingForce = breakingForce;
            Acceleration = acceleration;
            this.Nitro = Nitro;
            Hp = hp;
            Brand = brand;
            Model = model;
            Color = color;
            TintedWindows = tintedWindows;
            Weight = weight;
            Spoiler = spoiler;
            Rims = rims;
            this.nitroPower = nitroPower;
            Engine = engine;
            Break = @break;
            Exhaust = exhaust;
            Tyres = tyres;
            Image = image;
        }

        public Car(int id, int topSpeed, int breakingForce, int acceleration, int nitroPower, int hp, string brand, string model, string color, bool tintedWindows, double weight, string image, double price)
        {
            Id = id;
            TopSpeed = topSpeed;
            BreakingForce = breakingForce;
            Acceleration = acceleration;
            this.nitroPower = nitroPower;
            Hp = hp;
            Brand = brand;
            Model = model;
            Color = color;
            TintedWindows = tintedWindows;
            Weight = weight;
            Image = image;
            Price = price;
        }

        public Car()
        {

        }
    }
}
