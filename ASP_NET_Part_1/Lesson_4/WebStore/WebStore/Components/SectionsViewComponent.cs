﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public SectionsViewComponent(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        public IViewComponentResult Invoke()
        {
            return View(GetSections());
        }

        //public async Task<IViewComponentResult> InvokeAsync() { }


        private IEnumerable<SectionViewModel> GetSections()
        {
            var sections = _ProductData.GetSections();

            var parent_sections = sections
                .Where(section => section.ParentId == null)
                .Select(section => new SectionViewModel
                {
                    Id = section.Id,
                    Name = section.Name,
                    Order = section.Order
                })
                .ToList();

            foreach (var parent_section in parent_sections)
            {
                var child_sections = sections
                    .Where(section => section.ParentId == parent_section.Id)
                    .Select(section => new SectionViewModel
                    {
                        Id = section.Id,
                        Name = section.Name,
                        Order = section.Order
                    });
                parent_section.ChildSections.AddRange(child_sections);
                parent_section.ChildSections.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }
            parent_sections.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            return parent_sections;
        }
    }
}
