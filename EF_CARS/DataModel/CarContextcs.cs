using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainClasses;


namespace DataModel
{
    public class CarContextcs : DbContext
    {
        public CarContextcs() : base("CarDbConnectionString") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }

    }
}
