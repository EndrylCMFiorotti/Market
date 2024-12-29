using AutoMapper;
using Market.Data.Entity;
using System.Security.Claims;

namespace Market.Data.Models {
    public class UserModel {
        public UserModel() { }

        public UserModel(ClaimsPrincipal user) { 
            IdUser = int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int identifier) ? identifier : 0;
            Name = user.FindFirst(ClaimTypes.Name)?.Value;
            Email = user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public User ConvertToEntity(IMapper mapper) {
            return mapper.Map<User>(this);
        }
    }
}
