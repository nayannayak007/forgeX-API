using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
   public class Class
{
    public int Id { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public ICollection<Player> Players { get; set; } = new List<Player>();

     public ICollection<UserSchool> UserSchools { get; set; } = new List<UserSchool>();
}

}
