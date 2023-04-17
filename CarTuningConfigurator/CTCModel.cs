using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace CarTuningConfigurator
{
    public class CTCModel
    {
        public List<Rims> Rims { get; set; }
        public List<Spoiler> Spoilers { get; set; }
        public List<Nitro> Nitros { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Break> Breaks { get; set; }
        public List<Exhaust> Exhausts { get; set; }
        public List<Tyres> Tyres { get; set; }
        public List<Car> Cars { get; set; }
        public List<Car> TunedCars { get; set; }
        public List<List<TuningItem>> TuningItems { get; set; }

        private MySqlConnection conn;


        public CTCModel() 
        {
            Rims = new List<Rims>();
            Spoilers = new List<Spoiler>();
            Nitros = new List<Nitro>();
            Engines = new List<Engine>();
            Breaks = new List<Break>();
            Exhausts = new List<Exhaust>();
            Tyres = new List<Tyres>();
            Cars = new List<Car>();
            TunedCars = new List<Car>();
            TuningItems = new List<List<TuningItem>>();
            conn = new DBContext().GetDefaultConnection();

            ReadDatabase();

        }

        public CTCModel(bool config)
        {
            Rims = new List<Rims>();
            Spoilers = new List<Spoiler>();
            Nitros = new List<Nitro>();
            Engines = new List<Engine>();
            Breaks = new List<Break>();
            Exhausts = new List<Exhaust>();
            Tyres = new List<Tyres>();
            Cars = new List<Car>();
            TunedCars = new List<Car>();
            TuningItems = new List<List<TuningItem>>();
            conn = new DBContext().GetDefaultConnection();

            ReadTunedCars();

        }

        public void UpdateDatabase(Car car)
        {
            using (var context = new DBContext())
            {
                Car? existingCar = context.Cars.Find(car.Id);

                existingCar.TopSpeed = car.TopSpeed;
                existingCar.BreakingForce = car.BreakingForce;
                existingCar.Acceleration = car.Acceleration;
                existingCar.nitroPower = car.nitroPower;
                existingCar.Hp = car.Hp;
                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.Color = car.Color;
                existingCar.TintedWindows = car.TintedWindows;
                existingCar.Weight = car.Weight;
                existingCar.Image = car.Image;
                existingCar.Price = car.Price;
                existingCar.Spoiler = car.Spoiler;
                existingCar.Rims = car.Rims;
                existingCar.Nitro = car.Nitro;
                existingCar.Engine = car.Engine;
                existingCar.Break = car.Break;
                existingCar.Exhaust = car.Exhaust;
                existingCar.Tyres = car.Tyres;

                context.SaveChanges();
            }
        }

        public void SaveToDatabase(Car car)
        {
            using (var context = new DBContext())
            {
                var newCar = new Car
                {
                    TopSpeed = car.TopSpeed,
                    BreakingForce = car.BreakingForce,
                    Acceleration = car.Acceleration,
                    nitroPower = car.nitroPower,
                    Hp = car.Hp,
                    Brand = car.Brand,
                    Model = car.Model,
                    Color = car.Color,
                    TintedWindows = car.TintedWindows,
                    Weight = car.Weight,
                    Image = car.Image,
                    Price = car.Price,
                    Spoiler = car.Spoiler,
                    Rims = car.Rims,
                    Nitro = car.Nitro,
                    Engine = car.Engine,
                    Break = car.Break,
                    Exhaust = car.Exhaust,
                    Tyres = car.Tyres
                };


                context.Cars.Attach(newCar);
                context.Entry(newCar).State = EntityState.Added;
                context.SaveChanges();
            }
        }


        public Car GetDefaultCarModel(string brand)
        {

            List<Car> defCars = new List<Car>();
            using(var context = new DBContext())
            {
                defCars = context.Cars.Include("Break").Include("Exhaust").Include("Spoiler").Include("Tyres").Include("Rims").Include("Nitro").Include("Engine")
                    .Where(x => x.isDefaultCar == 1).Where(y => y.Brand == brand).ToList(); 
            }

            return defCars[0];   
        }



        public void ReadDatabase()
        {
            //Read 
            using (var context = new DBContext())
            {
                Rims = context.Rims.ToList();
                Spoilers = context.Spoilers.ToList();
                Nitros = context.Nitros.ToList();
                Engines = context.Engines.ToList();
                Exhausts = context.Exhausts.ToList();
                Tyres = context.Tyres.ToList();
                Breaks = context.Breaks.ToList();
                Cars = context.Cars.Include("Break").Include("Exhaust").Include("Spoiler").Include("Tyres").Include("Rims").Include("Nitro").Include("Engine")
                    .Where(x => x.isDefaultCar == 1).ToList();
            }
        }

        public void ReadTunedCars()
        {
            using (var context = new DBContext())
            {
                Rims = context.Rims.ToList();
                Spoilers = context.Spoilers.ToList();
                Nitros = context.Nitros.ToList();
                Engines = context.Engines.ToList();
                Exhausts = context.Exhausts.ToList();
                Tyres = context.Tyres.ToList();
                Breaks = context.Breaks.ToList();
                Cars = context.Cars.Include("Break").Include("Exhaust").Include("Spoiler").Include("Tyres").Include("Rims").Include("Nitro").Include("Engine")
                    .Where(x => x.isDefaultCar == 0).ToList();
            }
        }

        public CTCModel(List<Rims> rims, List<Spoiler> spoilers, List<Nitro> nitros, List<Engine> engines, List<Break> breaks, List<Exhaust> exhaust, List<Tyres> tyres, List<Car> cars, List<Car> tunedCars, List<List<TuningItem>> tuningItems, MySqlConnection conn)
        {
            Rims = rims;
            Spoilers = spoilers;
            Nitros = nitros;
            Engines = engines;
            Breaks = breaks;
            Exhausts = exhaust;
            Tyres = tyres;
            Cars = cars;
            TunedCars = tunedCars;
            TuningItems = tuningItems;
            this.conn = conn;
        }

        public void AddRims(Rims rims)
        {
            Rims.Add(rims);
        }

        public void AddSpoiler(Spoiler spoiler)
        {
            Spoilers.Add(spoiler);
        }

        public void AddNitro(Nitro nitro) 
        {
            Nitros.Add(nitro);
        }

        public void AddEngine(Engine engine) 
        {
            Engines.Add(engine);
        }

        public void AddCar(Car car) 
        {
            Cars.Add(car);
        }

        public void AddTyres(Tyres tyres)
        {
            Tyres.Add(tyres);
        }

        public void AddBreak(Break @break)
        {
            Breaks.Add(@break);
        }

        public void AddExhaust(Exhaust exhaust)
        {
            Exhausts.Add(exhaust);
        }

        public void AddTuningItems(List<TuningItem> tuningItems)
        {
            TuningItems.Add(tuningItems);
        }

        //----------------------------------------------------------------------

        public void RemoveRims(int index)
        {
            Rims.RemoveAt(index);
        }

        public void RemoveSpoiler(int index)
        {
            Spoilers.RemoveAt(index);
        }

        public void RemoveNitro(int index)
        {
            Nitros.RemoveAt(index);
        }

        public void RemoveEngine(int index)
        {
            Engines.RemoveAt(index);
        }

        public void RemoveCar(int index)
        {
            Cars.RemoveAt(index);
        }

        public void RemoveTyres(int index)
        {
            Tyres.RemoveAt(index);
        }

        public void RemoveBreak(int index)
        {
            Breaks.RemoveAt(index);
        }

        public void RemoveExhaust(int index)
        {
            Exhausts.RemoveAt(index);
        }

        public void RemoveTuningItems(int index)
        {
            TuningItems.RemoveAt(index);
        }

        //----------------------------------------------------------------------

        public void UpdateRims(int index, Rims rims)
        {
            Rims.Insert(index, rims);
        }

        public void UpdateSpoiler(int index, Spoiler spoiler)
        {
            Spoilers.Insert(index, spoiler);
        }

        public void UpdateNitro(int index, Nitro nitro)
        {
            Nitros.Insert(index, nitro);
        }

        public void UpdateEngine(int index, Engine engine)
        {
            Engines.Insert(index, engine);
        }

        public void UpdateCar(int index, Car car)
        {
            Cars.Insert(index, car);
        }

        public void UpdateTyres(int index, Tyres tyres)
        {
            Tyres.Insert(index, tyres);
        }

        public void UpdateBreak(int index, Break @break)
        {
            Breaks.Insert(index, @break);
        }

        public void UpdateExhaust(int index, Exhaust exhaust)
        {
            Exhausts.Insert(index, exhaust);
        }

        public void UpdateTuningItems(int index, List<TuningItem> tuningItems)
        {
            TuningItems.Insert(index, tuningItems);
        }
    }

    
}
