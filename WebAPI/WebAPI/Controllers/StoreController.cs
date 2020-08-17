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
    public class StoreController : Controller
    {
        IStore service;
        public StoreController()
        {
            service = new StoreService();
        }

        //api/store/GetAllStore
        [HttpGet]
        [Route("GetAllStore")]
        public List<Store> GetAllStore()
        {
            return service.GetListStore();
        }

        //api/store/GetStore/id
        [HttpGet]
        [Route("GetStore/{id}")]
        public Store GetStore(int idStore)
        {
            return service.GetStore(idStore);

        }

        //api/store/AddStore
        [HttpPost]
        [Route("AddStore")]
        public List<Store> AddStore(Store store)
        {
            service.AddStore(store);
            return GetAllStore();
        }

        //api/store/EditStore/id
        [HttpPut]
        [Route("EditStore")]
        public Store EditStore(int idStore,Store store)
        {
            service.UpdateStore(idStore,store);
            return GetStore(idStore);
        }

        //api/store/DeleteStore/id
        [HttpDelete]
        [Route("DeleteStore")]
        public List<Store> DeleteStore(int idStore)
        {
            service.RemoveStoreById(idStore);
            return GetAllStore();
        }

        //api/store/GetAllProductInStore/id
        [HttpGet]
        [Route("GetAllProductInStore/{idStore}")]
        public List<Product> GetAllProductInStore(int idStore)
        {
            return service.GetAllProductInStore(idStore);
        }

        //api/store/GetProductInStore/id/id
        [HttpGet]
        [Route("GetProductInStore/{idStore}/{idProduct}")]
        public Product GetProductInStore(int idStore , int idProduct)
        {
            return service.FindProductInStore(idStore, idProduct);
        }


        //api/store/AddProductIntoStore
        [HttpPost]
        [Route("AddProductIntoStore/{idStore}")]
        public List<Product> AddProductIntoStore(int idStore, Product product)
        {
            return service.AddProductIntoStore(idStore, product);
        }

        //api/store/DeleteProductInStore/id/id
        [HttpDelete]
        [Route("DeleteProductInStore/{idStore}/{idProduct}")]
        public List<Product> DeleteProductInStore(int idStore, int idProduct)
        {
            return service.RemoveProductInStore(idStore, idProduct);
        }

        //api/store/UpdateProductInStore/id
        [HttpPut]
        [Route("UpdateProductInStore/{idStore}/{idProduct}")]
        public List<Product> UpdateProductInStore(int idStore, int idProduct, Product product)
        {
            return service.UpdateProductInStore(idStore, idProduct, product);
        }
    }
}
