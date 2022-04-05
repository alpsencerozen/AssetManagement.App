using AssetManagement.App.GUI.Models.APIModels;
using AssetManagement.App.GUI.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult AddAsset(int a)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAsset()
        {
            return RedirectToAction("Index", "Inventory");
        }

        public async Task<IActionResult> GetAllAssets()
        {
            IEnumerable<AssetListDTO> assets = await _assetProvider.GetAssetListItems();
            return View(assets);
        }

        public async Task<IActionResult> ViewAsset(int id)
        {
            AssetDTO asset = await _assetProvider.GetAssets(id);
            return View(asset);
        }



    }
}
