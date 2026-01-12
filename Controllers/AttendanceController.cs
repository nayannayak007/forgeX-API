using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForgeXAPI.Data;       
using ForgeXAPI.Models;     

namespace ForgeXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ---------------------- CLASS ENDPOINTS ----------------------

        // GET: api/attendance/classes
        [HttpGet("classes")]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await _context.Classes
                .AsNoTracking()
                .Select(c => new
                {
                    c.Id,
                    c.ClassName,
                    StudentCount = _context.Players.Count(p => p.ClassId == c.Id)
                })
                .OrderBy(c => c.ClassName)
                .ToListAsync();

            return Ok(classes);
        }

        [HttpGet("classes/user/{userId}")]
        public async Task<IActionResult> GetClassesByUser(int userId)
        {
            var classes = await _context.UserSchools
                .Where(us => us.UserId == userId)
                .Include(us => us.School)
                .Select(us => new
                {
                    us.School.Id,
                    us.School.ClassName,
                    StudentCount = _context.Players.Count(p => p.ClassId == us.School.Id)
                })
                .AsNoTracking()
                .OrderBy(c => c.ClassName)
                .ToListAsync();

            return Ok(classes);
        }

        // POST: api/attendance/classes
        [HttpPost("classes")]
        public async Task<IActionResult> AddClass([FromBody] Class model)
        {
            if (string.IsNullOrWhiteSpace(model.ClassName))
                return BadRequest("Class name cannot be empty.");

            _context.Classes.Add(model);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Class added successfully", model });
        }

        // ---------------------- PLAYER ENDPOINTS ----------------------

        // GET: api/attendance/players/{classId}
        [HttpGet("players/{classId}")]
        public async Task<IActionResult> GetPlayersByClass(int classId)
        {
           var players = await _context.Players
                            .Where(p => p.ClassId == classId)
                            .OrderBy(p => p.FirstName)
                            .ThenBy(p => p.LastName)
                            .Select(p => new 
                            { 
                                p.Id, 
                                PlayerName = p.FirstName + " " + p.LastName, 
                                p.Dob 
                            })
                            .ToListAsync();
            return Ok(players);
        }

        // POST: api/attendance/players
        [HttpPost("players")]
        public async Task<IActionResult> AddPlayer([FromBody] Player model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName))
                return BadRequest("Player name cannot be empty.");

            // Validate class
            var existingClass = await _context.Classes.FindAsync(model.ClassId);
            if (existingClass == null)
                return NotFound("Class not found.");

             if (!model.Bmi.HasValue && model.HeightCm.HasValue && model.WeightKg.HasValue && model.HeightCm > 0)
            {
                var m = model.HeightCm.Value / 100m;
                model.Bmi = Math.Round(model.WeightKg.Value / (m * m), 2);
            }
            _context.Players.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Player added successfully", model });
        }

        // ---------------------- ATTENDANCE ENDPOINTS ----------------------

        // POST: api/attendance/submit
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAttendance([FromBody] List<AttendanceDto> attendanceList)
        {
            if (attendanceList == null || attendanceList.Count == 0)
                return BadRequest("No attendance records received.");

            foreach (var record in attendanceList)
            {
                var existing = await _context.Attendance
                    .FirstOrDefaultAsync(a =>
                        a.PlayerId == record.PlayerId &&
                        a.AttendanceDate.Date == record.AttendanceDate.Date);

                if (existing != null)
                {
                    existing.IsPresent = record.IsPresent;
                    existing.RecordedBy = record.RecordedBy;
                }
                else
                {
                    _context.Attendance.Add(new Attendance
                    {
                        PlayerId = record.PlayerId,
                        AttendanceDate = record.AttendanceDate,
                        IsPresent = record.IsPresent,
                        RecordedBy = record.RecordedBy
                    });
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Attendance saved successfully." });
        }

        // GET: api/attendance/{classId}/{date}
        [HttpGet("{classId}/{date}")]
        public async Task<IActionResult> GetAttendance(int classId, DateTime date)
        {
            var players = await _context.Players
                .Where(p => p.ClassId == classId)
                .ToListAsync();

            var attendance = await _context.Attendance
                .Where(a => a.AttendanceDate.Date == date.Date)
                .ToListAsync();

            var result = players.Select(p => new
            {
                p.Id,
                PlayerName = p.FirstName + " " + p.LastName,
                IsPresent = attendance.Any(a => a.PlayerId == p.Id && a.IsPresent)
            });

            return Ok(result);
        }
    }

    // DTO for attendance input
    public class AttendanceDto
    {
        public int PlayerId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public string? RecordedBy { get; set; }
    }
}
