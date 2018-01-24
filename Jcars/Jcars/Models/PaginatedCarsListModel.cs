using Jcars.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class PaginatedCarsListModel
    {
        public List<Car> Cars { get; set; }
        public int Pages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public PaginatedCarsListModel(IEnumerable<Car> cars, int pages, int pageSize, int pageNumber)
        {
            Cars = cars.ToList();
            Pages = pages;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}