using Jcars.Business.Entities;
using Jcars.Business.Services.CarService;
using Jcars.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jcars.Controllers
{
    public class CarController : Controller
    {
        ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        // GET: Car
        public async Task<ActionResult> Index(int pageNum = 1, int pageSize = 5)
        {
            if (pageSize > 100 || pageSize < 1)
            {
                pageSize = 5;
            }
            Tuple<IEnumerable<Car>, int> cars = await carService.GetPaginatedCarsAsync(pageNum, pageSize);
            if (pageNum > cars.Item2)
            {
                return RedirectToAction("Index");
            }
            var result = new PaginatedCarsListModel(cars.Item1, cars.Item2, pageSize, pageNum);
            return View(result);
        }

        [HttpGet]
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
                    UserID = User.Identity.GetUserId(),
                    BrandID = createCarModel.BrandID,
                    ModelID = createCarModel.ModelID,
                    Price = createCarModel.Price,
                    Year = createCarModel.Year,
                    Horsepower = createCarModel.Horsepower,
                    EngineID = createCarModel.EngineID,
                    TransmissionID = createCarModel.TransmissionID,
                    Mileage = createCarModel.Mileage,
                    AirConditioner = createCarModel.AirConditioner,
                    GPS = createCarModel.GPS,
                    ABS = createCarModel.ABS,
                    ESP = createCarModel.ESP,
                    Airbag = createCarModel.Airbag,
                    TractionControl = createCarModel.TractionControl
                };

                await carService.CreateCarAsync(car);

                byte[] fileData = null;

                for (int i = 1; i <= Request.Files.Count; i++)
                {
                    using (var binaryReader = new BinaryReader(Request.Files["photo" + i].InputStream))
                    {
                        if (Request.Files["photo" + i].ContentLength == 0)
                        {
                            continue;
                        }

                        fileData = binaryReader.ReadBytes(Request.Files["photo" + i].ContentLength);
                    }

                    await carService.CreateFileAsync(new Business.Entities.File { Car = car, Content = fileData });
                }

                return RedirectToAction("Index", "Car");
            }
            return RedirectToAction("Index");

            //return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> MyCars()
        {
            var result = await carService.GetMyCarsAsync();
            return View(result);
        }

        // GET: CarDetails
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Details(int id)
        {
            var result = await carService.GetCarAsync(id);
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Edit(int id)
        {
            var car = await carService.GetCarAsync(id);

            if (car.UserID != User.Identity.GetUserId())
            {
                return RedirectToAction("MyCars");//error
            }

            var engines = await carService.GetAllEnginesAsync();
            var transmissions = await carService.GetAllTransmissionsAsync();
            var brands = await carService.GetAllBrandsAsync();
            var models = await carService.GetAllModelsAsync();
            var result = new EditCarModel(car, brands, models, engines, transmissions);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Edit(EditCarModel editCarModel)
        {
            if (ModelState.IsValid)
            {
                var newCar = new Car
                {
                    CarID = editCarModel.CarID,
                    ABS = editCarModel.ABS,
                    Airbag = editCarModel.Airbag,
                    AirConditioner = editCarModel.AirConditioner,
                    BrandID = editCarModel.BrandID,
                    EngineID = editCarModel.EngineID,
                    ESP = editCarModel.ESP,
                    GPS = editCarModel.GPS,
                    Horsepower = editCarModel.Horsepower,
                    Mileage = editCarModel.Mileage,
                    ModelID = editCarModel.ModelID,
                    Price = editCarModel.Price,
                    TractionControl = editCarModel.TractionControl,
                    TransmissionID = editCarModel.TransmissionID,
                    Year = editCarModel.Year,
                };
                await carService.EditCarAsync(newCar);

                return RedirectToAction("Details", "Car", new { id = editCarModel.CarID });
            }
            return RedirectToAction("Details", new { id = editCarModel.CarID });
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task Delete(int id)
        {
            var car = await carService.GetCarAsync(id);
            if (car.UserID != User.Identity.GetUserId())
            {
                RedirectToAction("MyCars");//On Error
            }

            await carService.DeleteCarAsync(id);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Images(int id)
        {
            var car = await carService.GetCarAsync(id);
            if (car.UserID != User.Identity.GetUserId())
            {
                RedirectToAction("MyCars");//On Error
            }
            var files = car.Files;
            var result = new EditImagesModel(car.CarID, files);
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> UploadImage(int id)
        {
            var car = await carService.GetCarAsync(id);
            if (car.UserID != User.Identity.GetUserId())
            {
                RedirectToAction("MyCars");//On Error
            }
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(Request.Files["photo"].InputStream))
            {
                if (Request.Files["photo"].ContentLength != 0)
                {
                    fileData = binaryReader.ReadBytes(Request.Files["photo"].ContentLength);
                    await carService.CreateFileAsync(new Business.Entities.File { CarID = id, Content = fileData });
                }
            }
            return RedirectToAction("Images", new { id = id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task DeleteImage(int id, int carID)
        {
            var car = await carService.GetCarAsync(carID);
            if (car.UserID != User.Identity.GetUserId())
            {
                RedirectToAction("MyCars");//On Error
            }
            else if (!car.Files.Select(f => f.FileID).Contains(id))
            {
                RedirectToAction("MyCars");//On Error
            }
            else
            {
                await carService.DeleteFileAsync(id);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Search(SearchCarModel searchCarModel = null, int pageNum = 1, int pageSize = 10)
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
            Tuple<IEnumerable<Car>, int> cars = await carService.GetPaginatedSearchedCarsAsync(seachResult, pageNum, pageSize);
            if (pageNum > cars.Item2)
            {
                return RedirectToAction("Index");
            }
            var result = new PaginatedCarsListModel(cars.Item1, cars.Item2, pageSize, pageNum);
            return View(result);
        }
    }
}