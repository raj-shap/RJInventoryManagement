using InventoryManagement.DTOs;
using InventoryManagement.Helpers;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using static InventoryManagement.Common.MessageContants;

namespace InventoryManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuth _authRepository;

        public AuthService(IAuth authRepository)
        {
            _authRepository = authRepository;
        }


        public int Registeration(UserDTO userDTO)
        {
            var existingUser = _authRepository.GetUserByEmail(userDTO.Email);
            if (existingUser != null)
            {
                return Convert.ToInt32(Status.)
            }
            return Convert.ToInt32(Status.Failed);
        }
        //public async Task<ServiceResponse> Registeration(UserDTO userDTO)
        //{
        //    if (userDTO == null)
        //    {
        //        var error = new ServiceResponse { Success = false, Message = "Invalid User Data. Data is null" };
        //        Console.WriteLine($"Error : {error}");
        //        return error;
        //    }
        //    var existingUser =  _authRepository.GetUserByEmail(userDTO.Email);
        //    if (existingUser != null)
        //    {

        //        var error = new ServiceResponse { Success = false, Message = "User already registered with this email." };
        //        Console.WriteLine($"Error : {error}");
        //        return error;
        //    }

        //    var newUser = new User
        //    {
        //        id = Guid.NewGuid().ToString("N"),
        //        FirstName = userDTO.FirstName,
        //        LastName = userDTO.LastName,
        //        Email = userDTO.Email,
        //        UserName = userDTO.UserName,
        //        Password = AuthHelper.GetEncrypted(userDTO.Password),
        //    };

        //    await _authRepository.Register(newUser);
        //    var success = new ServiceResponse { Success = true, Message = "User Registered Successfully" };
        //    Console.WriteLine($"Error : {success}");
        //    return success;
        //}
    }
}
