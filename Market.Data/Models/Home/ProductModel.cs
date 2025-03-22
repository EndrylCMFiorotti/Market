using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Models.Home {
    public class ProductModel {
        public ProductModel(int idProduct, string nameProduct, string imageLink, string descriptionProduct)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            ImageLink = imageLink;
            DescriptionProduct = descriptionProduct;
        }
        public ProductModel() { }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string ImageLink { get; set; }
        public string DescriptionProduct { get; set; }
    }
}
