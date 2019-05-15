using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_MVC_Q3.Models.Interface
{
    interface IProductRepository
    {
        void Add(Product product);
        void Edit(Product product);
        void Delete(Product product);
        Product FindData(int id);
    }
}
