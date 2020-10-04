using Microsoft.EntityFrameworkCore;
using Rovers.Entity;
using Rovers.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rovers.Dal.Concreate
{
    public class RoversContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TANJUAVSAR;Database=RoversDB;Trusted_Connection=true;");
        }
        //public DbSet<Tablo olamasını istediğim class> Tablonun Adı 
        public DbSet<RoversEntity> Rovers { get; set; }
    }
}
