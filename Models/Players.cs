using System.Text.Json.Serialization;

namespace ForgeXAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        // General info
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? Dob { get; set; }
        public string Gender { get; set; } = "Prefer not to say";
        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; }
        public decimal? Bmi { get; set; }
        public string? BloodGroup { get; set; }
        public string? StudentRollNo { get; set; }

        // Relationships
        public int ClassId { get; set; }
        [JsonIgnore] public Class? Class { get; set; }

        // Health / Lifestyle
        public string? DominantHandFoot { get; set; }
        public string? MedicalConditions { get; set; }
        public string? CurrentSport { get; set; }
        public string FoodPreference { get; set; } = "Vegetarian";
        public string? NutritionPattern { get; set; }
        public string? DailyScreenTime { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        //Parents
        public string ParentName { get; set; } = string.Empty;
        public string ParentContact { get; set; } = string.Empty;
        public string? ParentEmail { get; set; }
        public string? PostalAddress { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? EmergencyContact { get; set; }
        public string? Remarks { get; set; }

    }
}
