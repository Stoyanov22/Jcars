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
        Task CreateCarAsync(Car car);
    }
}
