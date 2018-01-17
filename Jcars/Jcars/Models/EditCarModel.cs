using Jcars.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class EditCarModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Engine> Engines { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
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

        public EditCarModel()
        {

        }

        public EditCarModel(Car car, IEnumerable<Brand> brands, IEnumerable<Model> models
            , IEnumerable<Engine> engines, IEnumerable<Transmission> transmission)
        {
            CarID = car.CarID;
            BrandID = car.BrandID;
            ModelID = car.ModelID;
            Price = car.Price;
            Year = car.Year;
            Horsepower = car.Horsepower;
            EngineID = car.EngineID;
            TransmissionID = car.TransmissionID;
            Mileage = car.Mileage;
            AirConditioner = car.AirConditioner;
            GPS = car.GPS;
            ABS = car.ABS;
            ESP = car.ESP;
            Airbag = car.Airbag;
            TractionControl = car.TractionControl;
            Brands = brands;
            Models = models;
            Engines = engines;
            Transmissions = transmission;
        }
    }
}