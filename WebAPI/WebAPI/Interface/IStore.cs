using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IStore
    {
        List<Store> GetListStore();
        void AddStore(Store store);
        Store GetStore(int idStore);
        bool RemoveStoreById(int idStore);
        void UpdateStore(int idStore, Store store);

        List<Product> AddProductIntoStore(int idStore, Product product);
        Product FindProductInStore(int idStore, int idProduct);
        List<Product> RemoveProductInStore(int idStore, int idProduct);
        List<Product> UpdateProductInStore(int idStore, int idProduct, Product product);
        List<Product> GetAllProductInStore(int idStore);
    }
}
