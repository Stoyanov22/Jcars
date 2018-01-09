﻿using Jcars.Business.Entities;
using Jcars.Business.Services.CarService;
using Jcars.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jcars.Controllers
{
    public class CarController : Controller
    {
        static JcarsDbContext db = new JcarsDbContext();
        CarService carService = new CarService(db);

        public CarController()
        {

        }
        public CarController(CarService carService)
        {
            this.carService = carService;
        }
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Create()
        {
            var engines = await carService.GetAllEnginesAsync();
            var transmissions = await carService.GetAllTransmissionsAsync();
            var brands = await carService.GetAllBrandsAsync();
            var models = await carService.GetAllModelsAsync();
            var result = new CreateCarViewModel(brands, models, engines, transmissions);
            return View(result);
        }

        // POST: Custom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Create(CreateCarModel createCarModel)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    UserName = User.Identity.GetUserId(),
                    BrandID = createCarModel.BrandID,
                    ModelID = createCarModel.ModelID,
                    Price = createCarModel.Price,
                    Year = createCarModel.Year,
                    Horsepower = createCarModel.Horsepower,
                    EngineID = createCarModel.EngineID,
                    TransmissionID = createCarModel.TransmissionID,
                    Mileage = createCarModel.Mileage
                };
                await carService.CreateCarAsync(car);

                return RedirectToAction("Index", "Car");
            }
            return RedirectToAction("Index");

            //return View(movie);
        }
    }
}