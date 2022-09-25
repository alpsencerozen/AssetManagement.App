using AssetManagement.App.GUI.Provider;
using AssetManagement.App.GUI.Models.APIModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPanelController : Controller
    {
        AssetPropertyProvider _assetPropProvider;

        public AdminPanelController(AssetPropertyProvider assetPropProvider)
        {
            _assetPropProvider = assetPropProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SystemLists()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CurrencyList()
        {
            var currencyList = await _assetPropProvider.GetCurrencies();
            return View(currencyList);
        }
    }
}
