using Library.Data;
using Library.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var ListingResult = assetModels.Select(result => new AssetIndexListingModel
            {
                Id = result.ID,
                AuthorOrDirector = _assets.GetAuthorOrDirector(result.ID),
                ImgUrl = result.ImgURL,
                DeweyCallNumber = _assets.GetDeweyIndex(result.ID),
                Title = result.Title,
                Type = _assets.GetType(result.ID)
            });
            var model = new AssetIndexModel()
            {
                Assets = ListingResult
            };
            return View(model);
        }
    }
}
