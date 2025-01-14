using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReactAPI.Data.Entities;

[ApiController]
[Route("api/[controller]")]
public class LandInventoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LandInventoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/LandInventory
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LandInventory>>> GetLandInventory()
    {
        var landInventory = await _context.LandInventory.ToListAsync();
        return Ok(landInventory);
    }

    // GET: api/LandInventory/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LandInventory>> GetLandInventory(int id)
    {
        var landInventory = await _context.LandInventory.FindAsync(id);

        if (landInventory == null)
        {
            return NotFound();
        }

        return Ok(landInventory);
    }

    // POST: api/LandInventory
    [HttpPost]
    public async Task<ActionResult<LandInventory>> CreateLandInventory(LandInventory landInventory)
    {
        _context.LandInventory.Add(landInventory);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLandInventory", new { id = landInventory.Id }, landInventory);
    }

    // PUT: api/LandInventory/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLandInventory(int id, LandInventory landInventory)
    {
        if (id != landInventory.Id)
        {
            return BadRequest();
        }

        _context.Entry(landInventory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LandInventoryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/LandInventory/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLandInventory(int id)
    {
        var landInventory = await _context.LandInventory.FindAsync(id);

        if (landInventory == null)
        {
            return NotFound();
        }

        _context.LandInventory.Remove(landInventory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LandInventoryExists(int id)
    {
        return _context.LandInventory.Any(l => l.Id == id);
    }
}
