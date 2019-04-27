using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        public static int Maxid = Product.Data.Max(w => w.Id);
        List<Product> source = Product.Data;
        public ActionResult List()
        {
            source = source.OrderBy(o => o.Id).ToList();
            return View(source);
        }

        public ActionResult Add()
        {
            var itemlist = new List<SelectListItem>();
            itemlist.Add(new SelectListItem { Text = "Unite State", Value = "US", Selected = true });
            itemlist.Add(new SelectListItem { Text = "Germany", Value = "EU" });
            itemlist.Add(new SelectListItem { Text = "Canada", Value = "CA" });
            itemlist.Add(new SelectListItem { Text = "Spain", Value = "ES" });
            itemlist.Add(new SelectListItem { Text = "France", Value = "FR" });
            itemlist.Add(new SelectListItem { Text = "Japen", Value = "JP" });
            ViewData["items"] = itemlist;
            return View();
        }

        [HttpPost]

        public ActionResult Add(Product product)
        {

            if (ModelState.IsValid)
            {
                product.Id = Maxid + 1;
                Maxid = Maxid + 1;
                var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                product.CreateDate = DateTime.Parse(time);
                source.Add(new Product() { CreateDate = product.CreateDate, Id = product.Id, Locale = product.Locale, Name = product.Name });
                return RedirectToAction("List", source);
            }


            return RedirectToAction("Add", product);
        }
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            foreach (var item in source)
            {
                if (item.Id == id)
                {
                    product.Id = item.Id;
                    product.Locale = item.Locale;
                    product.Name = item.Name;
                    product.CreateDate = item.CreateDate;

                }
            }
            var itemlist = new List<SelectListItem>();
            itemlist.Add(new SelectListItem { Text = "Unite State", Value = "US", Selected = true });
            itemlist.Add(new SelectListItem { Text = "Germany", Value = "EU" });
            itemlist.Add(new SelectListItem { Text = "Canada", Value = "CA" });
            itemlist.Add(new SelectListItem { Text = "Spain", Value = "ES" });
            itemlist.Add(new SelectListItem { Text = "France", Value = "FR" });
            itemlist.Add(new SelectListItem { Text = "Japen", Value = "JP" });
            ViewBag.CategoryID = itemlist;
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            product.UpdateDate = DateTime.Parse(time);
            source.RemoveAll(a => a.Id == product.Id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                source.Add(new Product() { CreateDate = product.CreateDate, Id = product.Id, Locale = product.Locale, Name = product.Name, UpdateDate = product.UpdateDate });            
                return RedirectToAction("List", source);
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            Product product = new Product();
            foreach (var item in source)
            {
                if (id == item.Id)
                {              
                    product.Id = item.Id;
                    product.Locale = item.Locale;
                    product.Name = item.Name;
                    product.CreateDate = item.CreateDate;
                    product.UpdateDate = item.UpdateDate;
                }
            }
            return View(product);
        }
        public ActionResult DeletePage(Product product)
        {
            source.RemoveAll(a => a.Id == product.Id);
            return View();
        }
    }
}