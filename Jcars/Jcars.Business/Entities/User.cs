﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcars.Business.Entities
{
    public class User : IdentityUser
    {
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
