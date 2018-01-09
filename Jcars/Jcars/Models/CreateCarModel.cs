using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class CreateCarModel
    {
        public int BrandID { get; set; }
        public int ModelID { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public int EngineID { get; set; }
        public int TransmissionID { get; set; }
        public int Mileage { get; set; }
    }
}