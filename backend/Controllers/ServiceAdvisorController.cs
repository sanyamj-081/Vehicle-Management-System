using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Backend.Models;
using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAdvisorController : ControllerBase
    {
        private readonly Context _context;

        public ServiceAdvisorController(Context context)
        {
            _context = context;
        }

        [HttpGet("ScheduledServices")]
        public async Task<ActionResult<IEnumerable<ServiceRecord>>> GetScheduledServices([FromQuery] int serviceAdvisorId)
        {
            var serviceRecords = await _context.ServiceRecords
                .Where(sr => sr.Status == ServiceStatus.DUE && sr.ServiceAdvisorId == serviceAdvisorId)
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceAdvisor)
                .ToListAsync();

            return Ok(serviceRecords);
        }

/*
 for commit purpose
 */

        [HttpGet("ServiceRecord/{id}")]
        public async Task<ActionResult> GetServiceRecord(int id)
        {
            var serviceRecord = await _context.ServiceRecords
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceAdvisor)
                .FirstOrDefaultAsync(sr => sr.Id == id);

            if (serviceRecord == null)
            {
                return NotFound();
            }

            // Fetch associated ServiceItems and WorkItems
            var serviceItems = await _context.ServiceItems
                .Include(si => si.WorkItem)
                .Where(si => si.ServiceRecordId == id)
                .ToListAsync();

            var result = new
            {
                ServiceRecord = serviceRecord,
                ServiceItems = serviceItems
            };

            return Ok(result);
        }

        [HttpPost("AddServiceItem")]
        public async Task<IActionResult> AddServiceItem([FromBody] ServiceItemDto serviceItemDto)
        {
            if (serviceItemDto == null)
            {
                return BadRequest("ServiceItemDto cannot be null.");
            }

            if (serviceItemDto.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }

            // Ensure WorkItem exists
            var workItem = await _context.WorkItems.FindAsync(serviceItemDto.WorkItemId);
            if (workItem == null)
            {
                return NotFound($"WorkItem with ID {serviceItemDto.WorkItemId} not found.");
            }

            // Ensure ServiceRecord exists (Optional, if needed)
            var serviceRecord = await _context.ServiceRecords.FindAsync(serviceItemDto.ServiceRecordId);
            if (serviceRecord == null)
            {
                return NotFound($"ServiceRecord with ID {serviceItemDto.ServiceRecordId} not found.");
            }

            // Create and add the new ServiceItem
            var serviceItem = new ServiceItem
            {
                ServiceRecordId = serviceItemDto.ServiceRecordId,
                WorkItemId = serviceItemDto.WorkItemId,
                Quantity = serviceItemDto.Quantity
            };

            try
            {
                _context.ServiceItems.Add(serviceItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.Error.WriteLine($"Error saving ServiceItem: {ex.Message}");
                return StatusCode(500, "An error occurred while saving the service item.");
            }

            return Ok();
        }

        public class ServiceItemDto
        {
            public int ServiceRecordId { get; set; }
            public int WorkItemId { get; set; }
            public int Quantity { get; set; }
        }



        [HttpPost("CompleteServiceRecord/{id}")]
        public async Task<IActionResult> CompleteServiceRecord(int id)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(id);
            if (serviceRecord == null)
            {
                return NotFound();
            }

            serviceRecord.Status = ServiceStatus.COMPLETED;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
