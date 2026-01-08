using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Role { get; set; } = "User";

        [MaxLength(100)]
        public string? FullName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? Token { get; set; }

        public bool Approved { get; set; } = false;
        public ICollection<UserSchool> UserSchools { get; set; } = new List<UserSchool>();
    }
}
