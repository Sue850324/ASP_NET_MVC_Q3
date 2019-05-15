using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;
using ASP_NET_MVC_Q3.Models.Infrastructure.Repository;
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
        public object Locale()
        {
            var itemList = new List<SelectListItem>();
            itemList.Add(new SelectListItem { Text = "Unite State", Value = "US", Selected = true });
            itemList.Add(new SelectListItem { Text = "Germany", Value = "EU" });
            itemList.Add(new SelectListItem { Text = "Canada", Value = "CA" });
            itemList.Add(new SelectListItem { Text = "Spain", Value = "ES" });
            itemList.Add(new SelectListItem { Text = "France", Value = "FR" });
            itemList.Add(new SelectListItem { Text = "Japen", Value = "JP" });       
            return  ViewData["items"] = itemList;
        }
        public ActionResult List()
        {
            return View(source);
        }

        public ActionResult Add()
        {
            Locale();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {               
                new ProductRepository().Add(product);
                return RedirectToAction("List");
            }
            return RedirectToAction("Add", product);
        }
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            product = new ProductRepository().FindData(id);
            Locale();                       
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {    
            if (ModelState.IsValid)
            {
                new ProductRepository().Edit(product);
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit");
        }
        public ActionResult Delete(int id)
        {
            return View(new ProductRepository().FindData(id));
        }
        public ActionResult DeletePage(Product product)
        {
            new ProductRepository().Delete(product);      
            return View();
        }
    }
}