using Jcars.Business.Entities;
using Jcars.Business.Services.CarService;
using Jcars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jcars.Controllers
{
    public class HomeController : Controller
    {
        private ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }
        public async Task<ActionResult> Index(SearchCarModel searchCarModel = null, int pageNum = 1, int pageSize = 10)
        {
            var seachResult = new SearchResult(searchCarModel.BrandID, searchCarModel.ModelID, searchCarModel.EngineID
                , searchCarModel.TransmissionID, searchCarModel.MinPrice, searchCarModel.MaxPrice, searchCarModel.MinYear
                , searchCarModel.MaxYear, searchCarModel.MinHorsepower, searchCarModel.MaxHorsepower, searchCarModel.MinMileage
                , searchCarModel.MaxMileage, searchCarModel.AirConditioner, searchCarModel.GPS, searchCarModel.ABS
                , searchCarModel.ESP, searchCarModel.Airbag, searchCarModel.TractionControl);

            if (pageSize > 100 || pageSize < 1)
            {
                pageSize = 5;
            }

            Tuple<IEnumerable<Car>, int> cars = (searchCarModel.PageNumber != 0)?
                await carService.GetPaginatedSearchedCarsAsync(seachResult, searchCarModel.PageNumber, pageSize):
                await carService.GetPaginatedSearchedCarsAsync(seachResult, pageNum, pageSize);
            if (pageNum > cars.Item2)
            {
                return RedirectToAction("Index");
            }
            var result = new SearchCarModel(cars.Item1, cars.Item2, pageSize, pageNum, await carService.GetAllBrandsAsync(), await carService.GetAllModelsAsync()
                , await carService.GetAllEnginesAsync(), await carService.GetAllTransmissionsAsync(), searchCarModel.BrandID, searchCarModel.ModelID, searchCarModel.EngineID
                , searchCarModel.TransmissionID, searchCarModel.MinPrice, searchCarModel.MaxPrice, searchCarModel.MinYear
                , searchCarModel.MaxYear, searchCarModel.MinHorsepower, searchCarModel.MaxHorsepower, searchCarModel.MinMileage
                , searchCarModel.MaxMileage, searchCarModel.AirConditioner, searchCarModel.GPS, searchCarModel.ABS
                , searchCarModel.ESP, searchCarModel.Airbag, searchCarModel.TractionControl);
            return View(result);
        }
        
    }
}