using AutoMapper;
using Market.Data.Entity;

namespace Market.Data.Models {
    public class UserModel {
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public User ConvertToEntity(IMapper mapper) {
            return mapper.Map<User>(this);
        }
    }
}
