using AutoMapper;
using Market.Data.Models;
using Market.Data.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Entity {
    public class Product {
        public int IdProduct { get; set; }
        public string? NameProduct { get; set; }
        public string? ImageLink { get; set; }
        public string? DescriptionProduct { get; set; }

        public ProductModel ConvertToModel(IMapper mapper) {
            return mapper.Map<ProductModel>(this);
        }
    }
}
