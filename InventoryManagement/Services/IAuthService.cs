using InventoryManagement.DTOs;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse> Registeration(UserDTO userDTO);
    }
}
