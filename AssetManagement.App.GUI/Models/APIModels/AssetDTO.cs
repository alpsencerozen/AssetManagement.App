using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Models.APIModels
{
    public class AssetDTO
    {
        public int ID { get; set; }
        public bool? hasBarcode { get; set; }
        public Guid? RegistrationNumber { get; set; } //= Guid.NewGuid();
        public int CompanyID { get; set; }
        public int AssetGroupID { get; set; }
        public int AssetTypeID { get; set; }
        public int BrandModelID { get; set; }
        public int CurrencyID { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public bool? Guarantee { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? RetireReason { get; set; }
        public DateTime? RetireDate { get; set; }
    }
}
