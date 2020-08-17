using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Data;
using WebAPI.Singleton;
using WebAPI.Interface;

namespace WebAPI.Service
{
    public class ProductService : IProduct
    {
        ProductDB db;
        public ProductService()
        {
            var instance = SingletonPattern.Instance();
            db = instance.ProductDB;
            if (!instance.IsInitDummyData)
            {
                instance.IsInitDummyData = true;
                InitDummyDataProduct();
            }
        }

        public List<Product> GetListProduct()
        {
            return db._listProduct;
        }

        public void AddProduct(Product product)
        {
            if(db._listProduct.Count != 0)
            {
                var maxProductId = db._listProduct.Max(x => x.IdProduct);
                product.IdProduct = ++maxProductId;
            }    
            db._listProduct.Add(product);
            
        }

        public Product GetProduct(int idProduct)
        {
            Product product = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public void UpdateProduct(int idProduct, Product product)
        {
            Product p = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (p != null)
            {
                p.IdProduct = product.IdProduct;
                p.NameProduct = product.NameProduct;
                p.CodeProduct = product.CodeProduct;
                p.QualityProduct = product.QualityProduct;
            }
        }

        public bool RemoveProductById(int idProduct)
        {
            Product product = db._listProduct.Find(item => item.IdProduct == idProduct);
            if (product != null)
            {
                db._listProduct.Remove(product);
                return true;
            }
            return false;
        }

        //DummyData
        public void InitDummyDataProduct()
        {
            Product product1 = new Product(1, "Item1", "Code1", "Good");
            Product product2 = new Product(2, "Item2", "Code2", "Bad");
            Product product3 = new Product(3, "Item3", "Code3", "Good");
            Product product4 = new Product(4, "Item4", "Code4", "Bad");
            Product product5 = new Product(5, "Item5", "Code5", "Good");

            db._listProduct.Add(product1);
            db._listProduct.Add(product2);
            db._listProduct.Add(product3);
            db._listProduct.Add(product4);
            db._listProduct.Add(product5);
        }
    }
}
