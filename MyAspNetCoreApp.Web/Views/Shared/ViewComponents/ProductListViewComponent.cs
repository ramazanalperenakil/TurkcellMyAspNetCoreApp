using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModel;
using System.Xml.Linq;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _Context;

        public ProductListViewComponent(AppDbContext context)
        {
            _Context = context;
        }

       
        public async Task<IViewComponentResult> InvokeAsyc() 
        {
            var viewmodels = _Context.Products.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description,

            }).ToList();
            
  
            return View(viewmodels);
        
        
        }
    }
}
