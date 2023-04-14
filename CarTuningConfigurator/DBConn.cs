using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace CarTuningConfigurator
{
    public class DBContext : DbContext
    {

        public DbSet<Break> Breaks { get; set; }
        public DbSet<Rims> Rims { get; set; }
        public DbSet<Tyres> Tyres { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Spoiler> Spoilers { get; set; }
        public DbSet<Nitro> Nitros { get; set; }
        public DbSet<Exhaust> Exhausts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=10.195.252.88;user id=root;password=CasparBlond1200?;database=cartc;", new MySqlServerVersion(new Version(8, 0, 32)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Break>().ToTable(nameof(Break).ToLower());
            modelBuilder.Entity<Rims>().ToTable(nameof(Rims).ToLower());
            modelBuilder.Entity<Tyres>().ToTable(nameof(Tyres).ToLower());
            modelBuilder.Entity<Engine>().ToTable(nameof(Engine).ToLower());
            modelBuilder.Entity<Spoiler>().ToTable(nameof(Spoiler).ToLower());
            modelBuilder.Entity<Car>().ToTable(nameof(Car).ToLower());
            modelBuilder.Entity<Nitro>().ToTable(nameof(Nitro).ToLower());
            modelBuilder.Entity<Exhaust>().ToTable(nameof(Exhaust).ToLower());
        }

        public DBContext()
        {
            
        }


        public MySqlConnection GetDefaultConnection()
        {
            string connectionString = $"server=10.195.252.88;user id=root;password=CasparBlond1200?;database=cartc;";
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
