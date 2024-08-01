using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Backend.Models;
using Vehicle_Backend.Models.Enum;
using Vehicle_Backend.Models;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Vehicle_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        // Get vehicles currently under servicing
        [HttpGet("VehiclesUnderServicing")]
        public async Task<ActionResult<IEnumerable<ServiceRecord>>> GetVehiclesUnderServicing()
        {
            var records = await _context.ServiceRecords
                .Where(sr => sr.Status == ServiceStatus.UNDER_SERVICE)
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceAdvisor)
                .ToListAsync();

           

            return Ok(records);

        }

        // Get vehicles that have been serviced
        [HttpGet("VehiclesServiced")]
        public async Task<ActionResult<IEnumerable<ServiceRecord>>> GetVehiclesServiced()
        {
            var records = await _context.ServiceRecords
                .Where(sr => sr.Status == ServiceStatus.COMPLETED)
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceAdvisor)
                .Distinct()
                .ToListAsync();
            /*var vehicles = await _context.Vehicles
               .Where(v => records.Contains(v.Id))
               .ToListAsync();
*/
            return Ok(records); 
        }

        [HttpGet("VehiclesDueForServicing")]
        public async Task<IActionResult> VehiclesDueForServicing()
        {
            // Fetch Service Records with status DUE
            var dueServiceRecords = await _context.ServiceRecords
                .Where(sr => sr.Status == ServiceStatus.DUE)
                .Select(sr => sr.VehicleId)
                .Distinct()
                .ToListAsync();
          
            var vehicles = await _context.Vehicles
                .Where(v => dueServiceRecords.Contains(v.Id))
                .ToListAsync();

            return Ok(vehicles);
        }


        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            return Ok(await _context.Vehicles.ToListAsync());

        }









        [HttpPost("ScheduleService")]
        public async Task<IActionResult> ScheduleService([FromQuery] int vehicleId, [FromQuery] int serviceAdvisorId)
        {
            if (vehicleId <= 0 || serviceAdvisorId <= 0)
            {
                return BadRequest("Invalid vehicle or service advisor ID.");
            }

            var serviceRecord = new ServiceRecord
            {
                VehicleId = vehicleId,
                ServiceAdvisorId = serviceAdvisorId,
                ScheduledDate = DateTime.Now,
                Status = ServiceStatus.DUE
            };

            try
            {
                _context.ServiceRecords.Add(serviceRecord);
                await _context.SaveChangesAsync();
                return Ok(serviceRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("UpdateServiceStatus")]
        public async Task<IActionResult> UpdateServiceStatus([FromQuery] int serviceRecordId, [FromQuery] ServiceStatus status)
        {
            var serviceRecord = await _context.ServiceRecords.FindAsync(serviceRecordId);
            if (serviceRecord == null)
            {
                return NotFound("Service record not found.");
            }

            serviceRecord.Status = status;
            if (status == ServiceStatus.COMPLETED)
            {
                serviceRecord.CompletedDate = DateTime.Now;
            }

            _context.ServiceRecords.Update(serviceRecord);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(serviceRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }








        // Create an invoice for a completed service

        [HttpGet("GetServiceRecords")]
        public async Task<IActionResult> GetServiceRecords()
        {
            var serviceRecords = await _context.ServiceRecords
                .Include(sr => sr.Vehicle)
                .Include(sr => sr.ServiceAdvisor)
                .ToListAsync();
            return Ok(serviceRecords);
        }


        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice([FromQuery] int serviceRecordId)
        {
            // Fetch the ServiceRecord with related ServiceItems and WorkItems
            var serviceRecord = await _context.ServiceRecords
                .Include(sr => sr.ServiceAdvisor) // Include ServiceAdvisor details
                .FirstOrDefaultAsync(sr => sr.Id == serviceRecordId);

            if (serviceRecord == null)
            {
                return NotFound();
            }

            // Fetch the related ServiceItems with WorkItems
            var serviceItems = await _context.ServiceItems
                .Where(si => si.ServiceRecordId == serviceRecordId)
                .Include(si => si.WorkItem) // Include WorkItems for each ServiceItem
                .ToListAsync();

            // Calculate the total cost based on ServiceItems
            var totalCost = serviceItems.Sum(si => si.Quantity * si.WorkItem.Cost);

            // Create the invoice details object
            var invoiceDetails = new
            {
                ServiceRecordId = serviceRecord.Id,
                ServiceAdvisorName = serviceRecord.ServiceAdvisor.FirstName + " " + serviceRecord.ServiceAdvisor.LastName,
                ServiceItems = serviceItems.Select(si => new
                {
                    WorkItem = new
                    {
                        si.WorkItem.Name,
                        si.WorkItem.Cost
                    },
                    Quantity = si.Quantity,
                    Cost = si.WorkItem.Cost,
                   TotalCost = si.Quantity * si.WorkItem.Cost
                }),
                TotalCost = totalCost
            };

            return Ok(invoiceDetails);
        }



        // ===============================================
        //                 CRUD - VEHICLES
        // ===============================================



        

        [HttpPost("CreateVehicles")]
        public async Task<IActionResult> CreateVehicle([FromBody] Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVehicles), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("Vehicles/{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id) return BadRequest();
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("Vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return NotFound();
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        // ===============================================
        //                 CRUD - SA
        // ===============================================



        [HttpGet("GetSA")]
        public async Task<IActionResult> GetServiceAdvisors()
        {
            // Fetch only users with UserType as SERVICE_ADVISOR
            var advisors = await _context.Users
                .Where(u => u.UserType == UserType.SERVICE_ADVISOR)
                .ToListAsync();

            return Ok(advisors);
        }

        
        [HttpPost("CreateSA")]
        public async Task<IActionResult> CreateServiceAdvisor([FromBody] User advisor)
        {
            Console.WriteLine(advisor);
            if (advisor.UserType != UserType.SERVICE_ADVISOR)
            {
                return BadRequest("UserType must be SERVICE_ADVISOR");
            }

            advisor.CreatedOn = DateTime.UtcNow; // Set creation date
            advisor.AccountStatus = AccountStatus.UNAPPROVED; // Default status

            _context.Users.Add(advisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceAdvisors), new { id = advisor.Id }, advisor);
        }

        
        [HttpPut("UpdateSA/{id}")]
        public async Task<IActionResult> UpdateServiceAdvisor(int id, [FromBody] User advisor)
        {
            if (id != advisor.Id)
                return BadRequest("The advisor ID in the request body does not match the ID in the route.");

            // Validate the model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAdvisor = await _context.Users.FindAsync(id);
            if (existingAdvisor == null || existingAdvisor.UserType != UserType.SERVICE_ADVISOR)
                return NotFound("Service Advisor not found.");

            // Update fields
            existingAdvisor.FirstName = advisor.FirstName;
            existingAdvisor.LastName = advisor.LastName;
            existingAdvisor.Email = advisor.Email;
            existingAdvisor.Password = advisor.Password;
            existingAdvisor.MobileNumber = advisor.MobileNumber;
            existingAdvisor.AccountStatus = advisor.AccountStatus;

            try
            {
                _context.Entry(existingAdvisor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
                {
                    return NotFound("Service Advisor no longer exists.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("SA/{id}")]
        public async Task<IActionResult> DeleteServiceAdvisor(int id)
        {
            var advisor = await _context.Users
                .Where(u => u.Id == id && u.UserType == UserType.SERVICE_ADVISOR)
                .FirstOrDefaultAsync();

            if (advisor == null)
                return NotFound();

            _context.Users.Remove(advisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        // ===============================================
        //                 CRUD - WORKITEMS
        // ===============================================



        [HttpGet("GetWorkItem")]
        public async Task<ActionResult<IEnumerable<WorkItem>>> GetWorkItems()
        {
            return Ok(await _context.WorkItems.ToListAsync());
        }

        [HttpGet("GetWorkItem/{id}")]
        public async Task<ActionResult<WorkItem>> GetWorkItem(int id)
        {
            var workItem = await _context.WorkItems.FindAsync(id);

            if (workItem == null)
            {
                return NotFound();
            }

            return Ok(workItem);
        }

        [HttpPost("CreateWorkItem")]
        public async Task<ActionResult<WorkItem>> CreateWorkItem([FromBody] WorkItem workItem)
        {
            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkItem), new { id = workItem.Id }, workItem);
        }

        [HttpPut("UpdateWorkItem/{id}")]
        public async Task<IActionResult> UpdateWorkItem(int id, [FromBody] WorkItem workItem)
        {
            if (id != workItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(workItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteWorkItem/{id}")]
        public async Task<IActionResult> DeleteWorkItem(int id)
        {
            var workItem = await _context.WorkItems.FindAsync(id);

            if (workItem == null)
            {
                return NotFound();
            }

            _context.WorkItems.Remove(workItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}