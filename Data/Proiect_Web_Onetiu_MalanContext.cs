using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Web_Onetiu_Malan.Models;

namespace Proiect_Web_Onetiu_Malan.Data
{
    public class Proiect_Web_Onetiu_MalanContext : DbContext
    {
        public Proiect_Web_Onetiu_MalanContext (DbContextOptions<Proiect_Web_Onetiu_MalanContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Web_Onetiu_Malan.Models.Destination> Destination { get; set; } = default!;

        public DbSet<Proiect_Web_Onetiu_Malan.Models.City> City { get; set; }

        public DbSet<Proiect_Web_Onetiu_Malan.Models.Category> Category { get; set; }

        public DbSet<Proiect_Web_Onetiu_Malan.Models.Country> Country { get; set; }

        public DbSet<Proiect_Web_Onetiu_Malan.Models.Client> Client { get; set; }

        public DbSet<Proiect_Web_Onetiu_Malan.Models.Reservation> Reservation { get; set; }
    }
}
