using CoreAppwithMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.BussinessAccess
{
    interface IRetailBussiness
    {
        IEnumerable<Products> GetListOfProducts();
        void CreateProducts(Products product);
        void UpdateProductDetails(Products product);
        void DeleteProducts(int productId);
    }
}
