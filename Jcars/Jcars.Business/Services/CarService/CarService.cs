using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jcars.Business.Entities;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Jcars.Business.Services.CarService
{
    public class CarService : ICarService
    {
        private JcarsDbContext Context;

        public CarService(JcarsDbContext context)
        {
            Context = context;
        }

        public async Task CreateCarAsync(Car car)
        {
            Context.Cars.Add(car);
            await Context.SaveChangesAsync();
        }

        public async Task<Tuple<IEnumerable<Car>, int>> GetPaginatedCarsAsync(int pageNumber, int pageSize)
        {
            var cars = await Context.Cars.Include("Files").Include("Brand").Include("Model")
                .Include("Engine").Include("Transmission").OrderBy(c => c.CarID).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            int pages = (Context.Cars.Count() % pageSize != 0) ? Context.Cars.Count() / pageSize + 1 : Context.Cars.Count() / pageSize;
            Tuple<IEnumerable<Car>, int> result = new Tuple<IEnumerable<Car>, int>(cars, pages);
            return result;
        }

        public async Task<IEnumerable<Engine>> GetAllEnginesAsync()
        {
            var result = await Context.Engines.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Transmission>> GetAllTransmissionsAsync()
        {
            var result = await Context.Transmissions.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            var result = await Context.Brands.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Model>> GetAllModelsAsync()
        {
            var result = await Context.Models.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Car>> GetMyCarsAsync()
        {
            var user = HttpContext.Current.User;
            var userID = user.Identity.GetUserId();
            var result = await Context.Cars.Include("Files").Include("Brand").Include("Model")
    .Include("Engine").Include("Transmission").Where(c => c.UserID == userID).ToListAsync();
            return result;
        }

        public async Task<Car> GetCarAsync(int id)
        {
            var result = await Context.Cars.Include("Files").Include("Brand").Include("Model")
    .Include("Engine").Include("Transmission").Where(c => c.CarID == id).SingleOrDefaultAsync();
            return result;
        }

        public async Task EditCarAsync(Car car)
        {
            var currentCar = await Context.Cars.Where(c => c.CarID == car.CarID).SingleOrDefaultAsync();
            currentCar.ABS = car.ABS;
            currentCar.Airbag = car.Airbag;
            currentCar.AirConditioner = car.AirConditioner;
            currentCar.BrandID = car.BrandID;
            currentCar.EngineID = car.EngineID;
            currentCar.ESP = car.ESP;
            currentCar.GPS = car.GPS;
            currentCar.Horsepower = car.Horsepower;
            currentCar.Mileage = car.Mileage;
            currentCar.ModelID = car.ModelID;
            currentCar.Price = car.Price;
            currentCar.TractionControl = car.TractionControl;
            currentCar.TransmissionID = car.TransmissionID;
            currentCar.Year = car.Year;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await Context.Cars.Where(c => c.CarID == id).Include("Files").SingleOrDefaultAsync();
            Context.Cars.Remove(car);
            await Context.SaveChangesAsync();
        }

        public async Task CreateFileAsync(File file)
        {
            Context.Files.Add(file);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteFileAsync(int id)
        {
            var file = await Context.Files.Where(f => f.FileID == id).SingleOrDefaultAsync();
            Context.Files.Remove(file);
            await Context.SaveChangesAsync();

        }

        public async Task<Tuple<IEnumerable<Car>, int>> GetPaginatedSearchedCarsAsync(SearchResult searchResult, int pageNumber, int pageSize)
        {
            int? maxYear = searchResult.MaxYear.HasValue ? searchResult.MaxYear : DateTime.Now.Year;
            int? maxPrice = searchResult.MaxPrice.HasValue ? searchResult.MaxPrice : 10000000;
            int? maxHorsepower = searchResult.MaxHorsepower.HasValue ? searchResult.MaxHorsepower : Int32.MaxValue;
            int? maxMileage = searchResult.MaxMileage.HasValue ? searchResult.MaxMileage : Int32.MaxValue;
            int? minYear = searchResult.MinYear.HasValue ? searchResult.MinYear : 1900;
            int? minPrice = searchResult.MinPrice.HasValue ? searchResult.MinPrice : 0;
            int? minHorsepower = searchResult.MinHorsepower.HasValue ? searchResult.MinHorsepower : 0;
            int? minMileage = searchResult.MinMileage.HasValue ? searchResult.MinMileage : 0;

            var cars = await Context.Cars.OrderBy(c => c.CarID).Where(c => c.BrandID == searchResult.BrandID || searchResult.BrandID == null)
                .Where(c => c.ModelID == searchResult.ModelID || searchResult.ModelID == null)
                .Where(c=> c.EngineID == searchResult.EngineID || searchResult.EngineID == null)
                .Where(c=> c.TransmissionID == searchResult.TransmissionID || searchResult.TransmissionID == null)
                .Where(c=> c.Price >= minPrice && c.Price <= maxPrice)
                .Where(c=> c.Year >= minYear && c.Year <= maxYear)
                .Where(c=> c.Horsepower >= minHorsepower && c.Horsepower <= maxHorsepower)
                .Where(c=> c.Year >= minMileage && c.Year <= maxMileage)
                .Where(c=> searchResult.ABS == true && c.ABS == true)
                .Where(c=> searchResult.AirConditioner == true && c.AirConditioner == true)
                .Where(c=> searchResult.Airbag == true && c.Airbag == true)
                .Where(c=> searchResult.GPS == true && c.GPS == true)
                .Where(c=> searchResult.ESP == true && c.ESP == true)
                .Where(c=> searchResult.TractionControl == true && c.TractionControl == true)
                .Include("Files").Include("Brand").Include("Model").Include("Engine").Include("Transmission")
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            int pages = (Context.Cars.Count() % pageSize != 0) ? Context.Cars.Count() / pageSize + 1 : Context.Cars.Count() / pageSize;
            Tuple<IEnumerable<Car>, int> result = new Tuple<IEnumerable<Car>, int>(cars, pages);
            return result;
        }
    }
}
