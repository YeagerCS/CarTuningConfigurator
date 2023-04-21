using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningConfigurator
{
    public class Car : ICloneable
    {
        public int Id { get; set; }
        public int TopSpeed { get; set; }
        public int BreakingForce { get; set; }
        public double Acceleration { get; set; }
        [Column("nitro")]
        public int nitroPower { get; set; }
        public int Hp { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool TintedWindows { get; set; }
        public int Weight { get; set; }
        public Spoiler? Spoiler { get; set; }
        public Rims? Rims { get; set; }
        public Nitro? Nitro { get; set; }
        public Engine? Engine { get; set; }
        public Break? Break { get; set; }
        public Exhaust? Exhaust { get; set; }
        public Tyres? Tyres { get; set; }
        [Column("Spoiler_id")]
        public int? SpoilerId { get; set; }
        [Column("Rims_id")]
        public int? RimsId { get; set; }
        [Column("Nitro_id")]
        public int? NitroId { get; set; }
        [Column("Engine_id")]
        public int? EngineId { get; set; }
        [Column("Break_id")]
        public int? BreakId { get; set; }
        [Column("Exhaust_id")]
        public int? ExhaustId { get; set; }
        [Column("Tyres_id")]
        public int? TyresId { get; set; }

        public double Price { get; set; }
        [Column("path")]
        public string Image { get; set; }
        public int isDefaultCar { get; set; }

        public Car(int id, int breakingForce, int topSpeed, double acceleration, int nitroPower, int hp, string brand, string model, string color, bool tintedWindows, int weight, Spoiler? spoiler, Rims? rims, Nitro? Nitro, Engine? engine, Break? @break, Exhaust? exhaust, Tyres? tyres, string image)
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

            SpoilerId = Spoiler.SpoilerId;
            RimsId = Rims.RimsId;
            NitroId = Nitro.NitroId;
            EngineId = Engine.EngineId;
            BreakId = Break.BreakId;
            ExhaustId = Exhaust.ExhaustId;
            TyresId = Tyres.TyresId;


        }

        public Car(int id, int breakingForce, int topSpeed, double acceleration, int nitroPower, int hp, string brand, string model, string color, bool tintedWindows, int weight, string image, double price)
        {
            Id = id;
            TopSpeed = topSpeed;
            Acceleration = acceleration;
            BreakingForce = breakingForce;
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
