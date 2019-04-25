using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_NET_MVC_Q3.Models
{
    public class DataViewModel 
    {
        public Product product { set; get; }
        public List<Product> Data { set; get; } 
    }
}