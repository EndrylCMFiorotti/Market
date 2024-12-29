using Dapper;
using Market.Data.Entity;
using Market.Data.Interfaces;
using Market.Utils.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Market.Data.Repository {
    public class LoginRespository : ILoginRepository {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public LoginRespository(IConfiguration configuration) {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<User?> LogIn(string email, string password) {
            using (_connection) {
                _connection.Open();
                using (var transaction = await _connection.BeginTransactionAsync()) {
                    try {
                        User userQuery = await GetUserAsync(email, password, _connection, transaction);
                        await LogInUser(userQuery.IdUser, _connection, transaction);
                        await transaction.CommitAsync();
                        return userQuery;
                    } catch (Exception) {
                        await transaction.RollbackAsync();
                        return null;
                    }
                }
            }
        }

        private async Task<User> GetUserAsync(string email, string password, DbConnection connection, DbTransaction transaction) {
            string query = "SELECT u.IdUser, u.Name, u.Email, u.IsLogged FROM [User] u WHERE Email = @Email AND Password = @Password";
            return await connection.QueryFirstAsync<User>(query, new { Email = email, Password = password }, transaction);
        }

        private async Task LogInUser(int idUser, DbConnection connection, DbTransaction transaction) {
            string update = "UPDATE [User] SET IsLogged = 1 WHERE IdUser = @IdUser";
            await connection.ExecuteAsync(update, new { IdUser = idUser }, transaction);
        }

        public async Task LogOut(int idUser) {
            using (_connection) {
                _connection.Open();
                string update = "UPDATE [User] SET IsLogged = 0 WHERE IdUser = @idUser";
                await _connection.ExecuteAsync(update, new { idUser });
            }
        }
    }
}
