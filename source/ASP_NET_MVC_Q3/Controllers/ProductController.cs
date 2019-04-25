﻿using ASP_NET_MVC_Q3.Data;
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
        List<Product> source = Product.Data;  
        public ActionResult List()
        {           

            return View(source);
        }

        public ActionResult Add()
        {
            int newID = Product.Data.Max(w => w.Id) + 1;
            DataViewModel dataViewModel = new DataViewModel();
            dataViewModel.product = new Product();
            dataViewModel.product.Id = newID;
            var itemlist = new List<SelectListItem>();
            itemlist.Add(new SelectListItem { Text = "Unite State", Value = "US", Selected = true });
            itemlist.Add(new SelectListItem { Text = "Germany", Value = "EU" });
            itemlist.Add(new SelectListItem { Text = "Canada", Value = "CA" });
            itemlist.Add(new SelectListItem { Text = "Spain", Value = "ES" });
            itemlist.Add(new SelectListItem { Text = "France", Value = "FR" });
            itemlist.Add(new SelectListItem { Text = "Japen", Value = "JP" });
            ViewBag.CategoryID = itemlist;
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dataViewModel.product.CreateDate = DateTime.Parse(time);
            return View(dataViewModel);
        }

        [HttpPost]
        public ActionResult Add(DataViewModel dataViewModel)
        {           
            if (ModelState.IsValid)
            {
               source.Add(new Product() { CreateDate = dataViewModel.product.CreateDate, Id = dataViewModel.product.Id, Locale = dataViewModel.product.Locale, Name = dataViewModel.product.Name });
                return View("List",source);
            }
            return View("Add");
        }
        public ActionResult Edit(int id)
        {
            Product product = new Product();
            foreach (var item in source)
            {
                if (item.Id == id)
                {
                    product.Id = item.Id ;
                    product.Locale = item.Locale ;
                    product.Name = item.Name;
                    product.CreateDate = item.CreateDate ;
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
            
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {         
                source.Add(new Product() { CreateDate = product.CreateDate, Id = product.Id, Locale =product.Locale, Name = product.Name,UpdateDate=product.UpdateDate });
                return View("List", source);
            }
            return View("Edit");
        }
        public ActionResult Delete(Product product)
        {
            List<Product> source = Product.Data;
            return View(source);
        }
    }
}