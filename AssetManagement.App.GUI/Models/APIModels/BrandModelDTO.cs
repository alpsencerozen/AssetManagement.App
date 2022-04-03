using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Models.APIModels
{
    public class BrandModelDTO
    {
        public int ID { get; set; }
        public int? MasterID { get; set; }
        public bool? isBrand { get; set; }
        public string Description { get; set; }
    }
}
