using CsvToSqlTest.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlTest.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            Console.WriteLine();
        }


        public DbSet<Ride> Rides { get; set; }
        public AppDbContext() { }
    }
}
