using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public interface IJcarsDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Transmission> Transmissions { get; set; }
        Task<int> SaveChangesAsync();
    }
}
