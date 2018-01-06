using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class Transmission
    {
        public int TransmissionID { get; set; }
        public string Type { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        public Transmission()
        {

        }

    }
}
