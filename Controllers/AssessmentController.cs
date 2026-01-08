using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForgeXAPI.Data;       
using ForgeXAPI.Models;     

namespace ForgeXAPI.Controllers
{
 
[ApiController]
[Route("api/[controller]")]
public class AssessmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AssessmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.Assessments
            .Include(a => a.Player)
            .Include(a => a.Class)
            .Select(a => new
            {
                a.Id,
                PlayerName = a.Player.FirstName + " " + a.Player.LastName,
                ClassName = a.Class.ClassName,
                a.TrainerName,
                a.TakenOn,
                a.Status,
                a.PlayerId
            })
            .ToListAsync();

        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
       var assessment = await _context.Assessments
        .Include(a => a.Fields) 
        .Include(a => a.Player)
        .Include(a => a.Class)
        .FirstOrDefaultAsync(a => a.Id == id);

        if (assessment == null)
            return NotFound();

        return Ok(assessment);
    }

   [HttpPost]
public async Task<IActionResult> Create([FromBody] AssessmentDto model)
{
    if (model == null)
        return BadRequest("Invalid assessment data.");
        
    if (model.Id > 0)
    {
        var existing = await _context.Assessments
            .Include(a => a.Fields)
            .FirstOrDefaultAsync(a => a.Id == model.Id);

        if (existing != null)
        {
            _context.Assessments.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
    var assessment = new Assessment
    {
        ClassId = model.ClassId,
        PlayerId = model.PlayerId,
        TrainerName = model.TrainerName,
        Status = model.Status,
        TakenOn = DateTime.UtcNow,
        Fields = model.Fields.Select(f => new AssessmentField
        {
            Category = f.Category,
            Label = f.Label,
            InputType = f.InputType,
            Unit = f.Unit,
            Value = f.Value,
            Notes = f.Notes
        }).ToList()
    };

    _context.Assessments.Add(assessment);
    await _context.SaveChangesAsync();

    return Ok(new { message = "Assessment created successfully", assessment.Id });
}


}

}
