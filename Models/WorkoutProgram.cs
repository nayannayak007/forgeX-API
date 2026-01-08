using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
    public class WorkoutProgram
    {
        public int Id { get; set; }
        public string AgeGroup { get; set; } = string.Empty;
        public string ProgramName { get; set; } = string.Empty;
        public string? Description { get; set; }

        public List<WorkoutCategory> Categories { get; set; } = new();
    }


}
