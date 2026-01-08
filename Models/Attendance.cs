using System.ComponentModel.DataAnnotations;

namespace ForgeXAPI.Models
{
public class Attendance
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }
    public string? RecordedBy { get; set; }
}

}
