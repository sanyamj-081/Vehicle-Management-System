using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_Backend.Models;
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
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Check if a user with the provided email and password exists
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email.Equals(loginRequest.Email) && u.Password.Equals(loginRequest.Password));
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
                new
                {
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Check if the request data is valid
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { status = "error", message = "Invalid data provided" });
            }

            // Check if user already exists
            var existingUser = await _context.Users
                .SingleOrDefaultAsync(u => u.Email.Equals(request.Email));

            if (existingUser != null)
            {
                return Conflict(new { status = "error", message = "User already exists" });
            }

            // Ensure passwords match
            if (request.Password != request.Rpassword)
            {
                return BadRequest(new { status = "error", message = "Passwords do not match" });
            }

            // Create new user
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                Password = request.Password, // Password is stored in plain text as per user preference
                CreatedOn = DateTime.UtcNow,
                UserType = UserType.SERVICE_ADVISOR, // Default user type
                AccountStatus = AccountStatus.UNAPPROVED // Default account status
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = "success",
                    message = "User registered successfully",
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
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}
