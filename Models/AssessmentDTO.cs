using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForgeXAPI.Models
{
    public class AssessmentDto
    {
        public int? Id { get; set; }
        public int? ClassId { get; set; }
        public int? PlayerId { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public string Status { get; set; } = "Draft";
        public List<AssessmentFieldDto> Fields { get; set; } = new();
    }

    
    public class AssessmentFieldDto
    {
        public string Category { get; set; } = string.Empty;
        public string? Label { get; set; } = string.Empty;
        public string? InputType { get; set; } = "number";
        public string? Unit { get; set; }
        public string? Value { get; set; }
        public string? Notes { get; set; }
    }

    public class UserWithSchoolsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool Approved { get; set; }
        public string Role { get; set; } = "";
        public List<string> Schools { get; set; } = new();
    }


}
