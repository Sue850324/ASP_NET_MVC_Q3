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
        
        public ActionResult List()
        {
            return View(source);
        }

        public ActionResult Add()
        {
            ViewData["items"]= new ProductRepository().Locale();
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
            ViewData["items"] = new ProductRepository().Locale();                       
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