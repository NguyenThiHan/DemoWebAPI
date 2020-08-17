using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string CodeProduct { get; set; }
        public string QualityProduct { get; set; }

        public Product(int idProduct, string nameProduct, string codeProduct, string qualityProduct)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            CodeProduct = codeProduct;
            QualityProduct = qualityProduct;
        }
    }
}