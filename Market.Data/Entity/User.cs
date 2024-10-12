using AutoMapper;
using Market.Data.Models;

namespace Market.Data.Entity {
    public class User {
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserModel ConvertToModel(IMapper mapper) {
            return mapper.Map<UserModel>(this);
        }
    }
}
