using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Models.Infrastructure.Repository
{
    public class CRUD : ICRUD
    {
        public static int Maxid = Product.Data.Max(w => w.Id);
        List<Product> source = Product.Data;
        public List<Product> RemoveSource(Product product)
        {
            source.RemoveAll(a => a.Id == product.Id);
            return source;
        }
        public void Add(Product product)
        {
            product.Id = Maxid + 1;
            Maxid = Maxid + 1;
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            product.CreateDate = DateTime.Parse(time);
            source.Add(new Product() { CreateDate = product.CreateDate, Id = product.Id, Locale = product.Locale, Name = product.Name });

        }
        public void Edit(Product product)
        {
            var update = Product.Data.Where(x => x.Id == product.Id).FirstOrDefault();
            update.Name = product.Name;
            update.Locale = product.Locale;
            update.UpdateDate = DateTime.Now;
        }
        public void Delete(Product product)
        {
            RemoveSource(product);
        }

        public Product FindData(int id)
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
            return product;
        }
    }
}