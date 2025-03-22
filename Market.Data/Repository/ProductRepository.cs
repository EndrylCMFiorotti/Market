using Dapper;
using Market.Data.Entity;
using Market.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Repository {
    public class ProductRepository : IProductRepository {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public ProductRepository(IConfiguration configuration) {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Product>> GetAllProducts() {
            StringBuilder select = new();
            select.Append("SELECT p.IdProduct, p.Name NameProduct, p.ImageLink, p.Description DescriptionProduct FROM Product p");

            using (_connection) {
                _connection.Open();
                return (await _connection.QueryAsync<Product>(select.ToString())).ToList();
            }
        }
    }
}
