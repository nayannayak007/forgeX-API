using System.Text.Json.Serialization;

namespace ForgeXAPI.Models
{
   public class WorkoutCompletion
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public string AgeGroup { get; set; } = string.Empty;
    public int SessionId { get; set; }
    public string TrainerName { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CompletedOn { get; set; }
}

}
