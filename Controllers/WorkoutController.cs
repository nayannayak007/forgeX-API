using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForgeXAPI.Data;       
using ForgeXAPI.Models;     

namespace ForgeXAPI.Controllers
{
 
[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public WorkoutController(ApplicationDbContext context)
    {
        _context = context;
    }

        // [HttpPost("complete")]
        // public async Task<IActionResult> CompleteWorkout([FromBody] WorkoutCompletion model)
        // {
        //     if (!ModelState.IsValid) return BadRequest(ModelState);

        //     _context.WorkoutCompletions.Add(model);
        //     await _context.SaveChangesAsync();

        //     return Ok(new { success = true, message = "Workout completed logged ✅" });
        // }

        [HttpPost("create")]
    public async Task<IActionResult> CreateWorkout([FromBody] Workout workout)
    {
        _context.Add(workout);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Workout created successfully", workout.Id });
    }

    [HttpGet("by-date")]
    public async Task<IActionResult> GetByDate(DateTime date, string ageGroup)
    {
        var workout = await _context.Workouts
            .FirstOrDefaultAsync(w => w.WorkoutDate.Date == date.Date && w.AgeGroup == ageGroup);
        if (workout == null) return NotFound(new { message = "No workout found" });
        return Ok(workout);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _context.Workouts.OrderByDescending(w => w.WorkoutDate).ToListAsync();
        return Ok(workouts);
    }

    [HttpGet("getByAgeAndSession")]
    public async Task<IActionResult> GetWorkout(string ageGroup, int session)
    {
        var result = await _context.WorkoutPrograms
            .Where(x => x.AgeGroup == ageGroup)
            .SelectMany(p => p.Categories)
            .SelectMany(c => c.Exercises)
            .Where(e => e.SessionNumber == session)
            .Select(e => new {
                Category = e.Category.CategoryName,
                ExerciseName = e.ExerciseName,
                SetsReps = e.SetsReps,
                CategoryId = e.Category.Id
            })
            .ToListAsync();

        return Ok(result);
    }

    [HttpPost("complete")]
    public async Task<bool> SaveWorkoutCompletionAsync([FromBody]WorkoutCompletion dto)
    {
        var wc = new WorkoutCompletion
        {
            SchoolId = dto.SchoolId,
            AgeGroup = dto.AgeGroup,
            SessionId = dto.SessionId,
            TrainerName = dto.TrainerName,
            Notes = dto.Notes,
            CompletedOn = dto.CompletedOn
        };

        _context.WorkoutCompletions.Add(wc);
        await _context.SaveChangesAsync();
        return true;
    }

    [HttpGet("next-session/{schoolId}")]
    public async Task<int> GetNextSessionAsync(int schoolId, string ageGroup)
    {
        var last = await _context.WorkoutCompletions
            .Where(x => x.SchoolId == schoolId && x.AgeGroup == ageGroup)
            .OrderByDescending(x => x.CompletedOn)
            .FirstOrDefaultAsync();

        if (last == null)
            return 1; 

        int next = last.SessionId + 1;

        if (next > 12)
            next = 1;

        return next;
    }



    
}

}
