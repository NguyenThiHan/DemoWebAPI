using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class StoreDB
    {
        public List<Store> _listStore;

        public StoreDB()
        {
            _listStore = new List<Store>();
        }
    }
}
