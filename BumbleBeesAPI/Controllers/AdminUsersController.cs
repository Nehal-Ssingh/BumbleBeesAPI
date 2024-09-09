using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BumbleBeesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

 
[ApiController]
[Route("api/[controller]")]
public class AdminApiController : ControllerBase
{
    private readonly BumbleBeesContext _context;

    public AdminApiController(BumbleBeesContext context)
    {
        _context = context;
    }

    [HttpGet("organisations")]
    public async Task<IActionResult> GetOrganisations()
    {
        try
        {
            var organisations = await _context.Organisations
                .Include(o => o.Projects) // Include related projects if needed
                .ToListAsync();
            return Ok(organisations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching organisations", error = ex.Message });
        }
    }

    [HttpPost("organisations")]
    public async Task<IActionResult> AddOrganisation([FromBody] Organisation organisation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Organisations.Add(organisation);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrganisations), new { id = organisation.OrganisationRegNo }, organisation);
    }

    // Other API methods can go here
}
