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
    public class StoreService : IStore
    {
        StoreDB db;

        public StoreService()
        {
            var instance = SingletonPattern.Instance();
            db = instance.StoreDB;
            //InitDummyData();
            if (!instance.CheckData)
            {
                instance.CheckData = true;
                InitDummyDataStore();
            }
        }

        public List<Store> GetListStore()
        {
            return db._listStore;
        }

        public void AddStore(Store store)
        {
            if(db._listStore.Count != 0)
            {
                var maxStoreId = db._listStore.Max(n => n.IdStore);
                store.IdStore = ++maxStoreId;
            }
            db._listStore.Add(store);
        }

        public Store GetStore(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            return store;
        }

        public bool RemoveStoreById(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            if (store != null)
            {
                db._listStore.Remove(store);
                return true;
            }
            return false;
        }

        public void UpdateStore(int idStore, Store store)
        {
            Store result = db._listStore.Find(item => item.IdStore == idStore);
            if (result != null)
            {
                result.IdStore = store.IdStore;
                result.NameStore = store.NameStore;
            }
        }

        public List<Product> AddProductIntoStore(int idStore, Product product)
        {
            Store store = db._listStore.Find(id => id.IdStore == idStore);
            if (store == null)
            {
                return null;
            }
            store.listProduct.Add(product);
            return store.listProduct;
        }

        public Product FindProductInStore(int idStore, int idProduct)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            if (store == null)
            {
                return null;
            }
            Product product = store.listProduct.Find(item => item.IdProduct == idProduct);
            if(product == null)
            {
                return null;
            }
            return product;

            //return store != null ? store.listProduct.Find(item => item.IdProduct == idProduct) : null;
        }

        public List<Product> RemoveProductInStore(int idStore, int idProduct)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            Product product = store.listProduct.Find(item => item.IdProduct == idProduct);

            store.listProduct.Remove(product);
            return store.listProduct;
        }

        public List<Product> UpdateProductInStore(int idStore, int idProduct, Product product)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            Product result = store.listProduct.Find(item => item.IdProduct == idProduct);

            if (result == null)
            {
                return null;
            }
            result.IdProduct = product.IdProduct;
            result.NameProduct = product.NameProduct;
            result.QualityProduct = product.QualityProduct;
            result.CodeProduct = product.CodeProduct;

            return store.listProduct;
        }

        public List<Product> GetAllProductInStore(int idStore)
        {
            Store store = db._listStore.Find(item => item.IdStore == idStore);
            return store.listProduct;
        }

        //Dummy Data
        public void InitDummyDataStore()
        {
            Store store1 = new Store(1, "Store1");
            Store store2 = new Store(2, "Store2");
            Store store3 = new Store(3, "Store3");

            db._listStore.Add(store1);
            db._listStore.Add(store2);
            db._listStore.Add(store3);
        }
    }
}
