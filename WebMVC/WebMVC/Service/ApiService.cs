using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebMVC.Service
{ 
    public class ApiService
    {
        static HttpClient client = new HttpClient();
        private static readonly string localhost = "https://localhost:5001/api/";

        //Get All Product In List
        public static async Task<List<Product>> GetAllProductInList()
        {
            List<Product> listproduct = new List<Product>();
            HttpResponseMessage response = await client.GetAsync(localhost + "product/GetAllProduct");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listproduct = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return listproduct;
        }

        // Get Product
        public static async Task<Product> GetProduct(int? idProduct)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(localhost + "product/GetProductItem/" + idProduct);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(content);
            }
            return product;
        }

        //Update Product
        public static async Task<Product> UpdateProduct(int? idProduct, Product product)
        {
            Product item;
            string stringData = JsonConvert.SerializeObject(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(
                $"https://localhost:5001/api/product/PutProduct/" + idProduct, contentData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            item = JsonConvert.DeserializeObject<Product>(content);
            return item;
        }



    }
}