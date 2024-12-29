using Market.Data.Entity;

namespace Market.Data.Interfaces {
    public interface ILoginRepository {
        Task<User?> LogIn(string email, string password);
        Task LogOut(int idUser);
    }
}
