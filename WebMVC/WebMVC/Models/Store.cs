using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Store
    {
        public int IdStore { get; set; }
        public string NameStore { get; set; }
        public List<Product> listProduct { get; set; }

        public Store(int idStore, string nameStore)
        {
            this.IdStore = idStore;
            this.NameStore = nameStore;
            listProduct = new List<Product>();
        }

    }
}