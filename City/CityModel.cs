using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Cities
{
    public class CityModelImport

    {
        public string City_name { get; set; }
        public string City_ascii { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Country { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public string Admin_name { get; set; }
        public string Capital { get; set; }
        public double Population { get; set; }
        public float Id { get; set; }
    }

    public class CountryModel
    {
        public string Name { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
    }

    public class CountryEntity : CountryModel
    {
        [Key]
        public int CountryID { get; set; }

        public virtual List<CityEntity> Cities { get; set; }
    }

    public class CityModel
    {
        public string City_name { get; set; }
        public string City_ascii { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Admin_name { get; set; }
        public string Capital { get; set; }
        public double Population { get; set; }
        public int CountryId { get; set; }
    }

    public class CityEntity : CityModel
    {
        [Key]
        public int CityID { get; set; }

        public virtual CountryEntity Country { get; set; }
    }

    public class CitiesContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
    }
}