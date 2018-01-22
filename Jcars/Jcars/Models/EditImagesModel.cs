using Jcars.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jcars.Models
{
    public class EditImagesModel
    {
        public int CarID { get; set; }
        public List<File> Files { get; set; }

        public EditImagesModel(int carID, List<File> files)
        {
            CarID = carID;
            Files = files;
        }
    }
}