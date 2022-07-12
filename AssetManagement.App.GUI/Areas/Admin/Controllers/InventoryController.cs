using AssetManagement.App.GUI.Models.APIModels;
using AssetManagement.App.GUI.Provider;
using AssetManagement.App.GUI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class InventoryController : Controller
    {
        AssetProvider _assetProvider;
        AssetRepository _assetRepo;

        public InventoryController(AssetProvider assetProvider, AssetRepository assetRepo)
        {
            _assetProvider = assetProvider;
            _assetRepo = assetRepo;
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
            if (!ModelState.IsValid)
            {
                var assetChoices = await _assetProvider.GetAssetDetailChoices();
                return View(assetChoices);
            }

            await _assetProvider.CreateAsset(selectedChoices);
            return RedirectToAction("GetAllAssets", "Inventory");
        }

        public async Task<IActionResult> GetAllAssets()
        {
            IEnumerable<AssetListDTO> assets = await _assetProvider.GetAssetListItems();
            return View(assets);
        }

        public async Task<IActionResult> ViewAsset(int id)
        {
            AssetDetailChoicesDTO assetDetails = await _assetProvider.GetAssetDetailChoicesById(id);
            ViewBag.BrandList = _assetRepo.GetSelectedBrandList(assetDetails);
            TempData["hasBarcode"] = assetDetails.hasBarcode;
            return View(assetDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ViewAsset(AssetDetailChoicesDTO updatedAsset)
        {
            if (TempData.ContainsKey("hasBarcode"))
            {
                updatedAsset.hasBarcode = bool.Parse(TempData["hasBarcode"].ToString());
            }

            ModelState.Clear();

            if (!TryValidateModel(updatedAsset))
            {
                AssetDetailChoicesDTO assetDetails = await _assetProvider.GetAssetDetailChoicesById(updatedAsset.ID);
                ViewBag.BrandList = _assetRepo.GetSelectedBrandList(assetDetails);
                TempData["hasBarcode"] = assetDetails.hasBarcode;
                return View(assetDetails);
            }

            await _assetProvider.UpdateAsset(updatedAsset);
            return RedirectToAction("GetAllAssets", "Inventory");
        }


    }
}
