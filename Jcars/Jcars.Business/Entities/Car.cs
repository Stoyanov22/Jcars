using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int ModelID { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Horsepower { get; set; }
        public int EngineID { get; set; }
        public int TransmissionID { get; set; }
        public int Mileage { get; set; }
        public bool AirConditioner { get; set; }
        public bool GPS { get; set; }
        public bool ABS { get; set; }
        public bool ESP { get; set; }
        public bool Airbag { get; set; }
        public bool TractionControl { get; set; }
        public string UserID { get; set; }
        public virtual IEnumerable<File> Files { get; set; }
        public virtual Brand Brand {get; set;}
        //public virtual Model Model {get; set;}
        public virtual Engine Engine { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual User User{ get; set; }
    }
}
