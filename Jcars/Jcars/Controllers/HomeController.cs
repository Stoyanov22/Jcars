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
        public async Task<ActionResult> Index()
        {
            return View(new SearchCarModel(await carService.GetAllBrandsAsync(), await carService.GetAllModelsAsync(), await carService.GetAllEnginesAsync(), await carService.GetAllTransmissionsAsync()));
        }

     
    }
}