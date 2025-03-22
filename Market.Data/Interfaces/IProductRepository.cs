using Market.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Interfaces {
    public interface IProductRepository {
        Task<List<Product>> GetAllProducts();
    }
}
