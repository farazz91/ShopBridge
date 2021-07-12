using CoreAppwithMVC.Models;
using IRetailDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ShopBridge.DataBaseAccess
{
    public class RetailDB : IRetail
    {
        private readonly IOptions<AppSettingsModel> _appSettings;

        public RetailDB(IOptions<AppSettingsModel> appSettings)
        {
            _appSettings = appSettings;
        }
        public void CreateProducts(Products product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_appSettings.Value.DBConnection))
                {
                    string spName = "spCreateProduct";
                    using (SqlCommand cmd = new SqlCommand(spName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@txtProductName", product.productName);
                        cmd.Parameters.AddWithValue("@ProductDescription", product.productDescription);
                        cmd.Parameters.AddWithValue("@decProductPrice", product.productPrice);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProducts(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetListOfProducts()
        {
            List<Products> productList = new List<Products>();

            try
            {
                string spName = "spGetListOfProducts";
                using (SqlConnection connection = new SqlConnection(_appSettings.Value.DBConnection))
                {
                    SqlCommand command = new SqlCommand(spName, connection);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Products product = new Products();
                            product.productId = Convert.ToInt32(dataReader["intProductId"]);
                            product.productName = Convert.ToString(dataReader["txtProductName"]);
                            product.productDescription = Convert.ToString(dataReader["txtProductDescription"]);
                            product.productPrice = Convert.ToDecimal(dataReader["decProductPrice"]);
                            productList.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productList;
        }

        public void UpdateProductDetails(Products product)
        {
            using (SqlConnection connection = new SqlConnection(_appSettings.Value.DBConnection))
            {
                string spName = "spUpdateProducts";
                using (SqlCommand cmd = new SqlCommand(spName, connection))
                {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intProductId", product.productId);
                        cmd.Parameters.AddWithValue("@txtProductName", product.productName);
                        cmd.Parameters.AddWithValue("@txtProductDescription", product.productDescription);
                        cmd.Parameters.AddWithValue("@decProductPrice", product.productPrice);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                connection.Close();
            }
        }
    }
}
