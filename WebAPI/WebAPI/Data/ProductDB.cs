using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class ProductDB
    {
        public List<Product> _listProduct;

        public ProductDB()
        {
            _listProduct = new List<Product>();
        }
    }
}
