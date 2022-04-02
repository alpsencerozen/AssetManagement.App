using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Areas.User.Controllers
{
    [Area("User")]
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAsset()
        {
            return View();
        }

        public IActionResult AddAssetNoBarcode()
        {
            return View();
        }
    }
}
