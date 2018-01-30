using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class SearchResult
    {
        public int? BrandID { get; set; }
        public int? ModelID { get; set; }
        public int? EngineID { get; set; }
        public int? TransmissionID { get; set; }
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

        public SearchResult(int? brandID, int? modelID, int? engineID, int? transmissionID
            , int? minPrice, int? maxPrice, int? minYear, int? maxYear, int? minHorsepower
            , int? maxHorsepower, int? minMileage, int? maxMileage, bool airConditioner
            , bool gps, bool abs, bool esp, bool airbag, bool tractionControl)
        {
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
