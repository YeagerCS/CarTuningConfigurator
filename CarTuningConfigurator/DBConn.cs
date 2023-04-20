using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Org.BouncyCastle.Utilities.Net;

namespace CarTuningConfigurator
{
    public class DBContext : DbContext
    {
        public IniFile DataBaseConfiguration;

        public DbSet<Break?> Breaks { get; set; }
        public DbSet<Rims?> Rims { get; set; }
        public DbSet<Tyres?> Tyres { get; set; }
        public DbSet<Engine?> Engines { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Spoiler?> Spoilers { get; set; }
        public DbSet<Nitro?> Nitros { get; set; }
        public DbSet<Exhaust?> Exhausts { get; set; }
        private string IPAddress;
        private string password;
        private string user;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server={IPAddress};user id={user};password={password};database=cartc;", new MySqlServerVersion(new Version(8, 0, 32)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Break?>().ToTable(nameof(Break).ToLower());
            modelBuilder.Entity<Rims?>().ToTable(nameof(Rims).ToLower());
            modelBuilder.Entity<Tyres?>().ToTable(nameof(Tyres).ToLower());
            modelBuilder.Entity<Engine?>().ToTable(nameof(Engine).ToLower());
            modelBuilder.Entity<Spoiler?>().ToTable(nameof(Spoiler).ToLower());
            modelBuilder.Entity<Car>().ToTable(nameof(Car).ToLower());
            modelBuilder.Entity<Nitro?>().ToTable(nameof(Nitro).ToLower());
            modelBuilder.Entity<Exhaust?>().ToTable(nameof(Exhaust).ToLower());
        }

        public DBContext()
        {
            DataBaseConfiguration = new IniFile("config.ini");
            try
            {
                IPAddress = DataBaseConfiguration.ReadSection("IP_Address");
                password = DataBaseConfiguration.ReadSection("Password");
                user = DataBaseConfiguration.ReadSection("User");
            } catch(ArgumentNullException ex)
            {
                ex.GetBaseException();
            }
        }


        public MySqlConnection GetDefaultConnection()
        {
            string connectionString = $"server={IPAddress};user id={user};password={password};database=cartc;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conn;
        }

        

    }
}
