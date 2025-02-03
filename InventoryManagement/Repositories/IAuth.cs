using InventoryManagement.Models;

namespace InventoryManagement.Repositories
{
    public interface IAuth
    {
        Task<User> GetUserByEmail(string email);
        Task Register(User user);
    }
}
