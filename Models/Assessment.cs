using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ForgeXAPI.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }

        public int? ClassId { get; set; }
        public Class? Class { get; set; }

        public int? PlayerId { get; set; }
        public Player? Player { get; set; }

        public string TrainerName { get; set; } = string.Empty;
        public DateTime TakenOn { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Draft";

        public ICollection<AssessmentField> Fields { get; set; } = new List<AssessmentField>();
    }
    
    public class AssessmentField
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Assessment")]
        public int AssessmentId { get; set; }
        
        [JsonIgnore] 
        public Assessment Assessment { get; set; } = null!;

        public string Category { get; set; } = string.Empty;  

        public string Label { get; set; }
        public string InputType { get; set; } = "number";      
        public string Unit { get; set; }                     
        public string? Value { get; set; }                   
        public string? Notes { get; set; }  
        public string? Grade { get; set; }                   
    }

}
