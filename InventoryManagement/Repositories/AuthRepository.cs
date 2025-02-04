using InventoryManagement.Context;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
