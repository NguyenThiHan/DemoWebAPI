using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Singleton
{
    public class SingletonPattern
    {
        private static SingletonPattern _instance;

        public static SingletonPattern Instance()
        {
            if(_instance == null)
            {
                _instance = new SingletonPattern();
            }
            return _instance;
        }

        public ProductDB ProductDB = new ProductDB();
        public StoreDB StoreDB = new StoreDB();
        public bool IsInitDummyData = false;
        public bool CheckData = false;

    }
}
