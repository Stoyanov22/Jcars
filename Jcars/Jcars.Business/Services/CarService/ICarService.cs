using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jcars.Business.Entities;

namespace Jcars.Business.Services.CarService
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetPaginatedCarsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Car>> GetMyCarsAsync();
        Task CreateCarAsync(Car car);
        Task<IEnumerable<Brand>> GetAllBrandsAsync();
        Task<IEnumerable<Model>> GetAllModelsAsync();
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<IEnumerable<Transmission>> GetAllTransmissionsAsync();
        Task<Car> GetCarAsync(int id);
        Task EditCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}
