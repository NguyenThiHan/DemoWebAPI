using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IProduct
    {
        List<Product> GetListProduct();
        void AddProduct(Product product);
        Product GetProduct(int idProduct);
        void UpdateProduct(int idProduct,Product product);
        bool RemoveProductById(int idProduct);

    }
}
