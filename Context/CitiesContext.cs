using System;
using System.Data.Entity;
using Entity;

namespace Context
{
    public class CitiesContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
    }
}
