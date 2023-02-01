using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ExamenProAlberto.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenProAlberto.Data
{
    

    public class DataContext : DbContext
    {
        public DbSet<AV_Rootobject> AV_Rootobjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");
        }
    }

}
