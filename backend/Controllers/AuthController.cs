using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Context _context;

        public AuthController(Context context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Check if a user with the provided email and password exists
            
            var user = _context.Users
                .SingleOrDefault(u => u.Email.Equals(loginRequest.Email) && u.Password.Equals(loginRequest.Password));
            Console.WriteLine(user);
            if (user == null)
            {
                // Return JSON response for 'not found'
                return Ok(new { status = "not found", message = "Invalid credentials" });
            }

            if (user.AccountStatus == AccountStatus.UNAPPROVED)
            {
                return Ok(new { status = "unapproved", message = "Account is unapproved" });
            }

            if (user.AccountStatus == AccountStatus.SUSPENDED)
            {
                return Ok(new { status = "suspended", message = "Account is suspended" });
            }


            // If the user is found and is not unapproved or blocked, return a success message
            return Ok(
                new {
                    status = "success",
                    userType = user.UserType.ToString(),
                    userInfo = new
                    {
                        user.Id,
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.MobileNumber,
                        user.UserType,
                        user.AccountStatus,
                        user.CreatedOn
                    }
                }
            );
        }

    }
}
