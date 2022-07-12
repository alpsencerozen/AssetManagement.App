using AssetManagement.App.GUI.Models.APIModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Validation
{
    public class AddAssetValidation : AbstractValidator<AssetDetailChoicesDTO>
    {

        public AddAssetValidation()
        {
            RuleFor(x=>x.Barcode).NotEmpty().WithMessage("Barkod Giriniz").When(x=>x.hasBarcode == true);
            RuleFor(x=>x.AssetGroupID).NotEmpty().WithMessage("Grup Giriniz");
            RuleFor(x=>x.AssetTypeID).NotEmpty().WithMessage("Tip Giriniz");
            RuleFor(x=>x.BrandModelID).NotEmpty().WithMessage("Marka Giriniz");
            RuleFor(x=>x.Quantity).InclusiveBetween(1, int.MaxValue).WithMessage("Miktar Giriniz").When(x => x.hasBarcode == false);
            RuleFor(x=>x.UnitID).NotEmpty().WithMessage("Birim Giriniz").When(x => x.hasBarcode == false);
            RuleFor(x=>x.Cost).InclusiveBetween(1,int.MaxValue).WithMessage("Maliyet Giriniz");
            RuleFor(x=>x.CostCurrencyID).NotEmpty().WithMessage("Para Birimi Giriniz");
            RuleFor(x=>x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("Fiyat Giriniz");
            RuleFor(x=>x.PriceCurrencyID).NotEmpty().WithMessage("Para Birimi Giriniz");
        }
    }
}
