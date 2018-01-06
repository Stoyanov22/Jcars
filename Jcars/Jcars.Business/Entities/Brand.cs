using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Model> Models{ get; set; }

        public Brand()
        {

        }
    }
}
