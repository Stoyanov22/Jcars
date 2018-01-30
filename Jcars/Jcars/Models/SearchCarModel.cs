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
    }
}