using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarTuningConfigurator
{
    public class CTCModel
    {
        public List<Rims> Rims { get; set; }
        public List<Spoiler> Spoilers { get; set; }
        public List<Nitro> Nitros { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Break> Breaks { get; set; }
        public List<Exhaust> Exhaust { get; set; }
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
            Exhaust = new List<Exhaust>();
            Tyres = new List<Tyres>();
            Cars = new List<Car>();
            CarStats = new List<int>();
            TuningItems = new List<List<TuningItem>>();

            conn = new DBConn().GetDefaultConnection();
        }

    }
}
