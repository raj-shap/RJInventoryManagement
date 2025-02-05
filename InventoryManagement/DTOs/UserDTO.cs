using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.DTOs
{
    public class UserDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        [Range(8,16)]
        public required string Password { get; set; }
    }
}
