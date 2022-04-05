using AssetManagement.App.GUI.Provider;
using AssetManagement.App.GUI.Models;
using AssetManagement.App.GUI.Models.APIModels;
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
        AssetProvider _assetProvider;

        public InventoryController(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddAsset()
        {
            var assetChoices = await _assetProvider.GetAssetDetailChoices();
            return View(assetChoices);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetDetailChoicesDTO selectedChoices)
        {
            await _assetProvider.CreateAsset(selectedChoices);
            return Redirect("Index");
        }

        public IActionResult AddAssetNoBarcode()
        {
            return View();
        }

        public async Task<IActionResult> GetMyAssets()
        {
            IEnumerable<AssetListDTO> assets = await _assetProvider.GetAssetListItems();
            return View(assets);
        }


    }
}
