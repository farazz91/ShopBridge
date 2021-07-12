using CoreAppwithMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.BussinessAccess
{
    public class RetailBussiness : IRetailBussiness
    {
        public void CreateProducts(Products product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProducts(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetListOfProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProductDetails(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
