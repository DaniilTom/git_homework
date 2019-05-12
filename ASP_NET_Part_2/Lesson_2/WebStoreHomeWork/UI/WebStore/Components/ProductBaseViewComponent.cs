using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;
using WebStore.ViewModel;

namespace WebStore.Components
{
    public class ProductBaseViewComponent : ViewComponent
    {
        private readonly IServiceProductData _MicrocontrollerData;

        public ProductBaseViewComponent(IServiceProductData ProductData)
        {
            _MicrocontrollerData = ProductData;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<MicrocontrollerViewModel> mv_model = GetProducts();
            return View(mv_model);
        }

        private IEnumerable<MicrocontrollerViewModel> GetProducts()
        {
            var mc = _MicrocontrollerData.Products;
            var desc = _MicrocontrollerData.DetailedDescription;

            List<MicrocontrollerViewModel> list = new List<MicrocontrollerViewModel>();

            foreach(var product in mc)
            {
                MicrocontrollerViewModel mvModel = new MicrocontrollerViewModel { ProductBase = product };
                foreach(var d in desc)
                {
                    if (product.Id == d.Id)
                    {
                        mvModel.MCDescription = d;
                        break;
                    }
                }
                if (mvModel.MCDescription == null)
                    mvModel.MCDescription = new Domain.DTO.MCDescriptionDTO { DetailedDesription = "Нет описания;" };

                list.Add(mvModel);
            }

            return list;

            //return from m in mc
            //       from d in desc
            //       where m.Id == d.ProductId
            //       select new MicrocontrollerViewModel {ProductBase = m, MCDescription = d };
        }
    }
}
