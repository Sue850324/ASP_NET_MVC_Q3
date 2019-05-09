using ASP_NET_MVC_Q3.Data;
using System.Collections.Generic;

namespace ASP_NET_MVC_Q3.Models
{
    public class DataViewModel 
    {
        public Product product { set; get; }
        public List<Product> data { set; get; } 
    }
}