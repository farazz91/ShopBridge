using CoreAppwithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IRetailDB
{
    interface IRetail
    {
        IEnumerable<Products> GetListOfProducts();
        void CreateProducts(Products product);
        void UpdateProductDetails(Products product);
        void DeleteProducts(int productId);
    }
}
