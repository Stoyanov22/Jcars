using Jcars.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class CreateCarViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Engine> Engines { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }

        public CreateCarViewModel(IEnumerable<Brand> brands, IEnumerable<Model> models
            , IEnumerable<Engine> engines, IEnumerable<Transmission> transmission)
        {
            Brands = brands;
            Models = models;
            Engines = engines;
            Transmissions = transmission;
        }
    }
}