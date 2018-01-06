using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class Engine
    {
        public int EngineID { get; set; }
        public string Type { get; set; }
       // List cars with that type of engine
       public virtual IEnumerable<Car> Cars { get; set; }

        public Engine()
        {

        }
    }
}
