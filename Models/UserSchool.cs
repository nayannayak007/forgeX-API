using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
    public class UserSchool
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int SchoolId { get; set; }
    public Class School { get; set; } = null!;
}

}
