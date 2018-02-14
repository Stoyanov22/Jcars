using Jcars.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class SearchCarModel
    {
        public List<Car> Cars { get; set; }
        public int Pages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Engine> Engines { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
        public int? BrandID { get; set; }
        public int? ModelID { get; set; }
        public int? EngineID { get; set; }
        public int? TransmissionID { get; set; }

        [Display(Prompt = "Numbers Only")]
        public int? MinPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MinHorsepower { get; set; }
        public int? MinMileage { get; set; }
        public int? MaxPrice { get; set; }
        public int? MaxYear { get; set; }
        public int? MaxHorsepower { get; set; }
        public int? MaxMileage { get; set; }
        public bool AirConditioner { get; set; }
        public bool GPS { get; set; }
        public bool ABS { get; set; }
        public bool ESP { get; set; }
        public bool Airbag { get; set; }
        public bool TractionControl { get; set; }

        public SearchCarModel()
        {

        }

        public SearchCarModel(IEnumerable<Brand> brands, IEnumerable<Model> models
            , IEnumerable<Engine> engines, IEnumerable<Transmission> transmission)
        {
            Brands = brands;
            Models = models;
            Engines = engines;
            Transmissions = transmission;
        }

        public SearchCarModel(IEnumerable<Car> cars, int pages, int pageSize, int pageNumber)
        {
            Cars = cars.ToList();
            Pages = pages;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public SearchCarModel(IEnumerable<Car> cars, int pages, int pageSize, int pageNumber
            , IEnumerable<Brand> brands, IEnumerable<Model> models
            , IEnumerable<Engine> engines, IEnumerable<Transmission> transmission
            , int? brandID, int? modelID, int? engineID, int? transmissionID
            , int? minPrice, int? maxPrice, int? minYear, int? maxYear, int? minHorsepower
            , int? maxHorsepower, int? minMileage, int? maxMileage, bool airConditioner
            , bool gps, bool abs, bool esp, bool airbag, bool tractionControl)
        {
            Cars = cars.ToList();
            Pages = pages;
            PageSize = pageSize;
            PageNumber = pageNumber;
            Brands = brands;
            Models = models;
            Engines = engines;
            Transmissions = transmission;
            BrandID = brandID;
            ModelID = modelID;
            EngineID = engineID;
            TransmissionID = transmissionID;
            MinPrice = minPrice;
            MinYear = minYear;
            MinHorsepower = minHorsepower;
            MinMileage = minMileage;
            MaxPrice = maxPrice;
            MaxYear = maxYear;
            MaxHorsepower = maxHorsepower;
            MaxMileage = maxMileage;
            AirConditioner = airConditioner;
            GPS = gps;
            ABS = abs;
            ESP = esp;
            Airbag = airbag;
            TractionControl = tractionControl;
        }
    }
}