using AutoMapper;
using Market.Data.Entity;
using Market.Data.Interfaces;
using Market.Data.Models;

namespace Market.Data.Business {
    public class BLLogin {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _repository;

        public BLLogin(IMapper mapper, ILoginRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserModel?> LoginUser(string email, string password) {
            User? user = await _repository.LogIn(email, password);

            return user?.ConvertToModel(_mapper);
        }

        public async Task LogoutUser(int idUser) {
            await _repository.LogOut(idUser);
        }
    }
}
