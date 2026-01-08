using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
   public class WorkoutCategory
        {
            public int Id { get; set; }
            public int ProgramId { get; set; }
            public string CategoryName { get; set; } = string.Empty;

            public WorkoutProgram Program { get; set; }
            public List<WorkoutSessionExercise> Exercises { get; set; } = new();
        }

}
