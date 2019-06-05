using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;
using WebStore.Domain.ViewModel;

namespace WebStore.Components
{
    public class ProductBaseViewComponent : ViewComponent
    {
        private readonly IServiceProductData _MicrocontrollerData;

        public ProductBaseViewComponent(IServiceProductData ProductData)
        {
            _MicrocontrollerData = ProductData;
        }

        public IViewComponentResult Invoke(int page, int pageSize)
        {
            IEnumerable<MicrocontrollerViewModel> mv_model = GetProducts(page, pageSize);
            return View(mv_model);
        }

        private IEnumerable<MicrocontrollerViewModel> GetProducts(int page, int pageSize)
        {
            int count = _MicrocontrollerData.Products.Count();
            ViewBag.PageCount = (int)Math.Ceiling((double)count / pageSize);

            int skip = 0;

            if (page != 0)
                skip = (page - 1) * pageSize;
            else
                pageSize = count;

            var mc = _MicrocontrollerData.Products.Skip(skip).Take(pageSize);
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
