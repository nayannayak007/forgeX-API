using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
    public class WorkoutSessionExercise
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SessionNumber { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public string? SetsReps { get; set; }

        public WorkoutCategory Category { get; set; }
    }


}
