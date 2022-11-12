using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModel;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _Context;
        private readonly ProductRepository _productRepository;
        //private IHelper _helper;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context , IMapper mapper/*, IHelper helper*/)
        {
            _productRepository = new ProductRepository();
            _Context = context;
            _mapper = mapper;
            //_helper = helper;

            //if (!_Context.Products.Any())
            //{
            //    _Context.Products.Add(new() { Name = "Kalem ", Price = 100, Stock = 400, Color = "Kırmızı" });
            //    _Context.Products.Add(new() { Name = "Silgi ", Price = 400, Stock = 200 ,Color = "Beyaz"});
            //    _Context.Products.Add(new() { Name = "Defter ", Price =1500, Stock = 600, Color = "MAvi"});

            //    _Context.SaveChanges();

            //}


        }
        public IActionResult Index(/*[FromServices] IHelper*/ /*helper2*/)
        {


            //var text = "asp net";
            //var UpperText = _helper.Upper(text);
            //var status = _helper.Equals(helper2);

            var products = _Context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            var product = _Context.Products.Find(id);

            _Context.Products.Remove(product);
            _Context.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Add()
        {

             
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi", Value="Mavi"},
                new(){Data="Kırmızı", Value="Kırmızı"},
                new(){Data="Siyah", Value="Siyah"},
                new(){Data="Beyaz", Value="Beyaz" }

            },"Value","Data");

            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {

            //if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            //{
            //    ModelState.AddModelError(string.Empty, "A ile Olmaz");
            //}

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi", Value="Mavi"},
                new(){Data="Kırmızı", Value="Kırmızı"},
                new(){Data="Siyah", Value="Siyah"},
                new(){Data="Beyaz", Value="Beyaz" }

            }, "Value", "Data");
             

            if (ModelState.IsValid)
            {
                try
                {
                    _Context.Products.Add(_mapper.Map<Product>(newProduct));
                    _Context.SaveChanges();
                    TempData["Status"] = "Eklendi";
                    return RedirectToAction("Index");
                }
                catch (Exception error)
                {
                    
                        ModelState.AddModelError(string.Empty, "Ürün Kaydedirken Hata Oldu ");
                    

                    throw;
                }
            }
            else
            {

               

              
                return View();
            }
           
           
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _Context.Products.Find(id);
            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi", Value="Mavi"},
                new(){Data="Kırmızı", Value="Kırmızı"},
                new(){Data="Siyah", Value="Siyah"},
                new(){Data="Beyaz", Value="Beyaz" }

            }, "Value", "Data",product.Color);
            return View(_mapper.Map<ProductViewModel>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel p)
        {
            

            if (!ModelState.IsValid)
            {
                ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi", Value="Mavi"},
                new(){Data="Kırmızı", Value="Kırmızı"},
                new(){Data="Siyah", Value="Siyah"},
                new(){Data="Beyaz", Value="Beyaz" }

            }, "Value", "Data");
                return View();
            }
            _Context.Update(_mapper.Map<Product>(p));
            _Context.SaveChanges();
            TempData["Status"] = "Güncellendi";

            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get","Post")]
        public IActionResult HasProductName(string Name) 
        {
            var anyProducy = _Context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            if (anyProducy)
            {
                return Json("Ürün Vardır");

            }
            else
            {
                return Json(true);
            }
        
        
        }
    }
}
