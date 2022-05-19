using AssetManagement.App.GUI.Models.APIModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Repository
{
    public class AssetRepository
    {
        public List<SelectListItem> GetSelectedBrandList(AssetDetailChoicesDTO assetDetails)
        {
            int brandId = assetDetails.BrandModel.Where(x => x.ID == assetDetails.BrandModelID).First().MasterID.GetValueOrDefault();
            var brandList = new List<SelectListItem>() { new SelectListItem { Text = "Seçiniz...", Selected = true } };
            assetDetails.BrandModel.Where(x => x.isBrand == true).ToList().ForEach(select => brandList.Add(new SelectListItem { Text = select.Description, Value = select.ID.ToString() }));
            brandList.Where(x => x.Value == brandId.ToString()).First().Selected = true;

            return brandList;
        }
    }
}
