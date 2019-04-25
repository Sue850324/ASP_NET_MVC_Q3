using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        List<Product> source = Product.Data;
        public ActionResult List()
        {           
            return View(source);
        }
      
        public ActionResult Add()
        {
            Product product = new Product();
            product.CreateDate = DateTime.Now;
            var maxid = Product.Data.Max(w => w.Id);
            product.Id = maxid + 1;

            var itemlist = new List<SelectListItem>();
            itemlist.Add(new SelectListItem { Text = "Unite State", Value = "US", Selected = true });
            itemlist.Add(new SelectListItem { Text = "Germany", Value = "EU" });
            itemlist.Add(new SelectListItem { Text = "Canada", Value = "CA" });
            itemlist.Add(new SelectListItem { Text = "Spain", Value = "ES" });
            itemlist.Add(new SelectListItem { Text = "France", Value = "FR" });
            itemlist.Add(new SelectListItem { Text = "Japen", Value = "JP" });
            ViewBag.CategoryID = itemlist;
            

            source.Add(new Product() { CreateDate=product.CreateDate, Id=product.Id, Locale=product.Locale, Name=product.Name });

            return View(source);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }
            return View("Add");
        }
        public ActionResult Edit(Product product)
        {

            return View(product);
        }
        public ActionResult Delete()
        {
            List<Product> source = Product.Data;
            return View(source);
        }
    }
}