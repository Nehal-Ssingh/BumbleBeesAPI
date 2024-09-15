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








    [HttpGet("fundingrequests")]
    public async Task<IActionResult> GetFundingRequests()
    {
        try
        {
            var fundingRequests = await _context.Projects
                .Include(p => p.OrganisationRegNoNavigation) // Include the Organisation navigation property
                .Where(p => p.ProjectStatus == "Pending")
                .Select(p => new
                {
                    p.ProjectId,
                    OrganisationName = p.OrganisationRegNoNavigation.OrganisationName, // Access the organisation name
                    p.ProjectDate,
                    p.Amount,
                    p.ProjectStatus
                })
                .ToListAsync();

            if (fundingRequests == null || !fundingRequests.Any())
            {
                return NotFound(new { message = "No funding requests found." });
            }

            return Ok(fundingRequests);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
            return StatusCode(500, new { message = "An error occurred while fetching funding requests", error = ex.Message });
        }
    }



    // Approve funding request
    [HttpPost("approverequest/{id}")]
    public async Task<IActionResult> ApproveRequest(int id)
    {
        try
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound(new { message = "Project not found" });
            }

            project.ProjectStatus = "Approved";
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Funding request approved" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while approving the request", error = ex.Message });
        }
    }

    // Reject funding request
    [HttpPost("rejectrequest/{id}")]
    public async Task<IActionResult> RejectRequest(int id)
    {
        try
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound(new { message = "Project not found" });
            }

            project.ProjectStatus = "Rejected";
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Funding request rejected" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while rejecting the request", error = ex.Message });
        }
    }





}
