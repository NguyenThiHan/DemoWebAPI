using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Service;
using WebAPI.Model;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProduct service;
        public ProductController()
        {
            service = new ProductService();
        }

        //api/product/GetAllProduct
        [HttpGet]
        [Route("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            return service.GetListProduct();
        }

        //api/product/GetProductItem/id
        [HttpGet("{id}")]
        [Route("GetProductItem/{id}")]
        public Product GetProductItem(int id)
        {
            var itemProduct = service.GetProduct(id);
            return itemProduct;
        }

        //api/product/AddProduct
        [HttpPost]
        [Route("AddProduct")]
        public List<Product> AddProduct(Product product)
        {
            service.AddProduct(product);
            return GetAllProduct();
        }

        //api/product/EditProduct/id
        [HttpPut("{id}")]
        [Route("EditProduct/{id}")]
        public Product EditProduct(int id, Product product)
        {
            service.UpdateProduct(id, product);
            return GetProductItem(id);
        }

        //api/product/DeleteProduct/id
        [HttpDelete("{id}")]
        [Route("DeleteProduct/{id}")]
        public List<Product> DeleteProduct(int id)
        {
            service.RemoveProductById(id);
            return GetAllProduct();
        }

    }
}
