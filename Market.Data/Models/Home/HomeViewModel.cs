using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Models.Home {
    public class HomeViewModel {
        public HomeViewModel()
        {
            ProductList = new List<ProductModel>();
        }
        public List<ProductModel> ProductList { get; set; }
    }
}
