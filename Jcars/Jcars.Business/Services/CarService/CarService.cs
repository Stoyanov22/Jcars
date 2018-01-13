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

        public async Task<IEnumerable<Car>> GetPaginatedCarsAsync(int pageNumber, int pageSize)
        {
            var result = await Context.Cars.Include("Files").Include("Brands").Include("Models")
                .Include("Engines").Include("Transmissions").Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
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
    .Include("Engine").Include("Transmission").Where(c=>c.UserID == userID).ToListAsync();
            return result;
        }
    }
}
