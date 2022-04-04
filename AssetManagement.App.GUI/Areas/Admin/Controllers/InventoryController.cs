﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Areas.Admin.Controllers
{
    public class InventoryController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAsset(int a)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAsset()
        {
            return RedirectToAction("Index", "Inventory");
        }
    }
}