using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{

    public class Workout
    {
        public int Id { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string AgeGroup { get; set; } = string.Empty;

        // Each section
        public string WarmUp { get; set; } = string.Empty;
        public string WarmUpDuration { get; set; } = string.Empty;

        public string StrengthBlock { get; set; } = string.Empty;
        public string StrengthBlockDuration { get; set; } = string.Empty;

        public string AgilitySpeed { get; set; } = string.Empty;
        public string AgilitySpeedDuration { get; set; } = string.Empty;

        public string HybridEndurance { get; set; } = string.Empty;
        public string HybridEnduranceDuration { get; set; } = string.Empty;

        public string CoolDown { get; set; } = string.Empty;
        public string CoolDownDuration { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public string CreatedBy { get; set; } = string.Empty;
    }


}
