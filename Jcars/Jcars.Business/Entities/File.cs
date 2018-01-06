using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class File
    {
        public int FileID { get; set; }
        public int CarID { get; set; }
        public byte[] Content { get; set; }
        public virtual Car Car { get; set; }
    }
}
