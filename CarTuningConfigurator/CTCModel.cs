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
        public List<int> CarStats { get; set; }
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
            CarStats = new List<int>();
            TuningItems = new List<List<TuningItem>>();
            conn = new DBContext().GetDefaultConnection();

            ReadDatabase();

        }


        public Car GetDefaultCarModel(string brand)
        {

            List<Car> defCars = new List<Car>();
            string query = $"SELECT * FROM car WHERE brand = '{brand}' and isDefaultCar = 1";
            using (MySqlCommand command = new MySqlCommand(query, conn))

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Car car = new Car(
                        id: reader.GetInt32("id"),
                        topSpeed: reader.GetInt32("topSpeed"),
                        breakingForce: reader.GetInt32("breakingForce"),
                        acceleration: reader.GetInt32("acceleration"),
                        nitroPower: reader.GetInt32("nitro"),
                        hp: reader.GetInt32("hp"),
                        brand: reader.GetString("brand"),
                        model: reader.GetString("model"),
                        color: reader.GetString("color"),
                        tintedWindows: reader.GetBoolean("tintedWindows"),
                        weight: reader.GetDouble("weight"),
                        image: reader.GetString("path"),
                        price: reader.GetDouble("price")
                    );

                    defCars.Add(car);
                }
            }

            return defCars[0];   
        }



        public void ReadDatabase()
        {

            //string query = "SELECT * FROM car WHERE isDefaultCar = 1";
            //using (MySqlCommand command = new MySqlCommand(query, conn))

            //using (MySqlDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        Car car = new Car(
            //            id: reader.GetInt32("id"),
            //            topSpeed: reader.GetInt32("topSpeed"),
            //            breakingForce: reader.GetInt32("breakingForce"),
            //            acceleration: reader.GetInt32("acceleration"),
            //            nitroPower: reader.GetInt32("nitro"),
            //            hp: reader.GetInt32("hp"),
            //            brand: reader.GetString("brand"),
            //            model: reader.GetString("model"),
            //            color: reader.GetString("color"),
            //            tintedWindows: reader.GetBoolean("tintedWindows"),
            //            weight: reader.GetDouble("weight"),
            //            image: reader.GetString("path"),
            //            price: reader.GetDouble("price")
            //        );

            //        AddCar(car);
            //    }
            //}

            //Break 
            using (var context = new DBContext())
            {
                Rims = context.Rims.ToList();
                Spoilers = context.Spoilers.ToList();
                Nitros = context.Nitros.ToList();
                Engines = context.Engines.ToList();
                Exhausts = context.Exhausts.ToList();
                Tyres = context.Tyres.ToList();
                Breaks = context.Breaks.ToList();
                Cars = context.Cars.Include("Break").Include("Exhaust").Include("Spoiler").Include("Tyres").Include("Rims").Include("Nitro").Include("Engine").ToList(); ;
            }
        }

        public CTCModel(List<Rims> rims, List<Spoiler> spoilers, List<Nitro> nitros, List<Engine> engines, List<Break> breaks, List<Exhaust> exhaust, List<Tyres> tyres, List<Car> cars, List<int> carStats, List<List<TuningItem>> tuningItems, MySqlConnection conn)
        {
            Rims = rims;
            Spoilers = spoilers;
            Nitros = nitros;
            Engines = engines;
            Breaks = breaks;
            Exhausts = exhaust;
            Tyres = tyres;
            Cars = cars;
            CarStats = carStats;
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
