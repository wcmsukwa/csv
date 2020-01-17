using System;
using System.ComponentModel.DataAnnotations;
using Model;

namespace Entity
{
    public class CityEntity : CityModel
    {
        [Key]
        public int CityID { get; set; }

        public virtual CountryEntity Country { get; set; }
    }
}
