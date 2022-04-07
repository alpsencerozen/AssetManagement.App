using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Models.APIModels
{
    public class AssetDetailChoicesDTO
    {
        public int ID { get; set; }
        public bool hasBarcode { get; set; }
        public string Barcode { get; set; }

        public List<AssetGroupDTO> AssetGroupDesc { get; set; }
        public int AssetGroupID { get; set; }

        public List<AssetTypeDTO> AssetTypeDesc { get; set; }

        public int AssetTypeID { get; set; }

        public List<BrandModelDTO> BrandModel { get; set; }
        public int BrandModelID { get; set; }

        public bool hasGuarrantee { get; set; }
        public DateTime EntryDate { get; set; }

        //for no barcode
        public List<UnitDTO> Unit { get; set; }
        public string AssetUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public List<CurrencyDTO> CostCurrency { get; set; }
        public int CostCurrencyID { get; set; }

        public decimal Price { get; set; }
        public List<CurrencyDTO> PriceCurrency { get; set; }
        public int PriceCurrencyID { get; set; }

        public int CompanyID { get; set; }

        public string AssetDesc { get; set; }
    }
}
