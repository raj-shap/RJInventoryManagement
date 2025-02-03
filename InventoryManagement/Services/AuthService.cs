using InventoryManagement.DTOs;
using InventoryManagement.Helpers;
using InventoryManagement.Models;
using InventoryManagement.Repositories;

namespace InventoryManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuth _authRepository;

        public AuthService(IAuth authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResponse> Registeration(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return new ServiceResponse { Success = false, Message = "Invalid User Data. Data is null" };
            }
            var existingUser = await _authRepository.GetUserByEmail(userDTO.Email);
            if(existingUser != null)
            {
                return new ServiceResponse { Success = false, Message = "User already registered with this email." };
            }

            var newUser = new User
            {
                id = Guid.NewGuid().ToString("N"),
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                UserId = userDTO.UserId,
                Password = AuthHelper.GetEncrypted(userDTO.Password),
            };

            await _authRepository.Register(newUser);
            return new ServiceResponse { Success = true, Message = "User Registered Successfully" };
        }
    }
}
