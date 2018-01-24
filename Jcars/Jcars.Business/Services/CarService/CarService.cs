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

        public async Task<Tuple<IEnumerable<Car>,int>> GetPaginatedCarsAsync(int pageNumber, int pageSize)
        {
            var cars = await Context.Cars.Include("Files").Include("Brand").Include("Model")
                .Include("Engine").Include("Transmission").OrderBy(c=>c.CarID).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
            int pages = (Context.Cars.Count()%pageSize!=0)? Context.Cars.Count() / pageSize +1 : Context.Cars.Count() / pageSize;
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
    }
}
