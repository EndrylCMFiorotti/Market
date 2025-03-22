using AutoMapper;
using Market.Data.Interfaces;
using Market.Data.Models.Home;

namespace Market.Data.Business {
    public class BLProduct {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public BLProduct(IMapper mapper, IProductRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductModel>> GetAllProducts() {
            var productList = await _repository.GetAllProducts();
            var productListModel = new List<ProductModel>();

            foreach (var product in productList) productListModel.Add(product.ConvertToModel(_mapper));

            return productListModel;
        }
    }
}
